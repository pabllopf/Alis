using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for the WebAssembly JavaScript bridge script content.
    /// </summary>
    public class EmscriptenWebScriptTest
    {
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

        [Fact]
        public void GetBridgeScript_ReturnsNonEmptyString()
        {
            string script = EmscriptenWebScript.GetBridgeScript();
            Assert.NotNull(script);
            Assert.NotEmpty(script);
        }

        [Fact]
        public void GetBridgeScript_ContainsKeyFunctions()
        {
            string script = EmscriptenWebScript.GetBridgeScript();
            Assert.Contains("registerKeyboardCallbacks", script);
            Assert.Contains("registerMouseCallbacks", script);
            Assert.Contains("registerGamepadCallbacks", script);
            Assert.Contains("registerWindowCallbacks", script);
            Assert.Contains("getConnectedGamepads", script);
            Assert.Contains("getGamepadAxes", script);
            Assert.Contains("getGamepadButtons", script);
            Assert.Contains("showCanvas", script);
            Assert.Contains("hideCanvas", script);
            Assert.Contains("setWindowTitle", script);
            Assert.Contains("setCanvasSize", script);
            Assert.Contains("requestFullscreen", script);
            Assert.Contains("exitFullscreen", script);
            Assert.Contains("lockPointer", script);
            Assert.Contains("unlockPointer", script);
            Assert.Contains("vibrateGamepad", script);
            Assert.Contains("getSystemTimeMs", script);
            Assert.Contains("showAlert", script);
            Assert.Contains("showConfirm", script);
            Assert.Contains("getLanguage", script);
            Assert.Contains("isOnline", script);
            Assert.Contains("getBatteryLevel", script);
            Assert.Contains("isCharging", script);
            Assert.Contains("getOrientation", script);
            Assert.Contains("consoleLog", script);
            Assert.Contains("consoleWarn", script);
            Assert.Contains("consoleError", script);
        }

        [Fact]
        public void GetBridgeScript_ContainsEmscriptenWebBridge()
        {
            string script = EmscriptenWebScript.GetBridgeScript();
            Assert.Contains("EmscriptenWebBridge", script);
            Assert.Contains("keyboardCallbacks", script);
            Assert.Contains("mouseCallbacks", script);
            Assert.Contains("gamepadCallbacks", script);
            Assert.Contains("windowCallbacks", script);
        }

        [Fact]
        public void GetBridgeScript_ContainsArrayHelpers()
        {
            string script = EmscriptenWebScript.GetBridgeScript();
            Assert.Contains("createIntArray", script);
            Assert.Contains("createFloatArray", script);
            Assert.Contains("createBoolArray", script);
            Assert.Contains("freeArray", script);
        }

        [Fact]
        public void GetBridgeScript_ContainsInitFunction()
        {
            string script = EmscriptenWebScript.GetBridgeScript();
            Assert.Contains("init: function", script);
            Assert.Contains("registerKeyboardListeners", script);
            Assert.Contains("registerMouseListeners", script);
            Assert.Contains("registerGamepadListeners", script);
            Assert.Contains("registerWindowListeners", script);
        }

        [Fact]
        public void GetHtmlTemplate_ReturnsNonEmptyString()
        {
            string html = EmscriptenWebScript.GetHtmlTemplate();
            Assert.NotNull(html);
            Assert.NotEmpty(html);
        }

        [Fact]
        public void GetHtmlTemplate_ContainsRequiredElements()
        {
            string html = EmscriptenWebScript.GetHtmlTemplate();
            Assert.Contains("<!DOCTYPE html>", html);
            Assert.Contains("<html", html);
            Assert.Contains("<head>", html);
            Assert.Contains("<body>", html);
            Assert.Contains("canvas", html);
            Assert.Contains("</html>", html);
            Assert.Contains("WebAssembly Game", html);
            Assert.Contains("game.js", html);
        }
    }
}
