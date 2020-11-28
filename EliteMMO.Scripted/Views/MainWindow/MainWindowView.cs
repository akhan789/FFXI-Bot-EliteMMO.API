namespace EliteMMO.Scripted.Views.MainWindow
{
    using System.Windows.Forms;
    using System.Linq;
    using EliteMMO.Scripted.Models.MainWindow;
    using EliteMMO.Scripted.Controller.MainWindow;
    using System.Drawing;
    using EliteMMO.Scripted.Models;
    using EliteMMO.Scripted.Views.ScriptFarm;
    using EliteMMO.Scripted.Views.ScriptNaviMap;

    public partial class MainWindowView : Form, IMainWindowView
    {
        private IMainWindowController mainWindowController = new MainWindowController();
        private IMainWindowModel mainWindowModel = new MainWindowModel();

        public MainWindowView()
        {
            InitializeComponent();
            WireUp(mainWindowController, mainWindowModel);
            Update();

            farmView = new ScriptFarmView();
            healingSupportView = new ScriptHealingView();
            naviMapView = new ScriptNaviMapView();
            onEventToolView = new ScriptOnEventToolView();
        }
        public void WireUp(IMainWindowController controller, IMainWindowModel model)
        {
            if (mainWindowModel != null)
            {
                mainWindowModel.RemoveObserver(this);
            }
            mainWindowModel = model;
            mainWindowController = controller;
            mainWindowController.SetModel(mainWindowModel);
            mainWindowController.SetView(this);
            mainWindowModel.AddObserver(this);
        }

        public void Update(IScriptedModel model)
        {
            if (model is IMainWindowModel)
            {
                mainWindowModel = (IMainWindowModel)model;
                if (mainWindowModel.ProcessFound)
                {
                    StatusLabel.Text = @":: " + mainWindowModel.GetLocalPlayerName() + @" ::";
                }
                else
                {
                    StatusLabel.Text = @":: Final Fantasy Not Found ::";
                }

                switch (mainWindowModel.MainView)
                {
                    case MainWindowModel.Function.REFRESH_CHARACTERS:
                        eliteMMOProcesses.Items.Clear();
                        eliteMMOProcesses.Items.AddRange(mainWindowModel.CurrentProcesses.Select(process => process.MainWindowTitle).ToArray<string>());
                        eliteMMOProcesses.SelectedItem = mainWindowModel.SelectedProcess.MainWindowTitle;
                        break;
                    case MainWindowModel.Function.LOAD_FARM_VIEW:
                        farmView.Dock = DockStyle.Fill;
                        Controls.Add(farmView);
                        break;
                    case MainWindowModel.Function.LOAD_HEALING_SUPPORT_VIEW:
                        healingSupportView.Dock = DockStyle.Fill;
                        Controls.Add(healingSupportView);
                        break;
                    case MainWindowModel.Function.LOAD_ON_EVENT_TOOL_VIEW:
                        onEventToolView.Dock = DockStyle.Fill;
                        Controls.Add(onEventToolView);
                        break;
                    default:
                        break;
                }
            }
        }
        private void RefreshCharactersToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowController.RefreshCharacters();
        }
        private void EliteMmoProcSelectedIndexChanged(object sender, System.EventArgs e)
        {
            mainWindowController.ReinitializeApi();
        }
        private void FarmToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowController.LoadFarmView();
        }
        private void HealingSupportToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowController.LoadHealingSupportView();
        }
        private void AboutToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowController.LoadAboutView();
        }
        private void PaypalClick(object sender, System.EventArgs e)
        {
            mainWindowController.Donate("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=7U7Q2GRT6KUJN");
        }
        private void CloseExitToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowController.Exit();
        }
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainWindowController.Exit();
        }
        private void OnEventToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowController.LoadOnEventToolView();
        }

        public void HidePictureBox()
        {
            pictureBox.Hide();
        }

        public void ShowPictureBox()
        {
            pictureBox.Show();
        }

        public void HideHeader1()
        {
            scriptedHeader.Hide();
        }

        public void ShowHeader1()
        {
            scriptedHeader.Show();
        }

        public void HideHeader2()
        {
            scriptedSubHeader.Hide();
        }

        public void ShowHeader2()
        {
            scriptedSubHeader.Show();
        }

        public void HideSelectProcessLabel()
        {
            selectProcessLabel.Hide();
        }

        public void ShowSelectProcessLabel()
        {
            selectProcessLabel.Show();
        }

        public void HideButton1()
        {
            donateButton.Hide();
        }

        public void ShowButton1()
        {
            donateButton.Show();
        }

        public void HideEliteMMO_PROC()
        {
            eliteMMOProcesses.Hide();
        }

        public void ShowEliteMMO_PROC()
        {
            eliteMMOProcesses.Show();
        }

        public void HideFarmView()
        {
            farmView.Hide();
        }

        public void ShowFarmView()
        {
            farmView.Show();
        }

        public void HideHealingSupportView()
        {
            healingSupportView.Hide();
        }

        public void ShowHealingSupportView()
        {
            healingSupportView.Show();
        }

        public void HideNaviMapView()
        {
            naviMapView.Hide();
        }

        public void ShowNaviMapView()
        {
            naviMapView.Show();
        }

        public void HideOnEventToolView()
        {
            onEventToolView.Hide();
        }

        public void ShowOnEventToolView()
        {
            onEventToolView.Show();
        }

        public void SetSize(int width, int height)
        {
            Size = new Size(width, height);
        }

        public void EnableRefreshCharacters()
        {
            refreshCharactersToolStripMenuItem.Enabled = true;
        }

        public void DisableRefreshCharacters()
        {
            refreshCharactersToolStripMenuItem.Enabled = false;
        }
    }
}
