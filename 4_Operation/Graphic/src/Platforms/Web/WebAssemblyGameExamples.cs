// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameExamples.cs
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


using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Examples and utilities for developing games with WebAssembly
    ///     This class provides practical examples and helper methods for common game development tasks
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class WebAssemblyGameExamples
    {
        /// <summary>
        ///     Example 1: Basic game loop setup
        ///     Shows how to create a simple game context and run a basic game loop
        /// </summary>
        public static void BasicGameLoopExample()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(1280, 720, "My Game"))
            {
                gameContext.RegisterAction("Move_Up", ConsoleKey.W, ConsoleKey.UpArrow);
                gameContext.RegisterAction("Move_Down", ConsoleKey.S, ConsoleKey.DownArrow);
                gameContext.RegisterAction("Move_Left", ConsoleKey.A, ConsoleKey.LeftArrow);
                gameContext.RegisterAction("Move_Right", ConsoleKey.D, ConsoleKey.RightArrow);
                gameContext.RegisterAction("Jump", ConsoleKey.Spacebar);
                gameContext.RegisterAction("MenuToggle", ConsoleKey.Escape);

                gameContext.OnUpdate += (sender, e) =>
                {
                    if (gameContext.IsActionActive("Move_Up"))
                    {
                    }

                    if (gameContext.IsMouseButtonDown(0)) // Left mouse button
                    {
                        gameContext.GetMousePosition(out _, out _);
                    }
                };

                gameContext.OnFrame += (sender, e) =>
                {
                };

                gameContext.Run((context) =>
                {
                    float wheelDelta = context.InputManager.GetMouseWheelDelta();
                    if (wheelDelta != 0)
                    {
                    }
                });
            }
        }

        /// <summary>
        ///     Example 2: Advanced gamepad and input handling
        ///     Demonstrates how to handle multiple gamepad inputs and analog sticks
        /// </summary>
        public static void GamepadInputExample()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(1280, 720, "Gamepad Test"))
            {
                gameContext.Run((context) =>
                {
                    int[] connectedGamepads = context.GetConnectedGamepadIndices();

                    foreach (int gamepadIndex in connectedGamepads)
                    {
                        HandleSingleGamepadInput(context, gamepadIndex);
                    }
                });
            }
        }

        private static void HandleSingleGamepadInput(WebAssemblyGameContext context, int gamepadIndex)
        {
            if (context.TryGetGamepadState(gamepadIndex, out GamepadInputState gamepadState))
            {
                GamepadState state = gamepadState.CurrentState;

                if (state.ButtonA)
                {
                }

                if (state.ButtonB)
                {
                }

                if (context.InputManager.IsGamepadButtonJustPressed(gamepadIndex, 0)) // A button
                {
                }

                if (state.ButtonLb)
                {
                    WebAssemblyGameContext.VibrateGamepad(gamepadIndex, 1.0f, 0.5f, 0.1f);
                }
            }
        }

        /// <summary>
        ///     Example 3: Fullscreen and display management
        ///     Shows how to handle fullscreen transitions and display settings
        /// </summary>
        public static void DisplayManagementExample()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(1280, 720, "Display Test"))
            {
                gameContext.DisplayManager.OnDisplayResized += (sender, args) =>
                {
                    WebAssemblyGameContext.ConsoleLog($"Window resized to {args.Width}x{args.Height}");
                };

                gameContext.DisplayManager.OnOrientationChanged += (sender, args) =>
                {
                    WebAssemblyGameContext.ConsoleLog($"Orientation changed to: {args.Orientation}");
                };

                gameContext.DisplayManager.OnFullscreenChanged += (sender, args) =>
                {
                    WebAssemblyGameContext.ConsoleLog($"Fullscreen: {args.IsFullscreen}");
                };

                gameContext.Run((context) =>
                {
                    if (context.IsKeyDown(ConsoleKey.F))
                    {
                        Thread.Sleep(100); // Debounce
                        context.ToggleFullscreen();
                    }

                    ScreenOrientation orientation = context.DisplayManager.GetOrientation();
                    if (orientation == ScreenOrientation.Portrait)
                    {
                    }
                    else
                    {
                    }
                });
            }
        }

        /// <summary>
        ///     Example 4: Mouse and pointer lock for FPS games
        ///     Demonstrates pointer locking for first-person game controls
        /// </summary>
        public static void FpsGameExample()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(1280, 720, "FPS Game"))
            {
                bool pointerLocked = false;

                gameContext.Run((context) =>
                {
                    pointerLocked = HandlePointerLock(context, pointerLocked);
                    HandleKeyboardMovement(context);
                });
            }
        }

        private static bool HandlePointerLock(WebAssemblyGameContext context, bool pointerLocked)
        {
            if (context.IsMouseButtonDown(0) && !pointerLocked)
            {
                pointerLocked = WebAssemblyGameContext.LockPointer();
            }

            if (context.IsKeyDown(ConsoleKey.Escape) && pointerLocked)
            {
                pointerLocked = WebAssemblyGameContext.UnlockPointer();
            }

            if (pointerLocked)
            {
                context.GetMousePosition(out _, out _);
            }

            return pointerLocked;
        }

        private static void HandleKeyboardMovement(WebAssemblyGameContext context)
        {
            if (context.IsKeyDown(ConsoleKey.W))
            {
            }
            if (context.IsKeyDown(ConsoleKey.S))
            {
            }
            if (context.IsKeyDown(ConsoleKey.A))
            {
            }
            if (context.IsKeyDown(ConsoleKey.D))
            {
            }
        }

        /// <summary>
        ///     Example 5: Device information and system features
        ///     Shows how to query device capabilities and system information
        /// </summary>
        public static void SystemInfoExample()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(1280, 720, "System Info"))
            {
                WebAssemblyGameContext.ConsoleLog($"Device Language: {WebAssemblyGameContext.GetDeviceLanguage()}");
                WebAssemblyGameContext.ConsoleLog($"Is Online: {WebAssemblyGameContext.IsOnline()}");
                WebAssemblyGameContext.ConsoleLog($"Battery Level: {WebAssemblyGameContext.GetBatteryLevel():P}");
                WebAssemblyGameContext.ConsoleLog($"Is Charging: {WebAssemblyGameContext.IsCharging()}");
                WebAssemblyGameContext.ConsoleLog($"Screen Refresh Rate: {WebAssemblyGameContext.GetRefreshRate()} Hz");

                gameContext.Run((context) =>
                {
                    if (!WebAssemblyGameContext.IsOnline())
                    {
                        WebAssemblyGameContext.ConsoleWarn("Lost internet connection");
                    }

                    float batteryLevel = WebAssemblyGameContext.GetBatteryLevel();
                    if (batteryLevel < 0.2f && !WebAssemblyGameContext.IsCharging())
                    {
                        WebAssemblyGameContext.ConsoleWarn("Low battery warning");
                    }
                });
            }
        }

        /// <summary>
        ///     Example 6: Configuration presets for different game types
        ///     Demonstrates using predefined configurations for different scenarios
        /// </summary>
        public static void ConfigurationPresetsExample()
        {
            using (WebAssemblyGameContext game2D = new WebAssemblyGameContext(GameContextPresets.Game2D()))
            {
                game2D.Run((context) =>
                {
                });
            }

            using (WebAssemblyGameContext game3D = new WebAssemblyGameContext(GameContextPresets.Game3D()))
            {
                game3D.Run((context) =>
                {
                });
            }

            using (WebAssemblyGameContext mobileGame = new WebAssemblyGameContext(GameContextPresets.MobileGame()))
            {
                mobileGame.Run((context) =>
                {
                });
            }

            using (WebAssemblyGameContext customGame = WebAssemblyGameContext.Create(config =>
            {
                config
                    .WithSize(1600, 900)
                    .WithTitle("Custom Game")
                    .WithVSync(true)
                    .WithTargetFrameRate(120)
                    .WithMultisampling(true)
                    .WithMultisampleCount(8)
                    .WithGamepadInput(true)
                    .WithKeyboardInput(true)
                    .WithMouseInput(true);
            }))
            {
                customGame.Run((context) =>
                {
                });
            }
        }

        /// <summary>
        ///     Example 7: Text input handling
        ///     Shows how to handle keyboard text input for UI elements
        /// </summary>
        public static void TextInputExample()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(1280, 720, "Text Input"))
            {
                string userInput = "";

                gameContext.Run((context) =>
                {
                    if (context.TryGetInputText(out string text))
                    {
                        userInput += text;
                    }

                    if (context.IsKeyDown(ConsoleKey.Backspace) && userInput.Length > 0)
                    {
                        userInput = userInput.Substring(0, userInput.Length - 1);
                    }

                    if (userInput.Length > 50)
                    {
                        userInput = userInput.Substring(0, 50);
                    }

                    if (context.IsKeyDown(ConsoleKey.Delete))
                    {
                        userInput = "";
                    }
                });
            }
        }

        /// <summary>
        ///     Example 8: Performance monitoring and optimization
        ///     Shows how to monitor and optimize game performance
        /// </summary>
        public static void PerformanceMonitoringExample()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(1280, 720, "Performance Monitor"))
            {
                double lastFrameTime = 0;
                int frameCount = 0;
                double elapsedTime = 0;
                double fps = 0;

                gameContext.Run((context) =>
                {
                    double currentTime = EmscriptenWeb.GetSystemTimeMs();

                    if (lastFrameTime > 0)
                    {
                        double deltaTime = (currentTime - lastFrameTime) / 1000.0; // Convert to seconds
                        elapsedTime += deltaTime;
                        frameCount++;

                        if (elapsedTime >= 1.0)
                        {
                            fps = frameCount / elapsedTime;
                            WebAssemblyGameContext.ConsoleLog($"FPS: {fps:F2}");

                            if (fps < 30)
                            {
                                context.DisplayManager.SetDisplayQuality(DisplayQuality.Low);
                                WebAssemblyGameContext.ConsoleWarn("Low performance detected, reducing quality");
                            }
                            else if (fps > 60)
                            {
                                context.DisplayManager.SetDisplayQuality(DisplayQuality.High);
                            }

                            frameCount = 0;
                            elapsedTime = 0;
                        }
                    }

                    lastFrameTime = currentTime;
                });
            }
        }

        /// <summary>
        ///     Example 9: Dialog boxes and console logging
        ///     Demonstrates browser dialog interaction
        /// </summary>
        public static void DialogBoxExample()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(1280, 720, "Dialog Example"))
            {
                gameContext.Run((context) =>
                {
                    if (context.IsKeyDown(ConsoleKey.D1))
                    {
                        WebAssemblyGameContext.ConsoleLog("Debug message");
                        WebAssemblyGameContext.ConsoleWarn("Warning message");
                        WebAssemblyGameContext.ConsoleError("Error message");
                    }

                    if (context.IsKeyDown(ConsoleKey.D2))
                    {
                        WebAssemblyGameContext.ShowAlert("This is an alert!");
                    }

                    if (context.IsKeyDown(ConsoleKey.D3) && WebAssemblyGameContext.ShowConfirm("Do you want to quit?"))
                    {
                        context.Stop(); // Exit the game
                    }
                });
            }
        }

        /// <summary>
        ///     Example 10: Complete game starter template
        ///     A full example combining all features into a complete game template
        /// </summary>
        public static void CompleteGameTemplate()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(config =>
            {
                config
                    .WithSize(1280, 720)
                    .WithTitle("Game Template")
                    .WithVSync(true)
                    .WithTargetFrameRate(60)
                    .WithMultisampling(true)
                    .WithGamepadInput(true)
                    .WithKeyboardInput(true)
                    .WithMouseInput(true)
                    .WithDisplayQuality(DisplayQuality.High);
            }))
            {
                gameContext.RegisterAction("Move_Forward", ConsoleKey.W);
                gameContext.RegisterAction("Move_Backward", ConsoleKey.S);
                gameContext.RegisterAction("Move_Left", ConsoleKey.A);
                gameContext.RegisterAction("Move_Right", ConsoleKey.D);
                gameContext.RegisterAction("Jump", ConsoleKey.Spacebar);
                gameContext.RegisterAction("Attack", ConsoleKey.E);
                gameContext.RegisterAction("Menu", ConsoleKey.Escape);

                gameContext.OnUpdate += (s, e) =>
                {
                };

                gameContext.OnFrame += (s, e) =>
                {
                };

                gameContext.OnShutdown += (s, e) =>
                {
                    WebAssemblyGameContext.ConsoleLog("Game shutting down...");
                };

                gameContext.DisplayManager.OnDisplayResized += (s, e) =>
                {
                    WebAssemblyGameContext.ConsoleLog($"Resized to {e.Width}x{e.Height}");
                };

                gameContext.Run((context) =>
                {
                    if (context.IsActionActive("Move_Forward"))
                    {
                    }
                    if (context.IsActionActive("Move_Backward"))
                    {
                    }
                    if (context.IsActionActive("Move_Left"))
                    {
                    }
                    if (context.IsActionActive("Move_Right"))
                    {
                    }

                    if (context.IsActionJustPressed("Jump"))
                    {
                    }

                    if (context.IsActionJustPressed("Attack"))
                    {
                    }

                    if (context.IsActionJustPressed("Menu"))
                    {
                    }

                });
            }
        }
    }

    /// <summary>
    ///     Utility helper class for common game development tasks
    /// </summary>
    public static class GameDevelopmentUtils
    {
        /// <summary>
        ///     Applies deadzone filtering to analog stick input
        /// </summary>
        public static void ApplyDeadzone(ref float x, ref float y, float deadzone = 0.15f)
        {
            float magnitude = (float)Math.Sqrt(x * x + y * y);

            if (magnitude < deadzone)
            {
                x = 0;
                y = 0;
            }
            else
            {
                float normalizedMagnitude = (magnitude - deadzone) / (1.0f - deadzone);
                x = (x / magnitude) * normalizedMagnitude;
                y = (y / magnitude) * normalizedMagnitude;
            }
        }

        /// <summary>
        ///     Normalizes 2D vector input
        /// </summary>
        public static void NormalizeInput(ref float x, ref float y)
        {
            float magnitude = (float)Math.Sqrt(x * x + y * y);
            if (magnitude > 1.0f)
            {
                x /= magnitude;
                y /= magnitude;
            }
        }

        /// <summary>
        ///     Gets the button name for a gamepad button index
        /// </summary>
        public static string GetGamepadButtonName(int buttonIndex)
        {
            return buttonIndex switch
            {
                0 => "A / Cross",
                1 => "B / Circle",
                2 => "X / Square",
                3 => "Y / Triangle",
                4 => "LB / L1",
                5 => "RB / R1",
                6 => "LT",
                7 => "RT",
                8 => "Back / Select",
                9 => "Start",
                10 => "Left Stick Click",
                11 => "Right Stick Click",
                12 => "Guide / Home",
                _ => $"Button {buttonIndex}"
            };
        }

        /// <summary>
        ///     Converts a platform key to a human-readable name
        /// </summary>
        public static string GetKeyName(ConsoleKey key)
        {
            return WebAssemblyInputManager.GetKeyName(key);
        }
    }
}

