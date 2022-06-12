using Foundation;
using UIKit;

namespace Alis.Template.IOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    /// <summary>
    /// The app delegate class
    /// </summary>
    /// <seealso cref="UIApplicationDelegate"/>
    [Register ("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        /// <summary>
        /// Gets or sets the value of the window
        /// </summary>
        public override UIWindow Window {
            get;
            set;
        }

        /// <summary>
        /// Describes whether this instance finished launching
        /// </summary>
        /// <param name="application">The application</param>
        /// <param name="launchOptions">The launch options</param>
        /// <returns>The bool</returns>
        public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            return true;
        }

        /// <summary>
        /// Ons the resign activation using the specified application
        /// </summary>
        /// <param name="application">The application</param>
        public override void OnResignActivation (UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        /// <summary>
        /// Dids the enter background using the specified application
        /// </summary>
        /// <param name="application">The application</param>
        public override void DidEnterBackground (UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        /// <summary>
        /// Wills the enter foreground using the specified application
        /// </summary>
        /// <param name="application">The application</param>
        public override void WillEnterForeground (UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        /// <summary>
        /// Ons the activated using the specified application
        /// </summary>
        /// <param name="application">The application</param>
        public override void OnActivated (UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        /// <summary>
        /// Wills the terminate using the specified application
        /// </summary>
        /// <param name="application">The application</param>
        public override void WillTerminate (UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}


