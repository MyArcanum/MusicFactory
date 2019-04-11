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
using Android.Media;
using System.Threading.Tasks;

[assembly: Dependency(typeof(MusicFactory.Droid.PianoPlayer))]
namespace MusicFactory.Droid
{
    /// <summary>
    /// https://stackoverflow.com/questions/9106276/android-how-to-generate-a-frequency
    /// </summary>
    public class PianoPlayer : IFrequencyPlayer
    {
        private Dictionary<Keys, float> Frequencies;
        
        public Dictionary<Keys,ToneMaker> TM = new Dictionary<Keys, ToneMaker>();

        public void Init(Dictionary<Keys, float> frequencies)
        {
            Frequencies = frequencies;
            foreach (var k in frequencies.Keys)
            {
                TM.Add(k, new ToneMaker(frequencies[k]));
            }
        }

        public void Play(Keys key)
        {
            TM[key].Play();
            TM[key] = new ToneMaker(Frequencies[key]);
        }
    }
}