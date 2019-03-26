using Android.Views;
using MusicFactory.Droid;
using MusicFactory.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Button), typeof(ButtonDownRenderer))]
namespace MusicFactory.Droid
{
    public class ButtonDownRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            var customButton = e.NewElement as ButtonDown;

            var thisButton = Control as Android.Widget.Button;
            thisButton.Touch += (object sender, TouchEventArgs args) =>
            {
                if (args.Event.Action == MotionEventActions.Down)
                {
                    customButton.OnPressed();
                }
                else if (args.Event.Action == MotionEventActions.Up)
                {
                    customButton.OnReleased();
                }
            };
        }
    }
}