using System;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for WebAssemblyGameExamples behavior on non-browser platforms.
    /// </summary>
    public class WebAssemblyGameExamplesTest
    {
        /// <summary>
        ///     Verifies that the basic game loop example fails fast outside WebAssembly.
        /// </summary>
        [Fact]
        public void BasicGameLoopExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser())
            {
                return;
            }

            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.BasicGameLoopExample());
        }

        /// <summary>
        ///     Verifies that the gamepad input example fails fast outside WebAssembly.
        /// </summary>
        [Fact]
        public void GamepadInputExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser())
            {
                return;
            }

            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.GamepadInputExample());
        }

        /// <summary>
        ///     Verifies that the display management example fails fast outside WebAssembly.
        /// </summary>
        [Fact]
        public void DisplayManagementExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser())
            {
                return;
            }

            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.DisplayManagementExample());
        }
    }
}
