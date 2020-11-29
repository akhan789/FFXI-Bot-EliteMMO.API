using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Windows.Forms.ListView;

namespace EliteMMO.Scripted.Models.ScriptOnEventTool
{
    public interface IScriptOnEventToolModel : IScriptedModel
    {
        ScriptOnEventToolModel.Function ScriptOnEventToolFunction { get; set; }
        bool BotRunning { get; set; }
        string FileXML { get; set; }
        string Extension { get; set; }
        ListViewItemCollection CurrentEventsListItems { get; set; }
        void StartBot();
        void StopBot();
        void CreateOrSaveEvent();
    }
}
