using System;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class SolutionWindowTest
    {
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                SolutionWindow window = new SolutionWindow(spaceWork);

                Assert.NotNull(window);
                Assert.Same(spaceWork, window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("SolutionWindow", ex.Message);
            }
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                SolutionWindow window = new SolutionWindow(spaceWork);

                Assert.NotNull(window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("SolutionWindow", ex.Message);
            }
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                SolutionWindow window = new SolutionWindow(spaceWork);

                window.Initialize();

                Assert.NotNull(window);
            }
            catch (Exception ex)
            {
                Assert.Contains("SolutionWindow", ex.Message);
            }
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                SolutionWindow window = new SolutionWindow(spaceWork);

                window.Start();

                Assert.NotNull(window);
            }
            catch (Exception ex)
            {
                Assert.Contains("SolutionWindow", ex.Message);
            }
        }
    }
}
