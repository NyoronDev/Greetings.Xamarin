using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: Dependency(typeof(Greetings.Droid.PlatformInfo))]
namespace Greetings.Droid
{
    public class PlatformInfo : IPlatformInfo
    {
        public string GetModel()
        {
            return $"{Build.Manufacturer}, {Build.Model}";
        }

        public string GetVersion()
        {
            return Build.VERSION.Release.ToString();
        }
    }
}