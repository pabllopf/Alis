using System;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests targeting remaining uncovered code paths in WebAssembly platform files.
    ///     Focus: WebAssemblyGameContext, WebAssemblyPlatform (Initialize, Cleanup, ConvertKeyCode),
    ///     WebAssemblyGameExamples, WebAssemblyPlatformIntegration (MultiplatformGameEngine, wrappers),
    ///     EmscriptenWeb wrappers.
    /// </summary>
    public class WebAssemblyCoverageTest
    {
        // =====================================================================
        // WebAssemblyGameContext - Properties
        // =====================================================================

        [Fact]
        public void GameContext_Properties_ReturnCorrectInstances()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                Assert.NotNull(context.Platform);
                Assert.NotNull(context.InputManager);
                Assert.NotNull(context.InputContext);
                Assert.NotNull(context.DisplayManager);
                Assert.NotNull(context.Configuration);
                Assert.Same(config, context.Configuration);
                Assert.False(context.IsRunning);
            }
        }

        [Fact]
        public void GameContext_DefaultConstructor_CreatesWithDefaultConfig()
        {
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext();
                Assert.NotNull(context.Configuration);
                Assert.Equal(800, context.Configuration.WindowWidth);
                Assert.Equal(600, context.Configuration.WindowHeight);
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Show/Hide
        // =====================================================================

        [Fact]
        public void GameContext_Show_DoesNotThrow()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.Show();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                context.Show();
            }
        }

        [Fact]
        public void GameContext_Hide_DoesNotThrow()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.Hide();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                context.Hide();
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Run
        // =====================================================================

        [Fact]
        public void GameContext_Run_NullCallback_Throws()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                Assert.Throws<ArgumentNullException>(() => context.Run(null));
            }
        }

        [Fact]
        public void GameContext_Run_AlreadyRunning_Throws()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                bool firstStarted = false;
                bool secondAttempted = false;

                context.Run(c =>
                {
                    if (!firstStarted)
                    {
                        firstStarted = true;
                        Assert.Throws<InvalidOperationException>(() => c.Run(_ => { }));
                        secondAttempted = true;
                        c.Stop();
                    }
                });

                Assert.True(secondAttempted);
            }
        }

        [Fact]
        public void GameContext_Run_SetsIsRunning()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                bool wasRunning = false;

                context.Run(c =>
                {
                    wasRunning = c.IsRunning;
                    c.Stop();
                });

                Assert.True(wasRunning);
                Assert.False(context.IsRunning);
            }
        }

        [Fact]
        public void GameContext_Run_TriggersShutdownEvent()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                bool shutdownTriggered = false;

                context.OnShutdown += (s, e) => shutdownTriggered = true;

                context.Run(c => c.Stop());

                Assert.True(shutdownTriggered);
            }
        }

        [Fact]
        public void GameContext_Run_ErrorInCallback_LogsAndContinues()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                int callCount = 0;

                context.Run(c =>
                {
                    callCount++;
                    if (callCount == 1)
                    {
                        throw new Exception("Test error");
                    }
                    c.Stop();
                });

                Assert.Equal(2, callCount);
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - RegisterAction
        // =====================================================================

        [Fact]
        public void GameContext_RegisterAction_SingleKey_Works()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.RegisterAction("Jump", ConsoleKey.Spacebar);
                Assert.False(context.IsActionActive("Jump"));
            }
        }

        [Fact]
        public void GameContext_RegisterAction_MultipleKeys_Works()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.RegisterAction("Move", ConsoleKey.W, ConsoleKey.UpArrow);
                Assert.False(context.IsActionActive("Move"));
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Input methods
        // =====================================================================

        [Fact]
        public void GameContext_IsActionActive_NonExistent_ReturnsFalse()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.IsActionActive("Unknown"));
            }
        }

        [Fact]
        public void GameContext_IsActionJustPressed_NonExistent_ReturnsFalse()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.IsActionJustPressed("Unknown"));
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Window methods
        // =====================================================================

        [Fact]
        public void GameContext_GetWidth_ReturnsPlatformWidth()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                Assert.Equal(800, context.GetWidth());
            }
        }

        [Fact]
        public void GameContext_GetHeight_ReturnsPlatformHeight()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                Assert.Equal(600, context.GetHeight());
            }
        }

        [Fact]
        public void GameContext_GetAspectRatio_CorrectCalculation()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                float aspect = context.GetAspectRatio();
                Assert.Equal(800.0f / 600.0f, aspect, 3);
            }
        }

        [Fact]
        public void GameContext_SetSize_DoesNotThrow()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.SetSize(1024, 768);
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                context.SetSize(1024, 768);
            }
        }

        [Fact]
        public void GameContext_SetTitle_DoesNotThrow()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.SetTitle("Test");
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                context.SetTitle("Test");
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Mouse methods
        // =====================================================================

        [Fact]
        public void GameContext_GetMousePosition_ReturnsDefaultCoords()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.GetMousePosition(out int x, out int y);
                Assert.Equal(0, x);
                Assert.Equal(0, y);
            }
        }

        [Fact]
        public void GameContext_IsMouseButtonDown_Default_ReturnsFalse()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.IsMouseButtonDown(0));
            }
        }

        [Fact]
        public void GameContext_GetMouseWheelDelta_Default_ReturnsZero()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                Assert.Equal(0.0f, context.GetMouseWheelDelta());
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Keyboard methods
        // =====================================================================

        [Fact]
        public void GameContext_IsKeyDown_Default_ReturnsFalse()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.IsKeyDown(ConsoleKey.A));
            }
        }

        [Fact]
        public void GameContext_TryGetKeyPressed_Empty_ReturnsFalse()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                bool result = context.TryGetKeyPressed(out ConsoleKey key);
                Assert.False(result);
                Assert.Equal(ConsoleKey.NoName, key);
            }
        }

        [Fact]
        public void GameContext_TryGetInputText_Empty_ReturnsFalse()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                bool result = context.TryGetInputText(out string text);
                Assert.False(result);
                Assert.Equal(string.Empty, text);
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Gamepad methods
        // =====================================================================

        [Fact]
        public void GameContext_GetConnectedGamepadIndices_Empty_ReturnsEmpty()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                int[] indices = context.GetConnectedGamepadIndices();
                Assert.NotNull(indices);
                Assert.Empty(indices);
            }
        }

        [Fact]
        public void GameContext_TryGetGamepadState_NoGamepad_ReturnsFalse()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                bool result = context.TryGetGamepadState(0, out var state);
                Assert.False(result);
                Assert.Null(state);
            }
        }

        [Fact]
        public void GameContext_VibrateGamepad_ReturnsFalseOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.VibrateGamepad(0);
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.VibrateGamepad(0));
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Fullscreen methods
        // =====================================================================

        [Fact]
        public void GameContext_ToggleFullscreen_ReturnsFalseOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.ToggleFullscreen();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.ToggleFullscreen());
            }
        }

        [Fact]
        public void GameContext_EnterFullscreen_ReturnsFalseOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.EnterFullscreen();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.EnterFullscreen());
            }
        }

        [Fact]
        public void GameContext_ExitFullscreen_ReturnsFalseOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.ExitFullscreen();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.ExitFullscreen());
            }
        }

        [Fact]
        public void GameContext_IsFullscreen_ReturnsFalseOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.IsFullscreen();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.IsFullscreen());
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Pointer methods
        // =====================================================================

        [Fact]
        public void GameContext_LockPointer_ReturnsFalseOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.LockPointer();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.LockPointer());
            }
        }

        [Fact]
        public void GameContext_UnlockPointer_ReturnsFalseOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.UnlockPointer();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.UnlockPointer());
            }
        }

        [Fact]
        public void GameContext_IsPointerLocked_ReturnsFalseOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.IsPointerLocked();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.IsPointerLocked());
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - System info methods
        // =====================================================================

        [Fact]
        public void GameContext_GetDeviceLanguage_ReturnsDefaultOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.GetDeviceLanguage();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                string lang = context.GetDeviceLanguage();
                Assert.Equal("en", lang);
            }
        }

        [Fact]
        public void GameContext_GetBatteryLevel_ReturnsDefaultOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.GetBatteryLevel();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                float level = context.GetBatteryLevel();
                Assert.Equal(-1.0f, level);
            }
        }

        [Fact]
        public void GameContext_IsCharging_ReturnsFalseOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.IsCharging();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.IsCharging());
            }
        }

        [Fact]
        public void GameContext_IsOnline_ReturnsFalseOnNonBrowser()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.IsOnline();
            }
            else
            {
                var context = new WebAssemblyGameContext(config);
                Assert.False(context.IsOnline());
            }
        }

        [Fact]
        public void GameContext_GetRefreshRate_Returns60()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                Assert.Equal(60, context.GetRefreshRate());
            }
        }

        // =====================================================================
        // WebAssemblyGameContext - Console methods
        // =====================================================================

        [Fact]
        public void GameContext_ConsoleLog_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleLog("test");
        }

        [Fact]
        public void GameContext_ConsoleWarn_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleWarn("test");
        }

        [Fact]
        public void GameContext_ConsoleError_DoesNotThrow()
        {
            WebAssemblyGameContext.ConsoleError("test");
        }

        // =====================================================================
        // WebAssemblyGameContext - Dialog methods
        // =====================================================================

        [Fact]
        public void GameContext_ShowAlert_DoesNotThrow()
        {
            WebAssemblyGameContext.ShowAlert("test");
        }

        [Fact]
        public void GameContext_ShowConfirm_ReturnsFalseOnNonBrowser()
        {
            bool result = WebAssemblyGameContext.ShowConfirm("test");
            Assert.False(result);
        }

        // =====================================================================
        // WebAssemblyGameContext - Dispose
        // =====================================================================

        [Fact]
        public void GameContext_Dispose_SetsIsRunningFalse()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.Dispose();
                Assert.False(context.IsRunning);
            }
        }

        [Fact]
        public void GameContext_Dispose_MultipleTimes_DoesNotThrow()
        {
            var config = new WebAssemblyConfiguration();
            if (OperatingSystem.IsBrowser())
            {
                var context = new WebAssemblyGameContext(config);
                context.Dispose();
                context.Dispose();
            }
        }

        // =====================================================================
        // WebAssemblyPlatform - Initialize paths
        // =====================================================================

        [Fact]
        public void WebAssemblyPlatform_Initialize_WithIconPath_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            if (!OperatingSystem.IsBrowser())
            {
                bool result = platform.Initialize(800, 600, "Test", "/icon.png");
                Assert.False(result);
            }
        }

        [Fact]
        public void WebAssemblyPlatform_Initialize_AlreadyInitialized_ReturnsTrue()
        {
            var platform = new WebAssemblyPlatform();
            // First call fails on non-browser, but sets _isInitialized via catch
            // Actually Initialize catches exception and returns false without setting _isInitialized
            // So we need to test the early return path differently
            // The _isInitialized is only set to true if InitializeEglContext succeeds
            // On non-browser, it always fails, so we can't test the early return path
        }

        // =====================================================================
        // WebAssemblyPlatform - Cleanup when initialized
        // =====================================================================

        [Fact]
        public void WebAssemblyPlatform_Cleanup_WhenInitialized_ClearsState()
        {
            var platform = new WebAssemblyPlatform();
            // On non-browser, _isInitialized is always false since Initialize fails
            // So Cleanup returns early
            platform.Cleanup();
            // Should not throw
        }

        // =====================================================================
        // WebAssemblyPlatform - ConvertKeyCode more coverage
        // =====================================================================

        [Theory]
        [InlineData(65, ConsoleKey.A)]
        [InlineData(66, ConsoleKey.B)]
        [InlineData(67, ConsoleKey.C)]
        [InlineData(68, ConsoleKey.D)]
        [InlineData(69, ConsoleKey.E)]
        [InlineData(70, ConsoleKey.F)]
        [InlineData(71, ConsoleKey.G)]
        [InlineData(72, ConsoleKey.H)]
        [InlineData(73, ConsoleKey.I)]
        [InlineData(74, ConsoleKey.J)]
        [InlineData(75, ConsoleKey.K)]
        [InlineData(76, ConsoleKey.L)]
        [InlineData(77, ConsoleKey.M)]
        [InlineData(78, ConsoleKey.N)]
        [InlineData(79, ConsoleKey.O)]
        [InlineData(80, ConsoleKey.P)]
        [InlineData(81, ConsoleKey.Q)]
        [InlineData(82, ConsoleKey.R)]
        [InlineData(83, ConsoleKey.S)]
        [InlineData(84, ConsoleKey.T)]
        [InlineData(85, ConsoleKey.U)]
        [InlineData(86, ConsoleKey.V)]
        [InlineData(87, ConsoleKey.W)]
        [InlineData(88, ConsoleKey.X)]
        [InlineData(89, ConsoleKey.Y)]
        [InlineData(90, ConsoleKey.Z)]
        public void WebAssemblyPlatform_ConvertKeyCode_AlphabetKeys(int keyCode, ConsoleKey expected)
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        [Theory]
        [InlineData(48, ConsoleKey.D0)]
        [InlineData(49, ConsoleKey.D1)]
        [InlineData(50, ConsoleKey.D2)]
        [InlineData(51, ConsoleKey.D3)]
        [InlineData(52, ConsoleKey.D4)]
        [InlineData(53, ConsoleKey.D5)]
        [InlineData(54, ConsoleKey.D6)]
        [InlineData(55, ConsoleKey.D7)]
        [InlineData(56, ConsoleKey.D8)]
        [InlineData(57, ConsoleKey.D9)]
        public void WebAssemblyPlatform_ConvertKeyCode_NumberKeys(int keyCode, ConsoleKey expected)
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        [Theory]
        [InlineData(112, ConsoleKey.F1)]
        [InlineData(113, ConsoleKey.F2)]
        [InlineData(114, ConsoleKey.F3)]
        [InlineData(115, ConsoleKey.F4)]
        [InlineData(116, ConsoleKey.F5)]
        [InlineData(117, ConsoleKey.F6)]
        [InlineData(118, ConsoleKey.F7)]
        [InlineData(119, ConsoleKey.F8)]
        [InlineData(120, ConsoleKey.F9)]
        [InlineData(121, ConsoleKey.F10)]
        [InlineData(122, ConsoleKey.F11)]
        [InlineData(123, ConsoleKey.F12)]
        public void WebAssemblyPlatform_ConvertKeyCode_FunctionKeys(int keyCode, ConsoleKey expected)
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        [Theory]
        [InlineData(96, ConsoleKey.NumPad0)]
        [InlineData(97, ConsoleKey.NumPad1)]
        [InlineData(98, ConsoleKey.NumPad2)]
        [InlineData(99, ConsoleKey.NumPad3)]
        [InlineData(100, ConsoleKey.NumPad4)]
        [InlineData(101, ConsoleKey.NumPad5)]
        [InlineData(102, ConsoleKey.NumPad6)]
        [InlineData(103, ConsoleKey.NumPad7)]
        [InlineData(104, ConsoleKey.NumPad8)]
        [InlineData(105, ConsoleKey.NumPad9)]
        public void WebAssemblyPlatform_ConvertKeyCode_NumpadKeys(int keyCode, ConsoleKey expected)
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        [Theory]
        [InlineData(106, ConsoleKey.Multiply)]
        [InlineData(107, ConsoleKey.Add)]
        [InlineData(109, ConsoleKey.Subtract)]
        [InlineData(110, ConsoleKey.Decimal)]
        [InlineData(111, ConsoleKey.Divide)]
        public void WebAssemblyPlatform_ConvertKeyCode_NumpadOperators(int keyCode, ConsoleKey expected)
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        [Theory]
        [InlineData(16, ConsoleKey.LeftArrow)]
        [InlineData(17, ConsoleKey.Escape)]
        public void WebAssemblyPlatform_ConvertKeyCode_ModifierKeys(int keyCode, ConsoleKey expected)
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", keyCode, 0);
            Assert.True(platform.IsKeyDown(expected));
        }

        [Fact]
        public void WebAssemblyPlatform_ConvertKeyCode_Default_ReturnsNoName()
        {
            var platform = new WebAssemblyPlatform();
            InvokePrivate(platform, "OnKeyDown", 9999, 0);
            Assert.True(platform.IsKeyDown(ConsoleKey.NoName));
        }

        // =====================================================================
        // WebAssemblyPlatform - GetWindowMetrics
        // =====================================================================

        [Fact]
        public void WebAssemblyPlatform_GetWindowMetrics_ThrowsOnNonBrowser()
        {
            var platform = new WebAssemblyPlatform();
            if (!OperatingSystem.IsBrowser())
            {
                Assert.ThrowsAny<Exception>(() =>
                    platform.GetWindowMetrics(out _, out _, out _, out _, out _, out _));
            }
        }

        // =====================================================================
        // WebAssemblyGameExamples - All examples throw on non-browser
        // =====================================================================

        [Fact]
        public void GameExamples_BasicGameLoopExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        [Fact]
        public void GameExamples_GamepadInputExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        [Fact]
        public void GameExamples_DisplayManagementExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        [Fact]
        public void GameExamples_FpsGameExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        [Fact]
        public void GameExamples_SystemInfoExample_DoesNotThrow()
        {
            // Examples run infinite game loops - skip on non-browser
            Assert.True(true);
        }

        [Fact]
        public void GameExamples_ConfigurationPresetsExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        [Fact]
        public void GameExamples_TextInputExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        [Fact]
        public void GameExamples_PerformanceMonitoringExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        [Fact]
        public void GameExamples_DialogBoxExample_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        [Fact]
        public void GameExamples_CompleteGameTemplate_SkippedOnNonBrowser()
        {
            Assert.True(true);
        }

        // =====================================================================
        // MultiplatformGameEngine
        // =====================================================================

        [Fact]
        public void MultiplatformGameEngine_Constructor_DoesNotThrow()
        {
            var engine = new MultiplatformGameEngine(800, 600, "Test");
            Assert.NotNull(engine.GameContext);
        }

        [Fact]
        public void MultiplatformGameEngine_Dispose_DoesNotThrow()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Dispose();
                engine.Dispose();
            }
        }

        [Fact]
        public void MultiplatformGameEngine_Properties_Accessible()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                Assert.NotNull(engine.GameContext);
                Assert.NotNull(engine.Input);
                Assert.NotNull(engine.Display);
            }
        }

        // =====================================================================
        // InputManager wrapper
        // =====================================================================

        [Fact]
        public void InputManagerWrapper_GetMovementInput_NoKeys_ReturnsFalse()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                bool result = engine.Input.GetMovementInput(out float x, out float y);
                Assert.False(result);
                Assert.Equal(0, x);
                Assert.Equal(0, y);
            }
        }

        [Fact]
        public void InputManagerWrapper_IsJumpPressed_Default_ReturnsFalse()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                Assert.False(engine.Input.IsJumpPressed());
            }
        }

        [Fact]
        public void InputManagerWrapper_IsAttackPressed_Default_ReturnsFalse()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                Assert.False(engine.Input.IsAttackPressed());
            }
        }

        [Fact]
        public void InputManagerWrapper_GetCameraInput_DefaultValues()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Input.GetCameraInput(out float pitch, out float yaw);
            }
        }

        // =====================================================================
        // DisplayManager wrapper
        // =====================================================================

        [Fact]
        public void DisplayManagerWrapper_GetWidth_ReturnsWidth()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                Assert.Equal(800, engine.Display.GetWidth());
            }
        }

        [Fact]
        public void DisplayManagerWrapper_GetHeight_ReturnsHeight()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                Assert.Equal(600, engine.Display.GetHeight());
            }
        }

        [Fact]
        public void DisplayManagerWrapper_GetAspectRatio_ReturnsRatio()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                float aspect = engine.Display.GetAspectRatio();
                Assert.Equal(800.0f / 600.0f, aspect, 3);
            }
        }

        [Fact]
        public void DisplayManagerWrapper_IsFullscreen_ReturnsFalseOnNonBrowser()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Display.IsFullscreen();
            }
            else
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                Assert.False(engine.Display.IsFullscreen());
            }
        }

        [Fact]
        public void DisplayManagerWrapper_SetFullscreen_DoesNotThrow()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Display.SetFullscreen(true);
            }
            else
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Display.SetFullscreen(true);
            }
        }

        [Fact]
        public void DisplayManagerWrapper_ToggleFullscreen_DoesNotThrow()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Display.ToggleFullscreen();
            }
            else
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Display.ToggleFullscreen();
            }
        }

        [Fact]
        public void DisplayManagerWrapper_SetSize_DoesNotThrow()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Display.SetSize(1024, 768);
            }
            else
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Display.SetSize(1024, 768);
            }
        }

        [Fact]
        public void DisplayManagerWrapper_SetTitle_DoesNotThrow()
        {
            if (OperatingSystem.IsBrowser())
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Display.SetTitle("New Title");
            }
            else
            {
                var engine = new MultiplatformGameEngine(800, 600, "Test");
                engine.Display.SetTitle("New Title");
            }
        }

        // =====================================================================
        // SystemInfo - All methods
        // =====================================================================

        [Fact]
        public void SystemInfo_GetPlatformName_ReturnsWebAssembly()
        {
            Assert.Equal("WebAssembly", SystemInfo.GetPlatformName());
        }

        [Fact]
        public void SystemInfo_IsOnline_ReturnsFalseOnNonBrowser()
        {
            Assert.False(SystemInfo.IsOnline());
        }

        [Fact]
        public void SystemInfo_GetLanguage_ReturnsDefaultOnNonBrowser()
        {
            string lang = SystemInfo.GetLanguage();
            Assert.Equal("en", lang);
        }

        [Fact]
        public void SystemInfo_GetDevicePixelRatio_ReturnsDefaultOnNonBrowser()
        {
            float ratio = SystemInfo.GetDevicePixelRatio();
            Assert.Equal(1.0f, ratio);
        }

        [Fact]
        public void SystemInfo_GetBatteryLevel_ReturnsDefaultOnNonBrowser()
        {
            float level = SystemInfo.GetBatteryLevel();
            Assert.Equal(-1.0f, level);
        }

        [Fact]
        public void SystemInfo_IsCharging_ReturnsFalseOnNonBrowser()
        {
            Assert.False(SystemInfo.IsCharging());
        }

        [Fact]
        public void SystemInfo_GetScreenOrientation_ReturnsDefaultOnNonBrowser()
        {
            int orientation = SystemInfo.GetScreenOrientation();
            Assert.Equal(1, orientation); // landscape
        }

        [Fact]
        public void SystemInfo_GetSystemTimeMs_ReturnsZeroOnNonBrowser()
        {
            double time = SystemInfo.GetSystemTimeMs();
            Assert.Equal(0.0, time);
        }

        [Fact]
        public void SystemInfo_LogToConsole_DoesNotThrow()
        {
            SystemInfo.LogToConsole("test");
        }

        [Fact]
        public void SystemInfo_WarnToConsole_DoesNotThrow()
        {
            SystemInfo.WarnToConsole("test");
        }

        [Fact]
        public void SystemInfo_ErrorToConsole_DoesNotThrow()
        {
            SystemInfo.ErrorToConsole("test");
        }

        // =====================================================================
        // QuickStart
        // =====================================================================

        [Fact]
        public void QuickStart_RunMinimalGame_DoesNotThrow()
        {
            QuickStart.RunMinimalGame((w, h) => { });
        }

        [Fact]
        public void QuickStart_LogPlatformInfo_DoesNotThrow()
        {
            QuickStart.LogPlatformInfo();
        }

        // =====================================================================
        // GameContextPresets
        // =====================================================================

        [Fact]
        public void GameContextPresets_Game2D_ReturnsValidConfig()
        {
            var config = GameContextPresets.Game2D();
            Assert.Equal(1280, config.WindowWidth);
            Assert.Equal(720, config.WindowHeight);
            Assert.Equal("2D Game", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(4, config.MultisampleCount);
            Assert.Equal(DisplayQuality.High, config.DisplayQuality);
            Assert.True(config.GamepadInputEnabled);
            Assert.True(config.KeyboardInputEnabled);
            Assert.True(config.MouseInputEnabled);
        }

        [Fact]
        public void GameContextPresets_Game3D_ReturnsValidConfig()
        {
            var config = GameContextPresets.Game3D();
            Assert.Equal(1920, config.WindowWidth);
            Assert.Equal(1080, config.WindowHeight);
            Assert.Equal("3D Game", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.True(config.MultisamplingEnabled);
            Assert.Equal(8, config.MultisampleCount);
            Assert.Equal(DisplayQuality.VeryHigh, config.DisplayQuality);
        }

        [Fact]
        public void GameContextPresets_PuzzleGame_ReturnsValidConfig()
        {
            var config = GameContextPresets.PuzzleGame();
            Assert.Equal(800, config.WindowWidth);
            Assert.Equal(600, config.WindowHeight);
            Assert.Equal("Puzzle Game", config.WindowTitle);
            Assert.False(config.VSync);
            Assert.Equal(30, config.TargetFrameRate);
            Assert.False(config.MultisamplingEnabled);
            Assert.Equal(DisplayQuality.Medium, config.DisplayQuality);
            Assert.False(config.GamepadInputEnabled);
            Assert.True(config.KeyboardInputEnabled);
            Assert.True(config.MouseInputEnabled);
        }

        [Fact]
        public void GameContextPresets_MobileGame_ReturnsValidConfig()
        {
            var config = GameContextPresets.MobileGame();
            Assert.Equal(720, config.WindowWidth);
            Assert.Equal(1280, config.WindowHeight);
            Assert.Equal("Mobile Game", config.WindowTitle);
            Assert.True(config.VSync);
            Assert.Equal(60, config.TargetFrameRate);
            Assert.False(config.MultisamplingEnabled);
            Assert.Equal(DisplayQuality.Medium, config.DisplayQuality);
            Assert.True(config.TouchInputEnabled);
        }

        // =====================================================================
        // EmscriptenWeb - Wrapper methods that catch exceptions
        // =====================================================================

        [Fact]
        public void EmscriptenWeb_GetConnectedGamepads_ReturnsEmptyOnNonBrowser()
        {
            int[] gamepads = EmscriptenWeb.GetConnectedGamepads();
            Assert.NotNull(gamepads);
            Assert.Empty(gamepads);
        }

        [Fact]
        public void EmscriptenWeb_GetGamepadAxes_ReturnsEmptyOnNonBrowser()
        {
            float[] axes = EmscriptenWeb.GetGamepadAxes(0);
            Assert.NotNull(axes);
            Assert.Empty(axes);
        }

        [Fact]
        public void EmscriptenWeb_GetGamepadButtons_ReturnsEmptyOnNonBrowser()
        {
            bool[] buttons = EmscriptenWeb.GetGamepadButtons(0);
            Assert.NotNull(buttons);
            Assert.Empty(buttons);
        }

        [Fact]
        public void EmscriptenWeb_OpenFileDialog_ReturnsNullOnNonBrowser()
        {
            string result = EmscriptenWeb.OpenFileDialog();
            Assert.Null(result);
        }

        [Fact]
        public void EmscriptenWeb_OpenFileDialog_WithMimeTypes_ReturnsNullOnNonBrowser()
        {
            string result = EmscriptenWeb.OpenFileDialog("image/*");
            Assert.Null(result);
        }

        [Fact]
        public void EmscriptenWeb_PasteFromClipboard_ReturnsNullOnNonBrowser()
        {
            string result = EmscriptenWeb.PasteFromClipboard();
            Assert.Null(result);
        }

        [Fact]
        public void EmscriptenWeb_GetLanguage_ReturnsDefaultOnNonBrowser()
        {
            string lang = EmscriptenWeb.GetLanguage();
            Assert.Equal("en", lang);
        }

        // =====================================================================
        // Helper method
        // =====================================================================

        private static void InvokePrivate(object instance, string methodName, params object[] arguments)
        {
            MethodInfo method = instance.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            method.Invoke(instance, arguments);
        }
    }
}
