namespace EliteMMO.Scripted.Views.MainWindow
{
    using System.Windows.Forms;
    using System.Linq;
    using EliteMMO.Scripted.Models.MainWindow;
    using EliteMMO.Scripted.Presenters.MainWindow;
    using System.Drawing;
    using EliteMMO.Scripted.Models;
    using EliteMMO.Scripted.Views.ScriptFarm;
    using EliteMMO.Scripted.Views.ScriptHealing;
    using EliteMMO.Scripted.Views.ScriptNaviMap;
    using EliteMMO.Scripted.Views.ScriptOnEventTool;

    public partial class MainWindowView : Form, IMainWindowView
    {
        private IMainWindowPresenter mainWindowPresenter;
        private IMainWindowModel mainWindowModel;

        public MainWindowView()
        {
            InitializeComponent();
            mainWindowModel = new MainWindowModel();
            mainWindowModel.AddObserver(this);
            mainWindowPresenter = new MainWindowPresenter(mainWindowModel, this);

            scriptFarmView = new ScriptFarmView();
            scriptHealingSupportView = new ScriptHealingView();
            scriptNaviMapView = new ScriptNaviMapView();
            scriptOnEventToolView = new ScriptOnEventToolView();
        }

        private void RefreshCharactersToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowPresenter.RefreshCharacters();
        }
        private void EliteMmoProcSelectedIndexChanged(object sender, System.EventArgs e)
        {
            mainWindowPresenter.ReinitializeApi();
        }
        private void FarmToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowPresenter.LoadScriptFarmView();
        }
        private void HealingSupportToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowPresenter.LoadScriptHealingSupportView();
        }
        private void AboutToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowPresenter.LoadAboutView();
        }
        private void PaypalClick(object sender, System.EventArgs e)
        {
            mainWindowPresenter.Donate("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=7U7Q2GRT6KUJN");
        }
        private void CloseExitToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowPresenter.Exit();
        }
        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainWindowPresenter.Exit();
        }
        private void OnEventToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            mainWindowPresenter.LoadScriptOnEventToolView();
        }
        public void addControl(string control)
        {
            switch(control)
            {
                case "scriptFarmView":
                    Controls.Add(scriptFarmView);
                    break;
                case "scriptHealingSupportView":
                    Controls.Add(scriptHealingSupportView);
                    break;
                case "scriptNaviMapView":
                    Controls.Add(scriptNaviMapView);
                    break;
                case "scriptOnEventToolView":
                    Controls.Add(scriptOnEventToolView);
                    break;
                default:
                    break;
            }
        }
        public void SetSize(int width, int height)
        {
            Size = new Size(width, height);
        }

        public string StatusLabelText
        {
            get => statusLabel.Text;
            set => statusLabel.Text = value;
        }
        public bool ShowPictureBox
        {
            get => pictureBox.Visible;
            set => pictureBox.Visible = value;
        }
        public bool ShowScriptedHeader
        {
            get => scriptedHeader.Visible;
            set => scriptedHeader.Visible = value;
        }
        public bool ShowScriptedSubHeader
        {
            get => scriptedSubHeader.Visible;
            set => scriptedSubHeader.Visible = value;
        }
        public bool ShowSelectProcessLabel
        {
            get => selectProcessLabel.Visible;
            set => selectProcessLabel.Visible = value;
        }
        public bool ShowDonateButton
        {
            get => donateButton.Visible;
            set => donateButton.Visible = value;
        }
        public bool ShowEliteMMOProcesses
        {
            get => eliteMMOProcesses.Visible;
            set => eliteMMOProcesses.Visible = value;
        }
       
        public void ClearEliteMMOProcesses()
        {
            eliteMMOProcesses.Items.Clear();
        }

        public void AddEliteMMOProcesses(string[] mainWindowTitles)
        {
            eliteMMOProcesses.Items.AddRange(mainWindowTitles);
        }

        public string SelectedItemEliteMMOProcesses {
            get => (string)eliteMMOProcesses.SelectedItem;
            set => eliteMMOProcesses.SelectedItem = value;
        }
        public bool ShowScriptFarmView
        {
            get => scriptFarmView.Visible;
            set => scriptFarmView.Visible = value;
        }
        public string DockStyleScriptFarmView
        {
            get
            {
                if (scriptFarmView.Dock == DockStyle.Fill)
                {
                    return "Fill";
                }
                else
                {
                    return null;
                }
            }
            set
            {
                switch (value)
                {
                    case "Fill":
                        scriptFarmView.Dock = DockStyle.Fill;
                        break;
                    default:
                        break;
                }
            }
        }
        public bool ShowScriptHealingSupportView
        {
            get => scriptHealingSupportView.Visible;
            set => scriptHealingSupportView.Visible = value;
        }
        public string DockStyleScriptHealingSupportView
        {
            get
            {
                if (scriptHealingSupportView.Dock == DockStyle.Fill)
                {
                    return "Fill";
                }
                else
                {
                    return null;
                }
            }
            set
            {
                switch (value)
                {
                    case "Fill":
                        scriptHealingSupportView.Dock = DockStyle.Fill;
                        break;
                    default:
                        break;
                }
            }
        }
        public bool ShowScriptNaviMapView
        {
            get => scriptNaviMapView.Visible;
            set => scriptNaviMapView.Visible = value;
        }
        public string DockStyleScriptNaviMapView
        {
            get
            {
                if (scriptNaviMapView.Dock == DockStyle.Fill)
                {
                    return "Fill";
                }
                else
                {
                    return null;
                }
            }
            set
            {
                switch (value)
                {
                    case "Fill":
                        scriptNaviMapView.Dock = DockStyle.Fill;
                        break;
                    default:
                        break;
                }
            }
        }
        public bool ShowScriptOnEventToolView
        {
            get => scriptOnEventToolView.Visible;
            set => scriptOnEventToolView.Visible = value;
        }
        public string DockStyleScriptOnEventToolView
        {
            get
            {
                if (scriptOnEventToolView.Dock == DockStyle.Fill)
                {
                    return "Fill";
                }
                else
                {
                    return null;
                }
            }
            set
            {
                switch (value)
                {
                    case "Fill":
                        scriptOnEventToolView.Dock = DockStyle.Fill;
                        break;
                    default:
                        break;
                }
            }
        }
        public bool EnableRefreshCharacters
        {
            get => refreshCharactersToolStripMenuItem.Enabled;
            set => refreshCharactersToolStripMenuItem.Enabled = value;
        }
    }
}
