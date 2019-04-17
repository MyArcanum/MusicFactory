﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MusicFactory.Droid
{
    public class Metronom : Fragment
    {
        private static Metronom current;

        public static Metronom Current
        {
            get
            {
                if (current == null)
                    current = new Metronom();
                return current;
            }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.Metronom, container, false);

            var confirm = view.FindViewById<Button>(Resource.Id.confirmBtn);
            var pick = view.FindViewById<NumberPicker>(Resource.Id.freqPicker);
            confirm.Click += (s, e) => MainActivity.Current.MetronomFrequency = pick.Value;

            return view;
        }
    }
}