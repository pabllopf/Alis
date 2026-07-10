using System;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    public class WebAssemblyGameContextSafeTests
    {
        [Fact]
        public void Constructor_NullConfiguration_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WebAssemblyGameContext(null));
        }

        [Fact]
        public void Constructor_WithConfig_ThrowsOnNonWebAssembly()
        {
            Assert.ThrowsAny<Exception>(() => new WebAssemblyGameContext(new WebAssemblyConfiguration()));
        }

        [Fact]
        public void GameContextPresets_Game2D_ReturnsNonNullConfig()
        {
            Assert.NotNull(GameContextPresets.Game2D());
        }

        [Fact]
        public void GameContextPresets_Game3D_ReturnsNonNullConfig()
        {
            Assert.NotNull(GameContextPresets.Game3D());
        }

        [Fact]
        public void GameContextPresets_PuzzleGame_ReturnsNonNullConfig()
        {
            Assert.NotNull(GameContextPresets.PuzzleGame());
        }

        [Fact]
        public void GameContextPresets_MobileGame_ReturnsNonNullConfig()
        {
            Assert.NotNull(GameContextPresets.MobileGame());
        }

        [Fact]
        public void GameContextPresets_Game2D_WidthIs1280()
        {
            Assert.Equal(1280, GameContextPresets.Game2D().WindowWidth);
        }

        [Fact]
        public void GameContextPresets_Game3D_WidthIs1920()
        {
            Assert.Equal(1920, GameContextPresets.Game3D().WindowWidth);
        }

        [Fact]
        public void GameContextPresets_MobileGame_WidthIs720()
        {
            Assert.Equal(720, GameContextPresets.MobileGame().WindowWidth);
        }

        [Fact]
        public void ConsoleLog_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleLog("test");
        }

        [Fact]
        public void ConsoleWarn_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleWarn("test");
        }

        [Fact]
        public void ConsoleError_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleError("test");
        }

        [Fact]
        public void ShowAlert_DoesNotThrow()
        {
            WebAssemblyGameContext.ShowAlert("test");
        }

        [Fact]
        public void ShowConfirm_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.ShowConfirm("test"));
        }

        [Fact]
        public void IsFullscreen_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.IsFullscreen());
        }

        [Fact]
        public void VibrateGamepad_ReturnsFalse_OnNonWebAssembly()
        {
            Assert.False(WebAssemblyGameContext.VibrateGamepad(0));
        }
    }
}
