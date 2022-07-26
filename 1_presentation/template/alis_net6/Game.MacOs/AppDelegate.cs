using AppKit;
using Foundation;

namespace DrawCube
{
    /// <summary>
    /// The app delegate class
    /// </summary>
    /// <seealso cref="NSApplicationDelegate"/>
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDelegate"/> class
        /// </summary>
        public AppDelegate()
        {
        }

        /// <summary>
        /// Describes whether this instance application should terminate after last window closed
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <returns>The bool</returns>
        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender)
        {
            return true;
        }

        /// <summary>
        /// Dids the finish launching using the specified notification
        /// </summary>
        /// <param name="notification">The notification</param>
        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        /// <summary>
        /// Wills the terminate using the specified notification
        /// </summary>
        /// <param name="notification">The notification</param>
        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
