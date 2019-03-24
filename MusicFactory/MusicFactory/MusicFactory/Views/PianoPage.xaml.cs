using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicFactory.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PianoPage : ContentPage
	{
        int freq = 220;
		public PianoPage ()
		{
			InitializeComponent ();
            Beep.Clicked += delegate { beep(); };
		}

        private void beep()
        {
            System.Console.Beep(freq++, 50);
        }
	}
}