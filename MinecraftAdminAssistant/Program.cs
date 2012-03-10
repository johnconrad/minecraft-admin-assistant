using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using com.ramblingwood.minecraft.jsonapi;
using System.Collections;
using MinecraftAdminAssistant.Data;

namespace MinecraftAdminAssistant {
    static class Program {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            MinecraftAssistSettings.CheckForSettingsUpgrade();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PlayerForm());
        }
    }
}