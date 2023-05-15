// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MainApplication.cs
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

using System;
using Android.App;
using Android.Runtime;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Alis.Template.Game.Mobile.Android.Platforms.Android
{
    /// <summary>
    ///     The main application class
    /// </summary>
    /// <seealso cref="MauiApplication" />
    [Application]
    public class MainApplication : MauiApplication
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MainApplication" /> class
        /// </summary>
        /// <param name="handle">The handle</param>
        /// <param name="ownership">The ownership</param>
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        /// <summary>
        ///     Creates the maui app
        /// </summary>
        /// <returns>The maui app</returns>
        protected override MauiApp CreateMauiApp() => AppProgram.CreateMauiApp();
    }
}