using System.ComponentModel;
using System.Configuration.Install;

namespace DicomDcmPicker
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
