using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EliteMMO.Scripted.Controller.MainWindow
{
    public interface IMainWindowController : IScriptedController
    {
        void Donate(string donateURL);
        void Exit();
        void LoadOnEventToolView();
        void LoadAboutView();
        void LoadHealingSupportView();
        void LoadFarmView();
        void ReinitializeApi();
        void RefreshCharacters();
    }
}
