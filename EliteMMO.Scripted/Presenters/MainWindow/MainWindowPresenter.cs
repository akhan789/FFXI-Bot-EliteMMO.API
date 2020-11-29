using EliteMMO.Scripted.Models;
using EliteMMO.Scripted.Views;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using EliteMMO.Scripted.Models.MainWindow;
using EliteMMO.Scripted.Views.MainWindow;

namespace EliteMMO.Scripted.Presenters.MainWindow
{
    public class MainWindowPresenter : AbstractScriptedPresenter, IMainWindowPresenter
    {
        private IMainWindowView mainWindowView;
        private IMainWindowModel mainWindowModel;
        public MainWindowPresenter(IMainWindowModel model, IMainWindowView view) : base(model, view)
        {
            mainWindowView = (IMainWindowView)view;
            mainWindowModel = (IMainWindowModel)model;

            if(mainWindowModel.ProcessFound)
            {
                mainWindowView.StatusLabelText = @":: " + mainWindowModel.GetLocalPlayerName() + @" ::";
            }
            else
            {
                mainWindowView.StatusLabelText = @":: Final Fantasy Not Found ::";
            }
        }
        public void Donate(string donateURL)
        {
            Process.Start(donateURL);
        }
        public void Exit()
        {
            Application.Exit();
        }
        public void RefreshCharacters()
        {
            Process[] data = model.GetPOLProcesses();

            if (data.Length <= mainWindowModel.CurrentProcesses.Count && data.Length >= mainWindowModel.CurrentProcesses.Count)
            {
                // Do nothing.
            }
            else
            {
                int count = data.Length;
                if (count != 0)
                {
                    foreach (Process polProcess in data.Where(polProcess => mainWindowModel.CurrentProcesses.Contains(polProcess) == false))
                    {
                        mainWindowModel.AddToCurrentProcesses(polProcess);
                    }
                }
                else
                {
                    if (mainWindowModel.CurrentProcesses.Count != 0)
                    {
                        mainWindowModel.CurrentProcesses.Clear();
                    }
                }
            }
            mainWindowView.ClearEliteMMOProcesses();
            mainWindowView.AddEliteMMOProcesses(mainWindowModel.CurrentProcesses.Select(process => process.MainWindowTitle).ToArray<string>());
            mainWindowView.SelectedItemEliteMMOProcesses = mainWindowModel.SelectedProcess.MainWindowTitle;
        }

        public void ReinitializeApi()
        {
            mainWindowModel.ReInitializeApi();
        }

        public void LoadAboutView()
        {
            mainWindowView.ShowPictureBox = true;
            mainWindowView.ShowScriptedHeader = true;
            mainWindowView.ShowScriptedSubHeader = true;
            mainWindowView.ShowSelectProcessLabel = true;
            mainWindowView.ShowDonateButton = true;
            mainWindowView.ShowEliteMMOProcesses = true;
            mainWindowView.ShowScriptFarmView = false;
            mainWindowView.ShowScriptHealingSupportView = false;
            mainWindowView.ShowScriptNaviMapView = false;
            mainWindowView.ShowScriptOnEventToolView = false;
            mainWindowView.SetSize(372, 237);
            mainWindowView.EnableRefreshCharacters = true;
        }

        public void LoadScriptFarmView()
        {
            mainWindowView.ShowPictureBox = false;
            mainWindowView.ShowScriptedHeader = false;
            mainWindowView.ShowScriptedSubHeader = false;
            mainWindowView.ShowSelectProcessLabel = false;
            mainWindowView.ShowDonateButton = false;
            mainWindowView.ShowEliteMMOProcesses = false;
            mainWindowView.ShowScriptFarmView = true;
            mainWindowView.ShowScriptHealingSupportView = false;
            mainWindowView.ShowScriptNaviMapView = false;
            mainWindowView.ShowScriptOnEventToolView = false;
            mainWindowView.SetSize(734, 468);
            mainWindowView.EnableRefreshCharacters = false;
            mainWindowView.DockStyleScriptFarmView = "Fill";
            mainWindowView.addControl("scriptFarmView");
        }

        public void LoadScriptHealingSupportView()
        {
            mainWindowView.ShowPictureBox = false;
            mainWindowView.ShowScriptedHeader = false;
            mainWindowView.ShowScriptedSubHeader = false;
            mainWindowView.ShowSelectProcessLabel = false;
            mainWindowView.ShowDonateButton = false;
            mainWindowView.ShowEliteMMOProcesses = false;
            mainWindowView.ShowScriptFarmView = false;
            mainWindowView.ShowScriptHealingSupportView = true;
            mainWindowView.ShowScriptNaviMapView = false;
            mainWindowView.ShowScriptOnEventToolView = false;
            mainWindowView.SetSize(650, 442);
            mainWindowView.EnableRefreshCharacters = false;
            mainWindowView.addControl("scriptHealingSupportView");
        }

        public void LoadScriptOnEventToolView()
        {
            mainWindowView.ShowPictureBox = false;
            mainWindowView.ShowScriptedHeader = false;
            mainWindowView.ShowScriptedSubHeader = false;
            mainWindowView.ShowSelectProcessLabel = false;
            mainWindowView.ShowDonateButton = false;
            mainWindowView.ShowEliteMMOProcesses = false;
            mainWindowView.ShowScriptFarmView = false;
            mainWindowView.ShowScriptHealingSupportView = false;
            mainWindowView.ShowScriptNaviMapView = false;
            mainWindowView.ShowScriptOnEventToolView = true;
            mainWindowView.SetSize(482, 488);
            mainWindowView.EnableRefreshCharacters = false;
            mainWindowView.addControl("scriptOnEventToolView");
        }
    }
}
