using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Sample.Platform;

namespace Alis.Core.Graphic.Sample
{
    static class Program
    {
        // --- TriangleRenderer para renderizar un triángulo blanco ---
        class TriangleRenderer
        {
            private uint vao, vbo, shaderProgram;
            private float width, height;
            private float[] vertices = {
                // posiciones
                -0.5f, -0.5f, 0.0f,
                0.5f, -0.5f, 0.0f,
                0.0f,  0.5f, 0.0f
            };
            private string vertexShaderSource = @"
#version 150 core
in vec3 aPos;
void main() {
    gl_Position = vec4(aPos, 1.0);
}
";
            private string fragmentShaderSource = @"
#version 150 core
out vec4 FragColor;
void main() {
    FragColor = vec4(1.0, 1.0, 1.0, 1.0);
}
";

            public TriangleRenderer(float w, float h) { width = w; height = h; }

            public void Initialize()
            {
                vao = Gl.GenVertexArray();
                vbo = Gl.GenBuffer();
                Gl.GlBindVertexArray(vao);
                Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
                GCHandle vHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
                Gl.GlBufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
                vHandle.Free();
                uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
                Gl.ShaderSource(vertexShader, vertexShaderSource);
                Gl.GlCompileShader(vertexShader);
                if (!Gl.GetShaderCompileStatus(vertexShader))
                    Console.WriteLine("Vertex shader error: " + Gl.GetShaderInfoLog(vertexShader));
                uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
                Gl.ShaderSource(fragmentShader, fragmentShaderSource);
                Gl.GlCompileShader(fragmentShader);
                if (!Gl.GetShaderCompileStatus(fragmentShader))
                    Console.WriteLine("Fragment shader error: " + Gl.GetShaderInfoLog(fragmentShader));
                shaderProgram = Gl.GlCreateProgram();
                Gl.GlAttachShader(shaderProgram, vertexShader);
                Gl.GlAttachShader(shaderProgram, fragmentShader);
                Gl.GlLinkProgram(shaderProgram);
                if (!Gl.GetProgramLinkStatus(shaderProgram))
                    Console.WriteLine("Program link error: " + Gl.GetProgramInfoLog(shaderProgram));
                Gl.GlDeleteShader(vertexShader);
                Gl.GlDeleteShader(fragmentShader);
                Gl.GlBindVertexArray(vao);
                Gl.GlUseProgram(shaderProgram);
                Gl.EnableVertexAttribArray(0);
                Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);
            }

            public void Draw()
            {
                Gl.GlBindVertexArray(vao);
                Gl.GlUseProgram(shaderProgram);
                Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3);
            }

            public void Cleanup()
            {
                Gl.DeleteVertexArray(vao);
                Gl.DeleteBuffer(vbo);
                Gl.GlDeleteProgram(shaderProgram);
            }
        }

        static void Main()
        {
            INativePlatform platform = new MacNativePlatform();
            platform.Initialize(800, 600, "C# + Cocoa + OpenGL (Apple Silicon)");
            platform.MakeContextCurrent();
            Gl.Initialize(platform.GetProcAddress);
            Gl.GlViewport(0, 0, platform.GetWindowWidth(), platform.GetWindowHeight());
            Gl.GlEnable(EnableCap.DepthTest);
            Gl.GlClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            TriangleRenderer triangle = new TriangleRenderer(platform.GetWindowWidth(), platform.GetWindowHeight());
            triangle.Initialize();
            platform.ShowWindow();
            bool running = true;
            while (running)
            {
                running = platform.PollEvents();
                Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                triangle.Draw();
                platform.SwapBuffers();
                var glError = Gl.GlGetError();
                if (glError != 0)
                {
                    Console.WriteLine($"OpenGL error tras flushBuffer: 0x{glError:X}");
                }
                System.Threading.Thread.Sleep(10);
            }
            triangle.Cleanup();
            platform.Cleanup();
        }
    }
}