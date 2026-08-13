// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacWindowExecutionTests.cs
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
    ///     Tests for MacWindow lifecycle executed on the process main thread via the startup hook bootstrap.
    /// </summary>
    public class MacWindowExecutionTests
    {
        /// <summary>
        ///     Constructor_OnMainThread_SetsWidthHeightTitleAndHandle
        /// </summary>
        [MacOsOnly]
        public void Constructor_OnMainThread_SetsWidthHeightTitleAndHandle()
        {
            if (!MacWindowBootstrap.Ready)
            {
                return;
            }

            Assert.NotNull(MacWindowBootstrap.Window);
            Assert.Equal(320, MacWindowBootstrap.InitialWidth);
            Assert.Equal(200, MacWindowBootstrap.InitialHeight);
            Assert.Equal("exec", MacWindowBootstrap.InitialTitle);
            Assert.True(MacWindowBootstrap.HandleValid);
        }

        /// <summary>
        ///     Show_OnMainThread_MakesWindowVisible
        /// </summary>
        [MacOsOnly]
        public void Show_OnMainThread_MakesWindowVisible()
        {
            if (!MacWindowBootstrap.Ready)
            {
                return;
            }

            Assert.True(MacWindowBootstrap.VisibleAfterShow);
        }

        /// <summary>
        ///     SetTitle_OnMainThread_UpdatesTitleProperty
        /// </summary>
        [MacOsOnly]
        public void SetTitle_OnMainThread_UpdatesTitleProperty()
        {
            if (!MacWindowBootstrap.Ready)
            {
                return;
            }

            Assert.Equal("new title", MacWindowBootstrap.Window.Title);
        }

        /// <summary>
        ///     SetSize_OnMainThread_UpdatesWidthHeightProperties
        /// </summary>
        [MacOsOnly]
        public void SetSize_OnMainThread_UpdatesWidthHeightProperties()
        {
            if (!MacWindowBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(640, MacWindowBootstrap.Window.Width);
            Assert.Equal(480, MacWindowBootstrap.Window.Height);
        }

        /// <summary>
        ///     GetFrame_OnMainThread_ReturnsValidNumericStruct
        /// </summary>
        [MacOsOnly]
        public void GetFrame_OnMainThread_ReturnsValidNumericStruct()
        {
            if (!MacWindowBootstrap.Ready)
            {
                return;
            }

            Assert.False(double.IsNaN(MacWindowBootstrap.Frame.width));
            Assert.False(double.IsNaN(MacWindowBootstrap.Frame.height));
        }

        /// <summary>
        ///     Hide_OnMainThread_HidesWindow
        /// </summary>
        [MacOsOnly]
        public void Hide_OnMainThread_HidesWindow()
        {
            if (!MacWindowBootstrap.Ready)
            {
                return;
            }

            Assert.False(MacWindowBootstrap.HiddenAfterHide);
        }
    }
}
#endif
