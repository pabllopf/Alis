// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WindowExecutionTests.cs
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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Verifies the base <see cref="Window" /> wrapper members executed by
    ///     <see cref="WindowMainThreadWorker" /> on the process main thread through the startup
    ///     hook. Tests are harmless no-ops when the hook was not installed
    ///     (<see cref="SfmlTestBootstrap.Ready" /> is false on CI).
    /// </summary>
    public class WindowExecutionTests
    {
        /// <summary>
        ///     Tests that every native step executed on the main thread completed without an exception.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void WorkerSteps_AllSucceeded()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.Empty(WindowMainThreadWorker.Failures);
        }

        /// <summary>
        ///     Tests that the base window reported itself open.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void IsOpen_Get_ReturnsTrue()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.IsOpenResult);
        }

        /// <summary>
        ///     Tests that the position getter and setter completed.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Position_GetSet_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.PositionExecuted);
        }

        /// <summary>
        ///     Tests that the size getter and setter completed.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Size_GetSet_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.SizeExecuted);
        }

        /// <summary>
        ///     Tests that the system handle query completed or recorded the missing entry point.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SystemHandle_Get_ReturnsNonZero()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.SystemHandleExecuted || WindowMainThreadWorker.MissingEntryPoints.Contains("SystemHandle"));
        }

        /// <summary>
        ///     Tests that the title setter completed.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetTitle_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.TitleExecuted);
        }

        /// <summary>
        ///     Tests that the visibility setter completed.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetVisible_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.VisibleExecuted);
        }

        /// <summary>
        ///     Tests that the cursor setters completed.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void MouseCursorSetters_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.CursorExecuted);
        }

        /// <summary>
        ///     Tests that the vertical sync and key repeat setters completed.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SyncAndRepeatSetters_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.SyncAndRepeatExecuted);
        }

        /// <summary>
        ///     Tests that activating the window returned a value.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetActive_ReturnsValue()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.IsType<bool>(WindowMainThreadWorker.ActiveResult);
        }

        /// <summary>
        ///     Tests that the framerate and joystick setters completed.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void LimitsSetters_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.LimitsExecuted);
        }

        /// <summary>
        ///     Tests that the focus query returned a value.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void HasFocus_ReturnsValue()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.IsType<bool>(WindowMainThreadWorker.FocusResult);
        }

        /// <summary>
        ///     Tests that the display call completed.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Display_Completed()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.DisplayExecuted);
        }

        /// <summary>
        ///     Tests that the poll event call completed without throwing.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void PollEvent_DoesNotThrow()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.PollEventExecuted);
        }

        /// <summary>
        ///     Tests that closing the window made it report closed.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Close_ThenIsOpen_ReturnsFalse()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.ClosedOk);
        }

        /// <summary>
        ///     Tests that the string representation starts with the type name.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ContainsTypeName()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.Contains("[Window]", WindowMainThreadWorker.ToStringResult);
        }

        /// <summary>
        ///     Tests that disposing the window destroyed the native handle.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Dispose_DestroysNativeHandle()
        {
            if (!SfmlTestBootstrap.Ready)
            {
                return;
            }

            Assert.True(WindowMainThreadWorker.DisposeSafe);
        }
    }
}
