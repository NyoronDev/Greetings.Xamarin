using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Greetings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlatInfoSapPage : ContentPage
    {
        public PlatInfoSapPage()
        {
            InitializeComponent();

            var platformInfo = DependencyService.Get<IPlatformInfo>();
            this.modelLabel.Text = platformInfo.GetModel();
            this.versionLabel.Text = platformInfo.GetVersion();
        }
    }
}