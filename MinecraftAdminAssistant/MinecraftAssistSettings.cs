using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using MinecraftAdminAssistant.Properties;
using MinecraftAdminAssistant.Data;

namespace MinecraftAdminAssistant {
    public class MinecraftAssistSettings {
        private static MinecraftAssistSettings instance = null;

        BinaryFormatter binarySerializer = new BinaryFormatter();
        
        ASCIIEncoding asciiEncoder = new ASCIIEncoding();

        public List<Location> Locations {
            get {
                if (String.IsNullOrWhiteSpace(Settings.Default.LocationsStr))
                    return new List<Location>();

                return (List<Location>)Deserialize(Settings.Default.LocationsStr);
            }

            set {
                Settings.Default.LocationsStr = Serialize(value);
                Settings.Default.Save();
            }
        }

        public static MinecraftAssistSettings GetInstance() {
            if (instance == null) instance = new MinecraftAssistSettings();
            return instance;
        }

        private MinecraftAssistSettings() {
            CheckForSettingsUpgrade();
        }


        public static void CheckForSettingsUpgrade() {
            if (Settings.Default.UpgradeRequired) {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }
        }

        public string Serialize(object obj) {
            // convert to byte stream
            MemoryStream stream = new MemoryStream();
            binarySerializer.Serialize(stream, obj);
            byte[] bytes = stream.ToArray();

            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes) hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }

        public object Deserialize(string str) {
            int len = str.Length;
            byte[] bytes = new byte[len / 2];

            for (int i = 0; i < len; i += 2)
                bytes[i / 2] = Convert.ToByte(str.Substring(i, 2), 16);

            MemoryStream stream = new MemoryStream(bytes);
            return binarySerializer.Deserialize(stream);
        }
    }
}
