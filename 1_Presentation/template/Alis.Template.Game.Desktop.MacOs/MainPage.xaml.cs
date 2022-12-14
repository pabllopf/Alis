using System;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using SkiaSharp.Views.Maui;

namespace Alis.Template.Game.Desktop.MacOs
{
	/// <summary>
	/// The main page class
	/// </summary>
	/// <seealso cref="ContentPage"/>
	public partial class MainPage : ContentPage
	{
		 /// <summary>
		 /// The page active
		 /// </summary>
		 private bool _pageActive;
        /// <summary>
        /// The stopwatch
        /// </summary>
        private readonly Stopwatch _stopWatch = new Stopwatch();
        /// <summary>
        /// The fps wanted
        /// </summary>
        private const double _fpsWanted = 30.0;




        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ons the appearing
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            Init();
        }

        /// <summary>
        /// Ons the disappearing
        /// </summary>
        protected override void OnDisappearing()
        {
            _pageActive = false;

            base.OnDisappearing();
        }

        /// <summary>
        /// Inits this instance
        /// </summary>
        private void Init()
        {
            _pageActive = true;

            var ms = 1000.0/_fpsWanted;
            var ts = TimeSpan.FromMilliseconds(ms);

            // create a timer that triggers roughly every 1/30 seconds
            Device.StartTimer(ts, TimerLoop);
        }

        /// <summary>
        /// Describes whether this instance timer loop
        /// </summary>
        /// <returns>The page active</returns>
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

        /// <summary>
        /// Ons the painting using the specified sender
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The </param>
        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            CustomRender.Update(e.Surface.Canvas);
        }
	}
}
