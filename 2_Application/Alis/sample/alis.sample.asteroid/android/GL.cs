using System;
using System.Runtime.InteropServices;

namespace Alis.Sample.Asteroid.Android
{
    public static class GL
    {
        [DllImport("libGLESv2.so")]
        public static extern void glClearColor(float red, float green, float blue, float alpha);

        [DllImport("libGLESv2.so")]
        public static extern void glClear(uint mask);

        [DllImport("libGLESv2.so")]
        public static extern int glCreateShader(int type);

        [DllImport("libGLESv2.so")]
        public static extern void glShaderSource(int shader, int count, IntPtr stringArray, int[] length);

        [DllImport("libGLESv2.so")]
        public static extern void glCompileShader(int shader);

        [DllImport("libGLESv2.so")]
        public static extern int glCreateProgram();

        [DllImport("libGLESv2.so")]
        public static extern void glAttachShader(int program, int shader);

        [DllImport("libGLESv2.so")]
        public static extern void glLinkProgram(int program);

        [DllImport("libGLESv2.so")]
        public static extern void glUseProgram(int program);

        [DllImport("libGLESv2.so")]
        public static extern int glGetAttribLocation(int program, string name);

        [DllImport("libGLESv2.so")]
        public static extern void glEnableVertexAttribArray(int index);

        [DllImport("libGLESv2.so")]
        public static extern void glDisableVertexAttribArray(int index);

        [DllImport("libGLESv2.so")]
        public static extern void glVertexAttribPointer(int index, int size, uint type, bool normalized, int stride, IntPtr pointer);

        [DllImport("libGLESv2.so")]
        public static extern void glDrawArrays(uint mode, int first, int count);

        [DllImport("libGLESv2.so")]
        public static extern void glViewport(int x, int y, int width, int height);

        // Constantes
        public const int GL_VERTEX_SHADER = 0x8B31;
        public const int GL_FRAGMENT_SHADER = 0x8B30;
        public const uint GL_COLOR_BUFFER_BIT = 0x4000;
        public const uint GL_FLOAT = 0x1406;
        public const uint GL_TRIANGLES = 0x0004;
    }
}
