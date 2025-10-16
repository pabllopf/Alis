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
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        bool Initialize(int width, int height, string title);

        /// <summary>
        /// Initializes the width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        /// <param name="iconPath">The icon path</param>
        /// <returns>The bool</returns>
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
        /// <param name="title">The title</param>
        void SetTitle(string title);

        /// <summary>
        ///     Sets the size using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
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
        /// <returns>The bool</returns>
        bool IsWindowVisible();

        /// <summary>
        ///     Polls the events
        /// </summary>
        /// <returns>The bool</returns>
        bool PollEvents(); // Devuelve false si la ventana se ha cerrado

        /// <summary>
        ///     Cleanups this instance
        /// </summary>
        void Cleanup();

        /// <summary>
        ///     Gets the window width
        /// </summary>
        /// <returns>The int</returns>
        int GetWindowWidth();

        /// <summary>
        ///     Gets the window height
        /// </summary>
        /// <returns>The int</returns>
        int GetWindowHeight();
        
        

        // Otros métodos según necesidades
        /// <summary>
        ///     Gets the proc address using the specified proc name
        /// </summary>
        /// <param name="procName">The proc name</param>
        /// <returns>The int ptr</returns>
        IntPtr GetProcAddress(string procName);

        /// <summary>
        ///     Devuelve la última tecla pulsada, si existe
        /// </summary>
        /// <param name="key">La tecla pulsada</param>
        /// <returns>true si hay tecla, false si no</returns>
        bool TryGetLastKeyPressed(out ConsoleKey key);

        /// <summary>
        /// Ises the key down using the specified console key
        /// </summary>
        /// <param name="consoleKey">The console key</param>
        /// <returns>The bool</returns>
        bool IsKeyDown(ConsoleKey consoleKey);

        /// <summary>
        /// Sets the window icon from the specified BMP file path
        /// </summary>
        /// <param name="iconPath">Full path to the BMP icon file</param>
        void SetWindowIcon(string iconPath);
    }
}