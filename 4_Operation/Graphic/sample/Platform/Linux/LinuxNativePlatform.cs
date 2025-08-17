using System;

namespace Alis.Core.Graphic.Sample.Platform.LINUX
{
    public class LinuxNativePlatform : INativePlatform
    {
        public void Initialize(int w, int h, string t)
        {
            throw new NotImplementedException("LinuxNativePlatform.Initialize no implementado");
        }
        public void ShowWindow() => throw new NotImplementedException();
        public void HideWindow() => throw new NotImplementedException();
        public void SetTitle(string t) => throw new NotImplementedException();
        public void SetSize(int w, int h) => throw new NotImplementedException();
        public void MakeContextCurrent() => throw new NotImplementedException();
        public void SwapBuffers() => throw new NotImplementedException();
        public bool IsWindowVisible() => throw new NotImplementedException();
        public bool PollEvents() => throw new NotImplementedException();
        public void Cleanup() => throw new NotImplementedException();
        public int GetWindowWidth() => throw new NotImplementedException();
        public int GetWindowHeight() => throw new NotImplementedException();
        public IntPtr GetProcAddress(string name) => throw new NotImplementedException();
        public bool TryGetLastKeyPressed(out ConsoleKey key) => throw new NotImplementedException();
    }
}

