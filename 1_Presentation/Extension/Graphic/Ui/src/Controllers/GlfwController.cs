// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlfwController.cs
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
using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Logging;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Extension.Graphic.Ui.Controllers
{
    /// <summary>
    /// The glfw controller class
    /// </summary>
    /// <seealso cref="IControllerUi"/>
    public class GlfwController : IControllerUi
    {
        /// <summary>
        /// The title main window
        /// </summary>
        private string TitleMainWindow;

        /// <summary>
        /// The window
        /// </summary>
        public Window _window;

        /// <summary>
        /// The width main window
        /// </summary>
        public int _widthMainWindow;
        /// <summary>
        /// The height main window
        /// </summary>
        public int _heightMainWindow;

        /// <summary>
        /// The windows default
        /// </summary>
        private int _windowsDefault;
        
        /// <summary>
        /// The context version major
        /// </summary>
        private const int ContextVersionMajor = 3;
        /// <summary>
        /// The context version minor
        /// </summary>
        private const int ContextVersionMinor = 2;
        /// <summary>
        /// The core
        /// </summary>
        private const Profile OpenglProfile = Profile.Core;
        /// <summary>
        /// The opengl forward compatible
        /// </summary>
        private const bool OpenglForwardCompatible = true;
        /// <summary>
        /// The sync
        /// </summary>
        private const int VSync = 1;
        /// <summary>
        /// The scale to monitor
        /// </summary>
        private const bool ScaleToMonitor = true;
        /// <summary>
        /// The antialiasing
        /// </summary>
        private const int Antialiasing = 4; 
        /// <summary>
        /// The decorated window
        /// </summary>
        private const bool DecoratedWindow = true;
        
        /// <summary>
        /// The focused on init
        /// </summary>
        private const bool FocusedOnInit = true;
        
        /// <summary>
        /// The transparent framebuffer
        /// </summary>
        private const bool TransparentFramebuffer = false;
        
        /// <summary>
        /// The key callback delegate
        /// </summary>
        private KeyCallback _keyCallbackDelegate;
        /// <summary>
        /// The char callback delegate
        /// </summary>
        private CharCallback _charCallbackDelegate;
        /// <summary>
        /// The mouse button callback delegate
        /// </summary>
        private MouseButtonCallback _mouseButtonCallbackDelegate;
        /// <summary>
        /// The scroll callback delegate
        /// </summary>
        private MouseCallback _scrollCallbackDelegate;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="GlfwController"/> class
        /// </summary>
        /// <param name="titleMainWindow">The title main window</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="windowsDefault">The windows default</param>
        public GlfwController(string titleMainWindow = "GLFW Window", int width = 800, int height = 600, int windowsDefault = 0)
        {
            TitleMainWindow = titleMainWindow;
            _widthMainWindow = width;
            _heightMainWindow = height;
            _windowsDefault = windowsDefault;
        }
        
        /// <summary>
        /// Ons the init
        /// </summary>
        public void OnInit()
        {
            Logger.Info($"Initializing GLFW with OpenGL");
            if (!Glfw.Init())
            {
                ErrorCode errorCode = Glfw.GetError(out string description);
                Logger.Exception($"GLFW init failed: ErrorCode: {errorCode} - Description: {description}");
            }

            Glfw.WindowHint(Hint.ContextVersionMajor, ContextVersionMajor);
            Glfw.WindowHint(Hint.ContextVersionMinor, ContextVersionMinor);
            Logger.Info($"Setting GLFW context version to {ContextVersionMajor}.{ContextVersionMinor}");

            Glfw.WindowHint(Hint.OpenglProfile, OpenglProfile);
            Logger.Info($"Setting GLFW OpenGL profile to {OpenglProfile}");

            Glfw.WindowHint(Hint.OpenglForwardCompatible, OpenglForwardCompatible);
            Logger.Info($"Setting GLFW OpenGL forward compatible to {OpenglForwardCompatible}");

            Glfw.WindowHint(Hint.Doublebuffer, true);
            Glfw.WindowHint(Hint.DepthBits, 24);
            Glfw.WindowHint(Hint.AlphaBits, 8);
            Glfw.WindowHint(Hint.StencilBits, 8);
            
            Glfw.WindowHint(Hint.ScaleToMonitor, ScaleToMonitor); 
            Logger.Info($"Setting GLFW to scale to monitor = {(ScaleToMonitor == true ? "Yes" : "No")}");

            Glfw.WindowHint(Hint.Samples, Antialiasing);
            Logger.Info($"Setting GLFW antialiasing to {Antialiasing} samples");
            
            Glfw.WindowHint(Hint.Decorated, DecoratedWindow); 
            Logger.Info($"Setting GLFW window decorated = {(DecoratedWindow == true ? "Yes" : "No")}");
            
            Glfw.WindowHint(Hint.TransparentFramebuffer, TransparentFramebuffer);
            Logger.Info($"Setting GLFW transparent framebuffer = {(TransparentFramebuffer ? "Yes" : "No")}");
            
            Glfw.WindowHint(Hint.Focused, FocusedOnInit);
            Logger.Info($"Setting GLFW window focused on init = {(FocusedOnInit == true ? "Yes" : "No")}");
            
            // Configure color bits for the window
            Glfw.WindowHint(Hint.RedBits, 8);
            Glfw.WindowHint(Hint.GreenBits, 8);
            Glfw.WindowHint(Hint.BlueBits, 8);
            
            
            
            // Obtener el monitor principal
            if (_windowsDefault == 0)
            {
                Glfw.WindowHint(Hint.Resizable, true);
                
                Monitor primaryMonitor = Glfw.GetPrimaryMonitor();
                Glfw.GetMonitorWorkArea(primaryMonitor, out int monitorX, out int monitorY, out int monitorWidth, out int monitorHeight);
                
                _widthMainWindow = monitorWidth;
                _heightMainWindow = monitorHeight;
                _window = Glfw.CreateWindow(_widthMainWindow, _heightMainWindow, TitleMainWindow, Monitor.None, Window.None);
                Glfw.MaximizeWindow(_window);
            }
            else
            {
                
                Glfw.WindowHint(Hint.Resizable, false);
                Glfw.WindowHint(Hint.Maximized, false);
                
                // Crea la ventana
                _window = Glfw.CreateWindow(_widthMainWindow, _heightMainWindow, TitleMainWindow, Monitor.None, Window.None);
                
                // Obtén el área de trabajo del monitor principal
                Monitor primaryMonitor = Glfw.GetPrimaryMonitor();
                Glfw.GetMonitorWorkArea(primaryMonitor, out int monitorX, out int monitorY, out int monitorWidth, out int monitorHeight);
                
                // Obtén el tamaño real de la ventana (puede variar por DPI)
                Glfw.GetWindowSize(_window, out int winWidth, out int winHeight);
                
                // Calcula la posición centrada
                int posX = monitorX + (monitorWidth - winWidth) / 2;
                int posY = monitorY + (monitorHeight - winHeight) / 2;
                
                // Mueve la ventana al centro
                Glfw.SetWindowPosition(_window, posX, posY);
            }
            
            if (_window == Window.None)
            {
                ErrorCode errorCode = Glfw.GetError(out string description);
                Logger.Exception($"GLFW window creation failed: ErrorCode: {errorCode} - Description: {description}");
            }
            
            Glfw.MakeContextCurrent(_window);
            Logger.Info($"Created GLFW window with title '{TitleMainWindow}' and size {_widthMainWindow}x{_heightMainWindow}");

            Glfw.SwapInterval(VSync);
            Logger.Info($"V-Sync is active = {(VSync == 1 ? "Yes" : "No")}");
            
            SetupGlfwImGuiCallbacks();

            Logger.Log("GLFW initialized successfully");
        }

        /// <summary>
        /// Setup the glfw im gui callbacks
        /// </summary>
        private void SetupGlfwImGuiCallbacks()
        {
            _keyCallbackDelegate = KeyCallback;
            _charCallbackDelegate = CharCallback;
            _mouseButtonCallbackDelegate = MouseButtonCallback;
            _scrollCallbackDelegate = ScrollCallback;

            Glfw.SetKeyCallback(_window, _keyCallbackDelegate);
            Glfw.SetCharCallback(_window, _charCallbackDelegate);
            Glfw.SetMouseButtonCallback(_window, _mouseButtonCallbackDelegate);
            Glfw.SetScrollCallback(_window, _scrollCallbackDelegate);
        }

        // Callback de teclado
        /// <summary>
        /// Keys the callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="key">The key</param>
        /// <param name="scancode">The scancode</param>
        /// <param name="action">The action</param>
        /// <param name="mods">The mods</param>
        private void KeyCallback(Window window, Keys key, int scancode, InputState action, ModifierKeys mods)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            int idx = (int) key;
            if (key == Keys.Unknown) return;

            bool pressed = action == InputState.Press || action == InputState.Repeat;
            io.KeysDown[idx] = pressed;

            io.KeyCtrl = io.KeysDown[(int) Keys.LeftControl] || io.KeysDown[(int) Keys.RightControl];
            io.KeyShift = io.KeysDown[(int) Keys.LeftShift] || io.KeysDown[(int) Keys.RightShift];
            io.KeyAlt = io.KeysDown[(int) Keys.LeftAlt] || io.KeysDown[(int) Keys.RightAlt];
            io.KeySuper = io.KeysDown[(int) Keys.LeftSuper] || io.KeysDown[(int) Keys.RightSuper];

            //Logger.Info($"Key: {key}, Action: {action}, Pressed: {pressed}");
        }

        // Callback para caracteres (texto)
        /// <summary>
        /// Chars the callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="codepoint">The codepoint</param>
        private void CharCallback(Window window, uint codepoint)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            io.AddInputCharacter(codepoint);

            //Logger.Info($"Char: {codepoint}");
        }
        
        /// <summary>
        /// Mouses the button callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="button">The button</param>
        /// <param name="action">The action</param>
        /// <param name="mods">The mods</param>
        private static void MouseButtonCallback(Window window, MouseButton button, InputState action, ModifierKeys mods)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            if (button >= MouseButton.Left && button <= MouseButton.Middle)
            {
                int idx = (int)button;
                io.MouseDown[idx] = action == InputState.Press;
            }
          
            //Console.WriteLine($"Mouse Button: {button}, Action: {action}, Pressed: {io.MouseDown[(int)button]}");
        }
      
        // Callback de scroll
        /// <summary>
        /// Scrolls the callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="xoffset">The xoffset</param>
        /// <param name="yoffset">The yoffset</param>
        private static void ScrollCallback(Window window, double xoffset, double yoffset)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            io.MouseWheel += (float)yoffset;
            io.MouseWheelH += (float)xoffset;
          
            //Console.WriteLine($"Scroll: XOffset: {xoffset}, YOffset: {yoffset}, MouseWheel: {io.MouseWheel}, MouseWheelH: {io.MouseWheelH}");
        }


        
        /// <summary>
        /// Ons the start
        /// </summary>
        public void OnStart()
        {

        }

        /// <summary>
        /// Ons the poll events
        /// </summary>
        public void OnPollEvents()
        {
            Glfw.PollEvents();
        }

        /// <summary>
        /// Ons the start frame
        /// </summary>
        public void OnStartFrame()
        {

        }

        /// <summary>
        /// Ons the render frame
        /// </summary>
        public void OnRenderFrame()
        {

        }

        /// <summary>
        /// Ons the end frame
        /// </summary>
        public void OnEndFrame()
        {
            Glfw.SwapBuffers(_window);
        }

        /// <summary>
        /// Ons the exit
        /// </summary>
        public void OnExit()
        {
            
            
            Logger.Info("Shutting down GLFW...");
            
            Glfw.Terminate();
            
            if(Glfw.GetError(out string errorDescription) != ErrorCode.None)
            {
                Logger.Exception($"GLFW error during shutdown: {errorDescription}");
            }
            
            Logger.Info("GLFW terminated successfully");
        }


        /// <summary>
        /// Ises the window focused
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsWindowFocused() => Glfw.GetWindowAttribute(_window, WindowAttribute.Focused);

        /// <summary>
        /// Gets the cursor position
        /// </summary>
        /// <returns>The double double</returns>
        public (double X, double Y) GetCursorPosition()
        {
            Glfw.GetCursorPosition(_window, out double x, out double y);
            return (x, y);
        }
        
        /// <summary>
        /// Ises the mouse button pressed using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The bool</returns>
        public bool IsMouseButtonPressed(int button) => Glfw.GetMouseButton(_window, (MouseButton)button) == InputState.Press;

        /// <summary>
        /// Checks the if window should close
        /// </summary>
        /// <returns>The bool</returns>
        public bool CheckIfWindowShouldClose()
        {
            return Glfw.WindowShouldClose(_window);
        }
    }
}