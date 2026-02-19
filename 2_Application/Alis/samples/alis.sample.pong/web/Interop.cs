// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Interop.cs
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
using System.Runtime.InteropServices.JavaScript;

namespace Alis.Sample.Pong.Web
{
    /// <summary>
    /// The interop class
    /// </summary>
    internal static partial class Interop
    {
        /// <summary>
        /// Initializes
        /// </summary>
        [JSImport("initialize", "main.js")]
        public static partial void Initialize();

        /// <summary>
        /// Ons the key down using the specified shift
        /// </summary>
        /// <param name="shift">The shift</param>
        /// <param name="ctrl">The ctrl</param>
        /// <param name="alt">The alt</param>
        /// <param name="repeat">The repeat</param>
        /// <param name="code">The code</param>
        [JSExport]
        public static void OnKeyDown(bool shift, bool ctrl, bool alt, bool repeat, int code)
        {
        }

        /// <summary>
        /// Ons the key up using the specified shift
        /// </summary>
        /// <param name="shift">The shift</param>
        /// <param name="ctrl">The ctrl</param>
        /// <param name="alt">The alt</param>
        /// <param name="code">The code</param>
        [JSExport]
        public static void OnKeyUp(bool shift, bool ctrl, bool alt, int code)
        {
        }

        /// <summary>
        /// Ons the mouse move using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [JSExport]
        public static void OnMouseMove(float x, float y)
        {
        }

        /// <summary>
        /// Ons the mouse down using the specified shift
        /// </summary>
        /// <param name="shift">The shift</param>
        /// <param name="ctrl">The ctrl</param>
        /// <param name="alt">The alt</param>
        /// <param name="button">The button</param>
        [JSExport]
        public static void OnMouseDown(bool shift, bool ctrl, bool alt, int button)
        {
        }

        /// <summary>
        /// Ons the mouse up using the specified shift
        /// </summary>
        /// <param name="shift">The shift</param>
        /// <param name="ctrl">The ctrl</param>
        /// <param name="alt">The alt</param>
        /// <param name="button">The button</param>
        [JSExport]
        public static void OnMouseUp(bool shift, bool ctrl, bool alt, int button)
        {
        }

        /// <summary>
        /// Ons the canvas resize using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="devicePixelRatio">The device pixel ratio</param>
        [JSExport]
        public static void OnCanvasResize(float width, float height, float devicePixelRatio)
        {
            EntryPoint.CanvasResized((int) width, (int) height);
        }

        /// <summary>
        /// Sets the root uri using the specified uri
        /// </summary>
        /// <param name="uri">The uri</param>
        [JSExport]
        public static void SetRootUri(string uri)
        {
            EntryPoint.BaseAddress = new Uri(uri);
        }

        /// <summary>
        /// Adds the locale using the specified locale
        /// </summary>
        /// <param name="locale">The locale</param>
        [JSExport]
        public static void AddLocale(string locale)
        {
        }
    }
}