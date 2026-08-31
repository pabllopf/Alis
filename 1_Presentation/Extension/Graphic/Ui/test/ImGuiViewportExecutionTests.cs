// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiViewportExecutionTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui viewport execution tests class
    /// </summary>
    public class ImGuiViewportExecutionTests
    {
        /// <summary>
        ///     Tests that the id property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_Id_RoundTrips()
        {
            ImGuiViewport viewport = new ImGuiViewport { Id = 10u };

            Assert.Equal(10u, viewport.Id);
        }

        /// <summary>
        ///     Tests that the flags property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_Flags_RoundTrips()
        {
            ImGuiViewport viewport = new ImGuiViewport { Flags = ImGuiViewportFlags.TopMost };

            Assert.Equal(ImGuiViewportFlags.TopMost, viewport.Flags);
        }

        /// <summary>
        ///     Tests that the pos property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_Pos_RoundTrips()
        {
            Vector2F expected = new Vector2F(1.5f, 2.5f);
            ImGuiViewport viewport = new ImGuiViewport { Pos = expected };

            Assert.Equal(expected, viewport.Pos);
        }

        /// <summary>
        ///     Tests that the size property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_Size_RoundTrips()
        {
            Vector2F expected = new Vector2F(3.5f, 4.5f);
            ImGuiViewport viewport = new ImGuiViewport { Size = expected };

            Assert.Equal(expected, viewport.Size);
        }

        /// <summary>
        ///     Tests that the work pos property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_WorkPos_RoundTrips()
        {
            Vector2F expected = new Vector2F(5.5f, 6.5f);
            ImGuiViewport viewport = new ImGuiViewport { WorkPos = expected };

            Assert.Equal(expected, viewport.WorkPos);
        }

        /// <summary>
        ///     Tests that the work size property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_WorkSize_RoundTrips()
        {
            Vector2F expected = new Vector2F(7.5f, 8.5f);
            ImGuiViewport viewport = new ImGuiViewport { WorkSize = expected };

            Assert.Equal(expected, viewport.WorkSize);
        }

        /// <summary>
        ///     Tests that the dpi scale property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_DpiScale_RoundTrips()
        {
            ImGuiViewport viewport = new ImGuiViewport { DpiScale = 2.0f };

            Assert.Equal(2.0f, viewport.DpiScale);
        }

        /// <summary>
        ///     Tests that the parent viewport id property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_ParentViewportId_RoundTrips()
        {
            ImGuiViewport viewport = new ImGuiViewport { ParentViewportId = 99u };

            Assert.Equal(99u, viewport.ParentViewportId);
        }

        /// <summary>
        ///     Tests that the draw data property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_DrawData_RoundTrips()
        {
            IntPtr expected = new IntPtr(123);
            ImGuiViewport viewport = new ImGuiViewport { DrawData = expected };

            Assert.Equal(expected, viewport.DrawData);
        }

        /// <summary>
        ///     Tests that the renderer user data property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_RendererUserData_RoundTrips()
        {
            IntPtr expected = new IntPtr(456);
            ImGuiViewport viewport = new ImGuiViewport { RendererUserData = expected };

            Assert.Equal(expected, viewport.RendererUserData);
        }

        /// <summary>
        ///     Tests that the platform user data property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_PlatformUserData_RoundTrips()
        {
            IntPtr expected = new IntPtr(789);
            ImGuiViewport viewport = new ImGuiViewport { PlatformUserData = expected };

            Assert.Equal(expected, viewport.PlatformUserData);
        }

        /// <summary>
        ///     Tests that the platform handle property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_PlatformHandle_RoundTrips()
        {
            IntPtr expected = new IntPtr(11);
            ImGuiViewport viewport = new ImGuiViewport { PlatformHandle = expected };

            Assert.Equal(expected, viewport.PlatformHandle);
        }

        /// <summary>
        ///     Tests that the platform handle raw property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_PlatformHandleRaw_RoundTrips()
        {
            IntPtr expected = new IntPtr(22);
            ImGuiViewport viewport = new ImGuiViewport { PlatformHandleRaw = expected };

            Assert.Equal(expected, viewport.PlatformHandleRaw);
        }

        /// <summary>
        ///     Tests that the platform window created property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_PlatformWindowCreated_RoundTrips()
        {
            ImGuiViewport viewport = new ImGuiViewport { PlatformWindowCreated = 1 };

            Assert.Equal(1, viewport.PlatformWindowCreated);
        }

        /// <summary>
        ///     Tests that the platform request move property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_PlatformRequestMove_RoundTrips()
        {
            ImGuiViewport viewport = new ImGuiViewport { PlatformRequestMove = 1 };

            Assert.Equal(1, viewport.PlatformRequestMove);
        }

        /// <summary>
        ///     Tests that the platform request resize property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_PlatformRequestResize_RoundTrips()
        {
            ImGuiViewport viewport = new ImGuiViewport { PlatformRequestResize = 1 };

            Assert.Equal(1, viewport.PlatformRequestResize);
        }

        /// <summary>
        ///     Tests that the platform request close property round-trips
        /// </summary>
        [Fact]
        public void ImGuiViewport_PlatformRequestClose_RoundTrips()
        {
            ImGuiViewport viewport = new ImGuiViewport { PlatformRequestClose = 1 };

            Assert.Equal(1, viewport.PlatformRequestClose);
        }

        /// <summary>
        ///     Tests that a default instance has all-zero values
        /// </summary>
        [Fact]
        public void ImGuiViewport_Default_AllValuesZero()
        {
            ImGuiViewport viewport = default;

            Assert.Equal(0u, viewport.Id);
            Assert.Equal(ImGuiViewportFlags.None, viewport.Flags);
            Assert.Equal(default(Vector2F), viewport.Pos);
            Assert.Equal(default(Vector2F), viewport.Size);
            Assert.Equal(default(Vector2F), viewport.WorkPos);
            Assert.Equal(default(Vector2F), viewport.WorkSize);
            Assert.Equal(0f, viewport.DpiScale);
            Assert.Equal(0u, viewport.ParentViewportId);
            Assert.Equal(IntPtr.Zero, viewport.DrawData);
            Assert.Equal(IntPtr.Zero, viewport.RendererUserData);
            Assert.Equal(IntPtr.Zero, viewport.PlatformUserData);
            Assert.Equal(IntPtr.Zero, viewport.PlatformHandle);
            Assert.Equal(IntPtr.Zero, viewport.PlatformHandleRaw);
            Assert.Equal(0, viewport.PlatformWindowCreated);
            Assert.Equal(0, viewport.PlatformRequestMove);
            Assert.Equal(0, viewport.PlatformRequestResize);
            Assert.Equal(0, viewport.PlatformRequestClose);
        }
    }
}
