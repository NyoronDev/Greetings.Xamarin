using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Greetings.iOS.PlatformInfo))]
namespace Greetings.iOS
{
    public class PlatformInfo : IPlatformInfo
    {
        private UIDevice _device = new UIDevice();

        public string GetModel()
        {
            return this._device.Model.ToString();
        }

        public string GetVersion()
        {
            return $"{this._device.SystemName}, {this._device.SystemVersion}";
        }
    }
}