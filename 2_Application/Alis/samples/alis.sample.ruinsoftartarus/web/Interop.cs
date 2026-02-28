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

namespace Alis.Sample.RuinsOfTartarus.Web
{
    internal static partial class Interop
    {
        [JSImport("initialize", "main.js")]
        public static partial void Initialize();

        [JSExport]
        public static void OnKeyDown(bool shift, bool ctrl, bool alt, bool repeat, int code)
        {
        }

        [JSExport]
        public static void OnKeyUp(bool shift, bool ctrl, bool alt, int code)
        {
        }

        [JSExport]
        public static void OnMouseMove(float x, float y)
        {
        }

        [JSExport]
        public static void OnMouseDown(bool shift, bool ctrl, bool alt, int button)
        {
        }

        [JSExport]
        public static void OnMouseUp(bool shift, bool ctrl, bool alt, int button)
        {
        }

        [JSExport]
        public static void OnCanvasResize(float width, float height, float devicePixelRatio)
        {
            EntryPoint.CanvasResized((int) width, (int) height);
        }

        [JSExport]
        public static void SetRootUri(string uri)
        {
            EntryPoint.BaseAddress = new Uri(uri);
        }

        [JSExport]
        public static void AddLocale(string locale)
        {
        }
    }
}