using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flow.Launcher.Plugin.FandomSearch
{
    public partial class SettingsControl : UserControl
    {
        private Settings _settings;

        public SettingsControl(Settings settings)
        {
            InitializeComponent();
            _settings = settings;

        }
    }
}
