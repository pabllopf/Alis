using System;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    public class WebAssemblyGameContextRemainingTests
    {
        [Fact]
        public void GetDeviceLanguage_ReturnsDefault()
        {
            string lang = WebAssemblyGameContext.GetDeviceLanguage();
            Assert.NotNull(lang);
        }

        [Fact]
        public void GetBatteryLevel_ReturnsDefault()
        {
            WebAssemblyGameContext.GetBatteryLevel();
        }

        [Fact]
        public void IsCharging_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.IsCharging());
        }

        [Fact]
        public void IsOnline_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.IsOnline());
        }

        [Fact]
        public void GetRefreshRate_ReturnsDefault()
        {
            int rate = WebAssemblyGameContext.GetRefreshRate();
            Assert.True(rate >= 0);
        }

        [Fact]
        public void LockPointer_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.LockPointer());
        }

        [Fact]
        public void UnlockPointer_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.UnlockPointer());
        }

        [Fact]
        public void IsPointerLocked_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.IsPointerLocked());
        }
    }
}
