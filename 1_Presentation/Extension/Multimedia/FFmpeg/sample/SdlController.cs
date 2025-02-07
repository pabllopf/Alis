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
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Data.Dll;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Extension.Multimedia.FFmpeg.Audio;
using Alis.Extension.Multimedia.FFmpeg.BaseClasses;
using Alis.Extension.Multimedia.FFmpeg.Video;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.Multimedia.FFmpeg.Sample
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
            WindowSettings flags = WindowSettings.WindowResizable | WindowSettings.WindowShown;

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

            Logger.Info("Platform: " + EmbeddedDllClass.GetCurrentPlatform());
            Logger.Info("Processor: " + RuntimeInformation.ProcessArchitecture);

            IntPtr icon = Sdl.LoadBmp(AssetManager.Find("logo.bmp"));
            Sdl.SetWindowIcon(window, icon);

            Sdlinput();

            string input = AssetManager.Find("sample.mp4");

            VideoReader video = new VideoReader(input);
            video.LoadMetadataAsync().Wait();
            video.Load();

            AudioReader audioReader = new AudioReader(input);
            audioReader.LoadMetadataAsync().Wait();
            audioReader.Load();

            // Get video and audio stream metadata (or just access metadata properties directly instead)
            MediaStream vstream = video.Metadata.GetFirstVideoStream();
            MediaStream astream = audioReader.Metadata.GetFirstAudioStream();

            // Crear la textura
            IntPtr textureVideo = Sdl.CreateTexture(
                renderer,
                Sdl.PixelFormatRgb24,
                (int) TextureAccess.SdlTextureAccessStreaming,
                (int) vstream.Width!,
                (int) vstream.Height!);

            AudioSpec wavSpec = new AudioSpec
            {
                Freq = astream.SampleRateNumber, // Usar la tasa de muestreo del audio
                Format = Sdl.GlAudioS16Sys, // Formato de audio estándar
                Channels = (byte) astream.Channels!, // Usar el número de canales del audio
                Samples = 2048, // Tamaño del buffer de audio (puede necesitar ajustes)
                Callback = null // No estamos usando una función de callback
            };

            int deviceId = (int) Sdl.OpenAudioDevice(IntPtr.Zero, 0, ref wavSpec, out wavSpec, 0);
            if (deviceId == 0)
            {
                Logger.Info($"No se pudo abrir el dispositivo de audio: {Sdl.GetError()}");
                return;
            }

            VideoFrame videoFrame = new VideoFrame((int) vstream.Width, (int) vstream.Height);
            AudioFrame audioFrame = new AudioFrame((int) astream.Channels, 2048);

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
                    }
                    
                }

                // read next frame
                VideoFrame videoFrameTemp = video.NextFrame(videoFrame);
                if (videoFrameTemp == null)
                {
                    _running = false;
                }

                // Actualizar la textura con los datos del frame
                byte[] pixels = videoFrame.RawData;
                Sdl.UpdateTexture(textureVideo, IntPtr.Zero, pixels, videoFrameTemp.Width * 3);

                // Renderizar la textura
                Sdl.RenderCopy(renderer, textureVideo, IntPtr.Zero, IntPtr.Zero);
                Sdl.RenderPresent(renderer);

                // audio
                AudioFrame audioFrameTemp = audioReader.NextFrame(audioFrame);
                if (audioFrameTemp == null)
                {
                    break;
                }

                //player.WriteFrame(audioFrame);
                Sdl.QueueAudio(deviceId, audioFrame.RawData, (uint) audioFrame.RawData.Length);

                // if not playing, start
                if (Sdl.GetAudioDeviceStatus((uint) deviceId) != AudioStatus.SdlAudioPlaying)
                {
                    Sdl.SdlPauseAudioDevice((uint) deviceId, 0);
                }


                Thread.Sleep((int) (1000 / vstream.AvgFrameRateNumber));
            }

            Sdl.DestroyRenderer(renderer);
            Sdl.DestroyWindow(window);
            Sdl.Quit();
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