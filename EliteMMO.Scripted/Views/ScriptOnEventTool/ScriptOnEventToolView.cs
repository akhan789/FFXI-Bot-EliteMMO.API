namespace EliteMMO.Scripted.Views.ScriptOnEventTool
{
    using System;
    using System.Windows.Forms;
    using System.Linq;
    using System.Threading;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Xml;
    using System.IO;
    using EliteMMO.Scripted.Controller.ScriptOnEventTool;
    using EliteMMO.Scripted.Models.ScriptOnEventTool;
    using EliteMMO.Scripted.Models;

    public partial class ScriptOnEventToolView : UserControl, IScriptOnEventToolView
    {
        private IScriptOnEventToolController scriptOnEventToolController = new ScriptOnEventToolController();
        private IScriptOnEventToolModel scriptOnEventToolModel = new ScriptOnEventToolModel();
        public bool botRunning = false;
        public string fileXML;
        public string extension;
        public ScriptOnEventToolView()
        {
            InitializeComponent();
            WireUp(scriptOnEventToolController, scriptOnEventToolModel);
            Update();
        }
        public void WireUp(IScriptOnEventToolController controller, IScriptOnEventToolModel model)
        {
            if (scriptOnEventToolModel != null)
            {
                scriptOnEventToolModel.RemoveObserver(this);
            }
            scriptOnEventToolModel = model;
            scriptOnEventToolController = controller;
            scriptOnEventToolController.SetModel(scriptOnEventToolModel);
            scriptOnEventToolController.SetView(this);
            scriptOnEventToolModel.AddObserver(this);
        }

        public void Update(IScriptedModel model)
        {
            if (model is IScriptOnEventToolModel)
            {
                scriptOnEventToolModel = (IScriptOnEventToolModel)model;
            }
        }
        private void StartScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botRunning = true;

            startScriptToolStripMenuItem.Enabled = false;
            stopScriptToolStripMenuItem.Enabled = true;

            if (!bgw_script_events.IsBusy)
                bgw_script_events.RunWorkerAsync();
        }
        private void StopScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botRunning = false;

            startScriptToolStripMenuItem.Enabled = true;
            stopScriptToolStripMenuItem.Enabled = false;

            bgw_script_events.CancelAsync();
        }
        private void AddNewEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chatEvent.Text) ||
                !string.IsNullOrEmpty(executeCommand.Text))
            {
                var items = new string[] { chatEvent.Text, executeCommand.Text, chatTypeCombo.Text, useRegEx.Checked.ToString() };

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

                if (extension == ".oef" || extension == "xml")
                {
                    XmlDocument saveFile = new XmlDocument();

                    XmlNode rootNode = saveFile.CreateElement("OnEventsList");
                    saveFile.AppendChild(rootNode);

                    for (var x = 0; x < eventsList.Items.Count; x++)
                    {
                        XmlNode userNode = saveFile.CreateElement("Event");

                        if (extension == ".oef")
                        {
                            XmlAttribute ChatEvent = saveFile.CreateAttribute("eventtext");
                            ChatEvent.Value = eventsList.Items[x].SubItems[0].Text.ToString();
                            userNode.Attributes.Append(ChatEvent);

                            XmlAttribute EventCommand = saveFile.CreateAttribute("eventcmd");
                            EventCommand.Value = eventsList.Items[x].SubItems[1].Text.ToString();
                            userNode.Attributes.Append(EventCommand);

                            XmlAttribute isChecked = saveFile.CreateAttribute("eventchecked");
                            isChecked.Value = eventsList.Items[x].Checked.ToString();
                            userNode.Attributes.Append(isChecked);
                        }

                        if (extension == ".xml")
                        {
                            XmlAttribute isChecked = saveFile.CreateAttribute("isChecked");
                            isChecked.Value = eventsList.Items[x].Checked.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute ChatEvent = saveFile.CreateAttribute("ChatEvent");
                            ChatEvent.Value = eventsList.Items[x].SubItems[0].Text.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute EventCommand = saveFile.CreateAttribute("EventCommand");
                            EventCommand.Value = eventsList.Items[x].SubItems[1].Text.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute ChatTypeX = saveFile.CreateAttribute("ChatType");
                            ChatTypeX.Value = eventsList.Items[x].SubItems[2].Text.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute isRegEx = saveFile.CreateAttribute("isRegEx");
                            isRegEx.Value = eventsList.Items[x].SubItems[3].Text.ToString();
                            rootNode.AppendChild(userNode);
                        }

                        saveFile.Save(fileXML);
                    }
                }
            }
        }

        private void EventsList_DoubleClick(object sender, EventArgs e)
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

        private void LoadOEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var eventPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Events\\";

            if (Directory.Exists(eventPath) == false)
                Directory.CreateDirectory(eventPath);

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Select OnEvents File To Load";
            openFile.InitialDirectory = eventPath;
            openFile.Filter = "OnEvent File (*.xml)|*.xml|OnEvent File (*.oef)|*.oef";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            DialogResult dlgResult = openFile.ShowDialog();
            if (dlgResult != DialogResult.OK)
                return;

            fileXML = openFile.FileName;

            try
            {
                eventsList.Items.Clear();
                var ext = Path.GetExtension(openFile.FileName);
                extension = ext;

                if (ext == ".oef")
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(openFile.FileName);

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
                    xmlDoc.Load(openFile.FileName);

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

        private void SaveOEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var eventPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Events\\";

            if (Directory.Exists(eventPath) == false)
                Directory.CreateDirectory(eventPath);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save OnEvents File";
            saveFile.InitialDirectory = eventPath;
            saveFile.Filter = "OnEvent File (*.xml)|*.xml";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;

            DialogResult dlgResult = saveFile.ShowDialog();
            if (dlgResult != DialogResult.OK) return;

            try
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(saveFile.FileName, Encoding.UTF8);
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

        private void RemoveCheckedOEToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void EditSelectedToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void BgwScriptEventsDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (botRunning || !bgw_script_events.CancellationPending)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.1));

                var onEvent = (from object itemChecked in eventsList.CheckedItems
                               select itemChecked.ToString()).ToList();

                if (eventsList.Items.Count == 0 || onEvent.Count == 0)
                    continue;

                var line = api.Chat.GetNextChatLine();
                if (string.IsNullOrEmpty(line?.Text)) continue;

                if (useRegEx.Checked)
                {
                    foreach (var item in from item in eventsList.Items.Cast<ListViewItem>().Where(item => line.Text.ToLower().Contains(item.Text.ToLower())) let scan = new Regex(eventsList.Text, RegexOptions.IgnoreCase) where scan.IsMatch(line.Text) select item)
                    {
                        api.ThirdParty.SendString(item.SubItems[1].Text);
                    }
                }
                else
                {
                    foreach (var item in eventsList.Items.Cast<ListViewItem>().Where(item => line.Text.ToLower().Contains(item.Text.ToLower())))
                    {
                        api.ThirdParty.SendString(item.SubItems[1].Text);
                    }
                }
            }
        }
    }
}
