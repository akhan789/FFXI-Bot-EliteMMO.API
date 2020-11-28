using System.Linq;
using System.Text;
using System.Xml;

namespace EliteMMO.Scripted.Views.ScriptOnEventTool
{
    using System;
    using EliteMMO.API;
    using System.Windows.Forms;
    using System.IO;
    partial class ScriptOnEventToolView
    {
        public bool botRunning = false;
        public string fileXML;
        public string _ext;
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
            this.addNewEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatEvent = new System.Windows.Forms.TextBox();
            this.bgw_script_events = new System.ComponentModel.BackgroundWorker();
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
            this.startScriptToolStripMenuItem.Click += new System.EventHandler(this.ToolStartClick);
            // 
            // stopScriptToolStripMenuItem
            // 
            this.stopScriptToolStripMenuItem.Enabled = false;
            this.stopScriptToolStripMenuItem.Name = "stopScriptToolStripMenuItem";
            this.stopScriptToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.stopScriptToolStripMenuItem.Text = "Stop";
            this.stopScriptToolStripMenuItem.Click += new System.EventHandler(this.ToolStopClick);
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
            this.eventsList.DoubleClick += new System.EventHandler(this.Events_DoubleClick);
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
            this.loadOEToolStripMenuItem.Click += new System.EventHandler(this.LoadOEToolStripMenuItemClick);
            // 
            // saveOEToolStripMenuItem
            // 
            this.saveOEToolStripMenuItem.Enabled = false;
            this.saveOEToolStripMenuItem.Name = "saveOEToolStripMenuItem";
            this.saveOEToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveOEToolStripMenuItem.Text = "Save";
            this.saveOEToolStripMenuItem.Click += new System.EventHandler(this.SaveOEToolStripMenuItemClick);
            // 
            // editSelectedToolStripMenuItem
            // 
            this.editSelectedToolStripMenuItem.Enabled = false;
            this.editSelectedToolStripMenuItem.Name = "editSelectedToolStripMenuItem";
            this.editSelectedToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.editSelectedToolStripMenuItem.Text = "Edit Selected";
            this.editSelectedToolStripMenuItem.Click += new System.EventHandler(this.EditSelectedToolStripMenuItemClick);
            // 
            // removeCheckedOEToolStripMenuItem
            // 
            this.removeCheckedOEToolStripMenuItem.Enabled = false;
            this.removeCheckedOEToolStripMenuItem.Name = "removeCheckedOEToolStripMenuItem";
            this.removeCheckedOEToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.removeCheckedOEToolStripMenuItem.Text = "Remove Checked";
            this.removeCheckedOEToolStripMenuItem.Click += new System.EventHandler(this.RemoveCheckedOEToolStripMenuItemClick);
            // 
            // createEvent
            // 
            this.createEvent.Dock = System.Windows.Forms.DockStyle.None;
            this.createEvent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEventToolStripMenuItem});
            this.createEvent.Location = new System.Drawing.Point(284, 340);
            this.createEvent.Name = "createEvent";
            this.createEvent.Size = new System.Drawing.Size(122, 24);
            this.createEvent.TabIndex = 32;
            this.createEvent.Text = "menuStrip2";
            // 
            // addNewEventToolStripMenuItem
            // 
            this.addNewEventToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.addNewEventToolStripMenuItem.Name = "addNewEventToolStripMenuItem";
            this.addNewEventToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.addNewEventToolStripMenuItem.Text = "Create/Save Event";
            this.addNewEventToolStripMenuItem.Click += new System.EventHandler(this.AddNewEventToolStripMenuItemClick);
            // 
            // chatEvent
            // 
            this.chatEvent.Location = new System.Drawing.Point(284, 252);
            this.chatEvent.Name = "chatEvent";
            this.chatEvent.Size = new System.Drawing.Size(160, 20);
            this.chatEvent.TabIndex = 16;
            // 
            // bgw_script_events
            // 
            this.bgw_script_events.WorkerReportsProgress = true;
            this.bgw_script_events.WorkerSupportsCancellation = true;
            this.bgw_script_events.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptEventsDoWork);
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
        public System.Windows.Forms.ToolStripMenuItem addNewEventToolStripMenuItem;
        public System.ComponentModel.BackgroundWorker bgw_script_events;
        public System.Windows.Forms.Label chatTypeLabel;
        public System.Windows.Forms.ComboBox chatTypeCombo;
        public System.Windows.Forms.CheckBox useRegEx;
        public System.Windows.Forms.ColumnHeader chatTypeHeader;
        public System.Windows.Forms.ColumnHeader regExHeader;
        public System.Windows.Forms.ToolStripMenuItem editSelectedToolStripMenuItem;

        private void ToolStartClick(object sender, EventArgs e)
        {
            botRunning = true;

            startScriptToolStripMenuItem.Enabled = false;
            stopScriptToolStripMenuItem.Enabled = true;

            if (!bgw_script_events.IsBusy)
                bgw_script_events.RunWorkerAsync();
        }

        private void ToolStopClick(object sender, EventArgs e)
        {
            botRunning = false;

            startScriptToolStripMenuItem.Enabled = true;
            stopScriptToolStripMenuItem.Enabled = false;

            bgw_script_events.CancelAsync();
        }

        private void AddNewEventToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chatEvent.Text) ||
                !string.IsNullOrEmpty(executeCommand.Text))
            {
                var items = new string[] {chatEvent.Text, executeCommand.Text, chatTypeCombo.Text, useRegEx.Checked.ToString()};

                if (eventsList.SelectedItems.Count > 0)
                {
                    var selected = eventsList.SelectedItems[0];
                    selected.SubItems[0].Text = chatEvent.Text;
                    selected.SubItems[1].Text = executeCommand.Text;
                    selected.SubItems[2].Text = chatTypeCombo.Text;
                    selected.SubItems[3].Text = useRegEx.Checked.ToString();
                }
                else
                {
                    var item = new ListViewItem(items);
                    eventsList.Items.Add(item);
                }

                if (saveOEToolStripMenuItem.Enabled == false)
                    saveOEToolStripMenuItem.Enabled = true;

                if (removeCheckedOEToolStripMenuItem.Enabled == false)
                    removeCheckedOEToolStripMenuItem.Enabled = true;

                if (editSelectedToolStripMenuItem.Enabled == false)
                    editSelectedToolStripMenuItem.Enabled = true;

                chatEvent.Text = "";
                executeCommand.Text = "";

                if (_ext == ".oef" || _ext == "xml")
                {
                    XmlDocument _saveFile = new XmlDocument();

                    XmlNode rootNode = _saveFile.CreateElement("OnEventsList");
                    _saveFile.AppendChild(rootNode);

                    for (var x = 0; x < eventsList.Items.Count; x++)
                    {
                        XmlNode userNode = _saveFile.CreateElement("Event");

                        if (_ext == ".oef")
                        {
                            XmlAttribute ChatEvent = _saveFile.CreateAttribute("eventtext");
                            ChatEvent.Value = eventsList.Items[x].SubItems[0].Text.ToString();
                            userNode.Attributes.Append(ChatEvent);

                            XmlAttribute EventCommand = _saveFile.CreateAttribute("eventcmd");
                            EventCommand.Value = eventsList.Items[x].SubItems[1].Text.ToString();
                            userNode.Attributes.Append(EventCommand);

                            XmlAttribute isChecked = _saveFile.CreateAttribute("eventchecked");
                            isChecked.Value = eventsList.Items[x].Checked.ToString();
                            userNode.Attributes.Append(isChecked);
                        }

                        if (_ext == ".xml")
                        {
                            XmlAttribute isChecked = _saveFile.CreateAttribute("isChecked");
                            isChecked.Value = eventsList.Items[x].Checked.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute ChatEvent = _saveFile.CreateAttribute("ChatEvent");
                            ChatEvent.Value = eventsList.Items[x].SubItems[0].Text.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute EventCommand = _saveFile.CreateAttribute("EventCommand");
                            EventCommand.Value = eventsList.Items[x].SubItems[1].Text.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute ChatTypeX = _saveFile.CreateAttribute("ChatType");
                            ChatTypeX.Value = eventsList.Items[x].SubItems[2].Text.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute isRegEx = _saveFile.CreateAttribute("isRegEx");
                            isRegEx.Value = eventsList.Items[x].SubItems[3].Text.ToString();
                            rootNode.AppendChild(userNode);
                        }

                        _saveFile.Save(fileXML);
                    }
                }
            }
        }

        private void Events_DoubleClick(object sender, EventArgs e)
        {
            if (eventsList.SelectedItems.Count <= 0) return;

            foreach (ListViewItem selected in eventsList.SelectedItems)
            {
                eventsList.Items.Remove(selected);
            }

            if (eventsList.Items.Count == 0)
            {
                saveOEToolStripMenuItem.Enabled = false;
                removeCheckedOEToolStripMenuItem.Enabled = false;
                editSelectedToolStripMenuItem.Enabled = false;
            }
        }

        private void LoadOEToolStripMenuItemClick(object sender, EventArgs e)
        {
            var eventPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Events\\";

            if (Directory.Exists(eventPath) == false)
                Directory.CreateDirectory(eventPath);

            OpenFileDialog _openFile = new OpenFileDialog();
            _openFile.Title = "Select OnEvents File To Load";
            _openFile.InitialDirectory = eventPath;
            _openFile.Filter = "OnEvent File (*.xml)|*.xml|OnEvent File (*.oef)|*.oef";
            _openFile.FilterIndex = 1;
            _openFile.RestoreDirectory = true;

            DialogResult _dlgResult = _openFile.ShowDialog();
            if (_dlgResult != DialogResult.OK)
                return;

            fileXML = _openFile.FileName;

            try
            {
                eventsList.Items.Clear();
                var ext = Path.GetExtension(_openFile.FileName);
                _ext = ext;

                if (ext == ".oef")
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(_openFile.FileName);

                    XmlNode mainNode = xmlDoc.SelectSingleNode("OnEventsList");
                    XmlNodeList nodeList = mainNode.ChildNodes;

                    for (int x = 0; x < nodeList.Count; x++)
                    {
                        eventsList.Items.Add(new ListViewItem(new string[]
                        {
                            nodeList[x].Attributes["eventtext"].Value.ToString(), 
                            nodeList[x].Attributes["eventcmd"].Value.ToString(),
                        }));
                        string temp = nodeList[x].Attributes["eventchecked"].Value.ToString();
                        eventsList.Items[x].Checked = Convert.ToBoolean(temp);

                        eventsList.Items[x].SubItems.Add("ALL");
                        eventsList.Items[x].SubItems.Add("False");
                    }
                }
                else if (ext == ".xml")
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(_openFile.FileName);

                    XmlNode mainNode = xmlDoc.SelectSingleNode("OnEventsList");
                    XmlNodeList nodeList = mainNode.ChildNodes;

                    for (var x = 0; x < nodeList.Count; x++)
                    {
                        eventsList.Items.Add(new ListViewItem(new string[]
                        {
                            nodeList[x].Attributes["ChatEvent"].Value.ToString(), 
                            nodeList[x].Attributes["EventCommand"].Value.ToString(),
                            nodeList[x].Attributes["ChatType"].Value.ToString(),
                            nodeList[x].Attributes["isRegEx"].Value.ToString()
                        }));
                        
                        var temp = nodeList[x].Attributes["isChecked"].Value.ToString();
                        eventsList.Items[x].Checked = Convert.ToBoolean(temp);
                    }
                }

                if (saveOEToolStripMenuItem.Enabled == false)
                    saveOEToolStripMenuItem.Enabled = true;

                if (removeCheckedOEToolStripMenuItem.Enabled == false)
                    removeCheckedOEToolStripMenuItem.Enabled = true;

                if (editSelectedToolStripMenuItem.Enabled == false)
                    editSelectedToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load the OnEvents file. Please try again.\n" + ex.Message);
                throw;
            }
        }

        private void SaveOEToolStripMenuItemClick(object sender, EventArgs e)
        {
            var eventPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Events\\";
            
            if (Directory.Exists(eventPath) == false)
                Directory.CreateDirectory(eventPath);

            SaveFileDialog _saveFile = new SaveFileDialog();
            _saveFile.Title = "Save OnEvents File";
            _saveFile.InitialDirectory = eventPath;
            _saveFile.Filter = "OnEvent File (*.xml)|*.xml";
            _saveFile.FilterIndex = 0;
            _saveFile.RestoreDirectory = true;

            DialogResult _dlgResult = _saveFile.ShowDialog();
            if (_dlgResult != DialogResult.OK) return;

            try
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(_saveFile.FileName, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("OnEventsList");

                for (int i = 0; i < eventsList.Items.Count; i++)
                {
                    xmlWriter.WriteStartElement("Event");
                    xmlWriter.WriteAttributeString("isChecked", eventsList.Items[i].Checked.ToString());
                    xmlWriter.WriteAttributeString("ChatEvent", eventsList.Items[i].SubItems[0].Text.ToString());
                    xmlWriter.WriteAttributeString("EventCommand", eventsList.Items[i].SubItems[1].Text.ToString());
                    xmlWriter.WriteAttributeString("ChatType", eventsList.Items[i].SubItems[2].Text.ToString());
                    xmlWriter.WriteAttributeString("isRegEx", eventsList.Items[i].SubItems[3].Text.ToString());

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save OnEvents file. Please try another location.\n" + ex.Message);
                throw;
            }
        }

        private void RemoveCheckedOEToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach (ListViewItem items in eventsList.CheckedItems)
            {
                eventsList.Items.Remove(items);
            }

            if (eventsList.Items.Count == 0)
            {
                if (saveOEToolStripMenuItem.Enabled == true)
                    saveOEToolStripMenuItem.Enabled = false;

                if (removeCheckedOEToolStripMenuItem.Enabled == true)
                    removeCheckedOEToolStripMenuItem.Enabled = false;

                if (editSelectedToolStripMenuItem.Enabled == true)
                    editSelectedToolStripMenuItem.Enabled = false;   
            }
        }

        private void EditSelectedToolStripMenuItemClick(object sender, EventArgs e)
        {
            var i = eventsList.Items.IndexOf(eventsList.SelectedItems[0]);

            chatEvent.Text = eventsList.SelectedItems[0].SubItems[0].Text;
            executeCommand.Text = eventsList.SelectedItems[0].SubItems[1].Text;
            chatTypeCombo.Text = eventsList.SelectedItems[0].SubItems[2].Text;

            if (eventsList.SelectedItems[0].SubItems[3].Text.ToString() == "False")
            {
                useRegEx.Checked = false;
            }
            else
            {
                useRegEx.Checked = true;
            }
        }
    }
}
