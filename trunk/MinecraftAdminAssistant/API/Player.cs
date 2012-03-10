using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftAdminAssistant.Data {
    public enum GameMode { SURVIVAL, CREATIVE }
    
    [Serializable]
    public class Player {
        public static int MAX_HEALTH = 20;

        public string Name { get; internal set; }
        public DateTime? LastPlayed { get; internal set; }
        public DateTime? FirstPlayed { get; internal set; }
        public bool? Banned { get; internal set; }
        public bool? WhiteListed { get; internal set; }
        public GameMode? GameMode { get; internal set; }
        public long? Health { get; internal set; }
        public long? Hunger { get; internal set; }
        public long? Level { get; internal set; }
        public Location Location { get; internal set; }

        public int HealthPercentage {
            get { return (int) Math.Round((double)(100d * Health / MAX_HEALTH)); }
        }

        public void Update(Player newObj) {
            GameMode = newObj.GameMode;
            Health = newObj.Health;
            Hunger = newObj.Hunger;
            Level = newObj.Level;
            Location = newObj.Location;
        }

        public override string ToString() {
            return Name;
        }

        public override bool Equals(object obj) {
            Player otherPlayer = obj as Player;
            if (otherPlayer == null) return base.Equals(obj);

            return Name == otherPlayer.Name;
        }

        public override int GetHashCode() {
            return Name.GetHashCode();
        }

    }
}
