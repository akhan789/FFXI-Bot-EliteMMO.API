using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using static EliteMMO.API.EliteAPI;

namespace EliteMMO.Scripted.Models.ScriptOnEventTool
{
    public class ScriptOnEventToolModel : AbstractScriptedModel, IScriptOnEventToolModel
    {
        private System.ComponentModel.BackgroundWorker bgwScriptEvents;
        private bool botRunning;
        private string fileXML;
        private string extension;
        private string eventsFilePath;
        private bool useRegEx;
        public ScriptOnEventToolModel()
        {
            this.bgwScriptEvents = new BackgroundWorker();
            this.bgwScriptEvents.WorkerReportsProgress = true;
            this.bgwScriptEvents.WorkerSupportsCancellation = true;
            this.bgwScriptEvents.DoWork += new DoWorkEventHandler(this.BgwScriptEventsDoWork);
        }
        private void BgwScriptEventsDoWork(object sender, DoWorkEventArgs e)
        {
            while (botRunning || !bgwScriptEvents.CancellationPending)
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(100));

                IList onEvent = (from object itemChecked in eventsListItems.CheckedItems
                                 select itemChecked.ToString()).ToList();

                if (eventsListItems.Items.Count == 0 || onEvent.Count == 0)
                {
                    continue;
                }

                ChatEntry line = api.Chat.GetNextChatLine();
                if (string.IsNullOrEmpty(line?.Text))
                {
                    continue;
                }

                if (UseRegEx)
                {
                    foreach (ListViewItem item in from item in eventsListItems.Items.Cast<ListViewItem>().Where(item => line.Text.ToLower().Contains(item.Text.ToLower()))
                                                  let scan = new Regex(eventsListItems.Text, RegexOptions.IgnoreCase)
                                                  where scan.IsMatch(line.Text) select item)
                    {
                        api.ThirdParty.SendString(item.SubItems[1].Text);
                    }
                }
                else
                {
                    foreach (ListViewItem item in eventsListItems.Items.Cast<ListViewItem>().Where(item => line.Text.ToLower().Contains(item.Text.ToLower())))
                    {
                        api.ThirdParty.SendString(item.SubItems[1].Text);
                    }
                }
            }
        }
        public void StartBot()
        {
            BotRunning = true;
            if (!bgwScriptEvents.IsBusy)
            {
                bgwScriptEvents.RunWorkerAsync();
            }
        }
        public void StopBot()
        {
            BotRunning = false;
            bgwScriptEvents.CancelAsync();
        }
        public IList<EventElement> LoadOnEventsFile()
        {
            try
            {
                IList<EventElement> eventsList = new List<EventElement>();
                extension = Path.GetExtension(fileXML);
                if (extension == ".oef")
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(fileXML);
                    XmlNode mainNode = xmlDoc.SelectSingleNode("OnEventsList");
                    XmlNodeList nodeList = mainNode.ChildNodes;
                    for (int x = 0; x < nodeList.Count; x++)
                    {
                        eventsList.Add(new EventElement(nodeList[x].Attributes["eventtext"].Value.ToString()));
                        eventsList.Add(new EventElement(nodeList[x].Attributes["eventcmd"].Value.ToString()));
                        eventsList[x].Checked = Convert.ToBoolean(nodeList[x].Attributes["eventchecked"].Value.ToString());
                        eventsList[x].SubItems.Add("ALL");
                        eventsList[x].SubItems.Add("False");
                    }
                }
                else if (extension == ".xml")
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(fileXML);
                    XmlNode mainNode = xmlDoc.SelectSingleNode("OnEventsList");
                    XmlNodeList nodeList = mainNode.ChildNodes;
                    for (int x = 0; x < nodeList.Count; x++)
                    {
                        eventsList.Add(new EventElement(nodeList[x].Attributes["ChatEvent"].Value.ToString()));
                        eventsList.Add(new EventElement(nodeList[x].Attributes["EventCommand"].Value.ToString()));
                        eventsList.Add(new EventElement(nodeList[x].Attributes["ChatType"].Value.ToString()));
                        eventsList.Add(new EventElement(nodeList[x].Attributes["isRegEx"].Value.ToString()));
                        eventsList[x].Checked = Convert.ToBoolean(nodeList[x].Attributes["isChecked"].Value.ToString());
                    }
                }
                return eventsList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void SaveOnEventsFile(string saveFileName, IList currentEventsListItems, IList<string> chatEventTexts, IList<string> eventCommandTexts, IList<string> chatTypeXTexts, IList<string> isRegExTexts, IList<bool> checkedItem)
        {
            try
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(saveFileName, Encoding.UTF8);
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
            catch (Exception e)
            {
                throw e;
            }
        }
        public void CreateOrSaveEvent(IList currentEventsListItems, IList<string> chatEventTexts, IList<string> eventCommandTexts, IList<string> chatTypeXTexts, IList<string> isRegExTexts, IList<bool> checkedItem)
        {
            if (extension == ".oef" || extension == "xml")
            {
                XmlDocument saveFile = new XmlDocument();
                XmlNode rootNode = saveFile.CreateElement("OnEventsList");
                saveFile.AppendChild(rootNode);
                for (int x = 0; x < currentEventsListItems.Count; x++)
                {
                    XmlNode userNode = saveFile.CreateElement("Event");
                    if (extension == ".oef")
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
                    if (extension == ".xml")
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
        public bool BotRunning
        {
            get => botRunning;
            set => botRunning = value;
        }
        public string FileXML
        {
            get => fileXML;
            set => fileXML = value;
        }
        public string Extension
        {
            get => extension;
            set => extension = value;
        }
        public string EventsFilePath
        {
            get => eventsFilePath;
            set => eventsFilePath = value;
        }
        public bool UseRegEx
        {
            get => useRegEx;
            set => useRegEx = value;
        }
        public class EventElement
        {
            bool checkedElement;
            string item;
            IList<string> subItems;
            public EventElement(string item)
            {
                Item = item;
            }
            public string Item
            {
                get => item;
                set => item = value;
            }
            public bool Checked
            {
                get => checkedElement;
                set => checkedElement = value;
            }
            public IList<string> SubItems
            {
                get => subItems;
                set => subItems = value;
            }
        }
    }
}