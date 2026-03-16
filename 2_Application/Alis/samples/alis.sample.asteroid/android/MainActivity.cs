// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MainActivity.cs
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
using Android.OS;
using Android.Runtime;

namespace Alis.Sample.Asteroid.Android
{
    /// <summary>
    ///     The main activity class
    /// </summary>
    /// <seealso cref="Activity" />
    [Activity(Label = "Alis.Sample.Asteroid.Android", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar"), Register("crc647600d30597f44ece.MainActivity")]
    public class MainActivity : Activity
    {
        /// <summary>
        ///     Ons the create using the specified saved instance state
        /// </summary>
        /// <param name="savedInstanceState">The saved instance state</param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            GlView glView = new GlView(this);
            SetContentView(glView);
        }
    }
}