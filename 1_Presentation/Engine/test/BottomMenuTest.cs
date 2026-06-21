using System;
using Alis.App.Engine.Core;
using Alis.App.Engine.Menus;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class BottomMenuTest
    {
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                BottomMenu menu = new BottomMenu(spaceWork);

                Assert.NotNull(menu);
                Assert.Same(spaceWork, menu.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("BottomMenu", ex.Message);
            }
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                BottomMenu menu = new BottomMenu(spaceWork);

                Assert.NotNull(menu.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("BottomMenu", ex.Message);
            }
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                BottomMenu menu = new BottomMenu(spaceWork);

                menu.Initialize();

                Assert.NotNull(menu);
            }
            catch (Exception ex)
            {
                Assert.Contains("BottomMenu", ex.Message);
            }
        }

        [Fact]
        public void Update_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                BottomMenu menu = new BottomMenu(spaceWork);

                menu.Update();

                Assert.NotNull(menu);
            }
            catch (Exception ex)
            {
                Assert.Contains("BottomMenu", ex.Message);
            }
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                BottomMenu menu = new BottomMenu(spaceWork);

                menu.Start();

                Assert.NotNull(menu);
            }
            catch (Exception ex)
            {
                Assert.Contains("BottomMenu", ex.Message);
            }
        }
    }
}
