namespace EliteMMO.Scripted.Views.ScriptOnEventTool
{
    using System;
    using EliteMMO.API;
    using System.Windows.Forms;
    using System.IO;
    partial class ScriptOnEventToolView
    {
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

        public enum CType : short
        {
            SentSay = 1,			    // = a say message that the user sends
            SentShout = 2,		        // = a shout message that the user sends
            SentYell = 3,
            SentTell = 4,			    // = user sends tell to someone else
            SentParty = 5,		        // = user message to Party
            SentLinkShell = 6,	        // = user message to linkshell
            SentEmote = 7,			    // = user uses /emote
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.useRegEx = new System.Windows.Forms.CheckBox();
            this.chatTypeLabel = new System.Windows.Forms.Label();
            this.chatTypeCombo = new System.Windows.Forms.ComboBox();
            this.startStopStrip = new System.Windows.Forms.MenuStrip();
            this.startScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeCommandLabel = new System.Windows.Forms.Label();
            this.chatEventLabel = new System.Windows.Forms.Label();
            this.executeCommand = new System.Windows.Forms.TextBox();
            this.eventsList = new System.Windows.Forms.ListView();
            this.eventTextHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.commandExecuteHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chatTypeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.regExHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.getSetEvents = new System.Windows.Forms.MenuStrip();
            this.loadOEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCheckedOEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEvent = new System.Windows.Forms.MenuStrip();
            this.createSaveEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatEvent = new System.Windows.Forms.TextBox();
            this.mainGroupBox.SuspendLayout();
            this.startStopStrip.SuspendLayout();
            this.getSetEvents.SuspendLayout();
            this.createEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Controls.Add(this.useRegEx);
            this.mainGroupBox.Controls.Add(this.chatTypeLabel);
            this.mainGroupBox.Controls.Add(this.chatTypeCombo);
            this.mainGroupBox.Controls.Add(this.startStopStrip);
            this.mainGroupBox.Controls.Add(this.executeCommandLabel);
            this.mainGroupBox.Controls.Add(this.chatEventLabel);
            this.mainGroupBox.Controls.Add(this.executeCommand);
            this.mainGroupBox.Controls.Add(this.eventsList);
            this.mainGroupBox.Controls.Add(this.getSetEvents);
            this.mainGroupBox.Controls.Add(this.createEvent);
            this.mainGroupBox.Controls.Add(this.chatEvent);
            this.mainGroupBox.Location = new System.Drawing.Point(10, 30);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Size = new System.Drawing.Size(455, 397);
            this.mainGroupBox.TabIndex = 1;
            this.mainGroupBox.TabStop = false;
            this.mainGroupBox.Text = "On Event Tool";
            // 
            // useRegEx
            // 
            this.useRegEx.AutoSize = true;
            this.useRegEx.Location = new System.Drawing.Point(284, 320);
            this.useRegEx.Name = "useRegEx";
            this.useRegEx.Size = new System.Drawing.Size(144, 17);
            this.useRegEx.TabIndex = 35;
            this.useRegEx.Text = "Use Regular Expressions";
            this.useRegEx.UseVisualStyleBackColor = true;
            this.useRegEx.CheckedChanged += new System.EventHandler(this.UseRegEx_CheckedChanged);
            // 
            // chatTypeLabel
            // 
            this.chatTypeLabel.AutoSize = true;
            this.chatTypeLabel.Location = new System.Drawing.Point(222, 300);
            this.chatTypeLabel.Name = "chatTypeLabel";
            this.chatTypeLabel.Size = new System.Drawing.Size(56, 13);
            this.chatTypeLabel.TabIndex = 34;
            this.chatTypeLabel.Text = "Chat Type";
            // 
            // chatTypeCombo
            // 
            this.chatTypeCombo.Enabled = false;
            this.chatTypeCombo.FormattingEnabled = true;
            this.chatTypeCombo.Items.AddRange(new object[] {
            "Say",
            "Shout",
            "Yell",
            "Tell",
            "Party",
            "Linkshell",
            "Emote"});
            this.chatTypeCombo.Location = new System.Drawing.Point(284, 296);
            this.chatTypeCombo.Name = "chatTypeCombo";
            this.chatTypeCombo.Size = new System.Drawing.Size(160, 21);
            this.chatTypeCombo.TabIndex = 33;
            this.chatTypeCombo.Text = "ALL";
            // 
            // startStopStrip
            // 
            this.startStopStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startStopStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startScriptToolStripMenuItem,
            this.stopScriptToolStripMenuItem});
            this.startStopStrip.Location = new System.Drawing.Point(3, 370);
            this.startStopStrip.Name = "startStopStrip";
            this.startStopStrip.Size = new System.Drawing.Size(449, 24);
            this.startStopStrip.TabIndex = 31;
            this.startStopStrip.Text = "menuStrip1";
            // 
            // startScriptToolStripMenuItem
            // 
            this.startScriptToolStripMenuItem.Name = "startScriptToolStripMenuItem";
            this.startScriptToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startScriptToolStripMenuItem.Text = "Start";
            this.startScriptToolStripMenuItem.Click += new System.EventHandler(this.StartScriptToolStripMenuItem_Click);
            // 
            // stopScriptToolStripMenuItem
            // 
            this.stopScriptToolStripMenuItem.Enabled = false;
            this.stopScriptToolStripMenuItem.Name = "stopScriptToolStripMenuItem";
            this.stopScriptToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.stopScriptToolStripMenuItem.Text = "Stop";
            this.stopScriptToolStripMenuItem.Click += new System.EventHandler(this.StopScriptToolStripMenuItem_Click);
            // 
            // executeCommandLabel
            // 
            this.executeCommandLabel.AutoSize = true;
            this.executeCommandLabel.Location = new System.Drawing.Point(182, 278);
            this.executeCommandLabel.Name = "executeCommandLabel";
            this.executeCommandLabel.Size = new System.Drawing.Size(96, 13);
            this.executeCommandLabel.TabIndex = 30;
            this.executeCommandLabel.Text = "Execute Command";
            // 
            // chatEventLabel
            // 
            this.chatEventLabel.AutoSize = true;
            this.chatEventLabel.Location = new System.Drawing.Point(218, 255);
            this.chatEventLabel.Name = "chatEventLabel";
            this.chatEventLabel.Size = new System.Drawing.Size(60, 13);
            this.chatEventLabel.TabIndex = 29;
            this.chatEventLabel.Text = "Chat Event";
            // 
            // executeCommand
            // 
            this.executeCommand.Location = new System.Drawing.Point(284, 274);
            this.executeCommand.Name = "executeCommand";
            this.executeCommand.Size = new System.Drawing.Size(160, 20);
            this.executeCommand.TabIndex = 28;
            // 
            // eventsList
            // 
            this.eventsList.CheckBoxes = true;
            this.eventsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.eventTextHeader,
            this.commandExecuteHeader,
            this.chatTypeHeader,
            this.regExHeader});
            this.eventsList.FullRowSelect = true;
            this.eventsList.GridLines = true;
            this.eventsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.eventsList.HideSelection = false;
            this.eventsList.Location = new System.Drawing.Point(12, 48);
            this.eventsList.Name = "eventsList";
            this.eventsList.Size = new System.Drawing.Size(432, 198);
            this.eventsList.TabIndex = 27;
            this.eventsList.UseCompatibleStateImageBehavior = false;
            this.eventsList.View = System.Windows.Forms.View.Details;
            this.eventsList.DoubleClick += new System.EventHandler(this.EventsList_DoubleClick);
            // 
            // eventTextHeader
            // 
            this.eventTextHeader.Text = "Event Text";
            this.eventTextHeader.Width = 134;
            // 
            // commandExecuteHeader
            // 
            this.commandExecuteHeader.Text = "Command Execute";
            this.commandExecuteHeader.Width = 169;
            // 
            // chatTypeHeader
            // 
            this.chatTypeHeader.Text = "Chat Type";
            this.chatTypeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chatTypeHeader.Width = 78;
            // 
            // regExHeader
            // 
            this.regExHeader.Text = "RegEx";
            this.regExHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.regExHeader.Width = 47;
            // 
            // getSetEvents
            // 
            this.getSetEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadOEToolStripMenuItem,
            this.saveOEToolStripMenuItem,
            this.editSelectedToolStripMenuItem,
            this.removeCheckedOEToolStripMenuItem});
            this.getSetEvents.Location = new System.Drawing.Point(3, 16);
            this.getSetEvents.Name = "getSetEvents";
            this.getSetEvents.Size = new System.Drawing.Size(449, 24);
            this.getSetEvents.TabIndex = 0;
            this.getSetEvents.Text = "getSetEvents";
            // 
            // loadOEToolStripMenuItem
            // 
            this.loadOEToolStripMenuItem.Name = "loadOEToolStripMenuItem";
            this.loadOEToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadOEToolStripMenuItem.Text = "Load";
            this.loadOEToolStripMenuItem.Click += new System.EventHandler(this.LoadOEToolStripMenuItem_Click);
            // 
            // saveOEToolStripMenuItem
            // 
            this.saveOEToolStripMenuItem.Enabled = false;
            this.saveOEToolStripMenuItem.Name = "saveOEToolStripMenuItem";
            this.saveOEToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveOEToolStripMenuItem.Text = "Save";
            this.saveOEToolStripMenuItem.Click += new System.EventHandler(this.SaveOEToolStripMenuItem_Click);
            // 
            // editSelectedToolStripMenuItem
            // 
            this.editSelectedToolStripMenuItem.Enabled = false;
            this.editSelectedToolStripMenuItem.Name = "editSelectedToolStripMenuItem";
            this.editSelectedToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.editSelectedToolStripMenuItem.Text = "Edit Selected";
            this.editSelectedToolStripMenuItem.Click += new System.EventHandler(this.EditSelectedToolStripMenuItem_Click);
            // 
            // removeCheckedOEToolStripMenuItem
            // 
            this.removeCheckedOEToolStripMenuItem.Enabled = false;
            this.removeCheckedOEToolStripMenuItem.Name = "removeCheckedOEToolStripMenuItem";
            this.removeCheckedOEToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.removeCheckedOEToolStripMenuItem.Text = "Remove Checked";
            this.removeCheckedOEToolStripMenuItem.Click += new System.EventHandler(this.RemoveCheckedOEToolStripMenuItem_Click);
            // 
            // createEvent
            // 
            this.createEvent.Dock = System.Windows.Forms.DockStyle.None;
            this.createEvent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createSaveEventToolStripMenuItem});
            this.createEvent.Location = new System.Drawing.Point(284, 340);
            this.createEvent.Name = "createEvent";
            this.createEvent.Size = new System.Drawing.Size(122, 24);
            this.createEvent.TabIndex = 32;
            this.createEvent.Text = "menuStrip2";
            // 
            // createSaveEventToolStripMenuItem
            // 
            this.createSaveEventToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.createSaveEventToolStripMenuItem.Name = "createSaveEventToolStripMenuItem";
            this.createSaveEventToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.createSaveEventToolStripMenuItem.Text = "Create/Save Event";
            this.createSaveEventToolStripMenuItem.Click += new System.EventHandler(this.CreateSaveEventToolStripMenuItem_Click);
            // 
            // chatEvent
            // 
            this.chatEvent.Location = new System.Drawing.Point(284, 252);
            this.chatEvent.Name = "chatEvent";
            this.chatEvent.Size = new System.Drawing.Size(160, 20);
            this.chatEvent.TabIndex = 16;
            // 
            // ScriptOnEventToolView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainGroupBox);
            this.Name = "ScriptOnEventToolView";
            this.Size = new System.Drawing.Size(474, 435);
            this.mainGroupBox.ResumeLayout(false);
            this.mainGroupBox.PerformLayout();
            this.startStopStrip.ResumeLayout(false);
            this.startStopStrip.PerformLayout();
            this.getSetEvents.ResumeLayout(false);
            this.getSetEvents.PerformLayout();
            this.createEvent.ResumeLayout(false);
            this.createEvent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox mainGroupBox;
        public System.Windows.Forms.Label executeCommandLabel;
        public System.Windows.Forms.Label chatEventLabel;
        public System.Windows.Forms.TextBox executeCommand;
        public System.Windows.Forms.ListView eventsList;
        public System.Windows.Forms.ColumnHeader eventTextHeader;
        public System.Windows.Forms.ColumnHeader commandExecuteHeader;
        public System.Windows.Forms.MenuStrip getSetEvents;
        public System.Windows.Forms.ToolStripMenuItem loadOEToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveOEToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem removeCheckedOEToolStripMenuItem;
        public System.Windows.Forms.TextBox chatEvent;
        public System.Windows.Forms.MenuStrip startStopStrip;
        public System.Windows.Forms.ToolStripMenuItem startScriptToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem stopScriptToolStripMenuItem;
        public System.Windows.Forms.MenuStrip createEvent;
        public System.Windows.Forms.ToolStripMenuItem createSaveEventToolStripMenuItem;
        public System.Windows.Forms.Label chatTypeLabel;
        public System.Windows.Forms.ComboBox chatTypeCombo;
        public System.Windows.Forms.CheckBox useRegEx;
        public System.Windows.Forms.ColumnHeader chatTypeHeader;
        public System.Windows.Forms.ColumnHeader regExHeader;
        public System.Windows.Forms.ToolStripMenuItem editSelectedToolStripMenuItem;
    }
}
