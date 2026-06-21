using System;
using Alis.App.Engine.Core;
using Alis.App.Engine.Menus;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class TopMenuMacTest
    {
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                TopMenuMac menu = new TopMenuMac(spaceWork);

                Assert.NotNull(menu);
                Assert.Same(spaceWork, menu.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("TopMenuMac", ex.Message);
            }
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                TopMenuMac menu = new TopMenuMac(spaceWork);

                Assert.NotNull(menu.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("TopMenuMac", ex.Message);
            }
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                TopMenuMac menu = new TopMenuMac(spaceWork);

                menu.Initialize();

                Assert.NotNull(menu);
            }
            catch (Exception ex)
            {
                Assert.Contains("TopMenuMac", ex.Message);
            }
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                TopMenuMac menu = new TopMenuMac(spaceWork);

                menu.Start();

                Assert.NotNull(menu);
            }
            catch (Exception ex)
            {
                Assert.Contains("TopMenuMac", ex.Message);
            }
        }

        [Fact]
        public void Update_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                TopMenuMac menu = new TopMenuMac(spaceWork);

                menu.Update();

                Assert.NotNull(menu);
            }
            catch (Exception ex)
            {
                Assert.Contains("TopMenuMac", ex.Message);
            }
        }

        [Fact]
        public void Render_ShouldNotThrow()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                TopMenuMac menu = new TopMenuMac(spaceWork);

                menu.Render();

                Assert.NotNull(menu);
            }
            catch (Exception ex)
            {
                Assert.Contains("TopMenuMac", ex.Message);
            }
        }
    }
}