using System;
using System.Runtime.CompilerServices;
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
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            Assert.NotNull(menu);
            Assert.Same(spaceWork, menu.SpaceWork);
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            Assert.NotNull(menu.SpaceWork);
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            menu.Initialize();

            Assert.NotNull(menu);
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            menu.Start();

            Assert.NotNull(menu);
        }

        [Fact]
        public void Update_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            menu.Update();

            Assert.NotNull(menu);
        }

        [Fact]
        public void Render_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            menu.Render();

            Assert.NotNull(menu);
        }
    }
}
