using System.ComponentModel;
using System.Configuration.Install;

namespace CFindService
{
    [RunInstaller(true)]
    public partial class WinServiceInstaller : Installer
    {
        public WinServiceInstaller()
        {
            InitializeComponent();
        }
    }
}
