// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacOpenGLContext.cs
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
    ///     Gestiona el contexto OpenGL nativo en macOS
    /// </summary>
    internal class MacOpenGLContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MacOpenGLContext"/> class
        /// </summary>
        /// <param name="window">The window</param>
        public MacOpenGLContext(MacWindow window)
        {
            CrearContexto(window);
        }

        /// <summary>
        /// Gets or sets the value of the view
        /// </summary>
        public IntPtr View { get; private set; }

        /// <summary>
        /// Gets or sets the value of the context
        /// </summary>
        public IntPtr Context { get; private set; }

        /// <summary>
        /// Gets or sets the value of the pixel format
        /// </summary>
        public IntPtr PixelFormat { get; private set; }

        /// <summary>
        /// Crears the contexto using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        private void CrearContexto(MacWindow window)
        {
            int[] attrs =
            {
                MacConstants.NsOpenGlpfaOpenGlProfile, MacConstants.NsOpenGlProfileVersion32Core,
                MacConstants.NsOpenGlpfaDoubleBuffer,
                MacConstants.NsOpenGlpfaColorSize, 24,
                MacConstants.NsOpenGlpfaDepthSize, 24,
                0
            };
            PixelFormat = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSOpenGLPixelFormat"), ObjectiveCInterop.Sel("alloc"));
            GCHandle pin = GCHandle.Alloc(attrs, GCHandleType.Pinned);
            try
            {
                PixelFormat = ObjectiveCInterop.objc_msgSend_IntPtr(PixelFormat, ObjectiveCInterop.Sel("initWithAttributes:"), pin.AddrOfPinnedObject());
            }
            finally
            {
                pin.Free();
            }

            View = ObjectiveCInterop.objc_msgSend(ObjectiveCInterop.Class("NSOpenGLView"), ObjectiveCInterop.Sel("alloc"));
            NsRect frame = window.GetFrame();
            View = ObjectiveCInterop.objc_msgSend_NSRect_IntPtr(View, ObjectiveCInterop.Sel("initWithFrame:pixelFormat:"),
                frame.x, frame.y, frame.width, frame.height, PixelFormat);
            ObjectiveCInterop.objc_msgSend_void_IntPtr(window.Handle, ObjectiveCInterop.Sel("setContentView:"), View);
            Context = ObjectiveCInterop.objc_msgSend(View, ObjectiveCInterop.Sel("openGLContext"));
        }

        /// <summary>
        /// Makes the current
        /// </summary>
        public void MakeCurrent() => ObjectiveCInterop.objc_msgSend_void(Context, ObjectiveCInterop.Sel("makeCurrentContext"));

        /// <summary>
        /// Swaps the buffers
        /// </summary>
        public void SwapBuffers() => ObjectiveCInterop.objc_msgSend_void(Context, ObjectiveCInterop.Sel("flushBuffer"));
    }
}

#endif