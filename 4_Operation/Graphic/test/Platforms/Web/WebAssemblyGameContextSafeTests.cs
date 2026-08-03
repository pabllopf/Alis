using System;
using Alis.Core.Graphic.Platforms.Web;
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    /// The web assembly game context safe tests class
    /// </summary>
    public class WebAssemblyGameContextSafeTests
    {
        /// <summary>
        /// Tests that constructor null configuration throws argument null exception
        /// </summary>
        [WebOnly]
        public void Constructor_NullConfiguration_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WebAssemblyGameContext(null));
        }

        /// <summary>
        /// Tests that constructor with config throws on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void Constructor_WithConfig_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => new WebAssemblyGameContext(new WebAssemblyConfiguration()));
        }

        /// <summary>
        /// Tests that game context presets game 2 d returns non null config
        /// </summary>
        [WebOnlyAttribute]
        public void GameContextPresets_Game2D_ReturnsNonNullConfig()
        {
            Assert.NotNull(GameContextPresets.Game2D());
        }

        /// <summary>
        /// Tests that game context presets game 3 d returns non null config
        /// </summary>
        [WebOnlyAttribute]
        public void GameContextPresets_Game3D_ReturnsNonNullConfig()
        {
            Assert.NotNull(GameContextPresets.Game3D());
        }

        /// <summary>
        /// Tests that game context presets puzzle game returns non null config
        /// </summary>
        [WebOnlyAttribute]
        public void GameContextPresets_PuzzleGame_ReturnsNonNullConfig()
        {
            Assert.NotNull(GameContextPresets.PuzzleGame());
        }

        /// <summary>
        /// Tests that game context presets mobile game returns non null config
        /// </summary>
        [WebOnlyAttribute]
        public void GameContextPresets_MobileGame_ReturnsNonNullConfig()
        {
            Assert.NotNull(GameContextPresets.MobileGame());
        }

        /// <summary>
        /// Tests that game context presets game 2 d width is 1280
        /// </summary>
        [WebOnlyAttribute]
        public void GameContextPresets_Game2D_WidthIs1280()
        {
            Assert.Equal(1280, GameContextPresets.Game2D().WindowWidth);
        }

        /// <summary>
        /// Tests that game context presets game 3 d width is 1920
        /// </summary>
        [WebOnlyAttribute]
        public void GameContextPresets_Game3D_WidthIs1920()
        {
            Assert.Equal(1920, GameContextPresets.Game3D().WindowWidth);
        }

        /// <summary>
        /// Tests that game context presets mobile game width is 720
        /// </summary>
        [WebOnlyAttribute]
        public void GameContextPresets_MobileGame_WidthIs720()
        {
            Assert.Equal(720, GameContextPresets.MobileGame().WindowWidth);
        }

        /// <summary>
        /// Tests that console log does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleLog_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleLog("test");
        }

        /// <summary>
        /// Tests that console warn does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleWarn_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleWarn("test");
        }

        /// <summary>
        /// Tests that console error does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ConsoleError_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleError("test");
        }

        /// <summary>
        /// Tests that show alert does not throw
        /// </summary>
        [WebOnlyAttribute]
        public void ShowAlert_DoesNotThrow()
        {
            WebAssemblyGameContext.ShowAlert("test");
        }

        /// <summary>
        /// Tests that show confirm returns false on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void ShowConfirm_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.ShowConfirm("test"));
        }

        /// <summary>
        /// Tests that is fullscreen returns false on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void IsFullscreen_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.IsFullscreen());
        }

        /// <summary>
        /// Tests that vibrate gamepad returns false on non web assembly
        /// </summary>
        [WebOnlyAttribute]
        public void VibrateGamepad_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.VibrateGamepad(0));
        }
    }
}
