// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AppProgram.cs
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

#if UNSUPPORTED
using System;
#else
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using SkiaSharp.Views.Maui.Controls.Hosting;
#endif


namespace Alis.Template.Game.Desktop.MacOs
{
    /// <summary>
    ///     The maui program class
    /// </summary>
    public static class AppProgram
    {
#if UNSUPPORTED
        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) => Console.WriteLine("UNSUPPORTED PLATFORM: Can't compile 'Windows apps' on MacOS or Linux OS.");

#else
        /// <summary>
        ///     Creates the maui app
        /// </summary>
        /// <returns>The maui app</returns>
        public static MauiApp CreateMauiApp() =>
            MauiApp
                .CreateBuilder()
                .UseSkiaSharp(true)
                .UseMauiApp<App>()
                .Build();

#endif
    }
}