// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Installer.cs
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
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Alis.App.Engine.Fonts;
using Alis.App.Installer.Core;
using Alis.App.Installer.Shaders;
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory.Exceptions;
using Alis.Core.Aspect.Time;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Constructs;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Extras.GuizMo;
using Alis.Extension.Graphic.ImGui.Extras.Node;
using Alis.Extension.Graphic.ImGui.Extras.Plot.Native;
using Alis.Extension.Graphic.ImGui.Native;
using Alis.Extension.Graphic.Sdl2;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Updater;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;
using Gl = Alis.Extension.Graphic.Sdl2.Gl;
using PixelFormat = Alis.Core.Graphic.OpenGL.Enums.PixelFormat;

namespace Alis.App.Installer
{
    /// <summary>
    ///     The engine class
    /// </summary>
    public class Installer : IDisposable
    {
        /// <summary>
        ///     The name engine
        /// </summary>
        private const string NameEngine = "Alis Installer by @pabllopf";

        /// <summary>
        ///     The vertex shader
        /// </summary>
        private static readonly VertexShader VertexShader = new VertexShader();

        /// <summary>
        ///     The fragment shader
        /// </summary>
        private static readonly FragmentShader FragmentShader = new FragmentShader();

        /// <summary>
        ///     The mouse pressed
        /// </summary>
        private readonly bool[] _mousePressed = {false, false, false};

        /// <summary>
        ///     The fullscreen
        /// </summary>
        private readonly bool fullscreen = false;

        /// <summary>
        ///     The height window
        /// </summary>
        private readonly int heightWindow = 75;

        /// <summary>
        ///     The high dpi
        /// </summary>
        private readonly bool highDpi = false;

        /// <summary>
        ///     The width window
        /// </summary>
        private readonly int widthWindow = 600;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private uint _elementsHandle;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private uint _fontTextureId;

        /// <summary>
        ///     The gl context
        /// </summary>
        private IntPtr _glContext;

        /// <summary>
        ///     The quit
        /// </summary>
        private bool _quit;

        /// <summary>
        ///     The shader
        /// </summary>
        private GlShaderProgram _shader;

        /// <summary>
        ///     The time
        /// </summary>
        private float _time;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private uint _vboHandle;

        /// <summary>
        ///     The font texture id
        /// </summary>
        private uint _vertexArrayObject;

        /// <summary>
        ///     The arguments
        /// </summary>
        private string[] arguments;

        /// <summary>
        ///     The is open main
        /// </summary>
        private bool isOpenMain = true;

        /// <summary>
        ///     The windows
        /// </summary>
        private SpaceWork spaceWork = new SpaceWork();

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _shader?.Dispose();
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        /// <param name="args"></param>
        /// <returns>The int</returns>
        public void Run(string[] args)
        {
            arguments = args;
            Logger.Info(@$"Starting {NameEngine} with args: {string.Join(", ", arguments)}");

            string versionToInstall = null;

            for (int i = 0; i < args.Length; i++)
            {
                if ((args[i] == "-versionToInstall") && (i + 1 < args.Length))
                {
                    versionToInstall = args[i + 1];
                }
            }

            if (versionToInstall != null)
            {
                Logger.Info(@$"Version to install: {versionToInstall}");
            }
            else
            {
                versionToInstall = "latest";
                Logger.Warning($"Version to install: {versionToInstall}");
            }

            // initialize SDL and set a few defaults for the OpenGL context
            if (Sdl.Init(InitSettings.InitEverything) != 0)
            {
                Logger.Info($@"Error of SDL2: {Sdl.GetError()}");
                return;
            }

            spaceWork = new SpaceWork();

            spaceWork.Initialize();
            
            Sdl.SetHint(Hint.HintRenderDriver, "opengl");

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(Attr.SdlGlContextFlags, (int) Contexts.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(Attr.SdlGlContextProfileMask, Profiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(Attr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(Attr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(Attr.SdlGlContextProfileMask, Profiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(Attr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(Attr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(Attr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(Attr.SdlGlStencilSize, 8);

            // Enable vsync
            Sdl.SetSwapInterval(1);

            // create the window which should be able to have a valid OpenGL context and is resizable
            WindowSettings flags = WindowSettings.WindowOpengl | WindowSettings.WindowResizable;
            if (fullscreen)
            {
                flags |= WindowSettings.WindowFullscreen;
            }

            if (highDpi)
            {
                flags |= WindowSettings.WindowAllowHighDpi;
            }

            spaceWork.Window = Sdl.CreateWindow(NameEngine, (int) WindowPos.WindowPosCentered, (int) WindowPos.WindowPosCentered, widthWindow, heightWindow, flags);
            _glContext = CreateGlContext(spaceWork.Window);

            // compile the shader program
            _shader = new GlShaderProgram(VertexShader.ShaderCode, FragmentShader.ShaderCode);

            spaceWork.ContextGui = ImGui.CreateContext();

            spaceWork.Io = ImGui.GetIo();

            spaceWork.Io.DisplaySize = new Vector2F(320, 320);

            Logger.Info($@"IMGUI VERSION {ImGui.GetVersion()}");

            // active plot renders
            spaceWork.Io.BackendFlags |= ImGuiBackendFlags.RendererHasVtxOffset | ImGuiBackendFlags.PlatformHasViewports | ImGuiBackendFlags.HasGamepad | ImGuiBackendFlags.HasMouseHoveredViewport | ImGuiBackendFlags.HasMouseCursors;


            // Enable Keyboard Controls
            spaceWork.Io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
            spaceWork.Io.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;

            // CONFIG DOCKSPACE 

            spaceWork.Io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
            spaceWork.Io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;

            ImNodes.CreateContext();
            ImPlot.CreateContext();
            ImGuizMo.SetImGuiContext(spaceWork.ContextGui);
            ImGui.SetCurrentContext(spaceWork.ContextGui);

            // REBUILD ATLAS
            ImFontAtlasPtr fonts = ImGui.GetIo().Fonts;

            string dirFonts = AppDomain.CurrentDomain.BaseDirectory + "/Assets/Fonts/Jetbrains/";
            string fontToLoad = "JetBrainsMono-Bold.ttf";

            string dirFontsIcon = AppDomain.CurrentDomain.BaseDirectory + "/Assets/Icons/";

            if (!Directory.Exists(dirFonts))
            {
                Logger.Info(@$"ERROR, DIR NOT FOUND: {dirFonts}");
                return;
            }

            if (!File.Exists(dirFonts + fontToLoad))
            {
                Logger.Info(@$"ERROR, FONT NOT FOUND: {dirFonts + fontToLoad}");
                return;
            }


            //fonts.AddFontDefault();

            float fontSize = 14;
            float fontSizeIcon = 18;

            ImFontPtr fontLoaded16Solid = fonts.AddFontFromFileTtf(@$"{dirFonts}{fontToLoad}", fontSize);
            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 18;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                // Assuming 'io' is a valid ImGuiIO instance and 'dir' and 'dirIcon' are defined paths
                fonts.AddFontFromFileTtf(@$"{dirFontsIcon}{FontAwesome5.NameSolid}", fontSizeIcon, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {dirFontsIcon}{FontAwesome5.NameSolid} {e.Message}");
                return;
            }


            ImFontPtr fontLoaded16Regular = fonts.AddFontFromFileTtf(@$"{dirFonts}{fontToLoad}", fontSize);
            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 20;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                // Assuming 'io' is a valid ImGuiIO instance and 'dir' and 'dirIcon' are defined paths
                fonts.AddFontFromFileTtf(@$"{dirFontsIcon}{FontAwesome5.NameRegular}", fontSizeIcon, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {dirFontsIcon}{FontAwesome5.NameRegular} {e.Message}");
                return;
            }


            ImFontPtr fontLoaded16Light = fonts.AddFontFromFileTtf(@$"{dirFonts}{fontToLoad}", fontSize);
            try
            {
                ImFontConfigPtr iconsConfig = ImGui.ImFontConfig();
                iconsConfig.MergeMode = true;
                iconsConfig.SnapH = true;
                iconsConfig.GlyphMinAdvanceX = 20;

                ushort[] iconRanges = new ushort[3];
                iconRanges[0] = FontAwesome5.IconMin;
                iconRanges[1] = FontAwesome5.IconMax;
                iconRanges[2] = 0;

                // Allocate GCHandle to pin IconRanges in memory
                GCHandle iconRangesHandle = GCHandle.Alloc(iconRanges, GCHandleType.Pinned);

                IntPtr rangePtr = iconRangesHandle.AddrOfPinnedObject();

                // Assuming 'io' is a valid ImGuiIO instance and 'dir' and 'dirIcon' are defined paths
                fonts.AddFontFromFileTtf(@$"{dirFontsIcon}{FontAwesome5.NameLight}", fontSizeIcon, iconsConfig, rangePtr);
            }
            catch (Exception e)
            {
                Logger.Exception(@$"ERROR, FONT ICONS NOT FOUND: {dirFontsIcon}{FontAwesome5.NameLight} {e.Message}");
                return;
            }


            fonts.GetTexDataAsRgba32(out IntPtr pixelData, out int width, out int height, out int _);
            _fontTextureId = LoadTexture(pixelData, width, height);
            fonts.TexId = (IntPtr) _fontTextureId;
            fonts.ClearTexData();

            // CONFIG DOCKSPACE
            spaceWork.Viewport = ImGui.GetMainViewport();

            // config spaceWork.Style
            spaceWork.Style = ImGui.GetStyle();
            ImGui.StyleColorsDark();
            spaceWork.Style.WindowRounding = 0.0f;
            spaceWork.Style.Colors2 = new Vector4F(0.00f, 0.00f, 0.00f, 1.00f);

            // config input manager 

            spaceWork.Io.KeyMap[(int) ImGuiKey.Tab] = (int) SdlScancode.SdlScancodeTab;
            spaceWork.Io.KeyMap[(int) ImGuiKey.LeftArrow] = (int) SdlScancode.SdlScancodeLeft;
            spaceWork.Io.KeyMap[(int) ImGuiKey.RightArrow] = (int) SdlScancode.SdlScancodeRight;
            spaceWork.Io.KeyMap[(int) ImGuiKey.UpArrow] = (int) SdlScancode.SdlScancodeUp;
            spaceWork.Io.KeyMap[(int) ImGuiKey.DownArrow] = (int) SdlScancode.SdlScancodeDown;
            spaceWork.Io.KeyMap[(int) ImGuiKey.PageUp] = (int) SdlScancode.SdlScancodePageup;
            spaceWork.Io.KeyMap[(int) ImGuiKey.PageDown] = (int) SdlScancode.SdlScancodePagedown;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Home] = (int) SdlScancode.SdlScancodeHome;
            spaceWork.Io.KeyMap[(int) ImGuiKey.End] = (int) SdlScancode.SdlScancodeEnd;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Insert] = (int) SdlScancode.SdlScancodeInsert;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Delete] = (int) SdlScancode.SdlScancodeDelete;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Backspace] = (int) SdlScancode.SdlScancodeBackspace;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Space] = (int) SdlScancode.SdlScancodeSpace;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Enter] = (int) SdlScancode.SdlScancodeReturn;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Escape] = (int) SdlScancode.SdlScancodeEscape;
            spaceWork.Io.KeyMap[(int) ImGuiKey.KeypadEnter] = (int) SdlScancode.SdlScancodeReturn2;
            spaceWork.Io.KeyMap[(int) ImGuiKey.A] = (int) SdlScancode.SdlScancodeA;
            spaceWork.Io.KeyMap[(int) ImGuiKey.C] = (int) SdlScancode.SdlScancodeC;
            spaceWork.Io.KeyMap[(int) ImGuiKey.V] = (int) SdlScancode.SdlScancodeV;
            spaceWork.Io.KeyMap[(int) ImGuiKey.X] = (int) SdlScancode.SdlScancodeX;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Y] = (int) SdlScancode.SdlScancodeY;
            spaceWork.Io.KeyMap[(int) ImGuiKey.Z] = (int) SdlScancode.SdlScancodeZ;

            _vboHandle = Gl.GenBuffer();
            _elementsHandle = Gl.GenBuffer();
            _vertexArrayObject = Gl.GenVertexArray();

            // Set icon app:
            string iconPath = AssetManager.Find("app.bmp");
            if (!string.IsNullOrEmpty(iconPath) && File.Exists(iconPath))
            {
                IntPtr icon = Sdl.LoadBmp(iconPath);
                Sdl.SetWindowIcon(spaceWork.Window, icon);
            }

            string api = "https://api.github.com/repos/pabllopf/alis/releases";
            string dirProject = Path.Combine(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.FullName)!.FullName, "Editor", $"{versionToInstall}");
            Logger.Info(@$"API: {api}");
            Logger.Info(@$"DIR: {dirProject}");
            Logger.Info(@"Starting UpdateManager");
            UpdateManager manager = new UpdateManager(new GitHubApiService(api), versionToInstall, new FileService(), dirProject);
            Task<bool> task = manager.Start();
            //task.Start();

            // Definir la variable de estado fuera del bucle principal
            int animationState = 0;

            // Inicializar la variable de tiempo fuera del bucle principal
            double lastUpdateTime = 0;
            Clock clock = new Clock();
            clock.Start();
            Logger.Info(@$"Starting {NameEngine}");

            spaceWork.Start();
            while (!_quit)
            {
                while (Sdl.PollEvent(out Event e) != 0)
                {
                    ProcessEvent(e);
                    switch (e.type)
                    {
                        case EventType.WindowEvent:
                        {
                            if (e.window.windowEvent == WindowEventId.SdlWindowEventClose)
                            {
                                _quit = true;
                            }

                            break;
                        }

                        case EventType.Keydown:
                        {
                            switch (e.key.KeySym.sym)
                            {
                                case KeyCodes.Escape:
                                    _quit = true;
                                    break;
                            }

                            break;
                        }
                    }
                }

                //Gl.GlClearColor(0.05f, 0.05f, 0.05f, 1.00f);
                ImGui.NewFrame();
                ImGuizMo.BeginFrame();

                // Setup display size (every frame to accommodate for window resizing)
                Vector2F windowSize = Sdl.GetWindowSize(spaceWork.Window);
                Sdl.GetDrawableSize(spaceWork.Window, out int displayW, out int displayH);
                spaceWork.Io.DisplaySize = new Vector2F(windowSize.X, windowSize.Y);
                if ((windowSize.X > 0) && (windowSize.Y > 0))
                {
                    spaceWork.Io.DisplayFramebufferScale = new Vector2F(displayW / windowSize.X, displayH / windowSize.Y);
                }

                // Setup time step (we don't use SDL_GetTicks() because it is using millisecond resolution)
                ulong frequency = Sdl.GetPerformanceFrequency();
                ulong currentTime = Sdl.GetPerformanceCounter();
                spaceWork.Io.DeltaTime = _time > 0 ? (float) ((double) (currentTime - _time) / frequency) : 1.0f / 60.0f;
                if (spaceWork.Io.DeltaTime <= 0)
                {
                    spaceWork.Io.DeltaTime = 0.016f;
                }

                _time = currentTime;

                UpdateMousePosAndButtons();

                if (clock.ElapsedMilliseconds - lastUpdateTime >= 250) // Si ha pasado al menos 1 segundo
                {
                    // Actualizar el estado de la animación
                    animationState++;
                    if (animationState > 3)
                    {
                        animationState = 0;
                    }

                    // Reiniciar el tiempo de la última actualización
                    lastUpdateTime = clock.ElapsedMilliseconds;
                }

                // Determinar qué símbolo mostrar basado en el estado de la animación
                string animationSymbol = animationState switch
                {
                    0 => "[/]",
                    1 => "[-]",
                    2 => "[\\]",
                    _ => "[/]"
                };

                ImGui.PushFont(fontLoaded16Regular);

                ImGui.SetNextWindowSize(new Vector2F(displayW, displayH));
                ImGui.SetNextWindowPos(new Vector2F(displayW / windowSize.X, displayH / windowSize.Y));
                if (ImGui.Begin("MainWindow", ref isOpenMain, ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse))
                {
                    ImGui.Separator();
                    ImGui.ProgressBar(manager.Progress, new Vector2F(-1, 30), $"{Math.Round(manager.Progress * 100)}%");
                    ImGui.Separator();
                    ImGui.Text($"{animationSymbol} {manager.Message}");
                    ImGui.Separator();
                }

                Sdl.SetWindowTitle(spaceWork.Window, $"{NameEngine} - {Math.Round(clock.ElapsedSeconds)}s");

                ImGui.End();

                ImGui.PopFont();

                if (task.IsCompleted)
                {
                    _quit = true;
                }


                // END RENDER GUI


                Sdl.MakeCurrent(spaceWork.Window, _glContext);
                ImGui.Render();

                Gl.GlViewport(0, 0, (int) spaceWork.Io.DisplaySize.X, (int) spaceWork.Io.DisplaySize.Y);
                Gl.GlClear(ClearBufferMask.ColorBufferBit);

                RenderDrawData();

                IntPtr backupCurrentWindow = Sdl.GetCurrentWindow();
                IntPtr backupCurrentContext = Sdl.GetCurrentContext();
                ImGui.UpdatePlatformWindows();
                ImGui.RenderPlatformWindowsDefault();
                Sdl.MakeCurrent(backupCurrentWindow, backupCurrentContext);


                Gl.GlDisable(EnableCap.ScissorTest);
                Sdl.SwapWindow(spaceWork.Window);
            }

            task.Wait();

            if (_shader != null)
            {
                _shader.Dispose();
                _shader = null;
                Gl.DeleteBuffer(_vboHandle);
                Gl.DeleteBuffer(_elementsHandle);
                Gl.DeleteVertexArray(_vertexArrayObject);
                Gl.DeleteTexture(_fontTextureId);
            }

            Sdl.DeleteContext(_glContext);
            Sdl.DestroyWindow(spaceWork.Window);
            Sdl.Quit();

            Logger.Info(@$"Closing {NameEngine}");
        }


        /// <summary>
        ///     Processes the event using the specified evt
        /// </summary>
        /// <param name="evt">The evt</param>
        private void ProcessEvent(Event evt)
        {
            ImGuiIoPtr imGuiIoPtr = ImGui.GetIo();
            switch (evt.type)
            {
                case EventType.Mousewheel:
                {
                    if (evt.wheel.x > 0)
                    {
                        imGuiIoPtr.MouseWheelH += 1;
                    }

                    if (evt.wheel.x < 0)
                    {
                        imGuiIoPtr.MouseWheelH -= 1;
                    }

                    if (evt.wheel.y > 0)
                    {
                        imGuiIoPtr.MouseWheel += 1;
                    }

                    if (evt.wheel.y < 0)
                    {
                        imGuiIoPtr.MouseWheel -= 1;
                    }

                    return;
                }
                case EventType.MouseButtonDown:
                {
                    if (evt.button.button == Sdl.ButtonLeft)
                    {
                        _mousePressed[0] = true;
                    }

                    if (evt.button.button == Sdl.ButtonRight)
                    {
                        _mousePressed[1] = true;
                    }

                    if (evt.button.button == Sdl.ButtonMiddle)
                    {
                        _mousePressed[2] = true;
                    }

                    return;
                }
                case EventType.TextInput:
                {
                    string str = Encoding.UTF8.GetString(evt.text.Text);
                    imGuiIoPtr.AddInputCharactersUtf8(str);
                    return;
                }
                case EventType.Keydown:
                case EventType.Keyup:
                {
                    SdlScancode key = evt.key.KeySym.scancode;
                    imGuiIoPtr.KeysDown[(int) key] = evt.type == EventType.Keydown;
                    Logger.Info("spaceWork.Io.KeysDown[" + key + "] = " + evt.type + imGuiIoPtr.KeysDown[(int) key]);
                    imGuiIoPtr.KeyShift = (Sdl.GetModState() & KeyMods.KModShift) != 0;
                    imGuiIoPtr.KeyCtrl = (Sdl.GetModState() & KeyMods.KModCtrl) != 0;
                    imGuiIoPtr.KeyAlt = (Sdl.GetModState() & KeyMods.KModAlt) != 0;
                    imGuiIoPtr.KeySuper = (Sdl.GetModState() & KeyMods.KModGui) != 0;
                    break;
                }
            }
        }

        /// <summary>
        ///     Updates the mouse pos and buttons
        /// </summary>
        private void UpdateMousePosAndButtons()
        {
            ImGuiIoPtr imGuiIoPtr = ImGui.GetIo();

            // Set OS mouse position if requested (rarely used, only when ImGuiConfigFlags_NavEnableSetMousePos is enabled by user)
            if (imGuiIoPtr.WantSetMousePos)
            {
                Sdl.WarpMouseInWindow(spaceWork.Window, (int) imGuiIoPtr.MousePos.X, (int) imGuiIoPtr.MousePos.Y);
            }
            else
            {
                imGuiIoPtr.MousePos = new Vector2F(float.MinValue, float.MinValue);
            }

            uint mouseButtons = Sdl.GetMouseStateOutXAndY(out int mx, out int my);
            List<bool> rangeAccessor = imGuiIoPtr.MouseDown;
            rangeAccessor[0] =
                _mousePressed[0] ||
                (mouseButtons & Sdl.Button(Sdl.ButtonLeft)) !=
                0; // If a mouse press event came, always pass it as "mouse held this frame", so we don't miss click-release events that are shorter than 1 frame.
            rangeAccessor[1] = _mousePressed[1] || (mouseButtons & Sdl.Button(Sdl.ButtonRight)) != 0;
            rangeAccessor[2] = _mousePressed[2] || (mouseButtons & Sdl.Button(Sdl.ButtonMiddle)) != 0;
            _mousePressed[0] = _mousePressed[1] = _mousePressed[2] = false;

            imGuiIoPtr.MouseDown = rangeAccessor;

            IntPtr focusedWindow = Sdl.GetKeyboardFocus();
            if (spaceWork.Window == focusedWindow)
            {
                // SDL_GetMouseState() gives mouse position seemingly based on the last window entered/focused(?)
                // The creation of a new windows at runtime and SDL_CaptureMouse both seems to severely mess up with that, so we retrieve that position globally.
                Sdl.GetWindowPosition(focusedWindow, out int wx, out int wy);
                Sdl.GetGlobalMouseStateOutXAndOutY(out mx, out my);
                mx -= wx;
                my -= wy;
                imGuiIoPtr.MousePos = new Vector2F(mx, my);
            }

            // SDL_CaptureMouse() let the OS know e.g. that our imgui drag outside the SDL window boundaries shouldn't e.g. trigger the OS window resize cursor.
            bool anyMouseButtonDown = ImGui.IsAnyMouseDown();
            Sdl.CaptureMouse(anyMouseButtonDown);
        }

        /// <summary>
        ///     Setup the render state using the specified draw data
        /// </summary>
        /// <param name="drawData">The draw data</param>
        private void SetupRenderState(ImDrawData drawData)
        {
            Gl.GlEnable(EnableCap.Blend);
            Gl.GlBlendEquation(BlendEquationMode.FuncAdd);
            Gl.GlBlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            Gl.GlDisable(EnableCap.CullFace);
            Gl.GlDisable(EnableCap.DepthTest);
            Gl.GlEnable(EnableCap.ScissorTest);

            Gl.GlUseProgram(_shader.ProgramId);

            float left = drawData.DisplayPos.X;
            float right = drawData.DisplayPos.X + drawData.DisplaySize.X;
            float top = drawData.DisplayPos.Y;
            float bottom = drawData.DisplayPos.Y + drawData.DisplaySize.Y;


            _shader["Texture"].SetValue(0);
            _shader["ProjMtx"].SetValue(Matrix4X4.CreateOrthographicOffCenter(left, right, bottom, top, -1, 1));
            Gl.GlBindSampler(0, 0);

            Gl.GlBindVertexArray(_vertexArrayObject);

            // Bind vertex/index buffers and setup attributes for ImDrawVert
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, _vboHandle);
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, _elementsHandle);

            Gl.EnableVertexAttribArray(_shader["Position"].Location);
            Gl.EnableVertexAttribArray(_shader["UV"].Location);
            Gl.EnableVertexAttribArray(_shader["Color"].Location);

            int drawVertSize = Marshal.SizeOf<ImDrawVert>();
            // Manual offset calculations
            int posOffset = 0; // Offset of Pos is 0 bytes from the start
            int uvOffset = 8; // Offset of Uv is 8 bytes from the start (after Pos)
            int colOffset = 16; // Offset of Col is 16 bytes from the start (after Pos and Uv)

            Gl.VertexAttribPointer(_shader["Position"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, posOffset);
            Gl.VertexAttribPointer(_shader["UV"].Location, 2, VertexAttribPointerType.Float, false, drawVertSize, uvOffset);
            Gl.VertexAttribPointer(_shader["Color"].Location, 4, VertexAttribPointerType.UnsignedByte, true, drawVertSize, colOffset);
        }

        /// <summary>
        ///     Creates the gl context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <exception cref="Exception">CouldNotCreateContext</exception>
        /// <returns>The gl context</returns>
        private static IntPtr CreateGlContext(IntPtr window)
        {
            IntPtr glContext = Sdl.CreateContext(window);
            if (glContext == IntPtr.Zero)
            {
                throw new GeneralAlisException("CouldNotCreateContext");
            }

            Sdl.MakeCurrent(window, glContext);
            Sdl.SetSwapInterval(1);

            // initialize the screen to black as soon as possible
            Gl.GlClearColor(0f, 0f, 0f, 1f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit);
            Sdl.SwapWindow(window);

            Logger.Info($"GL Version: {Gl.GlGetString(StringName.Version)}");
            return glContext;
        }

        /// <summary>
        ///     Loads the texture using the specified pixel data
        /// </summary>
        /// <param name="pixelData">The pixel data</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="format">The format</param>
        /// <param name="internalFormat">The internal format</param>
        /// <returns>The texture id</returns>
        private static uint LoadTexture(IntPtr pixelData, int width, int height, PixelFormat format = PixelFormat.Rgba, PixelInternalFormat internalFormat = PixelInternalFormat.Rgba)
        {
            uint textureId = Gl.GenTexture();
            Gl.GlPixelStorei(StoreParameter.UnpackAlignment, 1);
            Gl.GlBindTexture(TextureTarget.Texture2D, textureId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, internalFormat, width, height, 0, format, PixelType.UnsignedByte, pixelData);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);
            return textureId;
        }

        /// <summary>
        ///     Renders the draw data
        /// </summary>
        private void RenderDrawData()
        {
            ImDrawData drawData = ImGui.GetDrawData();

            // Avoid rendering when minimized, scale coordinates for retina displays (screen coordinates != framebuffer coordinates)
            int fbWidth = (int) (drawData.DisplaySize.X * drawData.FramebufferScale.X);
            int fbHeight = (int) (drawData.DisplaySize.Y * drawData.FramebufferScale.Y);
            if (fbWidth <= 0 || fbHeight <= 0)
            {
                return;
            }

            SetupRenderState(drawData);

            Vector2F clipOffset = drawData.DisplayPos;
            Vector2F clipScale = drawData.FramebufferScale;

            drawData.ScaleClipRects(clipScale);

            IntPtr lastTexId = ImGui.GetIo().Fonts.TexId;
            Gl.GlBindTexture(TextureTarget.Texture2D, (uint) lastTexId);

            int drawVertSize = Marshal.SizeOf<ImDrawVert>();
            int drawIdxSize = sizeof(ushort);

            for (int n = 0; n < drawData.CmdListsCount; n++)
            {
                ImDrawListPtr cmdList = drawData.CmdListsRange[n];

                // Upload vertex/index buffers
                Gl.GlBufferData(BufferTarget.ArrayBuffer, cmdList.VtxBuffer.Size * drawVertSize, cmdList.VtxBuffer.Data, BufferUsageHint.StreamDraw);
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, cmdList.IdxBuffer.Size * drawIdxSize, cmdList.IdxBuffer.Data, BufferUsageHint.StreamDraw);

                for (int cmdI = 0; cmdI < cmdList.CmdBuffer.Size; cmdI++)
                {
                    ImDrawCmd pcmd = cmdList.CmdBuffer[cmdI];
                    if (pcmd.UserCallback != IntPtr.Zero)
                    {
                        Logger.Info("UserCallback not implemented");
                    }
                    else
                    {
                        // Project scissor/clipping rectangles into framebuffer space
                        Vector4F clipRect = pcmd.ClipRect;

                        clipRect.X = pcmd.ClipRect.X - clipOffset.X;
                        clipRect.Y = pcmd.ClipRect.Y - clipOffset.Y;
                        clipRect.Z = pcmd.ClipRect.Z - clipOffset.X;
                        clipRect.W = pcmd.ClipRect.W - clipOffset.Y;

                        Gl.GlScissor((int) clipRect.X, (int) (fbHeight - clipRect.W), (int) (clipRect.Z - clipRect.X), (int) (clipRect.W - clipRect.Y));

                        // Bind texture, Draw
                        if (pcmd.TextureId != IntPtr.Zero)
                        {
                            if (pcmd.TextureId != lastTexId)
                            {
                                lastTexId = pcmd.TextureId;
                                Gl.GlBindTexture(TextureTarget.Texture2D, (uint) pcmd.TextureId);
                            }
                        }

                        Gl.GlDrawElementsBaseVertex(BeginMode.Triangles, (int) pcmd.ElemCount, DrawElementsType.UnsignedShort, (IntPtr) (pcmd.IdxOffset * drawIdxSize), (int) pcmd.VtxOffset);
                    }
                }
            }
        }
    }
}