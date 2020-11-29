using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EliteMMO.Scripted.Presenters.MainWindow
{
    public interface IMainWindowPresenter : IScriptedPresenter
    {
        void Donate(string donateURL);
        void Exit();
        void ReinitializeApi();
        void RefreshCharacters();
        void LoadAboutView();
        void LoadScriptFarmView();
        void LoadScriptHealingSupportView();
        void LoadScriptOnEventToolView();
    }
}
