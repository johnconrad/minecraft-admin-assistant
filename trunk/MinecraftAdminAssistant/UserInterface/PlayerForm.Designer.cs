using MinecraftAssistant.UserInterface;
namespace MinecraftAssistant {
    partial class PlayerForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.ColumnHeader playerHeader;
            System.Windows.Forms.ColumnHeader worldHeader;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.ToolStrip toolStrip1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.ColumnHeader xHeader;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.settingsButton = new System.Windows.Forms.ToolStripButton();
            this.refreshButton = new System.Windows.Forms.ToolStripButton();
            this.playerListView = new System.Windows.Forms.ListView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.gameModeComboBox = new System.Windows.Forms.ComboBox();
            this.healthBar = new System.Windows.Forms.TrackBar();
            this.hungerBar = new System.Windows.Forms.TrackBar();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.teleportButton = new System.Windows.Forms.ToolStripSplitButton();
            this.addDestinationButton = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDestinationButton = new System.Windows.Forms.ToolStripMenuItem();
            this.returnButton = new System.Windows.Forms.ToolStripButton();
            this.yHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.zHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.destinationComboBox = new MinecraftAssistant.UserInterface.DestinationComboBox();
            label1 = new System.Windows.Forms.Label();
            playerHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            worldHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            label4 = new System.Windows.Forms.Label();
            xHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.healthBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hungerBar)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 136);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(63, 13);
            label1.TabIndex = 4;
            label1.Text = "Game Mode";
            // 
            // playerHeader
            // 
            playerHeader.Text = "Player";
            playerHeader.Width = 130;
            // 
            // worldHeader
            // 
            worldHeader.Text = "World";
            // 
            // label2
            // 
            label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(138, 136);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 13);
            label2.TabIndex = 6;
            label2.Text = "Health";
            // 
            // label3
            // 
            label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(247, 136);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(42, 13);
            label3.TabIndex = 8;
            label3.Text = "Hunger";
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsButton,
            this.refreshButton});
            toolStrip1.Location = new System.Drawing.Point(298, 9);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            toolStrip1.Size = new System.Drawing.Size(49, 25);
            toolStrip1.TabIndex = 9;
            toolStrip1.Text = "toolStrip1";
            // 
            // settingsButton
            // 
            this.settingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsButton.Image = global::MinecraftAssistant.Properties.Resources.Settings;
            this.settingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(23, 22);
            this.settingsButton.Text = "toolStripButton1";
            this.settingsButton.ToolTipText = "Server Settings";
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshButton.Image = global::MinecraftAssistant.Properties.Resources.RefreshIcon;
            this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(23, 22);
            this.refreshButton.Text = "toolStripButton1";
            this.refreshButton.ToolTipText = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // label4
            // 
            label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 200);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 13);
            label4.TabIndex = 10;
            label4.Text = "Teleport to:";
            // 
            // playerListView
            // 
            this.playerListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.playerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            playerHeader,
            xHeader,
            this.yHeader,
            this.zHeader,
            worldHeader});
            this.playerListView.FullRowSelect = true;
            this.playerListView.GridLines = true;
            this.playerListView.HideSelection = false;
            this.playerListView.Location = new System.Drawing.Point(12, 37);
            this.playerListView.MultiSelect = false;
            this.playerListView.Name = "playerListView";
            this.playerListView.Size = new System.Drawing.Size(335, 96);
            this.playerListView.TabIndex = 1;
            this.playerListView.UseCompatibleStateImageBehavior = false;
            this.playerListView.View = System.Windows.Forms.View.Details;
            this.playerListView.SelectedIndexChanged += new System.EventHandler(this.playerListView_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 21);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(283, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 2;
            // 
            // gameModeComboBox
            // 
            this.gameModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gameModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gameModeComboBox.FormattingEnabled = true;
            this.gameModeComboBox.Location = new System.Drawing.Point(11, 152);
            this.gameModeComboBox.Name = "gameModeComboBox";
            this.gameModeComboBox.Size = new System.Drawing.Size(122, 21);
            this.gameModeComboBox.Sorted = true;
            this.gameModeComboBox.TabIndex = 3;
            this.gameModeComboBox.SelectedIndexChanged += new System.EventHandler(this.gameModeComboBox_SelectedIndexChanged);
            // 
            // healthBar
            // 
            this.healthBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.healthBar.Location = new System.Drawing.Point(138, 152);
            this.healthBar.Maximum = 20;
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(104, 45);
            this.healthBar.TabIndex = 5;
            this.healthBar.Scroll += new System.EventHandler(this.healthBar_Scroll);
            // 
            // hungerBar
            // 
            this.hungerBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hungerBar.Location = new System.Drawing.Point(247, 152);
            this.hungerBar.Maximum = 20;
            this.hungerBar.Name = "hungerBar";
            this.hungerBar.Size = new System.Drawing.Size(99, 45);
            this.hungerBar.TabIndex = 7;
            this.hungerBar.Scroll += new System.EventHandler(this.hungerBar_Scroll);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teleportButton,
            this.returnButton});
            this.toolStrip2.Location = new System.Drawing.Point(292, 216);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(58, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // teleportButton
            // 
            this.teleportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.teleportButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDestinationButton,
            this.removeDestinationButton});
            this.teleportButton.Image = global::MinecraftAssistant.Properties.Resources.MapGo;
            this.teleportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.teleportButton.Name = "teleportButton";
            this.teleportButton.Size = new System.Drawing.Size(32, 22);
            this.teleportButton.Text = "toolStripSplitButton1";
            this.teleportButton.ToolTipText = "Teleport!";
            this.teleportButton.ButtonClick += new System.EventHandler(this.teleportButton_ButtonClick);
            // 
            // addDestinationButton
            // 
            this.addDestinationButton.Image = global::MinecraftAssistant.Properties.Resources.MapAdd;
            this.addDestinationButton.Name = "addDestinationButton";
            this.addDestinationButton.Size = new System.Drawing.Size(242, 22);
            this.addDestinationButton.Text = "Add Teleport Point";
            this.addDestinationButton.Click += new System.EventHandler(this.addDestinationButton_Click);
            // 
            // removeDestinationButton
            // 
            this.removeDestinationButton.Image = global::MinecraftAssistant.Properties.Resources.MapDelete;
            this.removeDestinationButton.Name = "removeDestinationButton";
            this.removeDestinationButton.Size = new System.Drawing.Size(242, 22);
            this.removeDestinationButton.Text = "Remove Selected Teleport Point";
            this.removeDestinationButton.Click += new System.EventHandler(this.removeDestinationButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.returnButton.Image = global::MinecraftAssistant.Properties.Resources.Return;
            this.returnButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(23, 22);
            this.returnButton.Text = "returnButton";
            this.returnButton.ToolTipText = "Return Player to Previous Locations";
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // xHeader
            // 
            xHeader.Text = "X";
            xHeader.Width = 40;
            // 
            // yHeader
            // 
            this.yHeader.Text = "Y";
            this.yHeader.Width = 40;
            // 
            // zHeader
            // 
            this.zHeader.Text = "Z";
            this.zHeader.Width = 40;
            // 
            // destinationComboBox
            // 
            this.destinationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.destinationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationComboBox.FormattingEnabled = true;
            this.destinationComboBox.Location = new System.Drawing.Point(12, 216);
            this.destinationComboBox.Name = "destinationComboBox";
            this.destinationComboBox.Size = new System.Drawing.Size(277, 22);
            this.destinationComboBox.TabIndex = 0;
            this.destinationComboBox.SelectedIndexChanged += new System.EventHandler(this.destinationComboBox_SelectedIndexChanged);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 250);
            this.Controls.Add(label4);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.destinationComboBox);
            this.Controls.Add(toolStrip1);
            this.Controls.Add(label3);
            this.Controls.Add(this.hungerBar);
            this.Controls.Add(label2);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(label1);
            this.Controls.Add(this.gameModeComboBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.playerListView);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(375, 1080);
            this.MinimumSize = new System.Drawing.Size(375, 265);
            this.Name = "PlayerForm";
            this.Text = "Minecraft Assistant";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.healthBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hungerBar)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView playerListView;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ComboBox gameModeComboBox;
        private System.Windows.Forms.TrackBar healthBar;
        private System.Windows.Forms.TrackBar hungerBar;
        private System.Windows.Forms.ToolStripButton refreshButton;
        private System.Windows.Forms.ToolStripButton settingsButton;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private DestinationComboBox destinationComboBox;
        private System.Windows.Forms.ToolStripSplitButton teleportButton;
        private System.Windows.Forms.ToolStripMenuItem addDestinationButton;
        private System.Windows.Forms.ToolStripMenuItem removeDestinationButton;
        private System.Windows.Forms.ToolStripButton returnButton;
        private System.Windows.Forms.ColumnHeader yHeader;
        private System.Windows.Forms.ColumnHeader zHeader;
    }
}

