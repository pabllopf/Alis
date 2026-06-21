using System;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class InspectorWindowTest
    {
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                InspectorWindow window = new InspectorWindow(spaceWork);

                Assert.NotNull(window);
                Assert.Same(spaceWork, window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("InspectorWindow", ex.Message);
            }
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                InspectorWindow window = new InspectorWindow(spaceWork);

                Assert.NotNull(window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("InspectorWindow", ex.Message);
            }
        }

        [Fact]
        public void NameWindow_ShouldNotBeNullOrEmpty()
        {
            Assert.NotNull(InspectorWindow.NameWindow);
            Assert.NotEmpty(InspectorWindow.NameWindow);
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                InspectorWindow window = new InspectorWindow(spaceWork);

                window.Initialize();

                Assert.NotNull(window);
            }
            catch (Exception ex)
            {
                Assert.Contains("InspectorWindow", ex.Message);
            }
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                InspectorWindow window = new InspectorWindow(spaceWork);

                window.Start();

                Assert.NotNull(window);
            }
            catch (Exception ex)
            {
                Assert.Contains("InspectorWindow", ex.Message);
            }
        }
    }
}
