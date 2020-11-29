using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EliteMMO.Scripted.Presenters.ScriptOnEventTool
{
    public interface IScriptOnEventToolPresenter : IScriptedPresenter
    {
        void RequestStartScript();
        void RequestStopScript();
        void CreateSaveEvent();
    }
}
