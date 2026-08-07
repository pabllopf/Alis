using System;
using Alis.Core.Graphic.Platforms.Web;
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    /// The web assembly game context remaining tests class
    /// </summary>
    public class WebAssemblyGameContextRemainingTests
    {
        /// <summary>
        /// Tests that get device language returns default
        /// </summary>
        [WebOnly]
        public void GetDeviceLanguage_ReturnsDefault()
        {
            string lang = WebAssemblyGameContext.GetDeviceLanguage();
            Assert.NotNull(lang);
        }

        /// <summary>
        /// Tests that get battery level returns default
        /// </summary>
        [WebOnly]
        public void GetBatteryLevel_ReturnsDefault()
        {
            WebAssemblyGameContext.GetBatteryLevel();
        }

        /// <summary>
        /// Tests that is charging returns false
        /// </summary>
        [WebOnly]
        public void IsCharging_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.IsCharging());
        }

        /// <summary>
        /// Tests that is online returns false
        /// </summary>
        [WebOnly]
        public void IsOnline_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.IsOnline());
        }

        /// <summary>
        /// Tests that get refresh rate returns default
        /// </summary>
        [WebOnly]
        public void GetRefreshRate_ReturnsDefault()
        {
            int rate = WebAssemblyGameContext.GetRefreshRate();
            Assert.True(rate >= 0);
        }

        /// <summary>
        /// Tests that lock pointer returns false
        /// </summary>
        [WebOnly]
        public void LockPointer_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.LockPointer());
        }

        /// <summary>
        /// Tests that unlock pointer returns false
        /// </summary>
        [WebOnly]
        public void UnlockPointer_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.UnlockPointer());
        }

        /// <summary>
        /// Tests that is pointer locked returns false
        /// </summary>
        [WebOnly]
        public void IsPointerLocked_ReturnsFalse()
        {
            Assert.False(WebAssemblyGameContext.IsPointerLocked());
        }
    }
}
