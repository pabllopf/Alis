#if LINUX

using System;

namespace Alis.Core.Graphic.Platforms.Linux
{
    /// <summary>
    /// The linux native platform class
    /// </summary>
    /// <seealso cref="INativePlatform"/>
    public class LinuxNativePlatform : INativePlatform
    {
        /// <summary>
        /// Initializes the w
        /// </summary>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="t">The </param>
        /// <exception cref="NotImplementedException">LinuxNativePlatform.Initialize no implementado</exception>
        public void Initialize(int w, int h, string t)
        {
            throw new NotImplementedException("LinuxNativePlatform.Initialize no implementado");
        }
        /// <summary>
        /// Shows the window
        /// </summary>
        public void ShowWindow() => throw new NotImplementedException();
        /// <summary>
        /// Hides the window
        /// </summary>
        public void HideWindow() => throw new NotImplementedException();
        /// <summary>
        /// Sets the title using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public void SetTitle(string t) => throw new NotImplementedException();
        /// <summary>
        /// Sets the size using the specified w
        /// </summary>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        public void SetSize(int w, int h) => throw new NotImplementedException();
        /// <summary>
        /// Makes the context current
        /// </summary>
        public void MakeContextCurrent() => throw new NotImplementedException();
        /// <summary>
        /// Swaps the buffers
        /// </summary>
        public void SwapBuffers() => throw new NotImplementedException();
        /// <summary>
        /// Ises the window visible
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsWindowVisible() => throw new NotImplementedException();
        /// <summary>
        /// Polls the events
        /// </summary>
        /// <returns>The bool</returns>
        public bool PollEvents() => throw new NotImplementedException();
        /// <summary>
        /// Cleanups this instance
        /// </summary>
        public void Cleanup() => throw new NotImplementedException();
        /// <summary>
        /// Gets the window width
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowWidth() => throw new NotImplementedException();
        /// <summary>
        /// Gets the window height
        /// </summary>
        /// <returns>The int</returns>
        public int GetWindowHeight() => throw new NotImplementedException();
        /// <summary>
        /// Gets the proc address using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        public IntPtr GetProcAddress(string name) => throw new NotImplementedException();
        /// <summary>
        /// Tries the get last key pressed using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The bool</returns>
        public bool TryGetLastKeyPressed(out ConsoleKey key) => throw new NotImplementedException();
    }
}

#endif

