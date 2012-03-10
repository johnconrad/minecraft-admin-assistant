using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MinecraftAdminAssistant.Properties;

namespace MinecraftAdminAssistant.Utils {
    public class GeographyNamer {
        private static GeographyNamer instance = null;
        Random r = new Random();

        string[] adjectives;
        string[] landforms;

        public static GeographyNamer GetInstance() {
            if (instance == null) instance = new GeographyNamer();

            return instance;
        }

        private GeographyNamer() {
            adjectives = Resources.Adjectives.Split(new char[] {'\n'});
            landforms = Resources.Landforms.Split(new char[] { '\n'});
        }

        public string GetGeographicName() {
            string adjective = UppercaseWords(adjectives[r.Next(adjectives.Length)]);
            string landform = UppercaseWords(landforms[r.Next(landforms.Length)]);

            return String.Format("{0} {1}", adjective.Trim(), landform.Trim());
        }

        private string UppercaseWords(string input) {
            if (input == null || input.Length == 0) return input;

            StringBuilder output = new StringBuilder();
            output.Append(char.ToUpper(input[0]));

            int i = 1;
            while (i < input.Length) {
                if (char.IsWhiteSpace(input[i-1]) || char.IsPunctuation(input[i-1])) {
                    output.Append(char.ToUpper(input[i]));
                } else {
                    output.Append(input[i]);
                }
                
                i++;
            }

            return output.ToString().Trim();
        }
    }
}
