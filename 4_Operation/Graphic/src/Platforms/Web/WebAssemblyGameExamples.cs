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

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Examples and utilities for developing games with WebAssembly
    ///     This class provides practical examples and helper methods for common game development tasks
    /// </summary>
    public static class WebAssemblyGameExamples
    {
        /// <summary>
        ///     Example 1: Basic game loop setup
        ///     Shows how to create a simple game context and run a basic game loop
        /// </summary>
        public static void BasicGameLoopExample()
        {
            // Create a game context with specific dimensions
            using (var gameContext = WebAssemblyGameContext.Create(1280, 720, "My Game"))
            {
                // Register keyboard controls
                gameContext.RegisterAction("Move_Up", ConsoleKey.W, ConsoleKey.UpArrow);
                gameContext.RegisterAction("Move_Down", ConsoleKey.S, ConsoleKey.DownArrow);
                gameContext.RegisterAction("Move_Left", ConsoleKey.A, ConsoleKey.LeftArrow);
                gameContext.RegisterAction("Move_Right", ConsoleKey.D, ConsoleKey.RightArrow);
                gameContext.RegisterAction("Jump", ConsoleKey.Spacebar);
                gameContext.RegisterAction("MenuToggle", ConsoleKey.Escape);

                // Subscribe to frame events
                gameContext.OnUpdate += (sender, e) =>
                {
                    // Your game update logic here
                    if (gameContext.IsActionActive("Move_Up"))
                    {
                        // Handle up movement
                    }

                    if (gameContext.IsMouseButtonDown(0)) // Left mouse button
                    {
                        gameContext.GetMousePosition(out int x, out int y);
                        // Handle mouse click at (x, y)
                    }
                };

                gameContext.OnFrame += (sender, e) =>
                {
                    // Your game rendering logic here
                };

                // Run the game with custom update logic
                gameContext.Run((context) =>
                {
                    // Per-frame update
                    float wheelDelta = context.InputManager.GetMouseWheelDelta();
                    if (wheelDelta != 0)
                    {
                        // Handle mouse wheel zoom
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
            using (var gameContext = WebAssemblyGameContext.Create(1280, 720, "Gamepad Test"))
            {
                gameContext.Run((context) =>
                {
                    // Get all connected gamepads
                    int[] connectedGamepads = context.GetConnectedGamepadIndices();

                    foreach (int gamepadIndex in connectedGamepads)
                    {
                        // Get gamepad state
                        if (context.TryGetGamepadState(gamepadIndex, out GamepadInputState gamepadState))
                        {
                            GamepadState state = gamepadState.CurrentState;

                            // Read analog sticks
                            float leftStickX = state.LeftStickX;
                            float leftStickY = state.LeftStickY;
                            float rightStickX = state.RightStickX;
                            float rightStickY = state.RightStickY;

                            // Apply deadzone
                            if (Math.Abs(leftStickX) < 0.15f) leftStickX = 0;
                            if (Math.Abs(leftStickY) < 0.15f) leftStickY = 0;

                            // Read triggers
                            float leftTrigger = state.LeftTrigger;
                            float rightTrigger = state.RightTrigger;

                            // Check buttons
                            if (state.ButtonA)
                            {
                                // Handle A button press
                            }

                            if (state.ButtonB)
                            {
                                // Handle B button press
                            }

                            // Check for button state changes
                            if (context.InputManager.IsGamepadButtonJustPressed(gamepadIndex, 0)) // A button
                            {
                                // A button was just pressed
                            }

                            // Trigger vibration feedback
                            if (state.ButtonLb)
                            {
                                context.VibrateGamepad(gamepadIndex, 1.0f, 0.5f, 0.1f);
                            }
                        }
                    }
                });
            }
        }

        /// <summary>
        ///     Example 3: Fullscreen and display management
        ///     Shows how to handle fullscreen transitions and display settings
        /// </summary>
        public static void DisplayManagementExample()
        {
            using (var gameContext = WebAssemblyGameContext.Create(1280, 720, "Display Test"))
            {
                gameContext.DisplayManager.OnDisplayResized += (sender, args) =>
                {
                    WebAssemblyGameContext.ConsoleLog($"Window resized to {args.Width}x{args.Height}");
                    // Update your game camera/UI layout here
                };

                gameContext.DisplayManager.OnOrientationChanged += (sender, args) =>
                {
                    WebAssemblyGameContext.ConsoleLog($"Orientation changed to: {args.Orientation}");
                    // Adjust game layout for portrait/landscape
                };

                gameContext.DisplayManager.OnFullscreenChanged += (sender, args) =>
                {
                    WebAssemblyGameContext.ConsoleLog($"Fullscreen: {args.IsFullscreen}");
                };

                gameContext.Run((context) =>
                {
                    // Toggle fullscreen with F key
                    if (context.IsKeyDown(ConsoleKey.F))
                    {
                        System.Threading.Thread.Sleep(100); // Debounce
                        context.ToggleFullscreen();
                    }

                    // Get current display info
                    int width = context.GetWidth();
                    int height = context.GetHeight();
                    float aspectRatio = context.GetAspectRatio();
                    float devicePixelRatio = context.DisplayManager.GetDevicePixelRatio();

                    // Check orientation for responsive layout
                    var orientation = context.DisplayManager.GetOrientation();
                    if (orientation == ScreenOrientation.Portrait)
                    {
                        // Use portrait layout
                    }
                    else
                    {
                        // Use landscape layout
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
            using (var gameContext = WebAssemblyGameContext.Create(1280, 720, "FPS Game"))
            {
                bool pointerLocked = false;

                gameContext.Run((context) =>
                {
                    // Click to lock pointer (typical FPS behavior)
                    if (context.IsMouseButtonDown(0) && !pointerLocked)
                    {
                        pointerLocked = context.LockPointer();
                    }

                    // Escape to unlock pointer
                    if (context.IsKeyDown(ConsoleKey.Escape) && pointerLocked)
                    {
                        pointerLocked = context.UnlockPointer();
                    }

                    // Get mouse movement for camera control
                    if (pointerLocked)
                    {
                        context.GetMousePosition(out int mouseX, out int mouseY);

                        // Use mouseX and mouseY for camera rotation
                        // Calculate delta from center of screen for smooth look
                    }

                    // Keyboard movement
                    float moveX = 0, moveY = 0;
                    if (context.IsKeyDown(ConsoleKey.W))
                        moveY += 1.0f;
                    if (context.IsKeyDown(ConsoleKey.S))
                        moveY -= 1.0f;
                    if (context.IsKeyDown(ConsoleKey.A))
                        moveX -= 1.0f;
                    if (context.IsKeyDown(ConsoleKey.D))
                        moveX += 1.0f;

                    // Gamepad support for WASD
                    if (context.TryGetGamepadState(0, out GamepadInputState gamepadState))
                    {
                        moveX += gamepadState.CurrentState.LeftStickX;
                        moveY += gamepadState.CurrentState.LeftStickY;

                        // Camera with right stick
                        float lookX = gamepadState.CurrentState.RightStickX;
                        float lookY = gamepadState.CurrentState.RightStickY;
                    }

                    // Normalize movement if both axes are pressed
                    float moveMagnitude = (float)Math.Sqrt(moveX * moveX + moveY * moveY);
                    if (moveMagnitude > 1.0f)
                    {
                        moveX /= moveMagnitude;
                        moveY /= moveMagnitude;
                    }
                });
            }
        }

        /// <summary>
        ///     Example 5: Device information and system features
        ///     Shows how to query device capabilities and system information
        /// </summary>
        public static void SystemInfoExample()
        {
            using (var gameContext = WebAssemblyGameContext.Create(1280, 720, "System Info"))
            {
                // Log system information
                WebAssemblyGameContext.ConsoleLog($"Device Language: {gameContext.GetDeviceLanguage()}");
                WebAssemblyGameContext.ConsoleLog($"Is Online: {gameContext.IsOnline()}");
                WebAssemblyGameContext.ConsoleLog($"Battery Level: {gameContext.GetBatteryLevel():P}");
                WebAssemblyGameContext.ConsoleLog($"Is Charging: {gameContext.IsCharging()}");
                WebAssemblyGameContext.ConsoleLog($"Screen Refresh Rate: {gameContext.GetRefreshRate()} Hz");

                gameContext.Run((context) =>
                {
                    // Check connection status periodically
                    if (!context.IsOnline())
                    {
                        WebAssemblyGameContext.ConsoleWarn("Lost internet connection");
                        // Pause gameplay or show offline message
                    }

                    // Monitor battery for mobile devices
                    float batteryLevel = context.GetBatteryLevel();
                    if (batteryLevel < 0.2f && !context.IsCharging())
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
            // Create a 2D game with optimized settings
            using (var game2D = new WebAssemblyGameContext(GameContextPresets.Game2D()))
            {
                game2D.Run((context) =>
                {
                    // 2D game logic
                });
            }

            // Create a 3D game with high-quality settings
            using (var game3D = new WebAssemblyGameContext(GameContextPresets.Game3D()))
            {
                game3D.Run((context) =>
                {
                    // 3D game logic
                });
            }

            // Create a mobile game with touch support
            using (var mobileGame = new WebAssemblyGameContext(GameContextPresets.MobileGame()))
            {
                mobileGame.Run((context) =>
                {
                    // Mobile game logic with touch input
                });
            }

            // Create a custom configuration with builder pattern
            using (var customGame = WebAssemblyGameContext.Create(config =>
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
                    // Custom game logic
                });
            }
        }

        /// <summary>
        ///     Example 7: Text input handling
        ///     Shows how to handle keyboard text input for UI elements
        /// </summary>
        public static void TextInputExample()
        {
            using (var gameContext = WebAssemblyGameContext.Create(1280, 720, "Text Input"))
            {
                string userInput = "";

                gameContext.Run((context) =>
                {
                    // Collect text input
                    if (context.TryGetInputText(out string text))
                    {
                        userInput += text;
                    }

                    // Handle backspace
                    if (context.IsKeyDown(ConsoleKey.Backspace) && userInput.Length > 0)
                    {
                        userInput = userInput.Substring(0, userInput.Length - 1);
                    }

                    // Handle maximum input length
                    if (userInput.Length > 50)
                    {
                        userInput = userInput.Substring(0, 50);
                    }

                    // Clear input with Ctrl+A then Delete
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
            using (var gameContext = WebAssemblyGameContext.Create(1280, 720, "Performance Monitor"))
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

                        // Calculate FPS every second
                        if (elapsedTime >= 1.0)
                        {
                            fps = frameCount / elapsedTime;
                            WebAssemblyGameContext.ConsoleLog($"FPS: {fps:F2}");

                            // Adjust quality if FPS is too low
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
            using (var gameContext = WebAssemblyGameContext.Create(1280, 720, "Dialog Example"))
            {
                gameContext.Run((context) =>
                {
                    // Show debug information in console
                    if (context.IsKeyDown(ConsoleKey.D1))
                    {
                        WebAssemblyGameContext.ConsoleLog("Debug message");
                        WebAssemblyGameContext.ConsoleWarn("Warning message");
                        WebAssemblyGameContext.ConsoleError("Error message");
                    }

                    // Show alert dialog
                    if (context.IsKeyDown(ConsoleKey.D2))
                    {
                        WebAssemblyGameContext.ShowAlert("This is an alert!");
                    }

                    // Show confirmation dialog
                    if (context.IsKeyDown(ConsoleKey.D3))
                    {
                        if (WebAssemblyGameContext.ShowConfirm("Do you want to quit?"))
                        {
                            context.Stop(); // Exit the game
                        }
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
            using (var gameContext = WebAssemblyGameContext.Create(config =>
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
                // Setup game actions
                gameContext.RegisterAction("Move_Forward", ConsoleKey.W);
                gameContext.RegisterAction("Move_Backward", ConsoleKey.S);
                gameContext.RegisterAction("Move_Left", ConsoleKey.A);
                gameContext.RegisterAction("Move_Right", ConsoleKey.D);
                gameContext.RegisterAction("Jump", ConsoleKey.Spacebar);
                gameContext.RegisterAction("Attack", ConsoleKey.E);
                gameContext.RegisterAction("Menu", ConsoleKey.Escape);

                // Setup event handlers
                gameContext.OnUpdate += (s, e) =>
                {
                    // Physics update, logic, etc.
                };

                gameContext.OnFrame += (s, e) =>
                {
                    // Rendering
                };

                gameContext.OnShutdown += (s, e) =>
                {
                    WebAssemblyGameContext.ConsoleLog("Game shutting down...");
                };

                // Display events
                gameContext.DisplayManager.OnDisplayResized += (s, e) =>
                {
                    WebAssemblyGameContext.ConsoleLog($"Resized to {e.Width}x{e.Height}");
                };

                // Run main game loop
                gameContext.Run((context) =>
                {
                    // Input handling
                    float moveX = 0, moveY = 0;

                    if (context.IsActionActive("Move_Forward"))
                        moveY += 1.0f;
                    if (context.IsActionActive("Move_Backward"))
                        moveY -= 1.0f;
                    if (context.IsActionActive("Move_Left"))
                        moveX -= 1.0f;
                    if (context.IsActionActive("Move_Right"))
                        moveX += 1.0f;

                    if (context.IsActionJustPressed("Jump"))
                    {
                        // Jump logic
                    }

                    if (context.IsActionJustPressed("Attack"))
                    {
                        // Attack logic
                    }

                    if (context.IsActionJustPressed("Menu"))
                    {
                        // Show menu or pause
                    }

                    // Gamepad analog stick movement
                    if (context.TryGetGamepadState(0, out GamepadInputState gamepadState))
                    {
                        moveX += gamepadState.CurrentState.LeftStickX;
                        moveY += gamepadState.CurrentState.LeftStickY;
                    }

                    // Normalize movement
                    float magnitude = (float)Math.Sqrt(moveX * moveX + moveY * moveY);
                    if (magnitude > 1.0f)
                    {
                        moveX /= magnitude;
                        moveY /= magnitude;
                    }

                    // Update game state with movement
                    // ... your game logic here ...
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

