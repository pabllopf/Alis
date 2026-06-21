using System;
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Menus;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class BottomMenuTest
    {
        private static SpaceWork CreateSpaceWork()
        {
            return (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
        }

        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            BottomMenu menu = new BottomMenu(spaceWork);

            Assert.NotNull(menu);
            Assert.Same(spaceWork, menu.SpaceWork);
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            BottomMenu menu = new BottomMenu(spaceWork);

            Assert.NotNull(menu.SpaceWork);
            Assert.Same(spaceWork, menu.SpaceWork);
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            BottomMenu menu = new BottomMenu(spaceWork);

            menu.Initialize();

            Assert.NotNull(menu);
        }

        [Fact]
        public void Update_ShouldNotThrow()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            BottomMenu menu = new BottomMenu(spaceWork);

            menu.Update();

            Assert.NotNull(menu);
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            BottomMenu menu = new BottomMenu(spaceWork);

            menu.Start();

            Assert.NotNull(menu);
        }

        [Fact]
        public void SpaceWork_Property_ShouldBeSameReference()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            BottomMenu menu = new BottomMenu(spaceWork);

            Assert.Same(spaceWork, menu.SpaceWork);
        }

        [Fact]
        public void SpaceWork_Property_ShouldNotBeNull()
        {
            SpaceWork spaceWork = CreateSpaceWork();
            BottomMenu menu = new BottomMenu(spaceWork);

            Assert.NotNull(menu.SpaceWork);
        }

        [Fact]
        public void MultipleInstances_ShouldHaveDifferentSpaceWork()
        {
            SpaceWork spaceWork1 = CreateSpaceWork();
            SpaceWork spaceWork2 = CreateSpaceWork();
            BottomMenu menu1 = new BottomMenu(spaceWork1);
            BottomMenu menu2 = new BottomMenu(spaceWork2);

            Assert.NotSame(menu1.SpaceWork, menu2.SpaceWork);
        }
    }
}
