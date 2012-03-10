using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MinecraftAdminAssistant.Properties;

namespace MinecraftAdminAssistant.UserInterface {
    public partial class ServerSettings : Form {
        public ServerSettings() {
            InitializeComponent();
            UpdateControls();
        }

        private void UpdateControls() {
            usernameTextBox.Text = Settings.Default.Username;
            passwordTextBox.Text = Settings.Default.Password;
            hostTextBox.Text = Settings.Default.Host;
            portTextBox.Text = Settings.Default.Port.ToString();
            saltTextBox.Text = Settings.Default.Salt;
        }

        private void okButton_Click(object sender, EventArgs e) {
            Settings.Default.Username = usernameTextBox.Text;
            Settings.Default.Password = passwordTextBox.Text;
            Settings.Default.Host = hostTextBox.Text;
            Settings.Default.Salt = saltTextBox.Text;

            int port;
            if (int.TryParse(portTextBox.Text, out port))
                Settings.Default.Port = port;

            Settings.Default.Save();
        }
    }
}
