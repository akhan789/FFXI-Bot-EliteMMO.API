using EliteMMO.Scripted.Views;
using System.Diagnostics;

namespace EliteMMO.Scripted.Models
{
    public interface IScriptedModel
    {
        void AddObserver(IScriptedView view);
        void RemoveObserver(IScriptedView view);
        void NotifyObservers();
        bool ProcessFound { get; set; }
        Process[] GetPOLProcesses();
        string GetLocalPlayerName();
    }
}
