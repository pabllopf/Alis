using System;
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class AssetsWindowTest
    {
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        [Fact]
        public void Constructor_ShouldSetIsDefaultSizeToTrue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.True(window.IsDefaultSize);
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.Initialize();

            Assert.NotNull(window);
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.Start();

            Assert.NotNull(window);
        }

        [Fact]
        public void IsDefaultSize_ShouldBeSettable()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            AssetsWindow window = new AssetsWindow(spaceWork);

            window.IsDefaultSize = false;
            Assert.False(window.IsDefaultSize);

            window.IsDefaultSize = true;
            Assert.True(window.IsDefaultSize);
        }

        [Fact]
        public void WindowName_ShouldBeAssets()
        {
            Assert.Contains("Assets", AssetsWindow.WindowName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
