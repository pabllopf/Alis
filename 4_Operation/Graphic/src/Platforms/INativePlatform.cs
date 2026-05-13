// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:INativePlatform.cs
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

namespace Alis.Core.Graphic.Platforms
{
    /// <summary>
    ///     The native platform interface
    /// </summary>
    public interface INativePlatform
    {
        /// <summary>
        ///     Initializes the width
        /// </summary>
        /// <param name="width">The width of the window in pixels</param>
        /// <param name="height">The height of the window in pixels</param>
        /// <param name="title">The title of the window</param>
        bool Initialize(int width, int height, string title);

        /// <summary>
        ///     Initializes the width
        /// </summary>
        /// <param name="width">The width of the window in pixels</param>
        /// <param name="height">The height of the window in pixels</param>
        /// <param name="title">The title of the window</param>
        /// <param name="iconPath">The path to the window icon file</param>
        /// <returns>True if initialization succeeded, otherwise false</returns>
        bool Initialize(int width, int height, string title, string iconPath);

        /// <summary>
        ///     Shows the window
        /// </summary>
        void ShowWindow();

        /// <summary>
        ///     Hides the window
        /// </summary>
        void HideWindow();

        /// <summary>
        ///     Sets the title using the specified title
        /// </summary>
        /// <param name="title">The new window title</param>
        void SetTitle(string title);

        /// <summary>
        ///     Sets the size using the specified width
        /// </summary>
        /// <param name="width">The new width of the window in pixels</param>
        /// <param name="height">The new height of the window in pixels</param>
        void SetSize(int width, int height);

        /// <summary>
        ///     Makes the context current
        /// </summary>
        void MakeContextCurrent();

        /// <summary>
        ///     Swaps the buffers
        /// </summary>
        void SwapBuffers();

        /// <summary>
        ///     Ises the window visible
        /// </summary>
        /// <returns>True if the window is visible, otherwise false</returns>
        bool IsWindowVisible();

        /// <summary>
        ///     Polls the events
        /// </summary>
        /// <returns>True if events were polled, false if the window was closed</returns>
        bool PollEvents(); // Devuelve false si la ventana se ha cerrado

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        void Cleanup();

        /// <summary>
        ///     Gets the window width
        /// </summary>
        /// <returns>The window width in pixels</returns>
        int GetWindowWidth();

        /// <summary>
        ///     Gets the window height
        /// </summary>
        /// <returns>The window height in pixels</returns>
        int GetWindowHeight();


        // Otros métodos según necesidades
        /// <summary>
        ///     Gets the proc address using the specified proc name
        /// </summary>
        /// <param name="procName">The name of the native function to look up</param>
        /// <returns>A function pointer to the requested OpenGL function, or IntPtr.Zero if not found</returns>
        IntPtr GetProcAddress(string procName);

        /// <summary>
        ///     Gets the last key pressed, if any
        /// </summary>
        /// <param name="key">The last pressed key, if available</param>
        /// <returns>True if a key was pressed, false otherwise</returns>
        bool TryGetLastKeyPressed(out ConsoleKey key);

        /// <summary>
        ///     Ises the key down using the specified console key
        /// </summary>
        /// <param name="consoleKey">The console key to check</param>
        /// <returns>True if the key is currently pressed, otherwise false</returns>
        bool IsKeyDown(ConsoleKey consoleKey);

        /// <summary>
        ///     Sets the window icon from the specified BMP file path
        /// </summary>
        /// <param name="iconPath">Full path to the BMP icon file</param>
        void SetWindowIcon(string iconPath);

        /// <summary>
        ///     Gets the mouse state: position and button array (left, right, middle, aux1, aux2)
        /// </summary>
        /// <param name="x">out x</param>
        /// <param name="y">out y</param>
        /// <param name="buttons">out buttons array</param>
        void GetMouseState(out int x, out int y, out bool[] buttons);

        /// <summary>
        ///     Gets the mouse wheel delta (vertical)
        /// </summary>
        /// <returns>float wheel</returns>
        float GetMouseWheel();

        /// <summary>
        ///     Gets the last input character string accumulated by the platform backend
        /// </summary>
        /// <param name="chars">The incoming characters string, may contain multiple characters</param>
        /// <returns>True if there were pending characters, false otherwise</returns>
        bool TryGetLastInputCharacters(out string chars);

        /// <summary>
        ///     Gets the window position x
        /// </summary>
        /// <returns>The window x position in pixels</returns>
        int GetWindowPositionX();

        /// <summary>
        ///     Gets the window position y
        /// </summary>
        /// <returns>The window y position in pixels</returns>
        int GetWindowPositionY();

        /// <summary>
        ///     Gets the window metrics using the specified win x
        /// </summary>
        /// <param name="winX">Window x position output</param>
        /// <param name="winY">Window y position output</param>
        /// <param name="winW">Window width output</param>
        /// <param name="winH">Window height output</param>
        /// <param name="fbW">Framebuffer width output</param>
        /// <param name="fbH">Framebuffer height output</param>
        void GetWindowMetrics(out int winX, out int winY,
            out int winW, out int winH,
            out int fbW, out int fbH);


        /// <summary>
        ///     Gets the mouse position in view using the specified x
        /// </summary>
        /// <param name="x">The mouse x position output</param>
        /// <param name="y">The mouse y position output</param>
        void GetMousePositionInView(out float x, out float y);
    }
}