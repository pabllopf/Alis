#if UNSUPPORTED
using System;
#else
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;
#endif



namespace Alis.Template.Game.Mobile.Android
{
    /// <summary>
    /// The maui program class
    /// </summary>
    public static class AppProgram
    {
#if UNSUPPORTED

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) => Console.WriteLine("UNSUPPORTED PLATFORM: Can't compile 'Windows apps' on MacOS or Linux OS.");

#else
        /// <summary>
        /// Creates the maui app
        /// </summary>
        /// <returns>The maui app</returns>
        public static MauiApp CreateMauiApp() =>
            MauiApp
                .CreateBuilder()
                .UseSkiaSharp(true)
                .UseMauiApp<App>()
                .Build();

#endif
    }
}