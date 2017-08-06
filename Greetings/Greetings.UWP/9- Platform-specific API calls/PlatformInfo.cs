using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Xamarin.Forms;

[assembly: Dependency(typeof(Greetings.UWP.PlatformInfo))]
namespace Greetings.UWP
{
    public class PlatformInfo : IPlatformInfo
    {
        private EasClientDeviceInformation _devInfo = new EasClientDeviceInformation();

        public string GetModel()
        {
            return $"{this._devInfo.SystemManufacturer}, {this._devInfo.SystemProductName}";
        }

        public string GetVersion()
        {
            return this._devInfo.OperatingSystem;
        }
    }
}
