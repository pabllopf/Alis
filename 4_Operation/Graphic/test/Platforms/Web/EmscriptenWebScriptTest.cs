// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EmscriptenWebScriptTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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
        /// Tests that get bridge script includes core sections
        /// </summary>
        [Fact]
        public void GetBridgeScript_IncludesCoreSections()
        {
            string script = EmscriptenWebScript.BridgeScript;
            Assert.False(string.IsNullOrWhiteSpace(script));
            Assert.Contains("EmscriptenWebBridge", script);
            Assert.Contains("registerKeyboardListeners", script);
            Assert.Contains("registerMouseListeners", script);
            Assert.Contains("registerGamepadListeners", script);
            Assert.Contains("createIntArray", script);
        }

        /// <summary>
        /// Tests that get bridge script returns non empty string
        /// </summary>
        [Fact]
        public void GetBridgeScript_ReturnsNonEmptyString()
        {
            string script = EmscriptenWebScript.BridgeScript;
            Assert.NotNull(script);
            Assert.NotEmpty(script);
        }

        /// <summary>
        /// Tests that get bridge script contains key functions
        /// </summary>
        [Fact]
        public void GetBridgeScript_ContainsKeyFunctions()
        {
            string script = EmscriptenWebScript.BridgeScript;
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

        /// <summary>
        /// Tests that get bridge script contains emscripten web bridge
        /// </summary>
        [Fact]
        public void GetBridgeScript_ContainsEmscriptenWebBridge()
        {
            string script = EmscriptenWebScript.BridgeScript;
            Assert.Contains("EmscriptenWebBridge", script);
            Assert.Contains("keyboardCallbacks", script);
            Assert.Contains("mouseCallbacks", script);
            Assert.Contains("gamepadCallbacks", script);
            Assert.Contains("windowCallbacks", script);
        }

        /// <summary>
        /// Tests that get bridge script contains array helpers
        /// </summary>
        [Fact]
        public void GetBridgeScript_ContainsArrayHelpers()
        {
            string script = EmscriptenWebScript.BridgeScript;
            Assert.Contains("createIntArray", script);
            Assert.Contains("createFloatArray", script);
            Assert.Contains("createBoolArray", script);
            Assert.Contains("freeArray", script);
        }

        /// <summary>
        /// Tests that get bridge script contains init function
        /// </summary>
        [Fact]
        public void GetBridgeScript_ContainsInitFunction()
        {
            string script = EmscriptenWebScript.BridgeScript;
            Assert.Contains("init: function", script);
            Assert.Contains("registerKeyboardListeners", script);
            Assert.Contains("registerMouseListeners", script);
            Assert.Contains("registerGamepadListeners", script);
            Assert.Contains("registerWindowListeners", script);
        }

        /// <summary>
        /// Tests that get html template returns non empty string
        /// </summary>
        [Fact]
        public void GetHtmlTemplate_ReturnsNonEmptyString()
        {
            string html = EmscriptenWebScript.HtmlTemplate;
            Assert.NotNull(html);
            Assert.NotEmpty(html);
        }

        /// <summary>
        /// Tests that get html template contains required elements
        /// </summary>
        [Fact]
        public void GetHtmlTemplate_ContainsRequiredElements()
        {
            string html = EmscriptenWebScript.HtmlTemplate;
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
