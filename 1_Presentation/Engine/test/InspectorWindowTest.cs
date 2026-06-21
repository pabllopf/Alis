using System;
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class InspectorWindowTest
    {
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            InspectorWindow window = new InspectorWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            InspectorWindow window = new InspectorWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
        }

        [Fact]
        public void NameWindow_ShouldNotBeNullOrEmpty()
        {
            Assert.NotNull(InspectorWindow.NameWindow);
            Assert.NotEmpty(InspectorWindow.NameWindow);
        }

        [Fact]
        public void Initialize_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            InspectorWindow window = new InspectorWindow(spaceWork);

            window.Initialize();

            Assert.NotNull(window);
        }

        [Fact]
        public void Start_ShouldNotThrow()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            InspectorWindow window = new InspectorWindow(spaceWork);

            window.Start();

            Assert.NotNull(window);
        }
    }
}
