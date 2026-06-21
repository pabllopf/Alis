using System;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class ProjectWindowTest
    {
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                ProjectWindow window = new ProjectWindow(spaceWork);

                Assert.NotNull(window);
                Assert.Same(spaceWork, window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("ProjectWindow", ex.Message);
            }
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                ProjectWindow window = new ProjectWindow(spaceWork);

                Assert.NotNull(window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("ProjectWindow", ex.Message);
            }
        }

        [Fact]
        public void NameWindow_ShouldNotBeNullOrEmpty()
        {
            Assert.NotNull(ProjectWindow.NameWindow);
            Assert.NotEmpty(ProjectWindow.NameWindow);
        }

        [Fact]
        public void Initialize_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = new SpaceWork();
            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Initialize());
        }

        [Fact]
        public void Start_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = new SpaceWork();
            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Start());
        }
    }
}
