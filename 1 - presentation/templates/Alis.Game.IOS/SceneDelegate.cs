namespace Alis.Game.IOS;

/// <summary>

/// The scene delegate class

/// </summary>

/// <seealso cref="UIResponder"/>

/// <seealso cref="IUIWindowSceneDelegate"/>

[Register("SceneDelegate")]
public class SceneDelegate : UIResponder, IUIWindowSceneDelegate
{
    /// <summary>
    /// Gets or sets the value of the window
    /// </summary>
    [Export("window")] public UIWindow? Window { get; set; }

    /// <summary>
    /// Wills the connect using the specified scene
    /// </summary>
    /// <param name="scene">The scene</param>
    /// <param name="session">The session</param>
    /// <param name="connectionOptions">The connection options</param>
    [Export("scene:willConnectToSession:options:")]
    public void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
    {
        // Use this method to optionally configure and attach the UIWindow `window` to the provided UIWindowScene `scene`.
        // If using a storyboard, the `window` property will automatically be initialized and attached to the scene.
        // This delegate does not imply the connecting scene or session are new (see UIApplicationDelegate `GetConfiguration` instead).
    }

    /// <summary>
    /// Dids the disconnect using the specified scene
    /// </summary>
    /// <param name="scene">The scene</param>
    [Export("sceneDidDisconnect:")]
    public void DidDisconnect(UIScene scene)
    {
        // Called as the scene is being released by the system.
        // This occurs shortly after the scene enters the background, or when its session is discarded.
        // Release any resources associated with this scene that can be re-created the next time the scene connects.
        // The scene may re-connect later, as its session was not neccessarily discarded (see UIApplicationDelegate `DidDiscardSceneSessions` instead).
    }

    /// <summary>
    /// Dids the become active using the specified scene
    /// </summary>
    /// <param name="scene">The scene</param>
    [Export("sceneDidBecomeActive:")]
    public void DidBecomeActive(UIScene scene)
    {
        // Called when the scene has moved from an inactive state to an active state.
        // Use this method to restart any tasks that were paused (or not yet started) when the scene was inactive.
    }

    /// <summary>
    /// Wills the resign active using the specified scene
    /// </summary>
    /// <param name="scene">The scene</param>
    [Export("sceneWillResignActive:")]
    public void WillResignActive(UIScene scene)
    {
        // Called when the scene will move from an active state to an inactive state.
        // This may occur due to temporary interruptions (ex. an incoming phone call).
    }

    /// <summary>
    /// Wills the enter foreground using the specified scene
    /// </summary>
    /// <param name="scene">The scene</param>
    [Export("sceneWillEnterForeground:")]
    public void WillEnterForeground(UIScene scene)
    {
        // Called as the scene transitions from the background to the foreground.
        // Use this method to undo the changes made on entering the background.
    }

    /// <summary>
    /// Dids the enter background using the specified scene
    /// </summary>
    /// <param name="scene">The scene</param>
    [Export("sceneDidEnterBackground:")]
    public void DidEnterBackground(UIScene scene)
    {
        // Called as the scene transitions from the foreground to the background.
        // Use this method to save data, release shared resources, and store enough scene-specific state information
        // to restore the scene back to its current state.
    }
}