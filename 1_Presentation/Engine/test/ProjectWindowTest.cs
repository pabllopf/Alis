using System;
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    /// The project window test class
    /// </summary>
    public class ProjectWindowTest
    {
        /// <summary>
        /// Tests that constructor should set space work
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        /// Tests that space work property should return set value
        /// </summary>
        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        /// Tests that constructor with null should set null space work
        /// </summary>
        [Fact]
        public void Constructor_WithNull_ShouldSetNullSpaceWork()
        {
            ProjectWindow window = new ProjectWindow(null);

            Assert.Null(window.SpaceWork);
        }

        /// <summary>
        /// Tests that name window should not be null or empty
        /// </summary>
        [Fact]
        public void NameWindow_ShouldNotBeNullOrEmpty()
        {
            Assert.NotNull(ProjectWindow.NameWindow);
            Assert.NotEmpty(ProjectWindow.NameWindow);
        }

        /// <summary>
        /// Tests that initialize throws not implemented exception
        /// </summary>
        [Fact]
        public void Initialize_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Initialize());
        }

        /// <summary>
        /// Tests that start throws not implemented exception
        /// </summary>
        [Fact]
        public void Start_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            ProjectWindow window = new ProjectWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Start());
        }

        /// <summary>
        /// Tests that name window should contain project
        /// </summary>
        [Fact]
        public void NameWindow_ShouldContainProject()
        {
            Assert.Contains("Project", ProjectWindow.NameWindow, StringComparison.OrdinalIgnoreCase);
        }
    }
}
