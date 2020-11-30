using System.Collections;
using System.Collections.Generic;
using static EliteMMO.Scripted.Models.ScriptOnEventTool.ScriptOnEventToolModel;

namespace EliteMMO.Scripted.Models.ScriptOnEventTool
{
    public interface IScriptOnEventToolModel : IScriptedModel
    {
        void StartBot();
        void StopBot();
        IList<EventElement> LoadOnEventsFile();
        void SaveOnEventsFile(string saveFileName, IList currentEventsListItems, IList<string> chatEventTexts, IList<string> eventCommandTexts, IList<string> chatTypeXTexts, IList<string> isRegExTexts, IList<bool> checkedItem);
        void CreateOrSaveEvent(IList currentEventsListItems, IList<string> chatEventTexts, IList<string> eventCommandTexts, IList<string> chatTypeXTexts, IList<string> isRegExTexts, IList<bool> checkedItem);
        bool BotRunning { get; set; }
        bool UseRegEx { get; set; }
        string FileXML { get; set; }
        string Extension { get; set; }
        string EventsFilePath { get; set; }
    }
}
