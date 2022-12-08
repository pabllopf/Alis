// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GLNativeES30Activity.cs
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

using Android.App;
using Android.Content.PM;
using Android.Opengl;
using Android.OS;
using Android.Views;

namespace Alis.Template.Game.Droid
{
    /// <summary>
    /// The game activity class
    /// </summary>
    /// <seealso cref="Activity"/>
    [Activity(ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden, MainLauncher = true)]
    public class GameActivity : Activity
    {
        /// <summary>
        /// The game surface view
        /// </summary>
        private GameSurfaceView gameSurfaceView;

        /// <summary>
        ///     Ons the create using the specified bundle
        /// </summary>
        /// <param name="bundle">The bundle</param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            

            Window.AddFlags(WindowManagerFlags.Fullscreen); // hide the status bar
            
            //set up notitle 
            RequestWindowFeature(WindowFeatures.NoTitle);
            
            //set up full screen
            if (Window != null)
            {
                Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            }

            // Create a GLSurfaceView instance and set it
            // as the ContentView for this Activity
            gameSurfaceView = new GameSurfaceView(this);
            
            gameSurfaceView.LayoutParameters = (new ViewGroup.LayoutParams(
                ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.MatchParent));
            
            SetContentView(gameSurfaceView);
        }

        /// <summary>
        ///     Ons the pause
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            gameSurfaceView.OnPause();
        }

        /// <summary>
        ///     Ons the resume
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            gameSurfaceView.OnResume();
        }
    }
}