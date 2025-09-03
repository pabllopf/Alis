using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The context tests class
    /// </summary>
    public class ContextTests
    {
        /// <summary>
        /// Tests that constructor creates context
        /// </summary>
        [Fact(Skip = "Cannot test Context without native SFML dependencies.")]
        public void Constructor_CreatesContext()
        {
            Context ctx = new Context();
            Assert.NotNull(ctx);
        }

        /// <summary>
        /// Tests that set active returns bool
        /// </summary>
        [Fact(Skip = "Cannot test Context without native SFML dependencies.")]
        public void SetActive_ReturnsBool()
        {
            Context ctx = new Context();
            bool result = ctx.SetActive(true);
            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests that settings returns context settings
        /// </summary>
        [Fact(Skip = "Cannot test Context without native SFML dependencies.")]
        public void Settings_ReturnsContextSettings()
        {
            Context ctx = new Context();
            ContextSettings settings = ctx.Settings;
            Assert.IsType<ContextSettings>(settings);
        }
    }
}

