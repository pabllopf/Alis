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
    public class GlfwController : IControllerUi
    {
        private string TitleMainWindow;

        public Window _window;

        public int _widthMainWindow;
        public int _heightMainWindow;

        private int _windowsDefault;
        
        private const int ContextVersionMajor = 3;
        private const int ContextVersionMinor = 2;
        private const Profile OpenglProfile = Profile.Core;
        private const bool OpenglForwardCompatible = true;
        private const int VSync = 1;
        private const bool ScaleToMonitor = true;
        private const int Antialiasing = 4; 
        private const bool DecoratedWindow = true;
        
        private const bool FocusedOnInit = true;
        
        private const bool TransparentFramebuffer = false;
        
        private KeyCallback _keyCallbackDelegate;
        private CharCallback _charCallbackDelegate;
        private MouseButtonCallback _mouseButtonCallbackDelegate;
        private MouseCallback _scrollCallbackDelegate;
        
        public GlfwController(string titleMainWindow = "GLFW Window", int width = 800, int height = 600, int windowsDefault = 0)
        {
            TitleMainWindow = titleMainWindow;
            _widthMainWindow = width;
            _heightMainWindow = height;
            _windowsDefault = windowsDefault;
        }
        
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
        private void CharCallback(Window window, uint codepoint)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            io.AddInputCharacter(codepoint);

            //Logger.Info($"Char: {codepoint}");
        }
        
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
        private static void ScrollCallback(Window window, double xoffset, double yoffset)
        {
            ImGuiIoPtr io = ImGui.GetIo();
            io.MouseWheel += (float)yoffset;
            io.MouseWheelH += (float)xoffset;
          
            //Console.WriteLine($"Scroll: XOffset: {xoffset}, YOffset: {yoffset}, MouseWheel: {io.MouseWheel}, MouseWheelH: {io.MouseWheelH}");
        }


        
        public void OnStart()
        {

        }

        public void OnPollEvents()
        {
            Glfw.PollEvents();
        }

        public void OnStartFrame()
        {

        }

        public void OnRenderFrame()
        {

        }

        public void OnEndFrame()
        {
            Glfw.SwapBuffers(_window);
        }

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


        public bool IsWindowFocused() => Glfw.GetWindowAttribute(_window, WindowAttribute.Focused);

        public (double X, double Y) GetCursorPosition()
        {
            Glfw.GetCursorPosition(_window, out double x, out double y);
            return (x, y);
        }
        
        public bool IsMouseButtonPressed(int button) => Glfw.GetMouseButton(_window, (MouseButton)button) == InputState.Press;

        public bool CheckIfWindowShouldClose()
        {
            return Glfw.WindowShouldClose(_window);
        }
    }
}