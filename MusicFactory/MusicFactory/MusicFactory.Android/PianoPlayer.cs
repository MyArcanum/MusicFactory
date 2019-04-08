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
using MusicFactory.Models;

[assembly: Dependency(typeof(MusicFactory.Droid.PianoPlayer))]
namespace MusicFactory.Droid
{
    public class PianoPlayer : IFrequencyPlayer
    {
        public void Play(int frequency, int duration)
        {
            //var tg = new ToneGenerator
        }
    }
}