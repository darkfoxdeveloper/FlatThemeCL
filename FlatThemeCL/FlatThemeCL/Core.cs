using CLCore;
using System.Linq;
using System.Windows.Forms;

namespace FlatThemeCL.Plugins
{
    public class FlatThemeCL : IPlugin
    {
        public string Explanation
        {
            get
            {
                return "This plugin is a example for use a Custom Theme in Conquer Loader.";
            }
        }

        public string Name
        {
            get
            {
                return "FlatThemeCL";
            }
        }

        public PluginType PluginType { get; } = PluginType.FREE;

        public void Init()
        {
            Control btnStart = CLTheme.MainControls.Find("btnStart", false).FirstOrDefault();
            Control btnSettings = CLTheme.MainControls.Find("btnSettings", false).FirstOrDefault();
            btnStart.Text = "PLAY NOW";
            btnSettings.Text = "CONFIG";
        }

        public void Configure()
        {
            MessageBox.Show($"No need configuration for now.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
