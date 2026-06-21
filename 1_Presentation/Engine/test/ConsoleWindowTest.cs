using System;
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class ConsoleWindowTest
    {
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ConsoleWindow window = new ConsoleWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ConsoleWindow window = new ConsoleWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
        }

        [Fact]
        public void NameWindow_ShouldNotBeNullOrEmpty()
        {
            Assert.NotNull(ConsoleWindow.NameWindow);
            Assert.NotEmpty(ConsoleWindow.NameWindow);
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ConsoleWindow window = new ConsoleWindow(spaceWork);

            window.Initialize();

            Assert.NotNull(window);
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ConsoleWindow window = new ConsoleWindow(spaceWork);

            window.Start();

            Assert.NotNull(window);
        }
    }
}
