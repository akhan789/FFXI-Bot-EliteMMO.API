using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EliteMMO.Scripted.Models.MainWindow
{
    public class MainWindowModel : AbstractScriptedModel, IMainWindowModel
    {
        private Process selectedProcess;
        private List<Process> currentProcesses;
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
