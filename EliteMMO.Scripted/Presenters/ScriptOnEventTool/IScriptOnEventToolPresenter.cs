using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EliteMMO.Scripted.Presenters.ScriptOnEventTool
{
    public interface IScriptOnEventToolPresenter : IScriptedPresenter
    {
        void StartScript();
        void StopScript();
        void CreateOrSaveEvent();
        void LoadOnEventsFile();
        void SaveOnEventsFile();
        void EditSelectedItem();
        void RemoveSelectedItems();
        void RemoveCheckedItems();
    }
}
