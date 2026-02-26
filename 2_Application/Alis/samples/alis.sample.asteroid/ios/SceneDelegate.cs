// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneDelegate.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Diagnostics;
using Foundation;
using UIKit;

namespace Alis.Sample.Asteroid.IOS
{
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
            Debug.WriteLine($"[SceneDelegate] WillConnect - UIScene: {scene}, UIWindowScene: {scene is UIWindowScene}");
            if (scene is UIWindowScene windowScene)
            {
                Window ??= new UIWindow(windowScene);
                Debug.WriteLine($"[SceneDelegate] Creando vista principal con bounds: {Window!.Bounds}");
                BlueGlkViewController blueGlkvc = new BlueGlkViewController(Window!.Bounds);
                Window.RootViewController = blueGlkvc;
                Window.MakeKeyAndVisible();
                Window.RootViewController?.View.SetNeedsLayout();
                Window.RootViewController?.View.LayoutIfNeeded();
                Debug.WriteLine("[SceneDelegate] Layout forzado tras asignar vista principal");
            }
            else
            {
                Debug.WriteLine("[SceneDelegate] ERROR: scene no es UIWindowScene");
            }
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
}