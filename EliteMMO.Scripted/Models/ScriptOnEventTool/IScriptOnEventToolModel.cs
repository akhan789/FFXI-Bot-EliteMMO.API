using System.Collections;
using System.Collections.Generic;

namespace EliteMMO.Scripted.Models.ScriptOnEventTool
{
    public interface IScriptOnEventToolModel : IScriptedModel
    {
        bool BotRunning { get; set; }
        string FileXML { get; set; }
        string Extension { get; set; }
        void StartBot();
        void StopBot();
        void LoadOnEventsFile();
        void SaveOnEventsFile(IList currentEventsListItems, IList<string> chatEventTexts, IList<string> eventCommandTexts, IList<string> chatTypeXTexts, IList<string> isRegExTexts, IList<bool> checkedItem);
        void CreateOrSaveEvent(IList currentEventsListItems, IList<string> chatEventTexts, IList<string> eventCommandTexts, IList<string> chatTypeXTexts, IList<string> isRegExTexts, IList<bool> checkedItem);
    }
}
