using System.Windows.Forms;

namespace EliteMMO.Scripted.Views.ScriptOnEventTool
{
    public interface IScriptOnEventToolView : IScriptedView
    {
        void EnableStartScriptToolStripMenuItem(bool enable);
        void EnableStopScriptToolStripMenuItem(bool enable);
        bool EnableSaveOEToolStripMenuItem { get; set; }
        bool EnableRemoveCheckedOEToolStripMenuItem { get; set; }
        bool EnableEditSelectedToolStripMenuItem { get; set; }
        string ChatEventText { get; set; }
        string ChatTypeComboText { get; set; }
        string ExecuteCommandText { get; set; }
        bool UseRegexChecked { get; set; }
        ListView EventsList { get; set; }
    }
}
