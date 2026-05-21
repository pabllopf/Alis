// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IWindowTest.cs
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

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     Unit tests for the IWindow interface.
    /// </summary>
    public class IWindowTest
    {
        /// <summary>
        ///     Tests that IWindow interface can be implemented.
        /// </summary>
        [Fact]
        public void IWindow_CanBeImplemented_CreatesValidInstance()
        {
            IWindow window = new MockWindow();

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Tests that Background property can be set and retrieved.
        /// </summary>
        [Fact]
        public void IWindow_SetBackground_RetrievesColorCorrectly()
        {
            IWindow window = new MockWindow();
            Color color = new Color(255, 128, 64, 255);

            window.Background = color;
            Color retrievedColor = window.Background;

            Assert.Equal(color, retrievedColor);
        }

        /// <summary>
        ///     Tests that Resolution property can be set and retrieved.
        /// </summary>
        [Fact]
        public void IWindow_SetResolution_RetrievesVectorCorrectly()
        {
            IWindow window = new MockWindow();
            Vector2F resolution = new Vector2F(1920, 1080);

            window.Resolution = resolution;
            Vector2F retrievedResolution = window.Resolution;

            Assert.Equal(resolution, retrievedResolution);
        }

        /// <summary>
        ///     Tests that IsWindowResizable property can be set and retrieved.
        /// </summary>
        [Fact]
        public void IWindow_SetIsWindowResizable_RetrievesBoolCorrectly()
        {
            IWindow window = new MockWindow();

            window.IsWindowResizable = true;
            bool isResizable = window.IsWindowResizable;

            Assert.True(isResizable);
        }

        /// <summary>
        ///     Tests setting IsWindowResizable to false.
        /// </summary>
        [Fact]
        public void IWindow_SetIsWindowResizableFalse_ReturnsFalse()
        {
            IWindow window = new MockWindow();

            window.IsWindowResizable = false;
            bool isResizable = window.IsWindowResizable;

            Assert.False(isResizable);
        }

        /// <summary>
        ///     Tests multiple property modifications.
        /// </summary>
        [Fact]
        public void IWindow_ModifyMultipleProperties_AllPropertiesUpdateCorrectly()
        {
            IWindow window = new MockWindow();
            Color expectedColor = new Color(100, 150, 200, 255);
            Vector2F expectedResolution = new Vector2F(800, 600);

            window.Background = expectedColor;
            window.Resolution = expectedResolution;
            window.IsWindowResizable = true;

            Assert.Equal(expectedColor, window.Background);
            Assert.Equal(expectedResolution, window.Resolution);
            Assert.True(window.IsWindowResizable);
        }

        /// <summary>
        ///     Tests that different window instances are independent.
        /// </summary>
        [Fact]
        public void IWindow_MultipleInstances_AreIndependent()
        {
            IWindow window1 = new MockWindow();
            IWindow window2 = new MockWindow();
            Color color1 = new Color(255, 0, 0, 255);
            Color color2 = new Color(0, 255, 0, 255);

            window1.Background = color1;
            window2.Background = color2;

            Assert.Equal(color1, window1.Background);
            Assert.Equal(color2, window2.Background);
            Assert.NotEqual(window1.Background, window2.Background);
        }

        /// <summary>
        ///     Tests setting Resolution with various sizes.
        /// </summary>
        [Theory, InlineData(640, 480), InlineData(1024, 768), InlineData(1920, 1080), InlineData(2560, 1440)]
        public void IWindow_SetResolution_WithVariousSizes_StoresCorrectly(float width, float height)
        {
            IWindow window = new MockWindow();
            Vector2F resolution = new Vector2F(width, height);

            window.Resolution = resolution;

            Assert.Equal(width, window.Resolution.X);
            Assert.Equal(height, window.Resolution.Y);
        }

        /// <summary>
        ///     Tests setting Background with various colors.
        /// </summary>
        [Fact]
        public void IWindow_SetBackground_WithBlackColor_StoresCorrectly()
        {
            IWindow window = new MockWindow();
            Color blackColor = new Color(0, 0, 0, 255);

            window.Background = blackColor;

            Assert.Equal(blackColor, window.Background);
        }

        /// <summary>
        ///     Tests setting Background with white color.
        /// </summary>
        [Fact]
        public void IWindow_SetBackground_WithWhiteColor_StoresCorrectly()
        {
            IWindow window = new MockWindow();
            Color whiteColor = new Color(255, 255, 255, 255);

            window.Background = whiteColor;

            Assert.Equal(whiteColor, window.Background);
        }

        /// <summary>
        ///     Mock implementation of IWindow for testing.
        /// </summary>
        private class MockWindow : IWindow
        {
            /// <summary>
            ///     Gets or sets the background color.
            /// </summary>
            public Color Background { get; set; }

            /// <summary>
            ///     Gets or sets the resolution.
            /// </summary>
            public Vector2F Resolution { get; set; }

            /// <summary>
            ///     Gets or sets a value indicating whether the window is resizable.
            /// </summary>
            public bool IsWindowResizable { get; set; }
        }
    }
}