

using System;
using System.Threading;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Mapping;
using Alis.Extension.Graphic.Sdl2.Structs;
using Version = Alis.Extension.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.Graphic.Sdl2.Sample
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
        ///     The blue
        /// </summary>
        private static byte _blue;

        /// <summary>
        ///     The blue
        /// </summary>
        private static byte _green;

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
        ///     Runs
        /// </summary>
        public static void Run()
        {
            if (Sdl.Init(InitSettings.InitEvents) < 0 || Sdl.Init(InitSettings.InitVideo) < 0)
            {
                Logger.Exception($@"There was an issue initializing SDL. {Sdl.GetError()}");
            }
            else
            {
                Logger.Info("OnInit all");
            }

            Version versionSdl2 = Sdl.GetVersion();
            Logger.Info($"SDL2 VERSION {versionSdl2.major}.{versionSdl2.minor}.{versionSdl2.patch}");

            Sdl.SetHint(Hint.HintRenderDriver, "opengl");

            WindowSettings flags = WindowSettings.WindowResizable | WindowSettings.WindowShown;

            IntPtr window = Sdl.CreateWindow("Sample", (int) WindowPos.WindowPosCentered, (int) WindowPos.WindowPosCentered, Width, Height, flags);

            if (window == IntPtr.Zero)
            {
                Logger.Exception($"There was an issue creating the renderer. {Sdl.GetError()}");
            }
            else
            {
                Logger.Info("Window created");
            }

            IntPtr renderer = Sdl.CreateRenderer(
                window,
                -1,
                Renderers.SdlRendererAccelerated);

            if (renderer == IntPtr.Zero)
            {
                Logger.Exception($"There was an issue creating the renderer. {Sdl.GetError()}");
            }
            else
            {
                Logger.Info("Renderer created");
            }

            Sdlinput();

            RectangleI rectBorder = new RectangleI
            {
                X = 0,
                Y = 0,
                W = 50,
                H = 50
            };

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

            IntPtr imageTilePtr = Sdl.LoadBmp("Assets/tile000.bmp");

            IntPtr textureTile = Sdl.CreateTextureFromSurface(renderer, imageTilePtr);
            while (_running)
            {
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
                                rectBorder.Y -= 10;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Down)
                            {
                                rectBorder.Y += 10;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Left)
                            {
                                rectBorder.X -= 10;
                            }

                            if (_sdlEvent.key.KeySym.sym == KeyCodes.Right)
                            {
                                rectBorder.X += 10;
                            }

                            Logger.Info(_sdlEvent.key.KeySym.sym + " was pressed");
                            break;
                    }
                }


                RenderColors();

                Sdl.SetRenderDrawColor(renderer, _red, _green, _blue, 255);

                Sdl.RenderClear(renderer);

                Sdl.SetRenderDrawColor(renderer, 255, 255, 255, 255);
                //Sdl.RenderDrawRect(renderer, ref rectBorder);

                Sdl.SetRenderDrawColor(renderer, 0, 0, 0, 255);

                //Sdl.RenderFillRect(renderer, ref rectFilled);

                Sdl.RenderCopy(renderer, textureTile, IntPtr.Zero, ref tileRectangleI);

                Sdl.RenderDrawRects(renderer, new[] {rectBorder, rectFilled}, 2);

                Sdl.SetRenderDrawColor(renderer, 255, 0, 0, 255);
                Sdl.RenderDrawLine(renderer, 0, 0, 100, 100);

                Sdl.RenderPresent(renderer);


                Thread.Sleep(1000 / 60);
            }

            Sdl.DestroyRenderer(renderer);
            Sdl.DestroyWindow(window);
            Sdl.Quit();
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