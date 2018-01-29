using System.ComponentModel;
using System.Configuration.Install;

namespace CStoreService
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
