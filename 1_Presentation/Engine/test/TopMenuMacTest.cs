using System;
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Menus;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    /// The top menu mac test class
    /// </summary>
    public class TopMenuMacTest
    {
        /// <summary>
        /// Tests that constructor should set space work
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            Assert.NotNull(menu);
            Assert.Same(spaceWork, menu.SpaceWork);
        }

        /// <summary>
        /// Tests that space work property should return set value
        /// </summary>
        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            Assert.NotNull(menu.SpaceWork);
        }

        /// <summary>
        /// Tests that initialize should not throw
        /// </summary>
        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            menu.Initialize();

            Assert.NotNull(menu);
        }

        /// <summary>
        /// Tests that start should not throw
        /// </summary>
        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            menu.Start();

            Assert.NotNull(menu);
        }

        /// <summary>
        /// Tests that update should not throw
        /// </summary>
        [Fact]
        public void Update_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            TopMenuMac menu = new TopMenuMac(spaceWork);

            menu.Update();

            Assert.NotNull(menu);
        }

        /// <summary>
        /// Tests that render should not throw
        /// </summary>
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
