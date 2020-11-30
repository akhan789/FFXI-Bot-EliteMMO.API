using System.Windows.Forms;
using System.Collections;

namespace EliteMMO.Scripted.Views.ScriptOnEventTool
{
    public interface IScriptOnEventToolView : IScriptedView
    {
        IList SelectedItems { get; }
        IList CheckedItems { get; }
        IList CurrentEventsListItems { get; }
        void removeEventsListItem(object item);
        void GetEventItemsSubItemsSetText(object listViewItem, int subItemIndex, string text);
        string GetEventItemsSubItemsGetText(int itemIndex, int subItemIndex);
        string GetSelectedEventItemsSubItemsGetText(int selectedItemIndex, int subItemIndex);
        bool IsEventsListItemChecked(int itemIndex);
        bool EnableStartScriptToolStripMenuItem { get; set; }
        bool EnableStopScriptToolStripMenuItem { get; set; }
        bool EnableSaveOEToolStripMenuItem { get; set; }
        bool EnableRemoveCheckedOEToolStripMenuItem { get; set; }
        bool EnableEditSelectedToolStripMenuItem { get; set; }
        string ChatEventText { get; set; }
        string ChatTypeComboText { get; set; }
        string ExecuteCommandText { get; set; }
        bool UseRegexChecked { get; set; }
    }
}
