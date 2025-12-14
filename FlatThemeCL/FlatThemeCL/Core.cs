using CLCore;
using System.IO;
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
            string settingsPath = "FlatThemeCL.settings.json";
            if (!File.Exists(settingsPath))
            {
                File.WriteAllText(settingsPath, Newtonsoft.Json.JsonConvert.SerializeObject(ThemeManager.Controls));
            } else
            {
                string json = File.ReadAllText(settingsPath);
                ThemeManager.Controls = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<ThemeControl>>(json);
            }
            RefreshFormControls();
        }
        private void RefreshFormControls()
        {
            foreach (ThemeControl control in ThemeManager.Controls)
            {
                Control formControl = CLTheme.MainControls.Find(control.Name, false).FirstOrDefault();
                if (formControl != null)
                {
                    formControl.Text = control.Text;
                    if (control.Width > 0)
                    {
                        formControl.Width = control.Width;
                    }
                    if (control.Height > 0)
                    {
                        formControl.Height = control.Width;
                    }
                }
            }
        }
        private void DebugFormControls()
        {
            foreach (Control formControl in CLTheme.MainControls)
            {
                formControl.Text = formControl.Name;
                if (formControl.Controls.Count > 0)
                {
                    foreach (Control subControl in formControl.Controls)
                    {
                        subControl.Text = subControl.Name;
                    }
                }
            }
        }

        public void Configure()
        {
            if (MessageBox.Show($"Do you want enable debug Controls in Main Form? Showing name in Controls.", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                DebugFormControls();
            }
        }

    }
}
