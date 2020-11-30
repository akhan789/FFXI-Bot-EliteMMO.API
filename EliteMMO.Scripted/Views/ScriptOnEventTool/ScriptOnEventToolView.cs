namespace EliteMMO.Scripted.Views.ScriptOnEventTool
{
    using System;
    using System.Windows.Forms;
    using System.Text;
    using System.Xml;
    using System.IO;
    using EliteMMO.Scripted.Presenters.ScriptOnEventTool;
    using EliteMMO.Scripted.Models.ScriptOnEventTool;
    using EliteMMO.Scripted.Models;
    using System.Collections;
    using System.Collections.Generic;

    public partial class ScriptOnEventToolView : UserControl, IScriptOnEventToolView
    {
        private IScriptOnEventToolPresenter scriptOnEventToolPresenter;
        private IScriptOnEventToolModel scriptOnEventToolModel;
        private string fileXML;
        private string extension;
        public ScriptOnEventToolView()
        {
            InitializeComponent();
            scriptOnEventToolModel = new ScriptOnEventToolModel();
            scriptOnEventToolModel.AddObserver(this);
            scriptOnEventToolPresenter = new ScriptOnEventToolPresenter(scriptOnEventToolModel, this);
        }
        private void StartScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriptOnEventToolPresenter.StartScript();
        }
        private void StopScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriptOnEventToolPresenter.StopScript();
        }
        private void CreateSaveEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriptOnEventToolPresenter.CreateOrSaveEvent();
        }
        private void EventsList_DoubleClick(object sender, EventArgs e)
        {
            scriptOnEventToolPresenter.RemoveSelectedItems();
        }
        private void LoadOEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriptOnEventToolPresenter.LoadOnEventsFile();
        }

        private void SaveOEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriptOnEventToolPresenter.SaveOnEventsFile();
        }

        private void RemoveCheckedOEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriptOnEventToolPresenter.RemoveCheckedItems();
        }

        private void EditSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scriptOnEventToolPresenter.EditSelectedItem();
        }
        public IList SelectedItems
        {
            get => eventsList.SelectedItems;
        }
        public IList CheckedItems
        {
            get => eventsList.CheckedItems;
        }
        public void removeEventsListItem(object item)
        {
            if (item is ListViewItem)
            {
                eventsList.Items.Remove((ListViewItem)item);
            }
        }
        public void GetEventItemsSubItemsSetText(object eventsListItem, int subItemIndex, string text)
        {
            if (eventsListItem is ListViewItem)
            {
                ((ListViewItem)eventsListItem).SubItems[subItemIndex].Text = text;
            }
        }
        public string GetEventItemsSubItemsGetText(int itemIndex, int subItemIndex)
        {
            return eventsList.Items[itemIndex].SubItems[subItemIndex].Text;
        }
        public string GetSelectedEventItemsSubItemsGetText(int selectedItemIndex, int subItemIndex)
        {
            return eventsList.SelectedItems[selectedItemIndex].SubItems[subItemIndex].Text;
        }
        public bool IsEventsListItemChecked(int itemIndex)
        {
            return eventsList.Items[itemIndex].Checked;
        }
        public IList CurrentEventsListItems
        {
            get => eventsList.Items;
        }

        public bool EnableStartScriptToolStripMenuItem
        {
            get => startScriptToolStripMenuItem.Enabled;
            set => startScriptToolStripMenuItem.Enabled = value;
        }
        public bool EnableStopScriptToolStripMenuItem
        {
            get => stopScriptToolStripMenuItem.Enabled;
            set => stopScriptToolStripMenuItem.Enabled = value;
        }
        public bool EnableSaveOEToolStripMenuItem
        {
            get => saveOEToolStripMenuItem.Enabled;
            set => saveOEToolStripMenuItem.Enabled = value;
        }
        public bool EnableRemoveCheckedOEToolStripMenuItem
        {
            get => removeCheckedOEToolStripMenuItem.Enabled;
            set => removeCheckedOEToolStripMenuItem.Enabled = value;
        }
        public bool EnableEditSelectedToolStripMenuItem
        {
            get => editSelectedToolStripMenuItem.Enabled;
            set => editSelectedToolStripMenuItem.Enabled = value;
        }
        public string ChatEventText
        {
            get => chatEvent.Text;
            set => chatEvent.Text = value;
        }
        public string ChatTypeComboText
        {
            get => chatTypeCombo.Text;
            set => chatTypeCombo.Text = value;
        }
        public string ExecuteCommandText
        {
            get => executeCommand.Text;
            set => executeCommand.Text = value;
        }
        public bool UseRegexChecked
        {
            get => useRegEx.Checked;
            set => useRegEx.Checked = value;
        }
    }
}
