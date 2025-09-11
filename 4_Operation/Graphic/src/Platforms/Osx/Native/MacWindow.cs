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

#if osxarm64
using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     Representa una ventana nativa de macOS
    /// </summary>
    internal class MacWindow
    {
        public MacWindow(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;
            CrearVentana();
        }

        public IntPtr Handle { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Title { get; private set; }

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

        public void Show() => ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("makeKeyAndOrderFront:"), IntPtr.Zero);
        public void Hide() => ObjectiveCInterop.objc_msgSend_void(Handle, ObjectiveCInterop.Sel("orderOut:"));

        public void SetTitle(string title)
        {
            Title = title;
            ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("setTitle:"), ObjectiveCInterop.NsString(Title));
        }

        public void SetSize(int width, int height)
        {
            Width = width;
            Height = height;
            // Cambiar tamaño de la ventana
            ObjectiveCInterop.objc_msgSend_void_IntPtr(Handle, ObjectiveCInterop.Sel("setContentSize:"), Marshal.AllocHGlobal(sizeof(double) * 2));
        }

        public bool IsVisible() => ObjectiveCInterop.objc_msgSend(Handle, ObjectiveCInterop.Sel("isVisible")) != IntPtr.Zero;

        public NsRect GetFrame()
        {
            IntPtr framePtr = ObjectiveCInterop.objc_msgSend(Handle, ObjectiveCInterop.Sel("frame"));
            return Marshal.PtrToStructure<NsRect>(framePtr);
        }
    }
}
#endif