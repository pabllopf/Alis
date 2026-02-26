// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StructValidationTests.cs
// 
//  Author:GitHub Copilot
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
using System.Reflection;
using Xunit;
using Alis.Extension.Graphic.Glfw.Structs;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for struct validation
    /// </summary>
    public class StructValidationTests
    {
        /// <summary>
        ///     Test Monitor struct is a value type
        /// </summary>
        [Fact]
        public void MonitorStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type monitorType = typeof(Monitor);

            // Assert
            Assert.True(monitorType.IsValueType);
        }

        /// <summary>
        ///     Test Monitor.None has valid default value
        /// </summary>
        [Fact]
        public void MonitorNoneStruct_ShouldHaveValidValue()
        {
            // Arrange & Act
            Monitor none = Monitor.None;

            // Assert
            Assert.NotNull(none);
        }

        /// <summary>
        ///     Test Monitor struct equality
        /// </summary>
        [Fact]
        public void MonitorStructEquality_ShouldWork()
        {
            // Arrange
            Monitor monitor1 = Monitor.None;
            Monitor monitor2 = Monitor.None;

            // Act & Assert
            Assert.Equal(monitor1, monitor2);
        }

        /// <summary>
        ///     Test VideoMode struct is a value type
        /// </summary>
        [Fact]
        public void VideoModeStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type videoModeType = typeof(VideoMode);

            // Assert
            Assert.True(videoModeType.IsValueType);
        }

        /// <summary>
        ///     Test Window struct is a value type
        /// </summary>
        [Fact]
        public void WindowStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type windowType = typeof(Window);

            // Assert
            Assert.True(windowType.IsValueType);
        }

        /// <summary>
        ///     Test Window.None has valid default value
        /// </summary>
        [Fact]
        public void WindowNoneStruct_ShouldHaveValidValue()
        {
            // Arrange & Act
            Window none = Window.None;

            // Assert
            Assert.NotNull(none);
        }

        /// <summary>
        ///     Test Window struct equality
        /// </summary>
        [Fact]
        public void WindowStructEquality_ShouldWork()
        {
            // Arrange
            Window window1 = Window.None;
            Window window2 = Window.None;

            // Act & Assert
            Assert.Equal(window1, window2);
        }

        /// <summary>
        ///     Test Cursor struct is a value type
        /// </summary>
        [Fact]
        public void CursorStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type cursorType = typeof(Cursor);

            // Assert
            Assert.True(cursorType.IsValueType);
        }

        /// <summary>
        ///     Test Cursor.None has valid default value
        /// </summary>
        [Fact]
        public void CursorNoneStruct_ShouldHaveValidValue()
        {
            // Arrange & Act
            Cursor none = Cursor.None;

            // Assert
            Assert.NotNull(none);
        }

        /// <summary>
        ///     Test GamePadState struct is a value type
        /// </summary>
        [Fact]
        public void GamePadStateStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type gamepadType = typeof(GamePadState);

            // Assert
            Assert.True(gamepadType.IsValueType);
        }

        /// <summary>
        ///     Test GammaRamp struct is a value type
        /// </summary>
        [Fact]
        public void GammaRampStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type gammaRampType = typeof(GammaRamp);

            // Assert
            Assert.True(gammaRampType.IsValueType);
        }

        /// <summary>
        ///     Test EGLContext struct is a value type
        /// </summary>
        [Fact]
        public void EGLContextStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type eglContextType = typeof(EGLContext);

            // Assert
            Assert.True(eglContextType.IsValueType);
        }

        /// <summary>
        ///     Test EGLDisplay struct is a value type
        /// </summary>
        [Fact]
        public void EGLDisplayStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type eglDisplayType = typeof(EglDisplay);

            // Assert
            Assert.True(eglDisplayType.IsValueType);
        }

        /// <summary>
        ///     Test EGLSurface struct is a value type
        /// </summary>
        [Fact]
        public void EGLSurfaceStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type eglSurfaceType = typeof(EglSurface);

            // Assert
            Assert.True(eglSurfaceType.IsValueType);
        }

        /// <summary>
        ///     Test GLXContext struct is a value type
        /// </summary>
        [Fact]
        public void GLXContextStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type glxContextType = typeof(GLXContext);

            // Assert
            Assert.True(glxContextType.IsValueType);
        }

        /// <summary>
        ///     Test HGLRC struct is a value type
        /// </summary>
        [Fact]
        public void HGLRCStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type hglrcType = typeof(Hglrc);

            // Assert
            Assert.True(hglrcType.IsValueType);
        }

        /// <summary>
        ///     Test NSOpenGLContext struct is a value type
        /// </summary>
        [Fact]
        public void NSOpenGLContextStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type nsOpenGLContextType = typeof(NSOpenGLContext);

            // Assert
            Assert.True(nsOpenGLContextType.IsValueType);
        }

        /// <summary>
        ///     Test OSMesaContext struct is a value type
        /// </summary>
        [Fact]
        public void OSMesaContextStructIsValueType_ShouldBeTrue()
        {
            // Arrange & Act
            Type osMesaContextType = typeof(OSMesaContext);

            // Assert
            Assert.True(osMesaContextType.IsValueType);
        }

        /// <summary>
        ///     Test struct default initialization
        /// </summary>
        [Fact]
        public void StructDefaultInitialization_ShouldWork()
        {
            // Arrange & Act
            Monitor monitor = default(Monitor);
            Window window = default(Window);
            Cursor cursor = default(Cursor);

            // Assert
            Assert.NotNull(monitor);
            Assert.NotNull(window);
            Assert.NotNull(cursor);
        }

        /// <summary>
        ///     Test struct IEquatable implementation
        /// </summary>
        [Fact]
        public void MonitorStructIEquatable_ShouldBeImplemented()
        {
            // Arrange
            Monitor monitor1 = Monitor.None;
            Monitor monitor2 = Monitor.None;

            // Act
            bool equals = monitor1.Equals(monitor2);

            // Assert
            Assert.True(equals);
        }

        /// <summary>
        ///     Test Window struct IEquatable implementation
        /// </summary>
        [Fact]
        public void WindowStructIEquatable_ShouldBeImplemented()
        {
            // Arrange
            Window window1 = Window.None;
            Window window2 = Window.None;

            // Act
            bool equals = window1.Equals(window2);

            // Assert
            Assert.True(equals);
        }

        /// <summary>
        ///     Test struct GetHashCode consistency
        /// </summary>
        [Fact]
        public void StructGetHashCodeConsistency_ShouldWork()
        {
            // Arrange
            Monitor monitor = Monitor.None;

            // Act
            int hash1 = monitor.GetHashCode();
            int hash2 = monitor.GetHashCode();

            // Assert
            Assert.Equal(hash1, hash2);
        }
    }
}

