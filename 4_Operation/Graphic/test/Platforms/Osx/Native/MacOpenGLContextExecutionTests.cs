// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacOpenGLContextExecutionTests.cs
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
using Alis.Core.Graphic.Platforms.Osx.Native;
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx.Native
{
    /// <summary>
    ///     Tests for MacOpenGLContext members executed on the process main thread via the startup hook bootstrap.
    /// </summary>
    public class MacOpenGLContextExecutionTests
    {
        /// <summary>
        ///     Constructor_OnMainThread_CreatesViewContextAndPixelFormat
        /// </summary>
        [MacOsOnly]
        public void Constructor_OnMainThread_CreatesViewContextAndPixelFormat()
        {
            if (!MacOpenGLContextBootstrap.Ready)
            {
                return;
            }

            Assert.NotNull(MacOpenGLContextBootstrap.Context);
            Assert.NotEqual(IntPtr.Zero, MacOpenGLContextBootstrap.View);
            Assert.NotEqual(IntPtr.Zero, MacOpenGLContextBootstrap.ContextHandle);
            Assert.NotEqual(IntPtr.Zero, MacOpenGLContextBootstrap.PixelFormat);
        }

        /// <summary>
        ///     View_OnMainThread_MatchesRecordedHandle
        /// </summary>
        [MacOsOnly]
        public void View_OnMainThread_MatchesRecordedHandle()
        {
            if (!MacOpenGLContextBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(MacOpenGLContextBootstrap.View, MacOpenGLContextBootstrap.Context.View);
        }

        /// <summary>
        ///     Context_OnMainThread_MatchesRecordedHandle
        /// </summary>
        [MacOsOnly]
        public void Context_OnMainThread_MatchesRecordedHandle()
        {
            if (!MacOpenGLContextBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(MacOpenGLContextBootstrap.ContextHandle, MacOpenGLContextBootstrap.Context.Context);
        }

        /// <summary>
        ///     PixelFormat_OnMainThread_MatchesRecordedHandle
        /// </summary>
        [MacOsOnly]
        public void PixelFormat_OnMainThread_MatchesRecordedHandle()
        {
            if (!MacOpenGLContextBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(MacOpenGLContextBootstrap.PixelFormat, MacOpenGLContextBootstrap.Context.PixelFormat);
        }

        /// <summary>
        ///     MakeCurrent_OnMainThread_Executes
        /// </summary>
        [MacOsOnly]
        public void MakeCurrent_OnMainThread_Executes()
        {
            if (!MacOpenGLContextBootstrap.Ready)
            {
                return;
            }

            Assert.True(MacOpenGLContextBootstrap.MakeCurrentOk);
        }

        /// <summary>
        ///     SwapBuffers_OnMainThread_Executes
        /// </summary>
        [MacOsOnly]
        public void SwapBuffers_OnMainThread_Executes()
        {
            if (!MacOpenGLContextBootstrap.Ready)
            {
                return;
            }

            Assert.True(MacOpenGLContextBootstrap.SwapOk);
        }
    }
}
#endif
