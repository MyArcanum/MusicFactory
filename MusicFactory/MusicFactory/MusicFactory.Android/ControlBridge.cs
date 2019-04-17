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
using MusicFactory.Models;

[assembly: Xamarin.Forms.Dependency(typeof(MusicFactory.Droid.ControlBridge))]
namespace MusicFactory.Droid
{
    public class ControlBridge : IControlBridge
    {
        public void OpenRecorder()
        {
            //var i = new Intent(Intent.)
        }

        public void ToggleMetronom(out int freq)
        {
            //var a = new MetronomLouncher();
            //var i = new Intent(MainActivity.Current.BaseContext, typeof(MetronomLouncher));
            MainActivity.Current.StartActivity(typeof(MetronomLouncher));
            
            freq = MainActivity.Current.MetronomFrequency;
        }
    }
}