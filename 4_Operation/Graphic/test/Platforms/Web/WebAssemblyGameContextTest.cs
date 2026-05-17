using System;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for WebAssemblyGameContext and GameContextPresets.
    /// </summary>
    public class WebAssemblyGameContextTest
    {
        [Fact]
        public void GameContext_Constructor_NullConfig_ThrowsArgumentNullException()
        {
            WebAssemblyConfiguration nullConfig = null;
            Assert.Throws<ArgumentNullException>(() =>
                new WebAssemblyGameContext(nullConfig));
        }

        [Fact]
        public void GameContext_DefaultConstructor_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    new WebAssemblyGameContext());
            }
        }

        [Fact]
        public void GameContext_Constructor_WithConfig_ThrowsOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    new WebAssemblyGameContext(config));
            }
        }

        [Fact]
        public void GameContext_Create_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyGameContext.Create(800, 600, "Test"));
            }
        }

        [Fact]
        public void GameContext_Create_WithBuilder_NullAction_Throws()
        {
            Assert.ThrowsAny<Exception>(() =>
                WebAssemblyGameContext.Create((Action<WebAssemblyConfigurationBuilder>)null));
        }

        [Fact]
        public void GameContext_Create_WithBuilder_ThrowsOnNonBrowser()
        {
            if (!OperatingSystem.IsBrowser())
            {
                Assert.Throws<InvalidOperationException>(() =>
                    WebAssemblyGameContext.Create(b => b.WithSize(800, 600)));
            }
        }
    }
}
