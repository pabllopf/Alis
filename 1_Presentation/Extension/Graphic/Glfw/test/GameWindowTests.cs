// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameWindowTests.cs
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
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    public class GameWindowTests : IDisposable
    {
        private GameWindow window;

        public void Dispose()
        {
            window?.Dispose();
        }

        [RequiresDisplay]
        public void GameWindow_DefaultConstructor_CreatesWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow();

            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        [RequiresDisplay]
        public void GameWindow_ConstructorWithParameters_CreatesWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow(800, 600, "Test Game Window");

            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        [RequiresDisplay]
        public void GameWindow_ConstructorWithAllParameters_CreatesWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow(1024, 768, "Full Test Window", Monitor.None, Window.None);

            Assert.NotNull(window);
            Assert.False(window.IsInvalid);
        }

        [RequiresDisplay]
        public void GameWindow_InheritsFromNativeWindow()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow();
            
            window.Close();

            Assert.IsAssignableFrom<NativeWindow>(window);
        }

        [RequiresDisplay]
        public void GameWindow_CanBeDisposed()
        {
            GlfwNative.WindowHint(Hint.Visible, false);
            window = new GameWindow(800, 600, "Disposable Window");

            window.Dispose();
            
            Assert.True(window.IsInvalid);
        }

        [RequiresDisplay]
        public void GameWindow_WithCustomSize_HasCorrectSize()
        {
            int expectedWidth = 1280;
            int expectedHeight = 720;
            GlfwNative.WindowHint(Hint.Visible, false);

            window = new GameWindow(expectedWidth, expectedHeight, "Sized Window");
            Size size = window.Size;

            Assert.Equal(expectedWidth, size.Width);
            Assert.Equal(expectedHeight, size.Height);
        }

        [Fact]
        public void GameWindow_IsPublicClass()
        {
            Type type = typeof(GameWindow);
            Assert.True(type.IsPublic);
        }

        [Fact]
        public void GameWindow_InheritsFromNativeWindow_Reflection()
        {
            Type type = typeof(GameWindow);
            Assert.Equal(typeof(NativeWindow), type.BaseType);
        }

        [Fact]
        public void GameWindow_HasDefaultConstructor_Reflection()
        {
            Type type = typeof(GameWindow);
            System.Reflection.ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
            Assert.NotNull(ctor);
            Assert.True(ctor.IsPublic);
        }

        [Fact]
        public void GameWindow_HasConstructorWithWidthHeightTitle_Reflection()
        {
            Type type = typeof(GameWindow);
            System.Reflection.ConstructorInfo ctor = type.GetConstructor(new[] { typeof(int), typeof(int), typeof(string) });
            Assert.NotNull(ctor);
            Assert.True(ctor.IsPublic);
        }

        [Fact]
        public void GameWindow_HasConstructorWithAllParams_Reflection()
        {
            Type type = typeof(GameWindow);
            System.Reflection.ConstructorInfo ctor = type.GetConstructor(new[] { typeof(int), typeof(int), typeof(string), typeof(Monitor), typeof(Window) });
            Assert.NotNull(ctor);
            Assert.True(ctor.IsPublic);
        }
    }
}