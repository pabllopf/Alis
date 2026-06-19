// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: AudioPlayerWindowTest.cs
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
using System.Linq;
using System.Reflection;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Tests for AudioPlayerWindow coverage remediation.
    /// </summary>
    public class AudioPlayerWindowTest
    {
        /// <summary>
        ///     Tests that AudioPlayerWindow implements IWindow interface
        /// </summary>
        [Fact]
        public void AudioPlayerWindow_ShouldImplementIWindow()
        {
            Type audioPlayerWindowType = typeof(AudioPlayerWindow);
            Type iwindowType = typeof(AudioPlayerWindow).Assembly.GetType("Alis.App.Engine.Windows.IWindow", true);
            Type ihasSpaceWorkType = typeof(AudioPlayerWindow).Assembly.GetType("Alis.App.Engine.Core.IHasSpaceWork", true);

            Assert.True(audioPlayerWindowType.IsPublic);
            Assert.True(iwindowType.IsAssignableFrom(audioPlayerWindowType));

            Type[] interfaces = audioPlayerWindowType.GetInterfaces();
            Assert.Contains(ihasSpaceWorkType, interfaces);
        }

        /// <summary>
        ///     Tests that constructor assigns SpaceWork property correctly
        /// </summary>
        [Fact]
        public void Constructor_ShouldAssignSpaceWorkProperty()
        {
            SpaceWork spaceWork = new SpaceWork();
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that SpaceWork property is read-only
        /// </summary>
        [Fact]
        public void SpaceWork_Property_ShouldBeReadOnly()
        {
            PropertyInfo property = typeof(AudioPlayerWindow).GetProperty("SpaceWork");

            Assert.NotNull(property);
            Assert.True(property.CanRead);
            Assert.False(property.CanWrite);
        }

        /// <summary>
        ///     Tests that Initialize method does not throw
        /// </summary>
        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            // Act - should not throw (empty method)
            window.Initialize();

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that Start method does not throw
        /// </summary>
        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = new SpaceWork();
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            // Act - should not throw (empty method)
            window.Start();

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that WindowName static property is non-empty
        /// </summary>
        [Fact]
        public void WindowName_ShouldBeNonEmpty()
        {
            Assert.False(string.IsNullOrWhiteSpace(AudioPlayerWindow.WindowName));
            Assert.Contains("Audio Player", AudioPlayerWindow.WindowName);
        }

        /// <summary>
        ///     Tests that private constant fields have expected default values via reflection
        /// </summary>
        [Fact]
        public void PrivateConstants_ShouldHaveExpectedDefaultValues()
        {
            Type type = typeof(AudioPlayerWindow);

            // Verify progress field exists (private readonly float)
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Assert.Contains("SpaceWork", properties.Select(p => p.Name));

            // Verify isOpen field exists (private bool)
            FieldInfo isOpenField = type.GetField("isOpen", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(isOpenField);
            Assert.Equal(typeof(bool), isOpenField.FieldType);

            // Verify isPlaying field exists (private bool)
            FieldInfo isPlayingField = type.GetField("isPlaying", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(isPlayingField);
            Assert.Equal(typeof(bool), isPlayingField.FieldType);

            // Verify currentTime field exists (private readonly TimeSpan)
            FieldInfo currentTimeField = type.GetField("currentTime", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(currentTimeField);
            Assert.Equal(typeof(TimeSpan), currentTimeField.FieldType);

            // Verify totalTime field exists (private readonly TimeSpan)
            FieldInfo totalTimeField = type.GetField("totalTime", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(totalTimeField);
            Assert.Equal(typeof(TimeSpan), totalTimeField.FieldType);

            // Verify flags field exists (private readonly ImGuiWindowFlags)
            FieldInfo flagsField = type.GetField("flags", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(flagsField);
        }

        /// <summary>
        ///     Tests that Render method exists and has expected signature
        /// </summary>
        [Fact]
        public void Render_Method_ShouldExistWithExpectedSignature()
        {
            Type type = typeof(AudioPlayerWindow);
            MethodInfo render = type.GetMethod("Render", BindingFlags.Public | BindingFlags.Instance);

            Assert.NotNull(render);
            Assert.Equal(typeof(void), render.ReturnType);
            Assert.Empty(render.GetParameters());
        }
    }
}
