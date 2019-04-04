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

        public PianoPage()
        {
            InitializeComponent();

            SizeChanged += delegate { DrawKeyboard(); };
        }

        private void DrawKeyboard()
        {
            MainKeyboard.HeightRequest = Height * 0.8;
            var PageSize = new Size() { Height = this.Height, Width = this.Width };

            var relativeLen = Width / 42;

            // math rule for black keys in section
            var BlackRule = new Dictionary<int, Size>
            {
                {0, new Size{Width = 6 } },
                {1, new Size{Width = 0 } },
                {2, new Size{Width = 6 } },
                {3, new Size{Width = 0 } },
                {4, new Size{Width = 0 } }
            };

            // relative size for white key. Same as values from BlackRule
            //var WhiteRelativeSize = new System.Drawing.Size { Width = 6 };

            BlackKeyboard.Spacing = relativeLen * 2;
            BlackKeyboard.Padding = new Thickness(relativeLen * -2, 0, 0, 0);

            // 12 keys in one section
            var section = 12;

            foreach (WhiteKey wk in WhiteKeyboard.Children)
            {
                wk.WidthRequest = relativeLen * 6;
            }

            for (var i = 0; i < BlackKeyboard.Children.Count; i++)
            {
                BlackKeyboard.Children[i].WidthRequest = relativeLen * 4;
                BlackKeyboard.Children[i].Margin = new Thickness(BlackRule[i % section].Width * relativeLen, 0, 0, PageSize.Height * 0.4);
            }
        }

        /*
        for (var i = 1; i < 13; i++)
        {
            if (BlackRule.Keys.Contains(i))
            {
                var bk = new BlackKey() { RelativeIndex = i, WidthRequest = relativeLen * 4 };
                bk.Margin = new Thickness(BlackRule[i % section].Width * relativeLen, 0, 0, PageSize.Height * 0.4);
                BlackKeys.Add(bk);
            }
            else
                WhiteKeys.Add(new WhiteKey() { RelativeIndex = i, WidthRequest = relativeLen * 6, VerticalOptions = LayoutOptions.FillAndExpand });
        }


        foreach (var wk in WhiteKeys)
            WhiteKeyboard.Children.Add(wk);

        foreach (var bk in BlackKeys)
            BlackKeyboard.Children.Add(bk);
            */
    }



}

