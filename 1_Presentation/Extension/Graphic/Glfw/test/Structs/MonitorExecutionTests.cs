// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MonitorExecutionTests.cs
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
using System.Drawing;
using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test.Structs
{
    /// <summary>
    ///     Executes the native-backed <see cref="Monitor" /> members against the real GLFW monitor captured by
    ///     <see cref="GlfwTestBootstrap" /> on the process main thread.
    ///     <para>
    ///         GLFW monitor queries are thread-safe, so the bootstrap-created primary monitor is read directly from the
    ///         xUnit worker thread. Every test is a harmless no-op when the startup hook was not installed
    ///         (<see cref="GlfwTestBootstrap.Ready" /> is false on CI).
    ///     </para>
    /// </summary>
    public class MonitorExecutionTests
    {
        /// <summary>
        ///     Tests that the work area of the primary monitor is a valid non-empty rectangle.
        /// </summary>
        [RequireGlfwFact]
        public void WorkArea_Get_ReturnsValidRectangle()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Rectangle workArea = GlfwTestBootstrap.PrimaryMonitor.WorkArea;

            Assert.True(workArea.Width > 0);
            Assert.True(workArea.Height > 0);
        }

        /// <summary>
        ///     Tests that the content scale of the primary monitor is positive on both axes.
        /// </summary>
        [RequireGlfwFact]
        public void ContentScale_Get_ReturnsPositiveScale()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            PointF scale = GlfwTestBootstrap.PrimaryMonitor.ContentScale;

            Assert.True(scale.X > 0.0f);
            Assert.True(scale.Y > 0.0f);
        }

        /// <summary>
        ///     Tests that the user pointer of the primary monitor can be set and read back.
        /// </summary>
        [RequireGlfwFact]
        public void UserPointer_SetThenGet_RoundTrips()
        {
            if (!GlfwTestBootstrap.Ready)
            {
                return;
            }

            Monitor monitor = GlfwTestBootstrap.PrimaryMonitor;
            IntPtr pointer = new IntPtr(0x7B);

            monitor.UserPointer = pointer;
            IntPtr result = monitor.UserPointer;

            monitor.UserPointer = IntPtr.Zero;

            Assert.Equal(pointer, result);
        }
    }
}
