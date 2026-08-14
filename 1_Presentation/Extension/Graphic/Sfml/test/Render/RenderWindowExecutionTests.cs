// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderWindowExecutionTests.cs
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
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Verifies the <see cref="RenderWindow" /> wrapper members against the real native CSFML library. The native
    ///     calls execute on the process main thread inside <see cref="RenderWindowMainThreadWorker" /> because SFML on
    ///     macOS requires the main thread for window creation and operations; the tests assert the recorded results.
    ///     Tests are harmless no-ops when the startup hook was not installed (<see cref="SfmlTestBootstrap.Ready" /> is
    ///     false on CI).
    /// </summary>
    public class RenderWindowExecutionTests
    {
        /// <summary>
        ///     Tests that the bootstrap created the persistent window on the main thread.
        /// </summary>
        [Fact]
        public void Bootstrap_CreatesLiveWindow()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.NotNull(SfmlTestBootstrap.Window);
        }

        /// <summary>
        ///     Tests that every native step executed on the main thread completed without an exception.
        /// </summary>
        [Fact]
        public void WorkerSteps_AllSucceeded()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.Empty(RenderWindowMainThreadWorker.Failures);
        }

        /// <summary>
        ///     Tests that the live window reports itself open.
        /// </summary>
        [Fact]
        public void IsOpen_Get_ReturnsTrue()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.IsOpenResult);
        }

        /// <summary>
        ///     Tests that the creation settings report the requested depth bits.
        /// </summary>
        [Fact]
        public void Settings_Get_ReturnsRequestedDepthBits()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(0u, RenderWindowMainThreadWorker.SettingsResult.DepthBits);
        }

        /// <summary>
        ///     Tests that the position getter and setter completed without throwing.
        /// </summary>
        [Fact]
        public void Position_GetSet_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.PositionExecuted);
        }

        /// <summary>
        ///     Tests that the size getter and setter completed without throwing.
        /// </summary>
        [Fact]
        public void Size_GetSet_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.SizeExecuted);
        }

        /// <summary>
        ///     Tests that the view set on the live window is returned with its size.
        /// </summary>
        [Fact]
        public void View_SetThenGet_SizeMatches()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(800f, RenderWindowMainThreadWorker.ViewSizeResult.X);
            Assert.Equal(600f, RenderWindowMainThreadWorker.ViewSizeResult.Y);
        }

        /// <summary>
        ///     Tests that the default view matches the window size.
        /// </summary>
        [Fact]
        public void DefaultView_Get_MatchesWindowSize()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.Equal(800f, RenderWindowMainThreadWorker.DefaultViewSizeResult.X);
            Assert.Equal(600f, RenderWindowMainThreadWorker.DefaultViewSizeResult.Y);
        }

        /// <summary>
        ///     Tests that the viewport query completed without throwing.
        /// </summary>
        [Fact]
        public void GetViewport_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.ViewportExecuted);
        }

        /// <summary>
        ///     Tests that the pixel to coords mapping completed without throwing.
        /// </summary>
        [Fact]
        public void MapPixelToCoords_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.PixelToCoordsExecuted);
        }

        /// <summary>
        ///     Tests that the coords to pixel mapping completed without throwing.
        /// </summary>
        [Fact]
        public void MapCoordsToPixel_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.CoordsToPixelExecuted);
        }

        /// <summary>
        ///     Tests that the push and pop GL states calls completed.
        /// </summary>
        [Fact]
        public void GlStates_PushPop_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.GlStatesOk);
        }

        /// <summary>
        ///     Tests that polling an event does not throw.
        /// </summary>
        [Fact]
        public void PollEvent_DoesNotThrow()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.PollEventExecuted);
        }

        /// <summary>
        ///     Tests that the mouse and touch queries do not throw.
        /// </summary>
        [Fact]
        public void MouseAndTouch_DoNotThrow()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.MousePositionExecuted);
            Assert.True(RenderWindowMainThreadWorker.TouchPositionExecuted);
        }

        /// <summary>
        ///     Tests that activating the window succeeded.
        /// </summary>
        [Fact]
        public void SetActive_ReturnsTrue()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.ActiveResult);
        }

        /// <summary>
        ///     Tests that the string description identifies a render window.
        /// </summary>
        [Fact]
        public void ToString_ContainsRenderWindow()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.Contains("[RenderWindow]", RenderWindowMainThreadWorker.ToStringResult);
        }

        /// <summary>
        ///     Tests that the system handle getter throws the missing entry point error because CSFML 3.0 renamed it.
        /// </summary>
        [Fact]
        public void SystemHandle_ThrowsMissingEntryPoint()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.Contains("SystemHandle", RenderWindowMainThreadWorker.MissingEntryPoints);
        }

        /// <summary>
        ///     Tests that the capture call throws the missing entry point error because CSFML 3.0 removed it.
        /// </summary>
        [Fact]
        public void Capture_ThrowsMissingEntryPoint()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.Contains("Capture", RenderWindowMainThreadWorker.MissingEntryPoints);
        }

        /// <summary>
        ///     Tests that closing the window makes it report closed.
        /// </summary>
        [Fact]
        public void Close_ThenIsOpen_ReturnsFalse()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.ClosedOk);
        }

        /// <summary>
        ///     Tests that disposing the window destroys the native handle and is safe twice.
        /// </summary>
        [Fact]
        public void Dispose_DestroysNativeHandle()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.DisposeSafe);
        }

        /// <summary>
        ///     Tests that the one argument handle constructor produced a valid window on the main thread.
        /// </summary>
        [Fact]
        public void Ctor_FromNativeHandle_CreatesValidWindow()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(RenderWindowMainThreadWorker.HandleCtorOk);
        }
    }
}
