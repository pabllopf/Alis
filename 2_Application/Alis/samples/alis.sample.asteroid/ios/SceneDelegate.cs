using Foundation;
using UIKit;

namespace Alis.Sample.Asteroid.IOS;

[Register("SceneDelegate")]
public class SceneDelegate : UIResponder, IUIWindowSceneDelegate
{
    [Export("window")] public UIWindow? Window { get; set; }

    [Export("scene:willConnectToSession:options:")]
    public void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
    {
        System.Diagnostics.Debug.WriteLine($"[SceneDelegate] WillConnect - UIScene: {scene}, UIWindowScene: {scene is UIWindowScene}");
        if (scene is UIWindowScene windowScene)
        {
            Window ??= new UIWindow(windowScene);
            System.Diagnostics.Debug.WriteLine($"[SceneDelegate] Creando vista principal con bounds: {Window!.Bounds}");
            var blueGlkvc = new BlueGlkViewController(Window!.Bounds);
            Window.RootViewController = blueGlkvc;
            Window.MakeKeyAndVisible();
            Window.RootViewController?.View.SetNeedsLayout();
            Window.RootViewController?.View.LayoutIfNeeded();
            System.Diagnostics.Debug.WriteLine("[SceneDelegate] Layout forzado tras asignar vista principal");
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("[SceneDelegate] ERROR: scene no es UIWindowScene");
        }
    }

    [Export("sceneDidDisconnect:")]
    public void DidDisconnect(UIScene scene)
    {
        // Called as the scene is being released by the system.
        // This occurs shortly after the scene enters the background, or when its session is discarded.
        // Release any resources associated with this scene that can be re-created the next time the scene connects.
        // The scene may re-connect later, as its session was not neccessarily discarded (see UIApplicationDelegate `DidDiscardSceneSessions` instead).
    }

    [Export("sceneDidBecomeActive:")]
    public void DidBecomeActive(UIScene scene)
    {
        // Called when the scene has moved from an inactive state to an active state.
        // Use this method to restart any tasks that were paused (or not yet started) when the scene was inactive.
    }

    [Export("sceneWillResignActive:")]
    public void WillResignActive(UIScene scene)
    {
        // Called when the scene will move from an active state to an inactive state.
        // This may occur due to temporary interruptions (ex. an incoming phone call).
    }

    [Export("sceneWillEnterForeground:")]
    public void WillEnterForeground(UIScene scene)
    {
        // Called as the scene transitions from the background to the foreground.
        // Use this method to undo the changes made on entering the background.
    }

    [Export("sceneDidEnterBackground:")]
    public void DidEnterBackground(UIScene scene)
    {
        // Called as the scene transitions from the foreground to the background.
        // Use this method to save data, release shared resources, and store enough scene-specific state information
        // to restore the scene back to its current state.
    }
}