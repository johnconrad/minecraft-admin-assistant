using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MinecraftAdminAssistant.Data;
using MinecraftAdminAssistant.UserInterface;
using MinecraftAdminAssistant.Utils;
using MinecraftAdminAssistant.Properties;

namespace MinecraftAdminAssistant {
    public partial class PlayerForm : Form {
        private static int UPDATE_INTERVAL = 15;
        
        private MinecraftApi api = null;

        private Dictionary<Player, ListViewItem> listItemLookup = new Dictionary<Player, ListViewItem>();

        private Dictionary<Player, Location> previousLocations;
        private bool populating = false;
        private bool refreshing = false;
        private long requestCount = 0;

        public Player SelectedPlayer {
            get {
                if (playerListView.SelectedItems.Count == 0) 
                    return null;

                return (Player) playerListView.SelectedItems[0].Tag;
            }
        }

        public List<Location> TeleportLocations {
            get {
                if (_teleportLocations == null) 
                    _teleportLocations = MinecraftAssistSettings.GetInstance().Locations;

                return _teleportLocations; 
            }
        } private List<Location> _teleportLocations;

        public PlayerForm() {
            InitializeComponent();

            previousLocations = new Dictionary<Player, Location>();
            destinationComboBox.Items.AddRange(TeleportLocations.ToArray());

            UpdateControls();

            if (!Login()) PromptForServerSettings();
            RefreshData();
            LaunchUpdateThread();
        }

        public bool Login() {
            if (string.IsNullOrWhiteSpace(Settings.Default.Username)) {
                api = null;
                return false;
            }

            api = new MinecraftApi(Settings.Default.Host, Settings.Default.Port, Settings.Default.Username, Settings.Default.Password, Settings.Default.Salt);
            return true;
        }

        private void PromptForServerSettings() {
            ServerSettings dialog = new ServerSettings();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                // clear ui and show progress bar
                progressBar.Visible = true;
                playerListView.Items.Clear();
                UpdateControls();
                
                // attempt a login and refresh
                Login();
                RefreshData();
            }
        }

        public void RefreshData() {
            if (refreshing) return;
            refreshing = true;

            if (api == null) { 
                progressBar.Visible = false;
                refreshing = false;
                return;
            }

            UpdateControls();

            Thread thread = new Thread(new ThreadStart(delegate {
                // attempt to retrieve our player list
                List<Player> players = null;
                try {
                    players = api.GetPlayers();
                } catch (Exception e) {
                    api = null;

                    Invoke(new ThreadStart(delegate {
                        refreshing = false;
                        MessageBox.Show("Failed to connect to the server.\n" + e.Message, "Error");
                        progressBar.Visible = false;
                        UpdateControls();
                    }));

                    return;
                }

                // run back on the gui thread
                Invoke(new ThreadStart(delegate {
                    populating = true;

                    // build list of players to remove and add
                    List<ListViewItem> playersToRemove = new List<ListViewItem>();
                    List<Player> playersToAdd = new List<Player>(players);
                    foreach (ListViewItem currItem in playerListView.Items) {
                        Player currPlayer = currItem.Tag as Player;
                        if (!players.Contains(currPlayer)) {
                            listItemLookup.Remove(currPlayer);
                            playersToRemove.Add(currItem);
                        }
                        foreach(Player p in playersToAdd) {
                            if (currPlayer.Equals(p)) currPlayer.Update(p);
                        }
                        playersToAdd.Remove(currPlayer);
                    }
                    
                    // remove logged off players
                    foreach(ListViewItem currItem in playersToRemove) {
                        playerListView.Items.Remove(currItem);
                        destinationComboBox.Items.Remove(currItem);
                    }

                    // add missing players
                    foreach (Player currPlayer in playersToAdd) {
                        // add to player list
                        ListViewItem listItem = new ListViewItem(new string[] {
                            currPlayer.Name, 
                            ((int)currPlayer.Location.X).ToString(), 
                            ((int)currPlayer.Location.Y).ToString(), 
                            ((int)currPlayer.Location.Z).ToString(), 
                            currPlayer.Location.World});

                        listItemLookup[currPlayer] = listItem;
                        listItem.Tag = currPlayer;
                        playerListView.Items.Add(listItem);
                    }

                    // update existing players
                    foreach (ListViewItem currItem in listItemLookup.Values) {
                        Player player = (Player)currItem.Tag;
                        currItem.SubItems[1].Text = ((int)player.Location.X).ToString();
                        currItem.SubItems[2].Text = ((int)player.Location.Y).ToString();
                        currItem.SubItems[3].Text = ((int)player.Location.Z).ToString();
                        currItem.SubItems[4].Text = player.Location.World;
                    }


                    // populate our teleport combo
                    if (playersToAdd.Count > 0 || playersToRemove.Count > 0) {
                        object previouslySelectedDestination = destinationComboBox.SelectedItem;
                        destinationComboBox.Items.Clear();
                        destinationComboBox.Items.AddRange(players.ToArray());
                        destinationComboBox.Items.AddRange(TeleportLocations.ToArray());
                        destinationComboBox.SelectedItem = previouslySelectedDestination;
                    }

                    // restore our selected teleport desitination
                    if (destinationComboBox.SelectedItem == null && destinationComboBox.Items.Count > 0)
                        destinationComboBox.SelectedIndex = 0;

                    populating = false;
                    refreshing = false;
                    progressBar.Visible = false;

                    // update the screen as needed
                    UpdateControls();
                }));
            }));

            thread.IsBackground = true;
            thread.Start();
        }

        public void ChangeGameMode(GameMode mode) {
            Player player = SelectedPlayer;

            Thread thread = new Thread(new ThreadStart(delegate {
                // fly you fools!
                api.SetPlayerGameMode(player, mode);
            }));

            thread.IsBackground = true;
            thread.Start();
        }

        public void SetHealth(int value) {
            Player player = SelectedPlayer;
            long requestNum = ++requestCount;

            Thread thread = new Thread(new ThreadStart(delegate {
                // wait a tick to see if further requests come in after this
                Thread.Sleep(200);
                if (requestNum != requestCount) return;

                // anyone got a bandaid?
                api.SetPlayerHealth(player, value);
            }));

            thread.IsBackground = true;
            thread.Start();
        }

        public void SetHunger(int value) {
            Player player = SelectedPlayer;
            long requestNum = ++requestCount;

            Thread thread = new Thread(new ThreadStart(delegate {
                // wait a tick to see if further requests come in after this
                Thread.Sleep(200);
                if (requestNum != requestCount) return;

                // yumm!
                api.SetPlayerFoodLevel(player, value);
            }));

            thread.IsBackground = true;
            thread.Start();
        }

        private void TeleportTo(object obj) {
            Location loc = obj as Location;
            if (loc != null) {
                TeleportTo(loc);
                return;
            }

            Player player = obj as Player;
            if (player != null) {
                TeleportTo(player);
                return;
            }
        }

        private void TeleportTo(Location loc) {
            Player player = SelectedPlayer;

            Thread thread = new Thread(new ThreadStart(delegate {
                // save the player's current location
                player = api.GetPlayer(player.Name);
                previousLocations[player] = (Location)player.Location.Clone();

                // send our subject on his way
                api.TeleportPlayerToWorldLocation(player, loc);

                // run back on the gui thread
                Invoke(new ThreadStart(delegate {
                    UpdateControls();
                }));
            }));

            thread.IsBackground = true;
            thread.Start();
        }

        private void TeleportTo(Player targetPlayer) {
            Player player = SelectedPlayer;

            Thread thread = new Thread(new ThreadStart(delegate {
                // save the player's current location
                player = api.GetPlayer(player.Name);
                previousLocations[player] = (Location)player.Location.Clone();
                
                // grab the latest location for the target player and send our subject on his way
                targetPlayer = api.GetPlayer(targetPlayer.Name);
                api.TeleportPlayerToWorldLocation(player, targetPlayer.Location);

                // run back on the gui thread
                Invoke(new ThreadStart(delegate {
                    UpdateControls();
                }));
            }));

            thread.IsBackground = true;
            thread.Start();
        }

        private void TeleportBack() {
            if (!previousLocations.ContainsKey(SelectedPlayer)) return;

            TeleportTo(previousLocations[SelectedPlayer]);
            previousLocations.Remove(SelectedPlayer);
        }

        private void AddTeleport() {
            Player player = SelectedPlayer;

            // prompt the user for a name
            NewTeleportDialog dialog = new NewTeleportDialog(player.Name);
            DialogResult result = dialog.ShowDialog();
            if (result != DialogResult.OK) return;

            Thread thread = new Thread(new ThreadStart(delegate {
                // run in the background
                player = api.GetPlayer(player.Name);

                Location loc = (Location)player.Location.Clone();
                loc.Name = dialog.ChosenName;

                TeleportLocations.Add(loc);
                MinecraftAssistSettings.GetInstance().Locations = TeleportLocations;

                // run back on the gui thread
                Invoke(new ThreadStart(delegate {
                    destinationComboBox.Items.Add(loc);
                    destinationComboBox.SelectedItem = loc;

                    UpdateControls();
                }));
            }));

            thread.IsBackground = true;
            thread.Start();
        }

        private void UpdateControls() {
            populating = true;

            refreshButton.Enabled = !refreshing && api != null;
            settingsButton.Enabled = !refreshing;

            if (destinationComboBox.SelectedItem == null && destinationComboBox.Items.Count > 0) destinationComboBox.SelectedIndex = 0;

            if (gameModeComboBox.Items.Count == 0) {
                gameModeComboBox.Items.Add(GameMode.CREATIVE);
                gameModeComboBox.Items.Add(GameMode.SURVIVAL);
            }

            removeDestinationButton.Enabled = destinationComboBox.SelectedItem as Location != null;

            if (SelectedPlayer == null) {
                gameModeComboBox.Enabled = false;
                healthBar.Enabled = false;
                hungerBar.Enabled = false;

                teleportButton.Enabled = false;
                destinationComboBox.Enabled = false;
                destinationComboBox.SelectedItem = null;
                returnButton.Enabled = false;
                return;
            }


            teleportButton.Enabled = true;
            destinationComboBox.Enabled = destinationComboBox.Items.Count > 0;
            if (destinationComboBox.Items.Count > 0 && destinationComboBox.SelectedItem == null) 
                destinationComboBox.SelectedIndex = 0;
            returnButton.Enabled = previousLocations.ContainsKey(SelectedPlayer);

            gameModeComboBox.Enabled = true;
            gameModeComboBox.SelectedItem = SelectedPlayer.GameMode;

            healthBar.Enabled = SelectedPlayer.GameMode == GameMode.SURVIVAL;
            healthBar.Value = (int)SelectedPlayer.Health;

            hungerBar.Enabled = SelectedPlayer.GameMode == GameMode.SURVIVAL;
            hungerBar.Value = (int)SelectedPlayer.Hunger;

            populating = false;
        }

        private void LaunchUpdateThread() {
            Thread thread = new Thread(new ThreadStart(delegate {
                while (true) {
                    Thread.Sleep(UPDATE_INTERVAL * 1000);
                    Invoke(new ThreadStart(RefreshData));
                }
            }));

            thread.IsBackground = true;
            thread.Start();
        }

        private void playerListView_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateControls();
        }

        private void gameModeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (populating) return;

            ChangeGameMode((GameMode)gameModeComboBox.SelectedItem);
        }

        private void healthBar_Scroll(object sender, EventArgs e) {
            if (populating) return;

            SetHealth(healthBar.Value);
        }

        private void hungerBar_Scroll(object sender, EventArgs e) {
            if (populating) return;

            SetHunger(hungerBar.Value);
        }

        private void refreshButton_Click(object sender, EventArgs e) {
            RefreshData();
        }

        private void teleportButton_ButtonClick(object sender, EventArgs e) {
            if (destinationComboBox.SelectedItem == null) {
                teleportButton.DropDown.Show(Cursor.Position.X, Cursor.Position.Y);
                return;
            }

            TeleportTo(destinationComboBox.SelectedItem);
        }

        private void addDestinationButton_Click(object sender, EventArgs e) {
            AddTeleport();
        }

        private void removeDestinationButton_Click(object sender, EventArgs e) {
            TeleportLocations.Remove((Location)destinationComboBox.SelectedItem);
            MinecraftAssistSettings.GetInstance().Locations = TeleportLocations;

            destinationComboBox.Items.Remove(destinationComboBox.SelectedItem);
            UpdateControls();
        }

        private void destinationComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (populating) return;

            UpdateControls();
        }

        private void returnButton_Click(object sender, EventArgs e) {
            TeleportBack();
        }

        private void settingsButton_Click(object sender, EventArgs e) {
            PromptForServerSettings();
        }
    }
}
