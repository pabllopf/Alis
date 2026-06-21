using System;
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows.Settings;
using Xunit;

namespace Alis.App.Engine.Test
{
    public class SettingsWindowTest
    {
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            SettingsWindow window = new SettingsWindow(spaceWork);

            Assert.NotNull(window);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            SettingsWindow window = new SettingsWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        [Fact]
        public void Constructor_WithNull_ShouldSetNullSpaceWork()
        {
            SettingsWindow window = new SettingsWindow(null);

            Assert.Null(window.SpaceWork);
        }

        [Fact]
        public void Initialize_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            SettingsWindow window = new SettingsWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Initialize());
        }

        [Fact]
        public void Start_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            SettingsWindow window = new SettingsWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Start());
        }

        [Fact]
        public void WindowName_ShouldContainSettings()
        {
            Assert.Contains("Settings", SettingsWindow.WindowName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
