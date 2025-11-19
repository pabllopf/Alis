// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacWindow.cs
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

#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     Representa una ventana nativa de macOS
    /// </summary>
    internal class MacWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MacWindow"/> class
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        public MacWindow(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;
            CrearVentana();
        }

        /// <summary>
        /// Gets or sets the value of the handle
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
        /// Gets or sets the value of the width
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets or sets the value of the height
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets or sets the value of the title
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Crears the ventana
        /// </summary>
        private void CrearVentana()
        {
            Handle = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSWindow"), ObjectiveCInterop.Sel("alloc"));
            Handle = ObjectiveCInterop.objc_msgSend_NSRect_UL_UL_Bool(
                Handle, ObjectiveCInterop.Sel("initWithContentRect:styleMask:backing:defer:"),
                100.0, 100.0, Width, Height,
                MacConstants.NsWindowStyleMaskTitled | MacConstants.NsWindowStyleMaskClosable | MacConstants.NsWindowStyleMaskMiniaturizable | MacConstants.NsWindowStyleMaskResizable,
                MacConstants.NsBackingStoreBuffered, false);
            ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("setTitle:"), ObjectiveCInterop.NsString(Title));
            ObjectiveCInterop.objc_msgSend_void(Handle, ObjectiveCInterop.Sel("center"));
        }

        /// <summary>
        /// Shows this instance
        /// </summary>
        public void Show() => ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("makeKeyAndOrderFront:"), IntPtr.Zero);

        /// <summary>
        /// Hides this instance
        /// </summary>
        public void Hide() => ObjectiveCInterop.objc_msgSend_void(Handle, ObjectiveCInterop.Sel("orderOut:"));

        /// <summary>
        /// Sets the title using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        public void SetTitle(string title)
        {
            Title = title;
            ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("setTitle:"), ObjectiveCInterop.NsString(Title));
        }

        /// <summary>
        /// Sets the size using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
            // Cambiar tamaño de la ventana
            ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("setContentSize:"), Marshal.AllocHGlobal(sizeof(double) * 2));
        }

        /// <summary>
        /// Ises the visible
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsVisible() => ObjectiveCInterop.objc_msgSend(Handle, ObjectiveCInterop.Sel("isVisible")) != IntPtr.Zero;

        // csharp
        /// <summary>
        /// Gets the frame
        /// </summary>
        /// <returns>The ns rect</returns>
        public NsRect GetFrame()
        {
            IntPtr framePtr = ObjectiveCInterop.objc_msgSend(Handle, ObjectiveCInterop.Sel("frame"));

            // Leer cuatro doubles (8 bytes cada uno) desde la estructura nativa (x, y, width, height)
            long v0 = Marshal.ReadInt64(framePtr, 0);
            long v1 = Marshal.ReadInt64(framePtr, 8);
            long v2 = Marshal.ReadInt64(framePtr, 16);
            long v3 = Marshal.ReadInt64(framePtr, 24);

            return new NsRect
            {
                x = BitConverter.Int64BitsToDouble(v0),
                y = BitConverter.Int64BitsToDouble(v1),
                width = BitConverter.Int64BitsToDouble(v2),
                height = BitConverter.Int64BitsToDouble(v3)
            };
        }
    }
}

#endif