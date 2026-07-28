// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RenderWindowTests.cs
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
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Windows;
using Moq;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The render window tests class
    /// </summary>
    public class RenderWindowTests
    {
        /// <summary>
        /// Tests that render window implements i render target
        /// </summary>
        [Fact]
        public void RenderWindow_ImplementsIRenderTarget()
        {
            Assert.True(typeof(IRenderTarget).IsAssignableFrom(typeof(RenderWindow)));
        }

        /// <summary>
        /// Tests that render window is assignable from window
        /// </summary>
        [Fact]
        public void RenderWindow_IsAssignableFromWindow()
        {
            Assert.True(typeof(Window).IsAssignableFrom(typeof(RenderWindow)));
        }

        /// <summary>
        /// Tests that is open property exists
        /// </summary>
        [Fact]
        public void IsOpen_Property_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("IsOpen"));
        }

        /// <summary>
        /// Tests that settings property exists
        /// </summary>
        [Fact]
        public void Settings_Property_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("Settings"));
        }

        /// <summary>
        /// Tests that position property exists
        /// </summary>
        [Fact]
        public void Position_Property_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("Position"));
        }

        /// <summary>
        /// Tests that system handle property exists
        /// </summary>
        [Fact]
        public void SystemHandle_Property_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("SystemHandle"));
        }

        /// <summary>
        /// Tests that size property exists
        /// </summary>
        [Fact]
        public void Size_Property_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("Size"));
        }

        /// <summary>
        /// Tests that default view property exists
        /// </summary>
        [Fact]
        public void DefaultView_Property_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("DefaultView"));
        }

        /// <summary>
        /// Tests that clear methods exist
        /// </summary>
        [Fact]
        public void Clear_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("Clear", Type.EmptyTypes));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Clear", new[] { typeof(Color) }));
        }

        /// <summary>
        /// Tests that set view method exists
        /// </summary>
        [Fact]
        public void SetView_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetView"));
        }

        /// <summary>
        /// Tests that get view method exists
        /// </summary>
        [Fact]
        public void GetView_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("GetView"));
        }

        /// <summary>
        /// Tests that get viewport method exists
        /// </summary>
        [Fact]
        public void GetViewport_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("GetViewport"));
        }

        /// <summary>
        /// Tests that map pixel to coords methods exist
        /// </summary>
        [Fact]
        public void MapPixelToCoords_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("MapPixelToCoords", new[] { typeof(Vector2F) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("MapPixelToCoords", new[] { typeof(Vector2F), typeof(View) }));
        }

        /// <summary>
        /// Tests that map coords to pixel methods exist
        /// </summary>
        [Fact]
        public void MapCoordsToPixel_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("MapCoordsToPixel", new[] { typeof(Vector2F) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("MapCoordsToPixel", new[] { typeof(Vector2F), typeof(View) }));
        }

        /// <summary>
        /// Tests that draw methods exist
        /// </summary>
        [Fact]
        public void Draw_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("Draw", new[] { typeof(IDrawable) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Draw", new[] { typeof(IDrawable), typeof(RenderStates) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(PrimitiveType) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(PrimitiveType), typeof(RenderStates) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(uint), typeof(uint), typeof(PrimitiveType) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Draw", new[] { typeof(Vertex[]), typeof(uint), typeof(uint), typeof(PrimitiveType), typeof(RenderStates) }));
        }

        /// <summary>
        /// Tests that push gl states method exists
        /// </summary>
        [Fact]
        public void PushGlStates_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("PushGlStates"));
        }

        /// <summary>
        /// Tests that pop gl states method exists
        /// </summary>
        [Fact]
        public void PopGlStates_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("PopGlStates"));
        }

        /// <summary>
        /// Tests that reset gl states method exists
        /// </summary>
        [Fact]
        public void ResetGlStates_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("ResetGlStates"));
        }

        /// <summary>
        /// Tests that close set title set icon methods exist
        /// </summary>
        [Fact]
        public void Close_SetTitle_SetIcon_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("Close"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetTitle"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetIcon"));
        }

        /// <summary>
        /// Tests that set visible set vertical sync enabled set mouse cursor visible methods exist
        /// </summary>
        [Fact]
        public void SetVisible_SetVerticalSyncEnabled_SetMouseCursorVisible_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetVisible"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetVerticalSyncEnabled"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetMouseCursorVisible"));
        }

        /// <summary>
        /// Tests that set mouse cursor grabbed set mouse cursor set key repeat enabled methods exist
        /// </summary>
        [Fact]
        public void SetMouseCursorGrabbed_SetMouseCursor_SetKeyRepeatEnabled_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetMouseCursorGrabbed"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetMouseCursor"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetKeyRepeatEnabled"));
        }

        /// <summary>
        /// Tests that set framerate limit set joystick threshold set active methods exist
        /// </summary>
        [Fact]
        public void SetFramerateLimit_SetJoystickThreshold_SetActive_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetFramerateLimit"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetJoystickThreshold"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetActive", new[] { typeof(bool) }));
        }

        /// <summary>
        /// Tests that request focus has focus display capture methods exist
        /// </summary>
        [Fact]
        public void RequestFocus_HasFocus_Display_Capture_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("RequestFocus"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("HasFocus"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Display"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Capture"));
        }

        /// <summary>
        /// Tests that poll event wait event methods exist
        /// </summary>
        [Fact]
        public void PollEvent_WaitEvent_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("PollEvent"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("WaitEvent"));
        }

        /// <summary>
        /// Tests that internal get mouse position internal set mouse position methods exist
        /// </summary>
        [Fact]
        public void InternalGetMousePosition_InternalSetMousePosition_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("InternalGetMousePosition"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("InternalSetMousePosition"));
        }

        /// <summary>
        /// Tests that internal get touch position method exists
        /// </summary>
        [Fact]
        public void InternalGetTouchPosition_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("InternalGetTouchPosition"));
        }

        /// <summary>
        /// Tests that destroy method exists
        /// </summary>
        [Fact]
        public void Destroy_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("Destroy"));
        }

        /// <summary>
        /// Tests that to string method exists
        /// </summary>
        [Fact]
        public void ToString_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("ToString"));
        }
    }
}
