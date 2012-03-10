using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MinecraftAssistant.Utils;

namespace MinecraftAssistant.UserInterface {
    public partial class NewTeleportDialog : Form {
        public string ChosenName {
            get { return nameTextBox.Text; }
        }
        
        public NewTeleportDialog(string playerName) {
            InitializeComponent();

            descriptionLabel.Text = String.Format(descriptionLabel.Text, playerName);
            nameTextBox.Text = GeographyNamer.GetInstance().GetGeographicName();
        }

        private void randomNameButton_Click(object sender, EventArgs e) {
            nameTextBox.Text = GeographyNamer.GetInstance().GetGeographicName();
        }
    }
}
