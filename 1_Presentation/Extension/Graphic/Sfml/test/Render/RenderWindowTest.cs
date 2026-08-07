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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the <see cref="RenderWindow"/> class.
    /// </summary>
    public class RenderWindowTest
    {
        /// <summary>
        /// Tests that render window implements i render target
        /// </summary>
        [RequireCSfmlSystemFact]
        public void RenderWindow_ImplementsIRenderTarget()
        {
            Assert.True(typeof(IRenderTarget).IsAssignableFrom(typeof(RenderWindow)));
        }

        /// <summary>
        /// Tests that render window is assignable from window
        /// </summary>
        [RequireCSfmlSystemFact]
        public void RenderWindow_IsAssignableFromWindow()
        {
            Assert.True(typeof(Window).IsAssignableFrom(typeof(RenderWindow)));
        }

        /// <summary>
        /// Tests that is open settings position properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsOpen_Settings_Position_Properties_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("IsOpen"));
            Assert.NotNull(typeof(RenderWindow).GetProperty("Settings"));
            Assert.NotNull(typeof(RenderWindow).GetProperty("Position"));
        }

        /// <summary>
        /// Tests that system handle size properties exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SystemHandle_Size_Properties_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("SystemHandle"));
            Assert.NotNull(typeof(RenderWindow).GetProperty("Size"));
        }

        /// <summary>
        /// Tests that clear draw view methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Clear_Draw_View_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("Clear", System.Type.EmptyTypes));
            Assert.NotNull(typeof(RenderWindow).GetMethod("Clear", new[] { typeof(Color) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetView"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("GetView"));
        }

        /// <summary>
        /// Tests that default view get viewport properties methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void DefaultView_GetViewport_Properties_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetProperty("DefaultView"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("GetViewport"));
        }

        /// <summary>
        /// Tests that map pixel to coords map coords to pixel methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MapPixelToCoords_MapCoordsToPixel_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("MapPixelToCoords", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
            Assert.NotNull(typeof(RenderWindow).GetMethod("MapCoordsToPixel", new[] { typeof(Alis.Core.Aspect.Math.Vector.Vector2F) }));
        }

        /// <summary>
        /// Tests that push gl states pop gl states reset gl states methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void PushGlStates_PopGlStates_ResetGlStates_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("PushGlStates"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("PopGlStates"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("ResetGlStates"));
        }

        /// <summary>
        /// Tests that close set title set icon methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Close_SetTitle_SetIcon_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("Close"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetTitle"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetIcon"));
        }

        /// <summary>
        /// Tests that set visible set vertical sync enabled set mouse cursor visible methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetVisible_SetVerticalSyncEnabled_SetMouseCursorVisible_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetVisible"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetVerticalSyncEnabled"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetMouseCursorVisible"));
        }

        /// <summary>
        /// Tests that set mouse cursor grabbed set mouse cursor set key repeat enabled methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetMouseCursorGrabbed_SetMouseCursor_SetKeyRepeatEnabled_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetMouseCursorGrabbed"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetMouseCursor"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetKeyRepeatEnabled"));
        }

        /// <summary>
        /// Tests that set framerate limit set joystick threshold set active methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetFramerateLimit_SetJoystickThreshold_SetActive_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetFramerateLimit"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetJoystickThreshold"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("SetActive", new[] { typeof(bool) }));
        }

        /// <summary>
        /// Tests that request focus has focus display capture methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
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
        [RequireCSfmlSystemFact]
        public void PollEvent_WaitEvent_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("PollEvent"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("WaitEvent"));
        }

        /// <summary>
        /// Tests that internal get mouse position internal set mouse position methods exist
        /// </summary>
        [RequireCSfmlSystemFact]
        public void InternalGetMousePosition_InternalSetMousePosition_Methods_Exist()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("InternalGetMousePosition"));
            Assert.NotNull(typeof(RenderWindow).GetMethod("InternalSetMousePosition"));
        }

        /// <summary>
        /// Tests that internal get touch position method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void InternalGetTouchPosition_Method_Exists()
        {
            Assert.NotNull(typeof(RenderWindow).GetMethod("InternalGetTouchPosition"));
        }
    }
}
