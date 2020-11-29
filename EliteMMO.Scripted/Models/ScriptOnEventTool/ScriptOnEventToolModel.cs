using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace EliteMMO.Scripted.Models.ScriptOnEventTool
{
    public class ScriptOnEventToolModel : AbstractScriptedModel, IScriptOnEventToolModel
    {
        public enum Function
        {
            START_BOT,
            STOP_BOT,
            CREATE_OR_SAVE_EVENT
        }

        private System.ComponentModel.BackgroundWorker bgwScriptEvents;
        private ScriptOnEventToolModel.Function scriptOnEventToolFunction;
        private ListView.ListViewItemCollection eventsListItems;
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
        public ScriptOnEventToolModel.Function ScriptOnEventToolFunction
        {
            get => this.scriptOnEventToolFunction;
            set => this.scriptOnEventToolFunction = value;
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
        public ListView.ListViewItemCollection CurrentEventsListItems
        {
            get => this.eventsListItems;
            set => this.eventsListItems = value;
        }

        public void CreateOrSaveEvent()
        {
            if (this.extension == ".oef" || this.extension == "xml")
            {
                XmlDocument saveFile = new XmlDocument();

                XmlNode rootNode = saveFile.CreateElement("OnEventsList");
                saveFile.AppendChild(rootNode);

                for (var x = 0; x < eventsListItems.Count; x++)
                {
                    XmlNode userNode = saveFile.CreateElement("Event");

                    if (this.extension == ".oef")
                    {
                        XmlAttribute ChatEvent = saveFile.CreateAttribute("eventtext");
                        ChatEvent.Value = eventsListItems[x].SubItems[0].Text.ToString();
                        userNode.Attributes.Append(ChatEvent);

                        XmlAttribute EventCommand = saveFile.CreateAttribute("eventcmd");
                        EventCommand.Value = eventsListItems[x].SubItems[1].Text.ToString();
                        userNode.Attributes.Append(EventCommand);

                        XmlAttribute isChecked = saveFile.CreateAttribute("eventchecked");
                        isChecked.Value = eventsListItems[x].Checked.ToString();
                        userNode.Attributes.Append(isChecked);
                    }

                    if (this.extension == ".xml")
                    {
                        XmlAttribute isChecked = saveFile.CreateAttribute("isChecked");
                        isChecked.Value = eventsListItems[x].Checked.ToString();
                        rootNode.AppendChild(userNode);

                        XmlAttribute ChatEvent = saveFile.CreateAttribute("ChatEvent");
                        ChatEvent.Value = eventsListItems[x].SubItems[0].Text.ToString();
                        rootNode.AppendChild(userNode);

                        XmlAttribute EventCommand = saveFile.CreateAttribute("EventCommand");
                        EventCommand.Value = eventsListItems[x].SubItems[1].Text.ToString();
                        rootNode.AppendChild(userNode);

                        XmlAttribute ChatTypeX = saveFile.CreateAttribute("ChatType");
                        ChatTypeX.Value = eventsListItems[x].SubItems[2].Text.ToString();
                        rootNode.AppendChild(userNode);

                        XmlAttribute isRegEx = saveFile.CreateAttribute("isRegEx");
                        isRegEx.Value = eventsListItems[x].SubItems[3].Text.ToString();
                        rootNode.AppendChild(userNode);
                    }

                    saveFile.Save(fileXML);
                }
            }
        }
        private void BgwScriptEventsDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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