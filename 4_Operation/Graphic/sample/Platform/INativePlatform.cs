using System;

namespace Alis.Core.Graphic.Sample.Platform
{
    public interface INativePlatform
    {
        void Initialize(int width, int height, string title);
        void ShowWindow();
        void HideWindow();
        void SetTitle(string title);
        void SetSize(int width, int height);
        void MakeContextCurrent();
        void SwapBuffers();
        bool IsWindowVisible();
        bool PollEvents(); // Devuelve false si la ventana se ha cerrado
        void Cleanup();
        int GetWindowWidth();
        int GetWindowHeight();
        
        // Otros métodos según necesidades
        IntPtr GetProcAddress(string procName);
    }
}

