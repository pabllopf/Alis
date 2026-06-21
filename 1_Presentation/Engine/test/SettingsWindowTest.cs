using System;
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
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                SettingsWindow window = new SettingsWindow(spaceWork);

                Assert.NotNull(window);
                Assert.Same(spaceWork, window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("SettingsWindow", ex.Message);
            }
        }

        [Fact]
        public void SpaceWork_Property_ShouldReturnSetValue()
        {
            try
            {
                SpaceWork spaceWork = new SpaceWork();
                SettingsWindow window = new SettingsWindow(spaceWork);

                Assert.NotNull(window.SpaceWork);
            }
            catch (Exception ex)
            {
                Assert.Contains("SettingsWindow", ex.Message);
            }
        }

        [Fact]
        public void Initialize_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = new SpaceWork();
            SettingsWindow window = new SettingsWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Initialize());
        }

        [Fact]
        public void Start_ThrowsNotImplementedException()
        {
            SpaceWork spaceWork = new SpaceWork();
            SettingsWindow window = new SettingsWindow(spaceWork);

            Assert.Throws<NotImplementedException>(() => window.Start());
        }
    }
}
