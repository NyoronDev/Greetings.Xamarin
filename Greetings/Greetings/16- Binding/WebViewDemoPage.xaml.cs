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
    public partial class WebViewDemoPage : ContentPage
    {
        public WebViewDemoPage()
        {
            InitializeComponent();
        }

        private void OnEntryCompleted(object sender, EventArgs args)
        {
            this.webView.Source = ((Entry)sender).Text;
        }

        private void OnGoBackClicked(object sender, EventArgs args)
        {
            this.webView.GoBack();
        }

        private void OnGoForwardClicked(object sender, EventArgs args)
        {
            this.webView.GoForward();
        }
    }
}