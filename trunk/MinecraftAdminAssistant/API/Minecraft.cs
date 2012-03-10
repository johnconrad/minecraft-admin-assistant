using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinecraftAdminAssistant.Data;
using com.ramblingwood.minecraft.jsonapi;
using System.Collections;

namespace MinecraftAdminAssistant {
    public class MinecraftApi {
        protected JSONAPI api;

        public MinecraftApi(string host, int port, string username, string password, string salt) {
            api = new JSONAPI(host, port, username, password, salt);
        }

        public Player GetPlayer(string name) {
            Dictionary<object, object> result = api.call("getPlayer", new ArrayList() { name });
            if ((string)result["result"] == "error") throw new Exception((string)result["error"]);

            return ParsePlayer((Hashtable)result["success"]);
        }

        public List<Player> GetPlayers() {
            Dictionary<object, object> result = api.call("getPlayers", null);
            if ((string)result["result"] == "error") throw new Exception((string)result["error"]);

            return ParsePlayers((ArrayList)result["success"]);
        }

        public List<Player> GetOfflinePlayers() {
            Dictionary<object, object> result = api.call("getOfflinePlayers", null);
            if ((string)result["result"] == "error") throw new Exception((string)result["error"]);

            return ParsePlayers((ArrayList)result["success"]);
        }

        public void TeleportPlayerToWorldLocation(Player player, Location loc) {
            Dictionary<object, object> result = api.call("teleportPlayerToWorldLocation", new ArrayList() { player.Name, loc.World, ((int)loc.X).ToString(), ((int)loc.Y).ToString(), ((int)loc.Z).ToString() });
            if ((string)result["result"] == "error") throw new Exception((string)result["error"]);

            player.Location = loc;
        }

        public void SetPlayerLevel(Player player, int level) {
            Dictionary<object, object> result = api.call("setPlayerLevel", new ArrayList() { player.Name, level.ToString() });
            if ((string)result["result"] == "error") throw new Exception((string)result["error"]);

            player.Level = level;
        }

        public void SetPlayerGameMode(Player player, GameMode mode) {
            Dictionary<object, object> result = api.call("setPlayerGameMode", new ArrayList() { player.Name, ((int)mode).ToString() });
            if ((string)result["result"] == "error") throw new Exception((string)result["error"]);

            player.GameMode = mode;
        }

        public void SetPlayerHealth(Player player, int value) {
            Dictionary<object, object> result = api.call("setPlayerHealth", new ArrayList() { player.Name, value.ToString() });
            if ((string)result["result"] == "error") throw new Exception((string)result["error"]);

            player.Health = value;
        }

        public void SetPlayerFoodLevel(Player player, int value) {
            Dictionary<object, object> result = api.call("setPlayerFoodLevel", new ArrayList() { player.Name, value.ToString() });
            if ((string)result["result"] == "error") throw new Exception((string)result["error"]);

            player.Hunger = value;
        }

        private static List<Player> ParsePlayers(ArrayList data) {
            List<Player> players = new List<Player>();

            foreach(object row in data) 
                players.Add(ParsePlayer((Hashtable)row));

            return players;
        }

        private static Player ParsePlayer(Hashtable data) {
            Player currPlayer = new Player();

            // common fields
            currPlayer.Name = (string)data["name"];

            // offline fields
            currPlayer.LastPlayed = data["lastPlayed"] == null ? (DateTime?)null : FromUnixTime((long)data["lastPlayed"]);
            currPlayer.FirstPlayed = data["firstPlayed"] == null ? (DateTime?)null : FromUnixTime((long)data["firstPlayed"]);
            currPlayer.Banned = data.ContainsKey("banned") ? (Boolean)data["banned"] : (bool?)null;
            currPlayer.WhiteListed = data.ContainsKey("whitelisted") ? (Boolean)data["whitelisted"] : (bool?)null;

            // online fields
            currPlayer.GameMode = data.ContainsKey("gameMode") ? (GameMode)Enum.Parse(typeof(GameMode), data["gameMode"].ToString()) : (GameMode?)null;
            currPlayer.Health = data.ContainsKey("health") ? (long)data["health"] : (long?)null;
            currPlayer.Hunger = data.ContainsKey("foodLevel") ? (long)data["foodLevel"] : (long?)null;
            currPlayer.Level = data.ContainsKey("level") ? (long)data["level"] : (long?)null;

            // location info
            if (data.ContainsKey("location")) {
                currPlayer.Location = new Location();

                Hashtable locInfo = (Hashtable)data["location"];
                currPlayer.Location.X = (double)locInfo["x"];
                currPlayer.Location.Y = (double)locInfo["y"];
                currPlayer.Location.Z = (double)locInfo["z"];

                if (data.ContainsKey("worldInfo")) {
                    currPlayer.Location.World = (string)((Hashtable)data["worldInfo"])["name"];
                }
            }

            return currPlayer;
        }

        private static DateTime FromUnixTime(long unixTimeStamp) {
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            date = date.AddSeconds(unixTimeStamp).ToLocalTime();
            return date;
        }
    }
}
