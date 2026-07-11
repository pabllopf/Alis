// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderWindowTest.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the <see cref="RenderWindow"/> class.
    /// </summary>
    public class RenderWindowTest
    {
        [Fact]
        public void RenderWindow_ImplementsIRenderTarget()
        {
            Assert.True(typeof(IRenderTarget).IsAssignableFrom(typeof(RenderWindow)));
        }

        [Fact]
        public void RenderWindow_IsAssignableFromWindow()
        {
            Assert.True(typeof(Window).IsAssignableFrom(typeof(RenderWindow)));
        }

        [Fact]
        public void IsOpen_Settings_Position_Properties_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("IsOpen"));
            Assert.NotNull(typeof(RenderWindow).GetProperty("Settings"));
            Assert.NotNull(typeof(RenderWindow).GetProperty("Position"));
        }

        [Fact]
        public void SystemHandle_Size_Properties_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("SystemHandle"));
            Assert.NotNull(typeof(RenderWindow).GetProperty("Size"));
        }

        [Fact]
        public void Clear_Draw_View_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("Clear", System.Type.EmptyTypes));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Clear", new[] { typeof(Color) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetView"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("GetView"));
        }

        [Fact]
        public void DefaultView_GetViewport_Properties_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("DefaultView"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("GetViewport"));
        }

        [Fact]
        public void MapPixelToCoords_MapCoordsToPixel_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("MapPixelToCoords", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("MapCoordsToPixel", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
        }

        [Fact]
        public void PushGlStates_PopGlStates_ResetGlStates_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("PushGlStates"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("PopGlStates"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("ResetGlStates"));
        }

        [Fact]
        public void Close_SetTitle_SetIcon_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("Close"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetTitle"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetIcon"));
        }

        [Fact]
        public void SetVisible_SetVerticalSyncEnabled_SetMouseCursorVisible_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetVisible"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetVerticalSyncEnabled"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetMouseCursorVisible"));
        }

        [Fact]
        public void SetMouseCursorGrabbed_SetMouseCursor_SetKeyRepeatEnabled_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetMouseCursorGrabbed"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetMouseCursor"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetKeyRepeatEnabled"));
        }

        [Fact]
        public void SetFramerateLimit_SetJoystickThreshold_SetActive_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetFramerateLimit"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetJoystickThreshold"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetActive", new[] { typeof(bool) }));
        }

        [Fact]
        public void RequestFocus_HasFocus_Display_Capture_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("RequestFocus"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("HasFocus"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Display"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Capture"));
        }

        [Fact]
        public void PollEvent_WaitEvent_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("PollEvent"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("WaitEvent"));
        }

        [Fact]
        public void InternalGetMousePosition_InternalSetMousePosition_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("InternalGetMousePosition"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("InternalSetMousePosition"));
        }

        [Fact]
        public void InternalGetTouchPosition_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("InternalGetTouchPosition"));
        }
    }
}
