using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for the WebAssembly JavaScript bridge script content.
    /// </summary>
    public class EmscriptenWebScriptTest
    {
        /// <summary>
        ///     Verifies that the generated bridge script contains required sections.
        /// </summary>
        [Fact]
        public void GetBridgeScript_IncludesCoreSections()
        {
            string script = EmscriptenWebScript.GetBridgeScript();

            Assert.False(string.IsNullOrWhiteSpace(script));
            Assert.Contains("EmscriptenWebBridge", script);
            Assert.Contains("registerKeyboardListeners", script);
            Assert.Contains("registerMouseListeners", script);
            Assert.Contains("registerGamepadListeners", script);
            Assert.Contains("createIntArray", script);
        }
    }
}
