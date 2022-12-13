using System;
using System.Diagnostics;
using Alis.Template.Game.Lib;
using Microsoft.Maui.Controls;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace Alis.Template.Game
{
	public partial class MainPage : ContentPage
	{
		 private bool _pageActive;
        private readonly Stopwatch _stopWatch = new Stopwatch();
        private double _fpsAverage = 0.0;
        private const double _fpsWanted = 30.0;
        private int _fpsCount = 0;
        
        private uint _frameCount = 0;

        

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Init();
        }

        protected override void OnDisappearing()
        {
            _pageActive = false;

            base.OnDisappearing();
        }

        private void Init()
        {
            _pageActive = true;

            var ms = 1000.0/_fpsWanted;
            var ts = TimeSpan.FromMilliseconds(ms);

            // create a timer that triggers roughly every 1/30 seconds
            Device.StartTimer(ts, TimerLoop);
        }

        private bool TimerLoop()
        {
            // get the elapsed time from the stopwatch because the 1/30 timer interval is not accurate and can be off by 2 ms
            var dt = _stopWatch.Elapsed.TotalSeconds;

            _stopWatch.Restart();

            // calculate current fps
            var fps = dt > 0 ? 1.0 / dt : 0;

            // when the fps is too low reduce the load by skipping the frame
            if (fps < _fpsWanted / 2){
                return _pageActive;
            }

            // trigger the redrawing of the view
            canvasView.InvalidateSurface();

            return _pageActive;
        }

        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            CustomRender.Update(e.Surface, e.Surface.Canvas);
        }
	}
}
