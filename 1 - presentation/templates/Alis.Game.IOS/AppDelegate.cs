namespace Alis.Game.IOS;

/// <summary>

/// The app delegate class

/// </summary>

/// <seealso cref="UIApplicationDelegate"/>

[Register("AppDelegate")]
public class AppDelegate : UIApplicationDelegate
{
    /// <summary>
    /// Gets or sets the value of the window
    /// </summary>
    public override UIWindow? Window { get; set; }

    /// <summary>
    /// Describes whether this instance finished launching
    /// </summary>
    /// <param name="application">The application</param>
    /// <param name="launchOptions">The launch options</param>
    /// <returns>The bool</returns>
    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
    {
        // create a new window instance based on the screen size
        Window = new UIWindow(UIScreen.MainScreen.Bounds);

        // create a UIViewController with a single UILabel
        var vc = new UIViewController();
        vc.View!.AddSubview(new UILabel(Window!.Frame)
        {
            BackgroundColor = UIColor.White,
            TextAlignment = UITextAlignment.Center,
            Text = "Hello, iOS!"
        });
        Window.RootViewController = vc;

        // make the window visible
        Window.MakeKeyAndVisible();

        return true;
    }
}