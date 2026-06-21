using System;
using System.Runtime.CompilerServices;
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
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        [Fact]
        public void Constructor_WithNull_ShouldSetNullSpaceWork()
        {
            ProjectWindow window = new ProjectWindow(null);

            Assert.Null(window.SpaceWork);
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
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Initialize());
        }

        [Fact]
        public void Start_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Start());
        }

        [Fact]
        public void NameWindow_ShouldContainProject()
        {
            Assert.Contains("Project", ProjectWindow.NameWindow, StringComparison.OrdinalIgnoreCase);
        }
    }
}
