using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteMMO.Scripted.Views.MainWindow
{
    public interface IMainWindowView : IScriptedView
    {
        void addControl(string control);
        void SetSize(int width, int height);
        string StatusLabelText { get; set; }
        bool ShowPictureBox { get; set; }
        bool ShowScriptedHeader { get; set; }
        bool ShowScriptedSubHeader { get; set; }
        bool ShowSelectProcessLabel { get; set; }
        bool ShowDonateButton { get; set; }
        bool ShowEliteMMOProcesses { get; set; }
        void ClearEliteMMOProcesses();
        void AddEliteMMOProcesses(string[] mainWindowTitles);
        string SelectedItemEliteMMOProcesses { get; set; }
        bool ShowScriptFarmView { get; set; }
        string DockStyleScriptFarmView { get; set; }
        bool ShowScriptHealingSupportView { get; set; }
        string DockStyleScriptHealingSupportView { get; set; }
        bool ShowScriptNaviMapView { get; set; }
        string DockStyleScriptNaviMapView { get; set; }
        bool ShowScriptOnEventToolView { get; set; }
        string DockStyleScriptOnEventToolView { get; set; }
        bool EnableRefreshCharacters { get; set; }
    }
}
