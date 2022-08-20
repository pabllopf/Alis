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

namespace Alis.Template.Game.Android
{
    // the ConfigurationChanges flags set here keep the EGL context
    // from being destroyed whenever the device is rotated or the
    // keyboard is shown (highly recommended for all GL apps)
    /// <summary>
    ///     The gl native es 30 activity class
    /// </summary>
    /// <seealso cref="Activity" />
    [Activity(ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden, MainLauncher = true)]
    public class GLNativeES30Activity : Activity
    {
        /// <summary>
        ///     The gl view
        /// </summary>
        private GLSurfaceView mGLView;

        /// <summary>
        ///     Ons the create using the specified bundle
        /// </summary>
        /// <param name="bundle">The bundle</param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //set up notitle 
            RequestWindowFeature(WindowFeatures.NoTitle);
            //set up full screen
            Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

            // Create a GLSurfaceView instance and set it
            // as the ContentView for this Activity
            mGLView = new MyGLSurfaceView(this);
            SetContentView(mGLView);
        }

        /// <summary>
        ///     Ons the pause
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();

            // The following call pauses the rendering thread.
            // If your OpenGL application is memory intensive,
            // you should consider de-allocating objects that
            // consume significant memory here.
            mGLView.OnPause();
        }

        /// <summary>
        ///     Ons the resume
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();

            // The following call resumes a paused rendering thread.
            // If you de-allocated graphic objects for onPause()
            // this is a good place to re-allocate them.
            mGLView.OnResume();
        }
    }
}