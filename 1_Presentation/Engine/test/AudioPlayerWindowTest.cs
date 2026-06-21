using System;
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class AudioPlayerWindowTest
    {
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            window.Initialize();

            Assert.NotNull(window);
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AudioPlayerWindow window = new AudioPlayerWindow(spaceWork);

            window.Start();

            Assert.NotNull(window);
        }

        [Fact]
        public void WindowName_ShouldContainAudioPlayer()
        {
            Assert.Contains("Audio", AudioPlayerWindow.WindowName, StringComparison.OrdinalIgnoreCase);
        }


    }
}
