using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace App2.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    /// <summary>
    /// The app delegate class
    /// </summary>
    /// <seealso cref="global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate"/>
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        /// <summary>
        /// Describes whether this instance finished launching
        /// </summary>
        /// <param name="app">The app</param>
        /// <param name="options">The options</param>
        /// <returns>The bool</returns>
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}