namespace EliteMMO.Scripted.Views.MainWindow
{
    using System.Windows.Forms;
    using API;
    partial class MainWindowView
    {
        private readonly UserControl scriptFarmView;
        private readonly UserControl scriptHealingSupportView;
        private readonly UserControl scriptNaviMapView;
        private readonly UserControl scriptOnEventToolView;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowView));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshCharactersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.farmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healingSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skillupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synergyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buySellTradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.melyonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shamiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sparksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaldonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stayOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToSysTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableMaintenanceModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.scriptedSubHeader = new System.Windows.Forms.Label();
            this.scriptedHeader = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.eliteMMOProcesses = new System.Windows.Forms.ComboBox();
            this.selectProcessLabel = new System.Windows.Forms.Label();
            this.donateButton = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(366, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "xmenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSettingsToolStripMenuItem,
            this.saveSettingsToolStripMenuItem,
            this.resetSettingsToolStripMenuItem,
            this.refreshCharactersToolStripMenuItem,
            this.closeExitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSettingsToolStripMenuItem
            // 
            this.loadSettingsToolStripMenuItem.Enabled = false;
            this.loadSettingsToolStripMenuItem.Name = "loadSettingsToolStripMenuItem";
            this.loadSettingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.loadSettingsToolStripMenuItem.Text = "Load Settings";
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Enabled = false;
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.saveSettingsToolStripMenuItem.Text = "Save Settings";
            // 
            // resetSettingsToolStripMenuItem
            // 
            this.resetSettingsToolStripMenuItem.Enabled = false;
            this.resetSettingsToolStripMenuItem.Name = "resetSettingsToolStripMenuItem";
            this.resetSettingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.resetSettingsToolStripMenuItem.Text = "Reset Settings";
            // 
            // refreshCharactersToolStripMenuItem
            // 
            this.refreshCharactersToolStripMenuItem.Name = "refreshCharactersToolStripMenuItem";
            this.refreshCharactersToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.refreshCharactersToolStripMenuItem.Text = "Refresh Characters";
            this.refreshCharactersToolStripMenuItem.Click += new System.EventHandler(this.RefreshCharactersToolStripMenuItemClick);
            // 
            // closeExitToolStripMenuItem
            // 
            this.closeExitToolStripMenuItem.Name = "closeExitToolStripMenuItem";
            this.closeExitToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.closeExitToolStripMenuItem.Text = "Close/Exit";
            this.closeExitToolStripMenuItem.Click += new System.EventHandler(this.CloseExitToolStripMenuItemClick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scriptsToolStripMenuItem,
            this.questsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // scriptsToolStripMenuItem
            // 
            this.scriptsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.farmToolStripMenuItem,
            this.healingSupportToolStripMenuItem,
            this.skillupToolStripMenuItem,
            this.synergyToolStripMenuItem,
            this.buySellTradeToolStripMenuItem,
            this.navigationToolStripMenuItem,
            this.onEventToolStripMenuItem});
            this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // farmToolStripMenuItem
            // 
            this.farmToolStripMenuItem.Name = "farmToolStripMenuItem";
            this.farmToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.farmToolStripMenuItem.Text = "Farm";
            this.farmToolStripMenuItem.Click += new System.EventHandler(this.FarmToolStripMenuItemClick);
            // 
            // healingSupportToolStripMenuItem
            // 
            this.healingSupportToolStripMenuItem.Enabled = false;
            this.healingSupportToolStripMenuItem.Name = "healingSupportToolStripMenuItem";
            this.healingSupportToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.healingSupportToolStripMenuItem.Text = "Healing Support";
            this.healingSupportToolStripMenuItem.Click += new System.EventHandler(this.HealingSupportToolStripMenuItemClick);
            // 
            // skillupToolStripMenuItem
            // 
            this.skillupToolStripMenuItem.Enabled = false;
            this.skillupToolStripMenuItem.Name = "skillupToolStripMenuItem";
            this.skillupToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.skillupToolStripMenuItem.Text = "Skillup";
            this.skillupToolStripMenuItem.Visible = false;
            // 
            // synergyToolStripMenuItem
            // 
            this.synergyToolStripMenuItem.Enabled = false;
            this.synergyToolStripMenuItem.Name = "synergyToolStripMenuItem";
            this.synergyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.synergyToolStripMenuItem.Text = "Synergy";
            this.synergyToolStripMenuItem.Visible = false;
            // 
            // buySellTradeToolStripMenuItem
            // 
            this.buySellTradeToolStripMenuItem.Enabled = false;
            this.buySellTradeToolStripMenuItem.Name = "buySellTradeToolStripMenuItem";
            this.buySellTradeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.buySellTradeToolStripMenuItem.Text = "Buy/Sell/Trade";
            this.buySellTradeToolStripMenuItem.Visible = false;
            // 
            // navigationToolStripMenuItem
            // 
            this.navigationToolStripMenuItem.Enabled = false;
            this.navigationToolStripMenuItem.Name = "navigationToolStripMenuItem";
            this.navigationToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.navigationToolStripMenuItem.Text = "Navigation";
            // 
            // onEventToolStripMenuItem
            // 
            this.onEventToolStripMenuItem.Name = "onEventToolStripMenuItem";
            this.onEventToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.onEventToolStripMenuItem.Text = "On Event Tool";
            this.onEventToolStripMenuItem.Click += new System.EventHandler(this.OnEventToolStripMenuItemClick);
            // 
            // questsToolStripMenuItem
            // 
            this.questsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.melyonToolStripMenuItem,
            this.shamiToolStripMenuItem,
            this.sparksToolStripMenuItem,
            this.zaldonToolStripMenuItem});
            this.questsToolStripMenuItem.Enabled = false;
            this.questsToolStripMenuItem.Name = "questsToolStripMenuItem";
            this.questsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.questsToolStripMenuItem.Text = "Quests";
            this.questsToolStripMenuItem.Visible = false;
            // 
            // melyonToolStripMenuItem
            // 
            this.melyonToolStripMenuItem.Name = "melyonToolStripMenuItem";
            this.melyonToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.melyonToolStripMenuItem.Text = "Melyon";
            // 
            // shamiToolStripMenuItem
            // 
            this.shamiToolStripMenuItem.Name = "shamiToolStripMenuItem";
            this.shamiToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.shamiToolStripMenuItem.Text = "Shami";
            // 
            // sparksToolStripMenuItem
            // 
            this.sparksToolStripMenuItem.Name = "sparksToolStripMenuItem";
            this.sparksToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.sparksToolStripMenuItem.Text = "Sparks";
            // 
            // zaldonToolStripMenuItem
            // 
            this.zaldonToolStripMenuItem.Name = "zaldonToolStripMenuItem";
            this.zaldonToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.zaldonToolStripMenuItem.Text = "Zaldon";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stayOnTopToolStripMenuItem,
            this.minimizeToSysTrayToolStripMenuItem,
            this.enableMaintenanceModeToolStripMenuItem});
            this.optionsToolStripMenuItem.Enabled = false;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // stayOnTopToolStripMenuItem
            // 
            this.stayOnTopToolStripMenuItem.Name = "stayOnTopToolStripMenuItem";
            this.stayOnTopToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.stayOnTopToolStripMenuItem.Text = "Stay on Top";
            // 
            // minimizeToSysTrayToolStripMenuItem
            // 
            this.minimizeToSysTrayToolStripMenuItem.Name = "minimizeToSysTrayToolStripMenuItem";
            this.minimizeToSysTrayToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.minimizeToSysTrayToolStripMenuItem.Text = "Minimize to SysTray";
            // 
            // enableMaintenanceModeToolStripMenuItem
            // 
            this.enableMaintenanceModeToolStripMenuItem.Name = "enableMaintenanceModeToolStripMenuItem";
            this.enableMaintenanceModeToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.enableMaintenanceModeToolStripMenuItem.Text = "Maintenance Mode";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fAQToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // fAQToolStripMenuItem
            // 
            this.fAQToolStripMenuItem.Enabled = false;
            this.fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            this.fAQToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.fAQToolStripMenuItem.Text = "FAQ";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 187);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(366, 22);
            this.statusStrip.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // scriptedSubHeader
            // 
            this.scriptedSubHeader.AutoSize = true;
            this.scriptedSubHeader.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptedSubHeader.Location = new System.Drawing.Point(222, 52);
            this.scriptedSubHeader.Name = "scriptedSubHeader";
            this.scriptedSubHeader.Size = new System.Drawing.Size(132, 28);
            this.scriptedSubHeader.TabIndex = 12;
            this.scriptedSubHeader.Text = "by cmalo/vicrelant\r\nmodified by Solidwater";
            // 
            // scriptedHeader
            // 
            this.scriptedHeader.AutoSize = true;
            this.scriptedHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptedHeader.Location = new System.Drawing.Point(170, 32);
            this.scriptedHeader.Name = "scriptedHeader";
            this.scriptedHeader.Size = new System.Drawing.Size(130, 20);
            this.scriptedHeader.TabIndex = 11;
            this.scriptedHeader.Text = "Scripted (c) 2020";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Image = global::EliteMMO.Scripted.Properties.Resources.xeyes_1_128x128x32;
            this.pictureBox.Location = new System.Drawing.Point(0, 24);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(366, 163);
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // eliteMMOProcesses
            // 
            this.eliteMMOProcesses.FormattingEnabled = true;
            this.eliteMMOProcesses.Location = new System.Drawing.Point(11, 160);
            this.eliteMMOProcesses.Name = "eliteMMOProcesses";
            this.eliteMMOProcesses.Size = new System.Drawing.Size(136, 21);
            this.eliteMMOProcesses.TabIndex = 14;
            this.eliteMMOProcesses.TabStop = false;
            this.eliteMMOProcesses.SelectedIndexChanged += new System.EventHandler(this.EliteMmoProcSelectedIndexChanged);
            // 
            // selectProcessLabel
            // 
            this.selectProcessLabel.AutoSize = true;
            this.selectProcessLabel.Location = new System.Drawing.Point(11, 146);
            this.selectProcessLabel.Name = "selectProcessLabel";
            this.selectProcessLabel.Size = new System.Drawing.Size(75, 13);
            this.selectProcessLabel.TabIndex = 15;
            this.selectProcessLabel.Text = "select process";
            // 
            // donateButton
            // 
            this.donateButton.BackColor = System.Drawing.Color.White;
            this.donateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donateButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.donateButton.Location = new System.Drawing.Point(174, 156);
            this.donateButton.Name = "donateButton";
            this.donateButton.Size = new System.Drawing.Size(185, 27);
            this.donateButton.TabIndex = 16;
            this.donateButton.Text = "Donate";
            this.donateButton.UseVisualStyleBackColor = false;
            this.donateButton.Click += new System.EventHandler(this.PaypalClick);
            // 
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 209);
            this.Controls.Add(this.donateButton);
            this.Controls.Add(this.selectProcessLabel);
            this.Controls.Add(this.eliteMMOProcesses);
            this.Controls.Add(this.scriptedSubHeader);
            this.Controls.Add(this.scriptedHeader);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindowView";
            this.Text = "Scripted  - by Solidwater";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip;
        public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem loadSettingsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem resetSettingsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem closeExitToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem scriptsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem farmToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem healingSupportToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem skillupToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem synergyToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem buySellTradeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem questsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem melyonToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem shamiToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem sparksToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem zaldonToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem stayOnTopToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel statusLabel;
        public System.Windows.Forms.PictureBox pictureBox;
        public System.Windows.Forms.Label scriptedSubHeader;
        public System.Windows.Forms.Label scriptedHeader;
        public System.Windows.Forms.ComboBox eliteMMOProcesses;
        public System.Windows.Forms.ToolStripMenuItem refreshCharactersToolStripMenuItem;
        public System.Windows.Forms.Label selectProcessLabel;
        public ToolStripMenuItem minimizeToSysTrayToolStripMenuItem;
        public ToolStripMenuItem enableMaintenanceModeToolStripMenuItem;
        public ToolStripMenuItem navigationToolStripMenuItem;
        private ToolStripMenuItem onEventToolStripMenuItem;
        private Button donateButton;
    }
}