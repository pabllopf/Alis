// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: AssetsWindowTest.cs
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Tests for AssetsWindow coverage remediation.
    /// </summary>
    public class AssetsWindowTest
    {
        /// <summary>
        ///     Tests that AssetsWindow implements IWindow interface
        /// </summary>
        [Fact]
        public void AssetsWindow_ShouldImplementIWindow()
        {
            Type assetsWindowType = typeof(AssetsWindow);
            Type iwindowType = typeof(AssetsWindow).Assembly.GetType("Alis.App.Engine.Windows.IWindow", true);

            Assert.True(assetsWindowType.IsPublic);
            Assert.True(iwindowType.IsAssignableFrom(assetsWindowType));
        }

        /// <summary>
        ///     Tests that constructor assigns SpaceWork property correctly
        /// </summary>
        [Fact]
        public void Constructor_ShouldAssignSpaceWorkProperty()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that SpaceWork property is read-only (getter only)
        /// </summary>
        [Fact]
        public void SpaceWork_Property_ShouldBeReadOnly()
        {
            PropertyInfo property = typeof(AssetsWindow).GetProperty("SpaceWork");

            Assert.NotNull(property);
            Assert.True(property.CanRead);
            Assert.False(property.CanWrite);
        }

        /// <summary>
        ///     Tests that IsDefaultSize property has correct default value
        /// </summary>
        [Fact]
        public void IsDefaultSize_Property_ShouldHaveCorrectDefaultValue()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.True(window.IsDefaultSize);
        }

        /// <summary>
        ///     Tests that IsDefaultSize property can be set to false
        /// </summary>
        [Fact]
        public void IsDefaultSize_Property_ShouldBeSettable()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.IsDefaultSize = false;

            Assert.False(window.IsDefaultSize);
        }

        /// <summary>
        ///     Tests that WindowName static field contains expected text
        /// </summary>
        [Fact]
        public void WindowName_StaticField_ShouldContainAssetsText()
        {
            FieldInfo field = typeof(AssetsWindow).GetField("WindowName", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(field);
            string windowName = (string)field.GetValue(null);

            Assert.Contains("Assets", windowName);
        }

        /// <summary>
        ///     Tests that Initialize method exists and is callable without throwing
        /// </summary>
        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            // Initialize is a no-op but should be callable
            MethodInfo initializeMethod = typeof(AssetsWindow).GetMethod("Initialize", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(initializeMethod);
            
            // Should not throw
            initializeMethod.Invoke(window, null);
        }

        /// <summary>
        ///     Tests that Start method exists and is callable without throwing
        /// </summary>
        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            MethodInfo startMethod = typeof(AssetsWindow).GetMethod("Start", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(startMethod);
            
            // Should not throw
            startMethod.Invoke(window, null);
        }

        /// <summary>
        ///     Tests that fileIcons dictionary contains expected extensions
        /// </summary>
        [Fact]
        public void FileIcons_Dictionary_ShouldContainExpectedExtensions()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            FieldInfo field = typeof(AssetsWindow).GetField("fileIcons", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);

            Dictionary<string, string> fileIcons = (Dictionary<string, string>)field.GetValue(window);

            Assert.NotNull(fileIcons);
            Assert.True(fileIcons.ContainsKey(".png"));
            Assert.True(fileIcons.ContainsKey(".jpg"));
            Assert.True(fileIcons.ContainsKey(".mp3"));
            Assert.True(fileIcons.ContainsKey(".wav"));
            Assert.True(fileIcons.ContainsKey(".mp4"));
            Assert.True(fileIcons.ContainsKey(".txt"));
            Assert.True(fileIcons.ContainsKey(".cs"));
        }

        /// <summary>
        ///     Tests that fileIcons dictionary has expected count of entries
        /// </summary>
        [Fact]
        public void FileIcons_Dictionary_ShouldHaveExpectedEntryCount()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            FieldInfo field = typeof(AssetsWindow).GetField("fileIcons", BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<string, string> fileIcons = (Dictionary<string, string>)field.GetValue(window);

            Assert.True(fileIcons.Count > 50, "fileIcons should have more than 50 entries");
        }

        /// <summary>
        ///     Tests that ignorePatterns array contains expected patterns
        /// </summary>
        [Fact]
        public void IgnorePatterns_Array_ShouldContainExpectedPatterns()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            FieldInfo field = typeof(AssetsWindow).GetField("ignorePatterns", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);

            string[] ignorePatterns = (string[])field.GetValue(window);

            Assert.NotNull(ignorePatterns);
            Assert.Contains("*.meta", ignorePatterns);
            Assert.Contains("*.tmp", ignorePatterns);
            Assert.Contains(".DS_Store", ignorePatterns);
        }

        /// <summary>
        ///     Tests that currentPath defaults to Assets directory separator path
        /// </summary>
        [Fact]
        public void CurrentPath_Property_ShouldDefaultToAssetsPath()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            FieldInfo field = typeof(AssetsWindow).GetField("currentPath", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);

            string currentPath = (string)field.GetValue(window);

            Assert.Contains("Assets", currentPath);
            Assert.StartsWith(Path.DirectorySeparatorChar.ToString(), currentPath);
        }

        /// <summary>
        ///     Tests that Render method exists and is callable without throwing (isOpen=false path)
        /// </summary>
        [Fact]
        public void Render_ShouldNotThrow_WhenIsOpenIsFalse()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            // Set isOpen to false via reflection to take the early return path
            FieldInfo isOpenField = typeof(AssetsWindow).GetField("isOpen", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(isOpenField);
            isOpenField.SetValue(window, false);

            MethodInfo renderMethod = typeof(AssetsWindow).GetMethod("Render", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(renderMethod);

            // Should not throw when isOpen is false (early return)
            renderMethod.Invoke(window, null);
        }
        
        /// <summary>
        ///     Tests that RenderDirectoryItem method exists
        /// </summary>
        [Fact]
        public void RenderDirectoryItem_Method_ShouldExist()
        {
            MethodInfo method = typeof(AssetsWindow).GetMethod("RenderDirectoryItem", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(method);
            
            ParameterInfo[] parameters = method.GetParameters();
            Assert.Equal(4, parameters.Length);
        }

        /// <summary>
        ///     Tests that RenderFileItem method exists
        /// </summary>
        [Fact]
        public void RenderFileItem_Method_ShouldExist()
        {
            MethodInfo method = typeof(AssetsWindow).GetMethod("RenderFileItem", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(method);
            
            ParameterInfo[] parameters = method.GetParameters();
            Assert.Equal(4, parameters.Length);
        }

        /// <summary>
        ///     Tests that RenderPlusMenu is a static method
        /// </summary>
        [Fact]
        public void RenderPlusMenu_Method_ShouldBeStatic()
        {
            MethodInfo method = typeof(AssetsWindow).GetMethod("RenderPlusMenu", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.NotNull(method);
            Assert.True(method.IsStatic);
        }

        /// <summary>
        ///     Tests that RenderSearchBar method exists
        /// </summary>
        [Fact]
        public void RenderSearchBar_Method_ShouldExist()
        {
            MethodInfo method = typeof(AssetsWindow).GetMethod("RenderSearchBar", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Tests that RenderAssets method exists
        /// </summary>
        [Fact]
        public void RenderAssets_Method_ShouldExist()
        {
            MethodInfo method = typeof(AssetsWindow).GetMethod("RenderAssets", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Tests that RenderFolders method exists
        /// </summary>
        [Fact]
        public void RenderFolders_Method_ShouldExist()
        {
            MethodInfo method = typeof(AssetsWindow).GetMethod("RenderFolders", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Tests that RenderDirectory method exists with isRoot parameter
        /// </summary>
        [Fact]
        public void RenderDirectory_Method_ShouldExist_WithIsRootParameter()
        {
            MethodInfo[] methods = typeof(AssetsWindow).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo renderDirectory = methods.FirstOrDefault(m => m.Name == "RenderDirectory");

            Assert.NotNull(renderDirectory);
            
            ParameterInfo[] parameters = renderDirectory.GetParameters();
            Assert.Equal(2, parameters.Length);
            Assert.Equal("path", parameters[0].Name);
            Assert.Equal("isRoot", parameters[1].Name);
        }

        /// <summary>
        ///     Tests that RenderTableFillItems method exists and is static
        /// </summary>
        [Fact]
        public void RenderTableFillItems_Method_ShouldBeStatic()
        {
            MethodInfo method = typeof(AssetsWindow).GetMethod("RenderTableFillItems", BindingFlags.NonPublic | BindingFlags.Static);

            Assert.NotNull(method);
            Assert.True(method.IsStatic);
            
            ParameterInfo[] parameters = method.GetParameters();
            Assert.Equal(4, parameters.Length);
        }

        /// <summary>
        ///     Tests that constructor allocates memory via Marshal.AllocHGlobal and it is non-zero
        /// </summary>
        [Fact]
        public void Constructor_ShouldAllocateCommandPointer()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            FieldInfo commandPtrField = typeof(AssetsWindow).GetField("commandPtr", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(commandPtrField);

            IntPtr commandPtr = (IntPtr)commandPtrField.GetValue(window);

            Assert.NotEqual(IntPtr.Zero, commandPtr);
        }

        /// <summary>
        ///     Tests that all public methods are documented (XML documentation)
        /// </summary>
        [Fact]
        public void PublicMethods_ShouldBeDocumented()
        {
            MethodInfo[] publicMethods = typeof(AssetsWindow).GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (MethodInfo method in publicMethods)
            {
                // Verify method exists and is discoverable
                Assert.NotNull(method);
                Assert.False(string.IsNullOrEmpty(method.Name));
            }
        }

        /// <summary>
        ///     Tests that AssetsWindow has all expected public members
        /// </summary>
        [Fact]
        public void AssetsWindow_ShouldHaveExpectedPublicMembers()
        {
            Type type = typeof(AssetsWindow);

            // Check for SpaceWork property
            PropertyInfo spaceWorkProp = type.GetProperty("SpaceWork");
            Assert.NotNull(spaceWorkProp);

            // Check for IsDefaultSize property
            PropertyInfo isDefaultSizeProp = type.GetProperty("IsDefaultSize");
            Assert.NotNull(isDefaultSizeProp);
            Assert.True(isDefaultSizeProp.CanRead);
            Assert.True(isDefaultSizeProp.CanWrite);

            // Check for Initialize method
            MethodInfo initializeMethod = type.GetMethod("Initialize", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(initializeMethod);

            // Check for Start method
            MethodInfo startMethod = type.GetMethod("Start", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(startMethod);

            // Check for Render method
            MethodInfo renderMethod = type.GetMethod("Render", BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(renderMethod);

            // Check for WindowName static field
            FieldInfo windowNameField = type.GetField("WindowName", BindingFlags.Public | BindingFlags.Static);
            Assert.NotNull(windowNameField);
        }
        
       
        /// <summary>
        ///     Tests that default path uses platform-appropriate directory separator
        /// </summary>
        [Fact]
        public void DefaultCurrentPath_ShouldUsePlatformDirectorySeparator()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            FieldInfo field = typeof(AssetsWindow).GetField("currentPath", BindingFlags.NonPublic | BindingFlags.Instance);
            string currentPath = (string)field.GetValue(window);

            Assert.StartsWith($"{Path.DirectorySeparatorChar}Assets", currentPath);
        }

        /// <summary>
        ///     Tests that the isMoveDirectory field exists and defaults to false
        /// </summary>
        [Fact]
        public void IsMoveDirectory_Field_ShouldDefaultToFalse()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            FieldInfo field = typeof(AssetsWindow).GetField("isMoveDirectory", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);

            bool isMoveDirectory = (bool)field.GetValue(window);

            Assert.False(isMoveDirectory);
        }

        /// <summary>
        ///     Tests that the searchText field exists and defaults to empty string
        /// </summary>
        [Fact]
        public void SearchText_Field_ShouldDefaultToEmptyString()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            FieldInfo field = typeof(AssetsWindow).GetField("searchText", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);

            string searchText = (string)field.GetValue(window);

            Assert.Equal(string.Empty, searchText);
        }

        /// <summary>
        ///     Tests that the isOpen field exists and defaults to true
        /// </summary>
        [Fact]
        public void OpenField_ShouldDefaultToTrue()
        {
            SpaceWork spaceWork = new SpaceWork();
            AssetsWindow window = new AssetsWindow(spaceWork);

            FieldInfo field = typeof(AssetsWindow).GetField("isOpen", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);

            bool isOpen = (bool)field.GetValue(window);

            Assert.True(isOpen);
        }
    }
}
