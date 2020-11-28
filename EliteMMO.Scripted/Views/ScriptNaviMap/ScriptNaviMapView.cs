namespace EliteMMO.Scripted.Views.ScriptNaviMap
{
    using System.Windows.Forms;
    public partial class ScriptNaviMapView : UserControl
    {
        public ScriptNaviMapView()
        {
            InitializeComponent();
        }

        private void BgwNaviDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (isRunning || !bgw_navi.CancellationPending)
            {
                
            }
        }
    }
}
