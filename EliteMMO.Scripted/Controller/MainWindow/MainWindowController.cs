using EliteMMO.Scripted.Models;
using EliteMMO.Scripted.Views;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;

namespace EliteMMO.Scripted.Controller.MainWindow
{
    public class MainWindowController : AbstractScriptedController, IMainWindowController
    {
        public MainWindowController()
        {
        }

        public MainWindowController(IMainWindowModel model, IMainWindowView view) : base(model, view)
        {
        }

        public void Donate(string donateURL)
        {
            Process.Start(donateURL);
        }

        public void Exit()
        {
            Application.Exit();
        }

        public void LoadAboutView()
        {
            if (model is IMainWindowModel)
            {
                ((IMainWindowModel)model).MainView = MainWindowModel.Function.LOAD_ABOUT_VIEW;
                if (view != null)
                {
                    SetView(MainWindowModel.Function.LOAD_ABOUT_VIEW);
                }
            }
        }

        public void LoadFarmView()
        {
            if(!model.ProcessFound)
            {
                return;
            }
            if (model is IMainWindowModel)
            {
                ((IMainWindowModel)model).MainView = MainWindowModel.Function.LOAD_FARM_VIEW;
                if (view != null)
                {
                    SetView(MainWindowModel.Function.LOAD_FARM_VIEW);
                }
            }
        }

        public void LoadHealingSupportView()
        {
            if (!model.ProcessFound)
            {
                return;
            }
            if (model is IMainWindowModel)
            {
                ((IMainWindowModel)model).MainView = MainWindowModel.Function.LOAD_HEALING_SUPPORT_VIEW;
                if (view != null)
                {
                    SetView(MainWindowModel.Function.LOAD_HEALING_SUPPORT_VIEW);
                }
            }
        }

        public void LoadOnEventToolView()
        {
            if (!model.ProcessFound)
            {
                return;
            }
            if (model is IMainWindowModel)
            {
                ((IMainWindowModel)model).MainView = MainWindowModel.Function.LOAD_ON_EVENT_TOOL_VIEW;
                if (view != null)
                {
                    SetView(MainWindowModel.Function.LOAD_ON_EVENT_TOOL_VIEW);
                }
            }
        }

        public void RefreshCharacters()
        {
            if (model is IMainWindowModel)
            {
                ((IMainWindowModel)model).MainView = MainWindowModel.Function.REFRESH_CHARACTERS;
                if (view != null)
                {
                    SetView(MainWindowModel.Function.REFRESH_CHARACTERS);
                }
            }
        }

        public void ReinitializeApi()
        {
            ((IMainWindowModel)model).ReInitializeApi();
            if (model is IMainWindowModel)
            {
                if (view != null)
                {
                    SetView(MainWindowModel.Function.RE_INITILIAZE_API);
                }
            }
        }

        public void SetView(MainWindowModel.Function function)
        {
            if (view is IMainWindowView && model is IMainWindowModel)
            {
                IMainWindowView mainWindowView = (IMainWindowView)view;
                IMainWindowModel mainWindowModel = (IMainWindowModel)model;
                if (function == MainWindowModel.Function.LOAD_ABOUT_VIEW)
                {
                    mainWindowView.ShowPictureBox();
                    mainWindowView.ShowHeader1();
                    mainWindowView.ShowHeader2();
                    mainWindowView.ShowLabel1();
                    mainWindowView.ShowButton1();
                    mainWindowView.ShowEliteMMO_PROC();
                    mainWindowView.HideOnEventToolView();
                    mainWindowView.HideFarmView();
                    mainWindowView.SetSize(372, 237);
                }
                else if (function == MainWindowModel.Function.LOAD_FARM_VIEW
                    || function == MainWindowModel.Function.LOAD_HEALING_SUPPORT_VIEW
                    || function == MainWindowModel.Function.LOAD_ON_EVENT_TOOL_VIEW)
                {
                    mainWindowView.HidePictureBox();
                    mainWindowView.HideHeader1();
                    mainWindowView.HideHeader2();
                    mainWindowView.HideLabel1();
                    mainWindowView.HideButton1();
                    mainWindowView.HideEliteMMO_PROC();
                    if (function == MainWindowModel.Function.LOAD_FARM_VIEW)
                    {
                        mainWindowView.ShowFarmView();
                        mainWindowView.HideHealingSupportView();
                        mainWindowView.HideOnEventToolView();
                        mainWindowView.SetSize(734, 468);
                    }
                    else if(function == MainWindowModel.Function.LOAD_HEALING_SUPPORT_VIEW)
                    {
                        mainWindowView.HideFarmView();
                        mainWindowView.ShowHealingSupportView();
                        mainWindowView.HideOnEventToolView();
                        mainWindowView.SetSize(650, 442);
                    }
                    else if (function == MainWindowModel.Function.LOAD_ON_EVENT_TOOL_VIEW)
                    {
                        mainWindowView.HideFarmView();
                        mainWindowView.HideHealingSupportView();
                        mainWindowView.ShowOnEventToolView();
                        mainWindowView.SetSize(482, 488);
                    }
                }
                else if (function == MainWindowModel.Function.REFRESH_CHARACTERS)
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
                }

                if (function == MainWindowModel.Function.LOAD_ABOUT_VIEW)
                {
                    mainWindowView.EnableRefreshCharacters();
                }
                else if (function == MainWindowModel.Function.LOAD_FARM_VIEW
                    || function == MainWindowModel.Function.LOAD_HEALING_SUPPORT_VIEW
                    || function == MainWindowModel.Function.LOAD_ON_EVENT_TOOL_VIEW)
                {
                    mainWindowView.DisableRefreshCharacters();
                }
                mainWindowModel.NotifyObservers();
            }
        }
    }
}
