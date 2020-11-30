using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace EliteMMO.Scripted.Models.ScriptOnEventTool
{
    public class ScriptOnEventToolModel : AbstractScriptedModel, IScriptOnEventToolModel
    {
        private System.ComponentModel.BackgroundWorker bgwScriptEvents;
        private bool botRunning;
        private string fileXML;
        private string extension;

        public ScriptOnEventToolModel()
        {
            this.bgwScriptEvents = new System.ComponentModel.BackgroundWorker();
            this.bgwScriptEvents.WorkerReportsProgress = true;
            this.bgwScriptEvents.WorkerSupportsCancellation = true;
            this.bgwScriptEvents.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptEventsDoWork);
        }
        public void StartBot()
        {
            this.botRunning = true;

            if (!bgwScriptEvents.IsBusy)
            {
                bgwScriptEvents.RunWorkerAsync();
            }
        }
        public void StopBot()
        {
            this.BotRunning = false;

            bgwScriptEvents.CancelAsync();
        }
        public bool BotRunning
        {
            get => this.botRunning;
            set => this.botRunning = value;
        }
        public string FileXML
        {
            get => this.fileXML;
            set => this.fileXML = value;
        }
        public string Extension
        {
            get => this.extension;
            set => this.extension = value;
        }
        public void LoadOnEventsFile()
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
            {
                return;
            }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load the OnEvents file. Please try again.\n" + ex.Message);
                throw;
            }
        }
        public void SaveOnEventsFile(IList currentEventsListItems, IList<string> chatEventTexts, IList<string> eventCommandTexts, IList<string> chatTypeXTexts, IList<string> isRegExTexts, IList<bool> checkedItem)
        {
            var eventPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Events\\";

            if (Directory.Exists(eventPath) == false)
            {
                Directory.CreateDirectory(eventPath);
            }

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save OnEvents File";
            saveFile.InitialDirectory = eventPath;
            saveFile.Filter = "OnEvent File (*.xml)|*.xml";
            saveFile.FilterIndex = 0;
            saveFile.RestoreDirectory = true;

            DialogResult dlgResult = saveFile.ShowDialog();
            if (dlgResult != DialogResult.OK)
            {
                return;
            }

            try
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(saveFile.FileName, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("OnEventsList");

                for (int i = 0; i < currentEventsListItems.Count; i++)
                {
                    xmlWriter.WriteStartElement("Event");
                    xmlWriter.WriteAttributeString("isChecked", checkedItem[i].ToString());
                    xmlWriter.WriteAttributeString("ChatEvent", chatEventTexts[i]);
                    xmlWriter.WriteAttributeString("EventCommand", eventCommandTexts[i]);
                    xmlWriter.WriteAttributeString("ChatType", chatTypeXTexts[i]);
                    xmlWriter.WriteAttributeString("isRegEx", isRegExTexts[i]);

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

        public void CreateOrSaveEvent(IList currentEventsListItems, IList<string> chatEventTexts, IList<string> eventCommandTexts, IList<string> chatTypeXTexts, IList<string> isRegExTexts, IList<bool> checkedItem)
        {
            if (this.extension == ".oef" || this.extension == "xml")
            {
                XmlDocument saveFile = new XmlDocument();

                XmlNode rootNode = saveFile.CreateElement("OnEventsList");
                saveFile.AppendChild(rootNode);

                for (var x = 0; x < currentEventsListItems.Count; x++)
                {
                    XmlNode userNode = saveFile.CreateElement("Event");

                    if (this.extension == ".oef")
                    {
                        XmlAttribute ChatEvent = saveFile.CreateAttribute("eventtext");
                        ChatEvent.Value = chatEventTexts[x];
                        userNode.Attributes.Append(ChatEvent);

                        XmlAttribute EventCommand = saveFile.CreateAttribute("eventcmd");
                        EventCommand.Value = eventCommandTexts[x];
                        userNode.Attributes.Append(EventCommand);

                        XmlAttribute isChecked = saveFile.CreateAttribute("eventchecked");
                        isChecked.Value = checkedItem[x].ToString();
                        userNode.Attributes.Append(isChecked);
                    }

                    if (this.extension == ".xml")
                    {
                        XmlAttribute isChecked = saveFile.CreateAttribute("isChecked");
                        isChecked.Value = checkedItem[x].ToString();
                        rootNode.AppendChild(userNode);

                        XmlAttribute ChatEvent = saveFile.CreateAttribute("ChatEvent");
                        ChatEvent.Value = chatEventTexts[x];
                        rootNode.AppendChild(userNode);

                        XmlAttribute EventCommand = saveFile.CreateAttribute("EventCommand");
                        EventCommand.Value = eventCommandTexts[x];
                        rootNode.AppendChild(userNode);

                        XmlAttribute ChatTypeX = saveFile.CreateAttribute("ChatType");
                        ChatTypeX.Value = chatTypeXTexts[x];
                        rootNode.AppendChild(userNode);

                        XmlAttribute isRegEx = saveFile.CreateAttribute("isRegEx");
                        isRegEx.Value = isRegExTexts[x];
                        rootNode.AppendChild(userNode);
                    }

                    saveFile.Save(fileXML);
                }
            }
        }

        private void BgwScriptEventsDoWork()
        {
            while (botRunning || !bgwScriptEvents.CancellationPending)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(100));

                var onEvent = (from object itemChecked in eventsListItems.CheckedItems
                               select itemChecked.ToString()).ToList();

                if (eventsListItems.Items.Count == 0 || onEvent.Count == 0)
                    continue;

                var line = api.Chat.GetNextChatLine();
                if (string.IsNullOrEmpty(line?.Text)) continue;

                if (useRegEx.Checked)
                {
                    foreach (var item in from item in eventsListItems.Items.Cast<ListViewItem>().Where(item => line.Text.ToLower().Contains(item.Text.ToLower())) let scan = new Regex(eventsListItems.Text, RegexOptions.IgnoreCase) where scan.IsMatch(line.Text) select item)
                    {
                        api.ThirdParty.SendString(item.SubItems[1].Text);
                    }
                }
                else
                {
                    foreach (var item in eventsListItems.Items.Cast<ListViewItem>().Where(item => line.Text.ToLower().Contains(item.Text.ToLower())))
                    {
                        api.ThirdParty.SendString(item.SubItems[1].Text);
                    }
                }
            }
        }

    }
}