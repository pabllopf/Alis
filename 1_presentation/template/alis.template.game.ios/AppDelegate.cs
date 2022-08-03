using Foundation;
using UIKit;

namespace Alis.Template.Game.Ios
{
    /// <summary>
    ///     The app delegate class
    /// </summary>
    /// <seealso cref="UIApplicationDelegate" />
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        /// <summary>
        ///     Gets or sets the value of the window
        /// </summary>
        public override UIWindow Window { get; set; }

        // There is no need for a FinishedLaunching method here as the
        // Main.storyboard is automagically loaded since it is specified
        // in the Info.plist -> <key>UIMainStoryboardFile~ipad</key>
    }
}