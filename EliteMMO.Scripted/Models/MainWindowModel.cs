using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EliteMMO.Scripted.Models
{
    public class MainWindowModel : AbstractScriptedModel, IMainWindowModel
    {
        public enum Function
        {
            LOAD_ABOUT_VIEW,
            LOAD_FARM_VIEW,
            LOAD_HEALING_SUPPORT_VIEW,
            LOAD_ON_EVENT_TOOL_VIEW,
            REFRESH_CHARACTERS,
            RE_INITILIAZE_API
        }

        private Process selectedProcess;
        private List<Process> currentProcesses;
        private MainWindowModel.Function mainView;
        public MainWindowModel()
        {
            this.CurrentProcesses = GetPOLProcesses().ToList<Process>();
            if (this.CurrentProcesses.Count > 0)
            {
                ProcessFound = true;
            }
        }
        public Process SelectedProcess
        {
            get => this.selectedProcess;
            set => this.selectedProcess = value;
        }
        public MainWindowModel.Function MainView
        {
            get => this.mainView;
            set => this.mainView = value;
        }
        public List<Process> CurrentProcesses
        {
            get => this.currentProcesses;
            set => this.currentProcesses = value;
        }

        public void AddToCurrentProcesses(Process process)
        {
            this.currentProcesses.Add(process);
        }
        public void ReInitializeApi()
        {
            List<Process> processes = GetPOLProcesses().ToList<Process>();
            if (processes.Any())
            {
                foreach (Process process in processes.Where(process => SelectedProcess.MainWindowTitle == process.MainWindowTitle))
                {
                    api.Reinitialize(process.Id);
                }
            }
        }
    }
}
