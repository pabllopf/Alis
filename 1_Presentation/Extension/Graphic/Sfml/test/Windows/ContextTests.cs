using Xunit;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class ContextTests
    {
        [Fact(Skip = "Cannot test Context without native SFML dependencies.")]
        public void Constructor_CreatesContext()
        {
            Context ctx = new Context();
            Assert.NotNull(ctx);
        }

        [Fact(Skip = "Cannot test Context without native SFML dependencies.")]
        public void SetActive_ReturnsBool()
        {
            Context ctx = new Context();
            bool result = ctx.SetActive(true);
            Assert.IsType<bool>(result);
        }

        [Fact(Skip = "Cannot test Context without native SFML dependencies.")]
        public void Settings_ReturnsContextSettings()
        {
            Context ctx = new Context();
            ContextSettings settings = ctx.Settings;
            Assert.IsType<ContextSettings>(settings);
        }
    }
}

