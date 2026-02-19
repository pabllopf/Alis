// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AppDelegate.cs
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

using Foundation;
using UIKit;

namespace Alis.Sample.Asteroid.IOS
{
    /// <summary>
    /// The app delegate class
    /// </summary>
    /// <seealso cref="UIApplicationDelegate"/>
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        /// <summary>
        /// Finisheds the launching using the specified application
        /// </summary>
        /// <param name="application">The application</param>
        /// <param name="launchOptions">The launch options</param>
        /// <returns>The bool</returns>
        public override bool FinishedLaunching(UIApplication application, NSDictionary? launchOptions) =>
            // Override point for customization after application launch.
            true;

        /// <summary>
        /// Gets the configuration using the specified application
        /// </summary>
        /// <param name="application">The application</param>
        /// <param name="connectingSceneSession">The connecting scene session</param>
        /// <param name="options">The options</param>
        /// <returns>The ui scene configuration</returns>
        public override UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options) =>
            // Called when a new scene session is being created.
            // Use this method to select a configuration to create the new scene with.
            // "Default Configuration" is defined in the Info.plist's 'UISceneConfigurationName' key.
            new UISceneConfiguration("Default Configuration", connectingSceneSession.Role);

        /// <summary>
        /// Dids the discard scene sessions using the specified application
        /// </summary>
        /// <param name="application">The application</param>
        /// <param name="sceneSessions">The scene sessions</param>
        public override void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
            // Called when the user discards a scene session.
            // If any sessions were discarded while the application was not running, this will be called shortly after 'FinishedLaunching'.
            // Use this method to release any resources that were specific to the discarded scenes, as they will not return.
        }
    }
}