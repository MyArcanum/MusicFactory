﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MusicFactory.Models;

namespace MusicFactory.Droid
{
    public class ToneMaker
    {
        public float freq;


        private float duration;
        private int sampleRate;
        private int numSamples;
        private double[] sample;

        private byte[] generatedSnd;

        private AudioTrack Track;
    
        public ToneMaker(float f)
        {
            freq = f;

            duration = 0.7f; //sec
            sampleRate = 8000;
            numSamples = (int)(duration * sampleRate);
            sample = new double[numSamples];
            generatedSnd = new byte[2 * numSamples];


            GenTone();
            WriteSound();
        }

        private void Clear()
        {
            duration = 0.7f; //sec
            sampleRate = 8000;
            numSamples = (int)(duration * sampleRate);
            sample = new double[numSamples];
            generatedSnd = new byte[2 * numSamples];

            sample = new double[numSamples];
            generatedSnd = new byte[2 * numSamples];
        }

        private void GenTone()
        {
            Clear();
            // fill out the array
            for (int i = 0; i < numSamples; ++i)
            {
                sample[i] = Math.Sin(2 * Math.PI * i / (sampleRate / freq));
            }

            // convert to 16 bit pcm sound array
            // assumes the sample buffer is normalised.
            int idx = 0;
            foreach (double dVal in sample)
            {
                // scale to maximum amplitude
                short val = (short)((dVal * 32767));
                // in 16 bit wav PCM, first byte is the low order byte
                generatedSnd[idx++] = (byte)(val & 0x00ff);
                generatedSnd[idx++] = (byte)((val & 0xff00) >> 8);
            }
        }

        private void WriteSound()
        {
            Track = new AudioTrack(Stream.Music, sampleRate, ChannelOut.Mono, Android.Media.Encoding.Pcm16bit, numSamples, AudioTrackMode.Static);
            Track.Write(generatedSnd, 0, generatedSnd.Length);
            //Track.SetNotificationMarkerPosition(generatedSnd.Length);
            //Track.SetPlaybackPositionUpdateListener(Track.li)
        }
        
        public void Play()
        {
            //Track.Flush();
            Track.Release();
            GenTone();
            WriteSound();
            Track.Play();
        }
    }
}