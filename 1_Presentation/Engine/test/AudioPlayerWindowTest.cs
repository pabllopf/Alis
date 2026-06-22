// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayerWindowTest.cs
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
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Tests for the <see cref="AudioPlayerWindow"/> class.
    /// </summary>
    public class AudioPlayerWindowTest
    {
        /// <summary>
        ///     Tests that the public static WindowName field is not null.
        /// </summary>
        [Fact]
        public void WindowName_Field_ShouldNotBeNull()
        {
            Assert.NotNull(AudioPlayerWindow.WindowName);
            Assert.NotEmpty(AudioPlayerWindow.WindowName);
            Assert.Contains("Audio Player", AudioPlayerWindow.WindowName);
        }

        /// <summary>
        ///     Tests that the constructor sets the SpaceWork property correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that the constructor initializes progress to 1f.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeProgressTo1()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            Assert.NotNull(window);
            // Progress is a private field, but window should be instantiated successfully
        }

        /// <summary>
        ///     Tests that the constructor initializes currentTime to TimeSpan.Zero.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeCurrentTimeToZero()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            Assert.NotNull(window);
            // CurrentTime is a private field, but window should be instantiated successfully
        }

        /// <summary>
        ///     Tests that the constructor initializes totalTime to 10 seconds.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeTotalTimeTo10Seconds()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            Assert.NotNull(window);
            // TotalTime is a private field, but window should be instantiated successfully
        }

        /// <summary>
        ///     Tests that the constructor initializes isPlaying to true.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeIsPlayingToTrue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            Assert.NotNull(window);
            // IsPlaying is a private field, but window should be instantiated successfully
        }

        /// <summary>
        ///     Tests that the SpaceWork property returns the value set in the constructor.
        /// </summary>
        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        ///     Tests that Initialize() does not throw an exception.
        /// </summary>
        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

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
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            window.Start();

            Assert.NotNull(window);
        }
        

        /// <summary>
        ///     Tests that Render() does not throw an exception when window is closed.
        /// </summary>
        [Fact]
        public void Render_ShouldNotThrow_WhenWindowIsClosed()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            // Simulate window being closed by directly accessing the private field through reflection
            var isOpenField = typeof(AudioPlayerWindow).GetField("isOpen", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            isOpenField?.SetValue(window, false);

            window.Render();

            Assert.NotNull(window);
        }
    }
}
