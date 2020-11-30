using System.Windows.Forms;
using System.Collections;

namespace EliteMMO.Scripted.Views.ScriptOnEventTool
{
    public interface IScriptOnEventToolView : IScriptedView
    {
        string ShowFileDialog(bool save, string title, string filter, int filterIndex, bool restoreDirectory);
        void ShowMessageBox(string message);
        void RemoveEventsListItem(object item);
        void GetEventItemsSubItemsSetText(object listViewItem, int subItemIndex, string text);
        string GetEventItemsSubItemsGetText(int itemIndex, int subItemIndex);
        string GetSelectedEventItemsSubItemsGetText(int selectedItemIndex, int subItemIndex);
        void SetEventsListItemChecked(int itemIndex, bool value);
        bool IsEventsListItemChecked(int itemIndex);
        void CurrentEventsListItemAddItem(string value);
        void CurrentEventsListItemAddSubItem(int itemIndex, string value);
        IList SelectedItems { get; }
        IList CheckedItems { get; }
        IList CurrentEventsListItems { get; }
        string ChatEventText { get; set; }
        string ChatTypeComboText { get; set; }
        string ExecuteCommandText { get; set; }
        bool UseRegexChecked { get; set; }
        bool EnableStartScriptToolStripMenuItem { get; set; }
        bool EnableStopScriptToolStripMenuItem { get; set; }
        bool EnableSaveOEToolStripMenuItem { get; set; }
        bool EnableRemoveCheckedOEToolStripMenuItem { get; set; }
        bool EnableEditSelectedToolStripMenuItem { get; set; }
    }
}
