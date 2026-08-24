// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeWindowCoverageTests.cs
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
using Alis.Extension.Graphic.Glfw.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Covers additional <see cref="NativeWindow" /> branches: null handling of managed events fired without
    ///     subscribers, null title assignment, null title construction, fullscreen video mode and the disposed event.
    ///     The native operations run on the process main thread inside <see cref="MainThreadNativeWorker" />.
    /// </summary>
    public class NativeWindowCoverageTests
    {
        /// <summary>
        ///     Tests that firing every managed event without subscribers completes without throwing.
        /// </summary>
        [RequireGlfwFact]
        public void FireOnEvents_WhenNoSubscribers_DoesNotThrow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.EventsNoSubscribersSucceeded);
        }

        /// <summary>
        ///     Tests that assigning a null title stores null without throwing.
        /// </summary>
        [RequireGlfwFact]
        public void Title_WhenSetToNull_StoresNull()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.Null(MainThreadNativeWorker.TitleNullResult);
        }

        /// <summary>
        ///     Tests that constructing a window with a null title creates a valid handle.
        /// </summary>
        [RequireGlfwFact]
        public void Constructor_WhenTitleIsNull_CreatesValidWindow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.NullTitleCtorValidHandle);
        }

        /// <summary>
        ///     Tests that reading the video mode while the window is fullscreen returns a valid mode.
        /// </summary>
        [RequireGlfwFact]
        public void VideoMode_WhenFullscreen_ReturnsValidMode()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.VideoModeFullscreenWidthResult > 0);
            Assert.True(MainThreadNativeWorker.VideoModeFullscreenHeightResult > 0);
        }

        /// <summary>
        ///     Tests that the disposed event is raised when a subscribed window is disposed.
        /// </summary>
        [RequireGlfwFact]
        public void Dispose_WhenDisposedSubscribed_RaisesEvent()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.DisposedEventRaised);
        }

        /// <summary>
        ///     Tests that equality with a non-window object returns false.
        /// </summary>
        [RequireGlfwFact]
        public void Equals_WhenObjectIsNotNativeWindow_ReturnsFalse()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;

            Assert.False(window.Equals(new object()));
            Assert.False(window.Equals(null));
        }

        /// <summary>
        ///     Tests that equality with another window instance compares the native handles.
        /// </summary>
        [RequireGlfwFact]
        public void Equals_WhenObjectIsDifferentNativeWindow_ReturnsFalse()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            TestableNativeWindow window = (TestableNativeWindow) GlfwTestBootstrap.Window;

            Assert.False(window.Equals((object) GlfwTestBootstrap.GameWindowInstance));
        }

        /// <summary>
        ///     Tests that constructing a window without a client API creates a valid handle.
        /// </summary>
        [RequireGlfwFact]
        public void Constructor_WhenNoClientApi_CreatesValidWindow()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(MainThreadNativeWorker.NoContextCtorValidHandle);
        }
    }
}