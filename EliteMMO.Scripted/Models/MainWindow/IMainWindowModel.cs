using System.Collections.Generic;
using System.Diagnostics;

namespace EliteMMO.Scripted.Models.MainWindow
{
    public interface IMainWindowModel : IScriptedModel
    {
        Process SelectedProcess { get; set; }
        List<Process> CurrentProcesses { get; set; }
        void AddToCurrentProcesses(Process process);
        void ReInitializeApi();
    }
}