using System;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for WebAssemblyGameExamples and GameDevelopmentUtils.
    /// </summary>
    public class WebAssemblyGameExamplesTest
    {
        [Fact]
        public void BasicGameLoopExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.BasicGameLoopExample());
        }

        [Fact]
        public void GamepadInputExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.GamepadInputExample());
        }

        [Fact]
        public void DisplayManagementExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.DisplayManagementExample());
        }

        [Fact]
        public void FpsGameExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.FpsGameExample());
        }

        [Fact]
        public void SystemInfoExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.SystemInfoExample());
        }

        [Fact]
        public void ConfigurationPresetsExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.ConfigurationPresetsExample());
        }

        [Fact]
        public void TextInputExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.TextInputExample());
        }

        [Fact]
        public void PerformanceMonitoringExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.PerformanceMonitoringExample());
        }

        [Fact]
        public void DialogBoxExample_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.DialogBoxExample());
        }

        [Fact]
        public void CompleteGameTemplate_ThrowsOutsideBrowser()
        {
            if (OperatingSystem.IsBrowser()) return;
            Assert.Throws<InvalidOperationException>(() => WebAssemblyGameExamples.CompleteGameTemplate());
        }

        // =====================================================================
        // GameDevelopmentUtils
        // =====================================================================

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_WithinDeadzone_ZeroesOutput()
        {
            float x = 0.1f;
            float y = 0.05f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_OutsideDeadzone_Normalizes()
        {
            float x = 0.5f;
            float y = 0.5f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True(magnitude > 0 && magnitude <= 1.0f);
        }

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_ZeroInput_StaysZero()
        {
            float x = 0;
            float y = 0;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_CustomDeadzone_Works()
        {
            float x = 0.3f;
            float y = 0.0f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.2f);
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            Assert.True(magnitude > 0);
        }

        [Fact]
        public void GameDevelopmentUtils_ApplyDeadzone_AtDeadzoneBoundary_ZeroesOutput()
        {
            float x = 0.15f;
            float y = 0.0f;
            GameDevelopmentUtils.ApplyDeadzone(ref x, ref y, 0.15f);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_WithinBounds_NoChange()
        {
            float x = 0.3f;
            float y = 0.4f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0.3f, x, 5);
            Assert.Equal(0.4f, y, 5);
        }

        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_ExceedsBounds_Normalizes()
        {
            float x = 2.0f;
            float y = 0.0f;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(1.0f, x, 5);
            Assert.Equal(0.0f, y, 5);
        }

        [Fact]
        public void GameDevelopmentUtils_NormalizeInput_ZeroInput_NoChange()
        {
            float x = 0;
            float y = 0;
            GameDevelopmentUtils.NormalizeInput(ref x, ref y);
            Assert.Equal(0, x);
            Assert.Equal(0, y);
        }

        [Theory]
        [InlineData(0, "A / Cross")]
        [InlineData(1, "B / Circle")]
        [InlineData(2, "X / Square")]
        [InlineData(3, "Y / Triangle")]
        [InlineData(4, "LB / L1")]
        [InlineData(5, "RB / R1")]
        [InlineData(6, "LT")]
        [InlineData(7, "RT")]
        [InlineData(8, "Back / Select")]
        [InlineData(9, "Start")]
        [InlineData(10, "Left Stick Click")]
        [InlineData(11, "Right Stick Click")]
        [InlineData(12, "Guide / Home")]
        [InlineData(13, "Button 13")]
        [InlineData(99, "Button 99")]
        public void GameDevelopmentUtils_GetGamepadButtonName_ReturnsCorrectName(int index, string expected)
        {
            string name = GameDevelopmentUtils.GetGamepadButtonName(index);
            Assert.Equal(expected, name);
        }

        [Fact]
        public void GameDevelopmentUtils_GetKeyName_DelegatesToInputManager()
        {
            Assert.Equal("A", GameDevelopmentUtils.GetKeyName(ConsoleKey.A));
            Assert.Equal("Enter", GameDevelopmentUtils.GetKeyName(ConsoleKey.Enter));
        }
    }
}
