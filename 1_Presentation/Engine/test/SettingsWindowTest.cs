using System;
using System.Runtime.CompilerServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Windows.Settings;
using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    /// The settings window test class
    /// </summary>
    public class SettingsWindowTest
    {
        /// <summary>
        /// Tests that constructor should set space work
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetSpaceWork()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            SettingsWindow window = new SettingsWindow(spaceWork);

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
            SettingsWindow window = new SettingsWindow(spaceWork);

            Assert.NotNull(window.SpaceWork);
            Assert.Same(spaceWork, window.SpaceWork);
        }

        /// <summary>
        /// Tests that constructor with null should set null space work
        /// </summary>
        [Fact]
        public void Constructor_WithNull_ShouldSetNullSpaceWork()
        {
            SettingsWindow window = new SettingsWindow(null);

            Assert.Null(window.SpaceWork);
        }

        /// <summary>
        /// Tests that initialize throws not implemented exception
        /// </summary>
        [Fact]
        public void Initialize_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            SettingsWindow window = new SettingsWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Initialize());
        }

        /// <summary>
        /// Tests that start throws not implemented exception
        /// </summary>
        [Fact]
        public void Start_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = (SpaceWork)RuntimeHelpers.GetUninitializedObject(typeof(SpaceWork));
            SettingsWindow window = new SettingsWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Start());
        }

        /// <summary>
        /// Tests that window name should contain settings
        /// </summary>
        [Fact]
        public void WindowName_ShouldContainSettings()
        {
            Assert.Contains("Settings", SettingsWindow.WindowName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
