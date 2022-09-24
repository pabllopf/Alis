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

using AppKit;
using Foundation;

namespace Alis.Template.Game.MacOs
{
    /// <summary>
    ///     The app delegate class
    /// </summary>
    /// <seealso cref="NSApplicationDelegate" />
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AppDelegate" /> class
        /// </summary>
        public AppDelegate()
        {
        }

        /// <summary>
        ///     Describes whether this instance application should terminate after last window closed
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <returns>The bool</returns>
        public override bool ApplicationShouldTerminateAfterLastWindowClosed(NSApplication sender) => true;

        /// <summary>
        ///     Dids the finish launching using the specified notification
        /// </summary>
        /// <param name="notification">The notification</param>
        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        /// <summary>
        ///     Wills the terminate using the specified notification
        /// </summary>
        /// <param name="notification">The notification</param>
        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}