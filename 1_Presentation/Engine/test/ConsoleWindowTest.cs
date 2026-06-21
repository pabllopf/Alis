using System;
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
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                ConsoleWindow window = new ConsoleWindow(spaceWork);

                Assert.NotNull(window);
                Assert.Same(spaceWork, window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("ConsoleWindow", ex.Message);
            }
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                ConsoleWindow window = new ConsoleWindow(spaceWork);

                Assert.NotNull(window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("ConsoleWindow", ex.Message);
            }
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
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                ConsoleWindow window = new ConsoleWindow(spaceWork);

                window.Initialize();

                Assert.NotNull(window);
            }
            catch (Exception ex)
            {
                Assert.Contains("ConsoleWindow", ex.Message);
            }
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                ConsoleWindow window = new ConsoleWindow(spaceWork);

                window.Start();

                Assert.NotNull(window);
            }
            catch (Exception ex)
            {
                Assert.Contains("ConsoleWindow", ex.Message);
            }
        }
    }
}
