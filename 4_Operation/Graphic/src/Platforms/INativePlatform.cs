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
//  --------------------------------------------------------------------------

using System;

namespace Alis.Core.Graphic.Platforms
{
    /// <summary>
    /// Defines the platform abstraction interface for creating and managing native windows,
    /// OpenGL contexts, input processing, and window properties.
    /// Each supported platform (Windows, macOS, Linux, Android, Web) provides its own implementation.
    /// </summary>
    public interface INativePlatform
    {
        /// <summary>
        /// Initializes the native platform with the specified window dimensions and title.
        /// Creates the window, sets up the OpenGL context, and makes it current.
        /// </summary>
        /// <param name="width">The desired window width in pixels.</param>
        /// <param name="height">The desired window height in pixels.</param>
        /// <param name="title">The window title string.</param>
        /// <returns>True if initialization succeeded, false otherwise.</returns>
        bool Initialize(int width, int height, string title);

        /// <summary>
        /// Initializes the native platform with the specified window dimensions, title, and icon.
        /// Creates the window, sets the icon, and prepares the OpenGL context.
        /// </summary>
        /// <param name="width">The desired window width in pixels.</param>
        /// <param name="height">The desired window height in pixels.</param>
        /// <param name="title">The window title string.</param>
        /// <param name="iconPath">The file path to a BMP icon file for the window.</param>
        /// <returns>True if initialization succeeded, false otherwise.</returns>
        bool Initialize(int width, int height, string title, string iconPath);

        /// <summary>
        /// Makes the window visible on screen.
        /// </summary>
        void ShowWindow();

        /// <summary>
        /// Hides the window from view.
        /// </summary>
        void HideWindow();

        /// <summary>
        /// Sets the window title text.
        /// </summary>
        /// <param name="title">The new window title.</param>
        void SetTitle(string title);

        /// <summary>
        /// Sets the window client area size.
        /// </summary>
        /// <param name="width">The new width in pixels.</param>
        /// <param name="height">The new height in pixels.</param>
        void SetSize(int width, int height);

        /// <summary>
        /// Makes the OpenGL rendering context current for the calling thread.
        /// </summary>
        void MakeContextCurrent();

        /// <summary>
        /// Swaps the front and back buffers, presenting the rendered frame.
        /// </summary>
        void SwapBuffers();

        /// <summary>
        /// Checks whether the window is currently visible.
        /// </summary>
        /// <returns>True if the window is visible, false otherwise.</returns>
        bool IsWindowVisible();

        /// <summary>
        /// Processes pending window events (input, resize, close, etc.).
        /// Returns false when the window has been requested to close.
        /// </summary>
        /// <returns>True if the window is still running, false if a close has been requested.</returns>
        bool PollEvents();

        /// <summary>
        /// Releases all native resources (window, context, display connections).
        /// </summary>
        void Cleanup();

        /// <summary>
        /// Gets the current window width in pixels.
        /// </summary>
        /// <returns>The window width.</returns>
        int GetWindowWidth();

        /// <summary>
        /// Gets the current window height in pixels.
        /// </summary>
        /// <returns>The window height.</returns>
        int GetWindowHeight();

        /// <summary>
        /// Resolves an OpenGL function pointer by name from the platform's OpenGL driver.
        /// </summary>
        /// <param name="procName">The name of the OpenGL function to resolve.</param>
        /// <returns>A function pointer, or IntPtr.Zero if not found.</returns>
        IntPtr GetProcAddress(string procName);

        /// <summary>
        /// Gets the last key pressed, if any, and clears the stored key.
        /// </summary>
        /// <param name="key">When this method returns, contains the last key pressed if available.</param>
        /// <returns>True if a key was available, false otherwise.</returns>
        bool TryGetLastKeyPressed(out ConsoleKey key);

        /// <summary>
        /// Checks if a specific key is currently held down.
        /// </summary>
        /// <param name="consoleKey">The key to check.</param>
        /// <returns>True if the key is currently pressed, false otherwise.</returns>
        bool IsKeyDown(ConsoleKey consoleKey);

        /// <summary>
        /// Sets the window icon from the specified BMP file path.
        /// </summary>
        /// <param name="iconPath">Full path to the BMP icon file.</param>
        void SetWindowIcon(string iconPath);

        /// <summary>
        /// Gets the current mouse position and button states.
        /// </summary>
        /// <param name="x">When this method returns, contains the mouse X coordinate.</param>
        /// <param name="y">When this method returns, contains the mouse Y coordinate.</param>
        /// <param name="buttons">An array of 5 bools indicating button states (left, right, middle, aux1, aux2).</param>
        void GetMouseState(out int x, out int y, out bool[] buttons);

        /// <summary>
        /// Gets the accumulated mouse wheel vertical delta and resets it.
        /// </summary>
        /// <returns>The accumulated wheel delta.</returns>
        float GetMouseWheel();

        /// <summary>
        /// Gets the last input characters (e.g., from WM_CHAR or X11 KeySym) for text input handling.
        /// </summary>
        /// <param name="chars">When this method returns, contains the accumulated input characters.</param>
        /// <returns>True if characters were available, false otherwise.</returns>
        bool TryGetLastInputCharacters(out string chars);

        /// <summary>
        /// Gets the window's X position on screen.
        /// </summary>
        /// <returns>The X coordinate of the window.</returns>
        int GetWindowPositionX();

        /// <summary>
        /// Gets the window's Y position on screen.
        /// </summary>
        /// <returns>The Y coordinate of the window.</returns>
        int GetWindowPositionY();

        /// <summary>
        /// Gets the window metrics including position, size, and framebuffer size.
        /// </summary>
        /// <param name="winX">Outputs the window X position.</param>
        /// <param name="winY">Outputs the window Y position.</param>
        /// <param name="winW">Outputs the window width.</param>
        /// <param name="winH">Outputs the window height.</param>
        /// <param name="fbW">Outputs the framebuffer width (may differ on HiDPI).</param>
        /// <param name="fbH">Outputs the framebuffer height.</param>
        void GetWindowMetrics(out int winX, out int winY, out int winW, out int winH, out int fbW, out int fbH);

        /// <summary>
        /// Gets the mouse position relative to the view area, normalized to 0.0-1.0 range.
        /// </summary>
        /// <param name="x">Outputs the normalized X coordinate.</param>
        /// <param name="y">Outputs the normalized Y coordinate.</param>
        void GetMousePositionInView(out float x, out float y);
    }
}
