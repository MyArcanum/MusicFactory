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

namespace MusicFactory.Droid
{
    [Activity(Label = "MetronomLouncher")]
    public class MetronomLouncher : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var frag = Metronom.Current;
            FragmentManager.BeginTransaction()
                            .Add(Android.Resource.Id.Content, frag)
                            .Commit();
        }
    }
}