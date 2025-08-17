using System;

namespace Alis.Core.Graphic.Sample.Platform
{
    /// <summary>
    /// The native platform interface
    /// </summary>
    public interface INativePlatform
    {
        /// <summary>
        /// Initializes the width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        void Initialize(int width, int height, string title);
        /// <summary>
        /// Shows the window
        /// </summary>
        void ShowWindow();
        /// <summary>
        /// Hides the window
        /// </summary>
        void HideWindow();
        /// <summary>
        /// Sets the title using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        void SetTitle(string title);
        /// <summary>
        /// Sets the size using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        void SetSize(int width, int height);
        /// <summary>
        /// Makes the context current
        /// </summary>
        void MakeContextCurrent();
        /// <summary>
        /// Swaps the buffers
        /// </summary>
        void SwapBuffers();
        /// <summary>
        /// Ises the window visible
        /// </summary>
        /// <returns>The bool</returns>
        bool IsWindowVisible();
        /// <summary>
        /// Polls the events
        /// </summary>
        /// <returns>The bool</returns>
        bool PollEvents(); // Devuelve false si la ventana se ha cerrado
        /// <summary>
        /// Cleanups this instance
        /// </summary>
        void Cleanup();
        /// <summary>
        /// Gets the window width
        /// </summary>
        /// <returns>The int</returns>
        int GetWindowWidth();
        /// <summary>
        /// Gets the window height
        /// </summary>
        /// <returns>The int</returns>
        int GetWindowHeight();
        
        // Otros métodos según necesidades
        /// <summary>
        /// Gets the proc address using the specified proc name
        /// </summary>
        /// <param name="procName">The proc name</param>
        /// <returns>The int ptr</returns>
        IntPtr GetProcAddress(string procName);
        /// <summary>
        /// Devuelve la última tecla pulsada, si existe
        /// </summary>
        /// <param name="key">La tecla pulsada</param>
        /// <returns>true si hay tecla, false si no</returns>
        bool TryGetLastKeyPressed(out ConsoleKey key);
    }
}
