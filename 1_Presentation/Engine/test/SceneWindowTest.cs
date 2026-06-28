using System;
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    /// The scene window test class
    /// </summary>
    public class SceneWindowTest
    {
        /// <summary>
        /// Tests that constructor should set space work
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            SceneWindow window = new SceneWindow(spaceWork);

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
            SceneWindow window = new SceneWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
        }

        /// <summary>
        /// Tests that name window should not be null or empty
        /// </summary>
        [Fact]
        public void NameWindow_ShouldNotBeNullOrEmpty()
        {
            Assert.NotNull(SceneWindow.NameWindow);
            Assert.NotEmpty(SceneWindow.NameWindow);
        }

        /// <summary>
        /// Tests that initialize should not throw
        /// </summary>
        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            SceneWindow window = new SceneWindow(spaceWork);

            window.Initialize();

            Assert.NotNull(window);
        }

        /// <summary>
        /// Tests that start should not throw
        /// </summary>
        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            SceneWindow window = new SceneWindow(spaceWork);

            window.Start();

            Assert.NotNull(window);
        }
    }
}
