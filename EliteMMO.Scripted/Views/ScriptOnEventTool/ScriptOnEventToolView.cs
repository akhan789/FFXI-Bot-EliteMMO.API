﻿namespace EliteMMO.Scripted.Views.ScriptOnEventTool
{
    using System;
    using System.Windows.Forms;
    using API;
    using System.Linq;
    using System.Threading;
    using System.Text.RegularExpressions;
    public partial class ScriptOnEventToolView : UserControl
    {
        public ScriptOnEventToolView()
        {
            InitializeComponent();
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
