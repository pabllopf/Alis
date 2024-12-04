// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlController.cs
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Data.Dll;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Fonts;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Core.Physic.Dynamics;
using MonoMac.AppKit;
using Action = System.Action;
using Sdl = Alis.Core.Graphic.Sdl2.Sdl;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Core.Sample
{
    /// <summary>
    ///     The sdl controller class
    /// </summary>
    public static class SdlController
    {
        /// <summary>
        ///     The width
        /// </summary>
        private const int Width = 640;

        /// <summary>
        ///     The height
        /// </summary>
        private const int Height = 480;

        /// <summary>
        ///     The pixels per meter
        /// </summary>
        private const float PIXELS_PER_METER = 32f;

        /// <summary>
        ///     The sdl game controller axis
        /// </summary>
        private static readonly List<GameControllerAxis> Axis = new List<GameControllerAxis>((GameControllerAxis[]) Enum.GetValues(typeof(GameControllerAxis)));

        /// <summary>
        ///     The sdl game controller button
        /// </summary>
        private static readonly List<GameControllerButton> Buttons = new List<GameControllerButton>((GameControllerButton[]) Enum.GetValues(typeof(GameControllerButton)));

        /// <summary>
        ///     The font manager
        /// </summary>
        private static FontManager _fontManager;

        /// <summary>
        ///     The blue
        /// </summary>
        private static byte _blue;

        /// <summary>
        ///     The blue
        /// </summary>
        private static byte _green;

        /// <summary>
        ///     The sdl keycode
        /// </summary>
        private static List<KeyCodes> _keys = new List<KeyCodes>((KeyCodes[]) Enum.GetValues(typeof(KeyCodes)));

        /// <summary>
        ///     The blue
        /// </summary>
        private static byte _red;

        /// <summary>
        ///     The running
        /// </summary>
        private static bool _running = true;

        /// <summary>
        ///     The sdl event
        /// </summary>
        private static Event _sdlEvent;

        /// <summary>
        ///     The player body
        /// </summary>
        private static Body _playerBody;

        /// <summary>
        ///     The player body radius
        /// </summary>
        private static readonly float _playerBodyRadius = 1.5f / 2f; // player diameter is 1.5 meters

        // Add a variable to store the desired frame rate
        /// <summary>
        ///     The target fps
        /// </summary>
        private static readonly int targetFps = 60;

        // Calculate the frame duration based on the desired frame rate
        /// <summary>
        ///     The target fps
        /// </summary>
        private static readonly int frameDuration = 1000 / targetFps;

        /// <summary>
        ///     The renderer
        /// </summary>
        private static IntPtr _renderer;

        // Importa la función para crear el menú desde la biblioteca compartida
        /// <summary>
        /// Creates the custom menu
        /// </summary>
        [DllImport("libCustomMenu.dylib", EntryPoint = "createMenu", CallingConvention = CallingConvention.Cdecl)]
        public static extern void createCustomMenu();

        // Importa las funciones de acción
        /// <summary>
        /// Files the new action
        /// </summary>
        [DllImport("libCustomMenu.dylib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void fileNewAction();

        /// <summary>
        /// Files the open action
        /// </summary>
        [DllImport("libCustomMenu.dylib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void fileOpenAction();

        /// <summary>
        /// Edits the undo action
        /// </summary>
        [DllImport("libCustomMenu.dylib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void editUndoAction();

        /// <summary>
        /// Edits the redo action
        /// </summary>
        [DllImport("libCustomMenu.dylib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void editRedoAction();

        /// <summary>
        /// Views the zoom in action
        /// </summary>
        [DllImport("libCustomMenu.dylib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void viewZoomInAction();

        /// <summary>
        /// Views the zoom out action
        /// </summary>
        [DllImport("libCustomMenu.dylib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void viewZoomOutAction();

        // Declarar la librería compartida .dylib
        /// <summary>
        /// Sets the dot net callback using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        [DllImport("libCustomMenu.dylib")]
        public static extern void setDotNetCallback(Action callback);

        // Método que se ejecutará cuando el botón en Cocoa sea presionado
        /// <summary>
        /// Samples the action
        /// </summary>
        public static void SampleAction()
        {
            Console.WriteLine("Called from .NET");
        }


        // Declaración de la función C expuesta para definir el callback
        /// <summary>
        /// Sets the test callback using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        [DllImport("libCustomMenu.dylib", CallingConvention = CallingConvention.Cdecl)]
        public static extern void setTestCallback(Action callback);


        /// <summary>
        ///     Runs
        /// </summary>
        public static void Run()
        {
            // Ejecutar la aplicación gráfica


            if (Sdl.Init(InitSettings.InitEverything) < 0)
            {
                Logger.Exception($@"There was an issue initializing SDL. {Sdl.GetError()}");
            }
            else
            {
                Logger.Info("Init all");
            }

            // GET VERSION SDL2
            Version versionSdl2 = Sdl.GetVersion();
            Logger.Info($"SDL2 VERSION {versionSdl2.major}.{versionSdl2.minor}.{versionSdl2.patch}");

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Windows)
            {
                Sdl.SetHint(Hint.HintRenderDriver, "direct3d");
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.OSX)
            {
                Sdl.SetHint(Hint.HintRenderDriver, "opengl");
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Linux)
            {
                Sdl.SetHint(Hint.HintRenderDriver, "opengl");
            }

            // create the window which should be able to have a valid OpenGL context and is resizable
            WindowSettings flags = WindowSettings.WindowResizable | WindowSettings.WindowShown | WindowSettings.WindowOpengl;

            // Creates a new SDL window at the center of the screen with the given width and height.
            IntPtr window = Sdl.CreateWindow("Sample", (int) WindowPos.WindowPosCentered, (int) WindowPos.WindowPosCentered, Width, Height, flags);

            // Check if the window was created successfully.
            if (window == IntPtr.Zero)
            {
                Logger.Exception($"There was an issue creating the renderer. {Sdl.GetError()}");
            }
            else
            {
                Logger.Info("Window created");
            }

            // Creates a new SDL hardware renderer using the default graphics device with VSYNC enabled.
            _renderer = Sdl.CreateRenderer(
                window,
                -1,
                Renderers.SdlRendererAccelerated);

            if (_renderer == IntPtr.Zero)
            {
                Logger.Exception($"There was an issue creating the renderer. {Sdl.GetError()}");
            }
            else
            {
                Logger.Info("Renderer created");
            }


            IntPtr icon = Sdl.LoadBmp(AssetManager.Find("logo.bmp"));
            Sdl.SetWindowIcon(window, icon);

            Sdlinput();

            // Rectangle to be drawn outline.
            RectangleI rectBorder = new RectangleI
            {
                X = 0,
                Y = 0,
                W = 50,
                H = 50
            };

            // Rectangle to be drawn filled.
            RectangleI rectFilled = new RectangleI
            {
                X = 200,
                Y = 200,
                W = 100,
                H = 100
            };

            RectangleI tileRectangleI = new RectangleI
            {
                X = 0,
                Y = 0,
                W = 32,
                H = 64
            };

            // Load the image from the specified path.
            IntPtr imageTilePtr = Sdl.LoadBmp("Assets/tile000.bmp");

            // Create a new texture from the image.
            IntPtr textureTile = Sdl.CreateTextureFromSurface(_renderer, imageTilePtr);

            World world = new World();
            //float PIXELS_PER_METER = 32f;

            /* Circle */
            Vector2 playerPosition = new Vector2(0, 50);

            // Create the player fixture
            _playerBody = world.CreateBody(playerPosition, 0, BodyType.Dynamic);
            Fixture pfixture = _playerBody.CreateCircle(_playerBodyRadius, 1f);

            // Give it some bounce and friction
            pfixture.Restitution = 0.3f;
            pfixture.Friction = 0.5f;

            Vector2 sizeBox = new Vector2(10, 1);
            Body box = world.CreateRectangle(sizeBox.X, sizeBox.Y, 1);
            box.BodyType = BodyType.Static;
            box.Position = new Vector2(0, 0);
            box.SetFriction(0.5f);
            box.SetRestitution(0.3f);


            Vector2 textureBoxSize = new Vector2(1, 1);
            Body textureBox = world.CreateRectangle(textureBoxSize.X, textureBoxSize.Y, 1);
            textureBox.BodyType = BodyType.Static;
            textureBox.Position = new Vector2(5, 5);
            textureBox.SetFriction(0.5f);
            textureBox.SetRestitution(0.3f);

            // Define two Transform objects to store the positions of the bodies
            Transform playerTransform = new Transform();
            Transform boxTransform = new Transform();
            Transform textureTransform = new Transform();

            Camera camera = new Camera(_renderer);


            Stopwatch stopwatch = new Stopwatch();

            Stopwatch realTimeStopwatch = new Stopwatch();
            realTimeStopwatch.Start();
            int frameCounter = 0;

            float timeStepPhysics = 1f / 20f;
            if (targetFps <= 240)
            {
                timeStepPhysics = 1f / 80f;
            }

            if (targetFps <= 200)
            {
                timeStepPhysics = 1f / 60f;
            }

            if (targetFps <= 120)
            {
                timeStepPhysics = 1f / 40f;
            }

            if (targetFps <= 60)
            {
                timeStepPhysics = 1f / 30f;
            }

            if (targetFps <= 30)
            {
                timeStepPhysics = 1f / 15f;
            }

            if (targetFps <= 15)
            {
                timeStepPhysics = 1f / 10f;
            }

            if (targetFps <= 5)
            {
                timeStepPhysics = 1f / 5f;
            }

            _fontManager = new FontManager(_renderer, RendererFlips.FlipVertical);
            _fontManager.LoadFont("MONO", 16, Color.White, Color.Black, $"{Environment.CurrentDirectory}/Assets/MONO_V5.bmp");

            // Llama al método que inicializa el menú
            //createCustomMenu();

            // Definir el callback en .NET y pasarlo a Objective-C
            /*setTestCallback(() =>
            {
                Console.WriteLine("Callback ejecutado desde .NET!");
            });*/

            /*
            setDotNetCallback(() => {
                Console.WriteLine("Botón presionado, llamando a .NET");
            });*/

            // Crea y configura el menú

#if OSX
            ConfigureMenu();
#endif

            while (_running)
            {
                stopwatch.Restart();

                Sdl.JoystickUpdate();

                while (Sdl.PollEvent(out _sdlEvent) != 0)
                {
                    switch (_sdlEvent.type)
                    {
                        case EventType.Quit:
                            _running = false;
                            break;
                        case EventType.Keydown:
                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Escape)
                            {
                                _running = false;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Up)
                            {
                                camera.Position.Y += 10;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Down)
                            {
                                camera.Position.Y -= 10;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Left)
                            {
                                camera.Position.X -= 10;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Right)
                            {
                                camera.Position.X += 10;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.W)
                            {
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.S)
                            {
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.A)
                            {
                                _playerBody.ApplyTorque(10); // Apply positive torque to rotate right
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.D)
                            {
                                _playerBody.ApplyTorque(-10); // Apply negative torque to rotate left
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Space)
                            {
                                _playerBody.ApplyLinearImpulse(new Vector2(0, 10));
                            }

                            //Logger.Info(_sdlEvent.key.KeySym.sym + " was pressed");
                            break;
                    }

                    foreach (GameControllerButton button in Buttons)
                    {
                        if ((_sdlEvent.type == EventType.JoyButtonDown)
                            && (button == (GameControllerButton) _sdlEvent.cButton.button))
                        {
                            Logger.Info($"[SDL_JoystickName_id = '{_sdlEvent.cDevice.which}'] Pressed button={button}");
                        }
                    }

                    foreach (GameControllerAxis axi in Axis)
                    {
                        if ((_sdlEvent.type == EventType.JoyAxisMotion)
                            && (axi == (GameControllerAxis) _sdlEvent.cAxis.axis))
                        {
                            Logger.Info($"[SDL_JoystickName_id = '{_sdlEvent.cDevice.which}'] Pressed axi={axi}");
                        }
                    }
                }


                /*RenderColors();

                // Sets the color that the screen will be cleared with.
                Sdl.SetRenderDrawColor(renderer, _red, _green, _blue, 255);

                Sdl.RenderClear(renderer);


                // Sets the color that the rectangle will be drawn with.
                Sdl.SetRenderDrawColor(renderer, 255, 255, 255, 255);
                // Draws a rectangle outline.
                Sdl.RenderDrawRect(renderer, ref rectBorder);

                // Sets the color that the rectangle will be drawn with.
                Sdl.SetRenderDrawColor(renderer, 0, 0, 0, 255);

                // Draws a filled rectangle.
                Sdl.RenderFillRect(renderer, ref rectFilled);

                Sdl.RenderCopy(renderer, _textureFont1, IntPtr.Zero, ref _dstRectFont1);

                Sdl.RenderCopy(renderer, textureTile, IntPtr.Zero, ref tileRectangleI);

                Sdl.RenderDrawRects(renderer, new[] {rectBorder, rectFilled}, 2);*/


                // PHYSICS:
                world.Step(timeStepPhysics);

                // TRANSFORMS:
                // Update the transforms with the positions of the bodies
                playerTransform.Position = _playerBody.Position;
                playerTransform.Rotation = _playerBody.Rotation;

                boxTransform.Position = box.Position;
                boxTransform.Rotation = box.Rotation;

                textureTransform.Position = textureBox.Position;
                textureTransform.Rotation = textureBox.Rotation;

                // START RENDER THE CAMERA
                IntPtr cameraTexture = camera.TextureTarget;
                Color bgColor = camera.BackgroundColor;

                // Set render target to camera texture
                Sdl.SetRenderTarget(_renderer, cameraTexture);
                Sdl.SetRenderDrawColor(_renderer, bgColor.R, bgColor.G, bgColor.B, bgColor.A);
                Sdl.RenderClear(_renderer);

                // RENDER:

                // Convert positions and sizes from meters to pixels
                float playerPosX = playerTransform.Position.X * PIXELS_PER_METER;
                float playerPosY = playerTransform.Position.Y * PIXELS_PER_METER;
                float boxPosX = boxTransform.Position.X * PIXELS_PER_METER;
                float boxPosY = boxTransform.Position.Y * PIXELS_PER_METER;
                float boxWidth = sizeBox.X * PIXELS_PER_METER;
                float boxHeight = sizeBox.Y * PIXELS_PER_METER;

                // Draw the player circle:
                int circleX = (int) (playerPosX - camera.Position.X + camera.Resolution.X / 2);
                int circleY = (int) (playerPosY - camera.Position.Y + camera.Resolution.Y / 2);
                Sdl.SetRenderDrawColor(_renderer, 0, 255, 0, 255);
                DrawCircleWithLine(_renderer, circleX, circleY, (int) (_playerBodyRadius * PIXELS_PER_METER), playerTransform.Rotation * 180 / MathF.PI);

                // Draw the box:
                int boxX = (int) (boxPosX - camera.Position.X + camera.Resolution.X / 2);
                int boxY = (int) (boxPosY - camera.Position.Y + camera.Resolution.Y / 2);
                Sdl.SetRenderDrawColor(_renderer, 255, 0, 0, 255);
                RectangleI boxRect = new RectangleI
                {
                    X = (int) (boxX - boxWidth / 2),
                    Y = (int) (boxY - boxHeight / 2),
                    W = (int) boxWidth,
                    H = (int) boxHeight
                };
                Sdl.RenderDrawRect(_renderer, ref boxRect);


                _fontManager.RenderText("MONO", "0123456789", 10, 10);

                _fontManager.RenderText("MONO", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", 10, 40);

                _fontManager.RenderText("MONO", "abcdefghijklmnopqrstuvwxyz", 10, 70, Color.Brown, Color.White);


                _fontManager.RenderText("MONO", "0123456789", 320, 10, Color.White, Color.Transparent);

                _fontManager.RenderText("MONO", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", 320, 40, Color.Green, Color.White);

                _fontManager.RenderText("MONO", "abcdefghijklmnopqrstuvwxyz", 320, 70, Color.DarkGreen, Color.White);


                _fontManager.RenderText("MONO", "0123456789", 10, 100, Color.White, Color.Transparent, 32);

                // render the texture box
                Sdl.SetRenderDrawColor(_renderer, 0, 0, 255, 255);
                RectangleI textureBoxRect = new RectangleI
                {
                    X = (int) (textureTransform.Position.X * PIXELS_PER_METER - camera.Position.X + camera.Resolution.X / 2 - tileRectangleI.W / 2),
                    Y = (int) (textureTransform.Position.Y * PIXELS_PER_METER - camera.Position.Y + camera.Resolution.Y / 2 - tileRectangleI.H / 2),
                    W = tileRectangleI.W,
                    H = tileRectangleI.H
                };
                Sdl.RenderDrawRect(_renderer, ref textureBoxRect);
                Sdl.RenderCopyEx(_renderer, textureTile, IntPtr.Zero, ref textureBoxRect, textureTransform.Rotation * 180 / MathF.PI, IntPtr.Zero, RendererFlips.FlipVertical);


                // RENDER THE CAMERA
                // Reset the render target to the default SDL backbuffer
                Sdl.SetRenderTarget(_renderer, IntPtr.Zero);

                // Copy the custom backbuffer to the SDL backbuffer with vertical flip
                Sdl.RenderCopyEx(_renderer, cameraTexture, IntPtr.Zero, IntPtr.Zero, 0, IntPtr.Zero, RendererFlips.FlipVertical);

                Sdl.RenderPresent(_renderer);


                stopwatch.Stop();
                int frameTime = (int) stopwatch.ElapsedMilliseconds;

                // Sleep for the remaining time to maintain the desired frame rate
                if (frameTime < frameDuration)
                {
                    Thread.Sleep(frameDuration - frameTime);
                }

                frameCounter++;

                if (realTimeStopwatch.ElapsedMilliseconds >= 500)
                {
                    double averageFps = frameCounter / (realTimeStopwatch.ElapsedMilliseconds / 1000.0);
                    Console.WriteLine($"Average FPS: {averageFps:F2}");
                    frameCounter = 0;
                    realTimeStopwatch.Restart();
                }
            }

            Sdl.DestroyRenderer(_renderer);
            Sdl.DestroyWindow(window);
            Sdl.Quit();
        }


        /// <summary>
        /// Configures the menu
        /// </summary>
        [Conditional("OSX")]
        private static void ConfigureMenu()
        {
            NSApplication.Init();

            // Configuración del menú principal
            NSMenu mainMenu = new NSMenu();

            // Crea un ítem para el menú de la aplicación
            NSMenuItem appMenuItem = new NSMenuItem();
            mainMenu.AddItem(appMenuItem);

            NSMenu appMenu = new NSMenu();
            appMenuItem.Submenu = appMenu;

            // "Acerca de" (About)
            NSMenuItem aboutMenuItem = new NSMenuItem("About", (sender, e) =>
            {
                NSAlert alert = new NSAlert
                {
                    AlertStyle = NSAlertStyle.Informational,
                    MessageText = "About My App",
                    InformativeText = "This is a .NET macOS app configured before launch!"
                };
                alert.RunModal();
            });
            appMenu.AddItem(aboutMenuItem);

            // "Salir" (Quit)
            NSMenuItem quitMenuItem = new NSMenuItem("Quit", (sender, e) => { NSApplication.SharedApplication.Terminate(null); })
            {
                KeyEquivalent = "q" // Atajo de teclado: Command + Q
            };
            appMenu.AddItem(quitMenuItem);

            // Asigna el menú configurado a la aplicación
            NSApplication.SharedApplication.MainMenu = mainMenu;
        }


        /// <summary>
        ///     Draws the circle using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x0">The </param>
        /// <param name="y0">The </param>
        /// <param name="radius">The radius</param>
        private static void DrawCircle(IntPtr renderer, int x0, int y0, int radius)
        {
            int x = radius - 1;
            int y = 0;
            int dx = 1;
            int dy = 1;
            int err = dx - (radius << 1);

            while (x >= y)
            {
                Sdl.RenderDrawPoint(renderer, x0 + x, y0 + y);
                Sdl.RenderDrawPoint(renderer, x0 + y, y0 + x);
                Sdl.RenderDrawPoint(renderer, x0 - y, y0 + x);
                Sdl.RenderDrawPoint(renderer, x0 - x, y0 + y);
                Sdl.RenderDrawPoint(renderer, x0 - x, y0 - y);
                Sdl.RenderDrawPoint(renderer, x0 - y, y0 - x);
                Sdl.RenderDrawPoint(renderer, x0 + y, y0 - x);
                Sdl.RenderDrawPoint(renderer, x0 + x, y0 - y);

                if (err <= 0)
                {
                    y++;
                    err += dy;
                    dy += 2;
                }

                if (err > 0)
                {
                    x--;
                    dx += 2;
                    err += dx - (radius << 1);
                }
            }
        }

        /// <summary>
        ///     Draws the half circle using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x0">The </param>
        /// <param name="y0">The </param>
        /// <param name="radius">The radius</param>
        private static void DrawHalfCircle(IntPtr renderer, int x0, int y0, int radius)
        {
            int x = radius - 1;
            int y = 0;
            int dx = 1;
            int dy = 1;
            int err = dx - (radius << 1);

            while (x >= y)
            {
                for (int i = -x; i <= x; i++)
                {
                    Sdl.RenderDrawPoint(renderer, x0 + i, y0 + y);
                    Sdl.RenderDrawPoint(renderer, x0 + i, y0 - y);
                }

                for (int i = -y; i <= y; i++)
                {
                    Sdl.RenderDrawPoint(renderer, x0 + i, y0 + x);
                    Sdl.RenderDrawPoint(renderer, x0 + i, y0 - x);
                }

                if (err <= 0)
                {
                    y++;
                    err += dy;
                    dy += 2;
                }

                if (err > 0)
                {
                    x--;
                    dx += 2;
                    err += dx - (radius << 1);
                }
            }
        }

        /// <summary>
        ///     Draws the circle with line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x0">The </param>
        /// <param name="y0">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="angle">The angle</param>
        private static void DrawCircleWithLine(IntPtr renderer, int x0, int y0, int radius, float angle)
        {
            int x = radius - 1;
            int y = 0;
            int dx = 1;
            int dy = 1;
            int err = dx - (radius << 1);

            while (x >= y)
            {
                Sdl.RenderDrawPoint(renderer, x0 + x, y0 + y);
                Sdl.RenderDrawPoint(renderer, x0 + y, y0 + x);
                Sdl.RenderDrawPoint(renderer, x0 - y, y0 + x);
                Sdl.RenderDrawPoint(renderer, x0 - x, y0 + y);
                Sdl.RenderDrawPoint(renderer, x0 - x, y0 - y);
                Sdl.RenderDrawPoint(renderer, x0 - y, y0 - x);
                Sdl.RenderDrawPoint(renderer, x0 + y, y0 - x);
                Sdl.RenderDrawPoint(renderer, x0 + x, y0 - y);

                if (err <= 0)
                {
                    y++;
                    err += dy;
                    dy += 2;
                }

                if (err > 0)
                {
                    x--;
                    dx += 2;
                    err += dx - (radius << 1);
                }
            }

            // Calculate the end points of the line based on the angle
            float radian = angle * (float) Math.PI / 180f;
            int lineX1 = x0 + (int) (radius * Math.Cos(radian));
            int lineY1 = y0 + (int) (radius * Math.Sin(radian));
            int lineX2 = x0 - (int) (radius * Math.Cos(radian));
            int lineY2 = y0 - (int) (radius * Math.Sin(radian));

            // Draw the line
            Sdl.RenderDrawLine(renderer, lineX1, lineY1, lineX2, lineY2);
        }


        /// <summary>
        ///     Renders the colors
        /// </summary>
        private static void RenderColors()
        {
            if (_red < 255)
            {
                _red++;
            }
            else if (_green < 255)
            {
                _green++;
            }
            else if (_blue < 255)
            {
                _blue++;
            }
            else
            {
                _red = 0;
                _green = 0;
                _blue = 0;
            }
        }

        /// <summary>
        ///     Sdlinputs
        /// </summary>
        private static void Sdlinput()
        {
            Sdl.SetHint(Hint.HintXInputEnabled, "0");
            Sdl.SetHint(Hint.SdlHintJoystickThread, "1");

            for (int i = 0; i < Sdl.NumJoysticks(); i++)
            {
                IntPtr myJoystick = Sdl.JoystickOpen(i);
                if (myJoystick == IntPtr.Zero)
                {
                    Logger.Info(@"Ooops, something fishy's goin' on here!" + Sdl.GetError());
                }
                else
                {
                    Logger.Info($"[SDL_JoystickName_id = '{i}'] \n" +
                                $"SDL_JoystickName={Sdl.JoystickName(myJoystick)} \n" +
                                $"SDL_JoystickNumAxes={Sdl.JoystickNumAxes(myJoystick)} \n" +
                                $"SDL_JoystickNumButtons={Sdl.JoystickNumButtons(myJoystick)}");
                }
            }
        }
    }
}