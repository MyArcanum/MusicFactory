using MusicFactory.Models;
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
        public List<ButtonDown> WhiteKeys { get; set; }

        public List<ButtonDown> BlackKeys { get; set; }

        public Size PageSize { get; }

        IFrequencyPlayer FP;

        public PianoPage()
        {
            InitializeComponent();
            
            var sf = new SectionFrequency(4);
            
            FP = DependencyService.Get<IFrequencyPlayer>();
            FP.Init(sf.Frequencies);

            SizeChanged += (s, a) => DrawKeyboard();
        }

        private void DrawKeyboard()
        {
            InitializeComponent();
            MainKeyboard.HeightRequest = Height * 0.8;
            BlackKeyboard.HeightRequest = MainKeyboard.Height * 0.6;

            var PageSize = new Size() { Height = this.Height, Width = this.Width };

            var relativeLen = Width / 42;

            // math rule for black keys in section. Value is left margin
            var BlackRule = new Dictionary<int, int>
            {
                {0, 6 },
                {1, 0 },
                {2, 6 },
                {3, 0 },
                {4, 0 }
            };

            // relative size for white key. Same as values from BlackRule
            //var WhiteRelativeSize = new System.Drawing.Size { Width = 6 };

            BlackKeyboard.Spacing = relativeLen * 2;
            BlackKeyboard.Margin = new Thickness(relativeLen * -2, 0, 0, 0);

            // 12 keys in one section
            var section = 12;

            int i = 0;

            foreach(BlackKey bk in BlackKeyboard.Children)
            {
                var note = (Keys)i;
                bk.Pressed += (s, a) => /*Task.Run(() => {*/ FP.Play(note);
                bk.WidthRequest = relativeLen * 4;
                bk.Margin = new Thickness(BlackRule[i % section] * relativeLen, 0, 0,0);
                i++;
            }

            foreach (WhiteKey wk in WhiteKeyboard.Children)
            {
                var note = (Keys)i;
                wk.Pressed += (s, a) => /*Task.Run(() => { */FP.Play(note);
                wk.WidthRequest = relativeLen * 6;
                i++;
            }
        }
        
    }



}

