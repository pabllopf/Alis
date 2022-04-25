namespace Alis.Game.MacOs;

/// <summary>

/// The app delegate class

/// </summary>

/// <seealso cref="NSApplicationDelegate"/>

[Register("AppDelegate")]
public class AppDelegate : NSApplicationDelegate
{
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