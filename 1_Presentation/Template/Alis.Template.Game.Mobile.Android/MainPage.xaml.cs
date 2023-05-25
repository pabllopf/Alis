// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MainPage.xaml.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics;
using Alis.Template.Game.SKIA;
using Microsoft.Maui.Controls;
using SkiaSharp.Views.Maui;

namespace Alis.Template.Game.Mobile.Android
{
    /// <summary>
    ///     The main page class
    /// </summary>
    /// <seealso cref="ContentPage" />
    public partial class MainPage : ContentPage
    {
        /// <summary>
        ///     The stopwatch
        /// </summary>
        private readonly Stopwatch _stopWatch = new Stopwatch();

        /// <summary>
        ///     The fps average
        /// </summary>
        private double _fpsAverage = 0.0;

        /// <summary>
        ///     The fps count
        /// </summary>
        private int _fpsCount = 0;

        /// <summary>
        ///     The frame count
        /// </summary>
        private uint _frameCount = 0;

        /// <summary>
        ///     The page active
        /// </summary>
        private bool _pageActive;


        /// <summary>
        ///     Initializes a new instance of the <see cref="MainPage" /> class
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     The fps wanted
        /// </summary>
        private const double _fpsWanted = 30.0;

        /// <summary>
        ///     Ons the appearing
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            Init();
        }

        /// <summary>
        ///     Ons the disappearing
        /// </summary>
        protected override void OnDisappearing()
        {
            _pageActive = false;

            base.OnDisappearing();
        }

        /// <summary>
        ///     Inits this instance
        /// </summary>
        private void Init()
        {
            _pageActive = true;

            double ms = 1000.0 / _fpsWanted;
            TimeSpan ts = TimeSpan.FromMilliseconds(ms);

            // create a timer that triggers roughly every 1/30 seconds
            Device.StartTimer(ts, TimerLoop);
        }

        /// <summary>
        ///     Describes whether this instance timer loop
        /// </summary>
        /// <returns>The page active</returns>
        private bool TimerLoop()
        {
            // get the elapsed time from the stopwatch because the 1/30 timer interval is not accurate and can be off by 2 ms
            double dt = _stopWatch.Elapsed.TotalSeconds;

            _stopWatch.Restart();

            // calculate current fps
            double fps = dt > 0 ? 1.0 / dt : 0;

            // when the fps is too low reduce the load by skipping the frame
            if (fps < _fpsWanted / 2)
            {
                return _pageActive;
            }

            // trigger the redrawing of the view
            canvasView.InvalidateSurface();

            return _pageActive;
        }

        /// <summary>
        ///     Ons the painting using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            CustomRender.Update(e.Surface.Canvas);
        }
    }
}