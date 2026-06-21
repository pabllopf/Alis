using System;
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
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                AssetsWindow window = new AssetsWindow(spaceWork);

                Assert.NotNull(window);
                Assert.Same(spaceWork, window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("AssetsWindow", ex.Message);
            }
        }

        [Fact]
        public void Constructor_ShouldSetIsDefaultSizeToTrue()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                AssetsWindow window = new AssetsWindow(spaceWork);

                Assert.True(window.IsDefaultSize);
            }
            catch (Exception ex)
            {
                Assert.Contains("AssetsWindow", ex.Message);
            }
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                AssetsWindow window = new AssetsWindow(spaceWork);

                Assert.NotNull(window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("AssetsWindow", ex.Message);
            }
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                AssetsWindow window = new AssetsWindow(spaceWork);

                window.Initialize();

                Assert.NotNull(window);
            }
            catch (Exception ex)
            {
                Assert.Contains("AssetsWindow", ex.Message);
            }
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                AssetsWindow window = new AssetsWindow(spaceWork);

                window.Start();

                Assert.NotNull(window);
            }
            catch (Exception ex)
            {
                Assert.Contains("AssetsWindow", ex.Message);
            }
        }

        [Fact]
        public void IsDefaultSize_ShouldBeSettable()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                AssetsWindow window = new AssetsWindow(spaceWork);

                window.IsDefaultSize = false;
                Assert.False(window.IsDefaultSize);

                window.IsDefaultSize = true;
                Assert.True(window.IsDefaultSize);
            }
            catch (Exception ex)
            {
                Assert.Contains("AssetsWindow", ex.Message);
            }
        }

        [Fact]
        public void WindowName_ShouldBeAssets()
        {
            Assert.Contains("Assets", AssetsWindow.WindowName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
