using EliteMMO.API;
using EliteMMO.Scripted.Views;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EliteMMO.Scripted.Models
{
    public abstract class AbstractScriptedModel : IScriptedModel
    {
        protected static EliteAPI api;
        IList<IScriptedView> views = new List<IScriptedView>();
        private bool processFound = false;
        static AbstractScriptedModel()
        {
            Process[] processes;
            if ((processes = Process.GetProcessesByName("pol"))?.Count() != 0)
            {
                AbstractScriptedModel.api = new EliteAPI(processes.First().Id);
            }
        }
        public AbstractScriptedModel()
        {
        }
        public void AddObserver(IScriptedView view)
        {
            views.Add(view);
        }
        public void NotifyObservers()
        {
            foreach (IScriptedView view in views)
            {
                view.Update(this);
            }
        }
        public void RemoveObserver(IScriptedView view)
        {
            views.Remove(view);
        }
        public bool ProcessFound
        {
            get => this.processFound;
            set => this.processFound = value;
        }
        public Process[] GetPOLProcesses() => Process.GetProcessesByName("pol");
        public string GetLocalPlayerName() => api.Entity.GetLocalPlayer().Name;
    }
}
