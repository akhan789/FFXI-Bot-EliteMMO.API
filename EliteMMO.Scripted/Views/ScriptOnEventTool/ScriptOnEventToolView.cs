namespace EliteMMO.Scripted.Views.ScriptOnEventTool
{
    using System;
    using System.Windows.Forms;
    using EliteMMO.Scripted.Presenters.ScriptOnEventTool;
    using EliteMMO.Scripted.Models.ScriptOnEventTool;
    using System.Collections;
    using System.IO;

    public partial class ScriptOnEventToolView : UserControl, IScriptOnEventToolView
    {
        private IScriptOnEventToolPresenter scriptOnEventToolPresenter;
        private IScriptOnEventToolModel scriptOnEventToolModel;
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
        private void UseRegEx_CheckedChanged(object sender, EventArgs e)
        {
            scriptOnEventToolPresenter.SetUseRegEx();
        }
        public string ShowFileDialog(bool save, string title, string filter, int filterIndex, bool restoreDirectory)
        {
            string eventPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Events\\";
            if (Directory.Exists(eventPath) == false)
            {
                Directory.CreateDirectory(eventPath);
            }
            FileDialog fileDialog;
            if (save)
            {
                fileDialog = new SaveFileDialog();
            }
            else
            {
                fileDialog = new OpenFileDialog();
            }
            fileDialog.Title = title;
            fileDialog.InitialDirectory = eventPath;
            fileDialog.Filter = filter;
            fileDialog.FilterIndex = filterIndex;
            fileDialog.RestoreDirectory = restoreDirectory;
            DialogResult dlgResult = fileDialog.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                return fileDialog.FileName;
            }
            return null;
        }
        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
        public void RemoveEventsListItem(object item)
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
        public void SetEventsListItemChecked(int itemIndex, bool value)
        {
            eventsList.Items[itemIndex].Checked = value;
        }
        public bool IsEventsListItemChecked(int itemIndex)
        {
            return eventsList.Items[itemIndex].Checked;
        }
        public void CurrentEventsListItemAddItem(string value)
        {
            eventsList.Items.Add(value);
        }
        public void CurrentEventsListItemAddSubItem(int itemIndex, string value)
        {
            eventsList.Items[itemIndex].SubItems.Add(value);
        }
        public IList SelectedItems
        {
            get => eventsList.SelectedItems;
        }
        public IList CheckedItems
        {
            get => eventsList.CheckedItems;
        }
        public IList CurrentEventsListItems
        {
            get => eventsList.Items;
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
    }
}
