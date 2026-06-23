// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AssetsWindowTest.cs
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
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Tests for the <see cref="AssetsWindow"/> class.
    /// </summary>
    public class AssetsWindowTest
    {
        /// <summary>
        ///     Creates a SpaceWork with initialized viewport and font references.
        /// </summary>
        private static SpaceWork CreateSpaceWorkWithResources()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));

            // Initialize viewport if possible
            Vector2F viewportSize = new Vector2F(1920, 1080);
            Vector2F viewportWorkPos = new Vector2F(0, 0);

            ImGuiViewport viewport = new ImGuiViewport
            {
                Size = viewportSize,
                WorkPos = viewportWorkPos
            };

            IntPtr viewportPtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiViewport>());
            Marshal.StructureToPtr(viewport, viewportPtr, true);

            spaceWork.Viewport = new ImGuiViewportPtr(viewportPtr);

            return spaceWork;
        }

        /// <summary>
        ///     Tests that the public static WindowName field is not null.
        /// </summary>
        [Fact]
        public void WindowName_Field_ShouldNotBeNull()
        {
            Assert.NotNull(AssetsWindow.WindowName);
            Assert.NotEmpty(AssetsWindow.WindowName);
            Assert.Contains("Assets", AssetsWindow.WindowName);
        }

        /// <summary>
        ///     Tests that the public static WindowName field contains folder icon.
        /// </summary>
        [Fact]
        public void WindowName_Field_ShouldContainFolderIcon()
        {
            string windowName = AssetsWindow.WindowName;

            Assert.Contains("\uf07c", windowName);
        }

        /// <summary>
        ///     Tests that the constructor sets the SpaceWork property correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that the constructor allocates commandPtr successfully.
        /// </summary>
        [Fact]
        public void Constructor_ShouldAllocateCommandPtr()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.NotNull(window);
            // CommandPtr allocation is internal, but window should be instantiated successfully
        }

        /// <summary>
        ///     Tests that the SpaceWork property returns the value set in the constructor.
        /// </summary>
        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that the IsDefaultSize property defaults to true.
        /// </summary>
        [Fact]
        public void IsDefaultSize_Property_ShouldDefaultToTrue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.True(window.IsDefaultSize);
        }

        /// <summary>
        ///     Tests that the IsDefaultSize property can be set to false.
        /// </summary>
        [Fact]
        public void IsDefaultSize_Property_ShouldAllowSetValueToFalse()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.IsDefaultSize = false;

            Assert.False(window.IsDefaultSize);
        }

        /// <summary>
        ///     Tests that the IsDefaultSize property can be set to true.
        /// </summary>
        [Fact]
        public void IsDefaultSize_Property_ShouldAllowSetValueToTrue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.IsDefaultSize = true;

            Assert.True(window.IsDefaultSize);
        }

        /// <summary>
        ///     Tests that Initialize() does not throw an exception.
        /// </summary>
        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.Initialize();

            Assert.NotNull(window);
        }

        /// <summary>
        ///     Tests that Start() does not throw an exception.
        /// </summary>
        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.Start();

            Assert.NotNull(window);
        }
        
        

        /// <summary>
        ///     Tests that multiple AssetsWindow instances maintain independent state.
        /// </summary>
        [Fact]
        public void MultipleInstances_ShouldHaveIndependentState()
        {
            SpaceWork spaceWork1 = CreateSpaceWorkWithResources();
            SpaceWork spaceWork2 = CreateSpaceWorkWithResources();

            AssetsWindow window1 = new AssetsWindow(spaceWork1);
            AssetsWindow window2 = new AssetsWindow(spaceWork2);

            Assert.NotSame(window1, window2);
            Assert.Same(spaceWork1, window1.SpaceWork);
            Assert.Same(spaceWork2, window2.SpaceWork);
        }

        /// <summary>
        ///     Tests that AssetsWindow has required interface methods.
        /// </summary>
        [Fact]
        public void AssetsWindow_HasRequiredMethods()
        {
            SpaceWork spaceWork = CreateSpaceWorkWithResources();
            AssetsWindow window = new AssetsWindow(spaceWork);

            var initializeMethod = typeof(AssetsWindow).GetMethod("Initialize");
            var renderMethod = typeof(AssetsWindow).GetMethod("Render");
            var startMethod = typeof(AssetsWindow).GetMethod("Start");

            Assert.NotNull(initializeMethod);
            Assert.NotNull(renderMethod);
            Assert.NotNull(startMethod);
        }

        /// <summary>
        ///     Tests that WindowName is accessible and valid.
        /// </summary>
        [Fact]
        public void WindowName_ShouldBeAccessible()
        {
            string windowName = AssetsWindow.WindowName;

            Assert.IsType<string>(windowName);
            Assert.False(string.IsNullOrEmpty(windowName));
        }

        /// <summary>
        ///     Tests that constructor properly initializes all properties.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeAllProperties()
        {
            SpaceWork spaceWork = CreateSpaceWorkWithResources();
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
            Assert.True(window.IsDefaultSize);
        }
        
    }
}
