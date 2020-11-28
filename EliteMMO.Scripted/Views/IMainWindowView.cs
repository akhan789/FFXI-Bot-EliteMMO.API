using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteMMO.Scripted.Views
{
    public interface IMainWindowView : IScriptedView
    {
        void HidePictureBox();
        void ShowPictureBox();
        void HideHeader1();
        void ShowHeader1();
        void HideHeader2();
        void ShowHeader2();
        void HideLabel1();
        void ShowLabel1();
        void HideButton1();
        void ShowButton1();
        void HideEliteMMO_PROC();
        void ShowEliteMMO_PROC();
        void HideFarmView();
        void ShowFarmView();
        void HideHealingSupportView();
        void ShowHealingSupportView();
        void HideNaviMapView();
        void ShowNaviMapView();
        void HideOnEventToolView();
        void ShowOnEventToolView();
        void SetSize(int width, int height);
        void EnableRefreshCharacters();
        void DisableRefreshCharacters();
    }
}
