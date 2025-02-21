using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Exception = System.Exception;

namespace Alis.Core.Graphic.Sample
{
    public class RenderSquareUnfilled
    {
        private bool running = true;
        private uint shaderProgram;
        private uint vao;
        private uint vbo;
        private Window window;

        public void Run()
        {
            Init();

            while (running)
            {
                Glfw.PollEvents();
                if (Glfw.WindowShouldClose(window))
                {
                    running = false;
                }

                Gl.GlClear(ClearBufferMask.ColorBufferBit);

                Draw(new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.5f));
                Draw(new Vector2F(0.5f, 0.5f), new Vector2F(0.25f, 0.25f));

                Glfw.SwapBuffers(window);
            }

            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.GlDeleteProgram(shaderProgram);
        }

        private void Init()
        {
            if (!Glfw.Init())
            {
                throw new Exception("Failed to initialize GLFW");
            }

            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
            Glfw.WindowHint(Hint.OpenglForwardCompatible, true);

            window = Glfw.CreateWindow(800, 600, "OpenGL Window", Monitor.None, Window.None);
            if (window == Window.None)
            {
                throw new Exception("Failed to create GLFW window");
            }

            Glfw.MakeContextCurrent(window);
            Glfw.SwapInterval(1);

            Glfw.SetFramebufferSizeCallback(window, FramebufferSizeCallback);

            float[] vertices =
            {
                -0.5f, 0.5f, 0.0f, // Top-left
                0.5f, 0.5f, 0.0f, // Top-right
                0.5f, -0.5f, 0.0f, // Bottom-right
                -0.5f, -0.5f, 0.0f // Bottom-left
            };

            uint[] indices =
            {
                0, 1, 2, // First triangle
                2, 3, 0 // Second triangle
            };

            vbo = Gl.GenBuffer();
            vao = Gl.GenVertexArray();
            uint ebo = Gl.GenBuffer();

            Gl.GlBindVertexArray(vao);

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            handle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            string vertexShaderSource = @"
              #version 330 core
              layout (location = 0) in vec3 aPos;
              void main()
              {
                  gl_Position = vec4(aPos, 1.0);
              }
          ";

            string fragmentShaderSource = @"
              #version 330 core
              out vec4 FragColor;
              void main()
              {
                  FragColor = vec4(1.0f, 0.0f, 0.0f, 1.0f); // Red color
              }
          ";

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, fragmentShaderSource);
            Gl.GlCompileShader(fragmentShader);

            shaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(shaderProgram, vertexShader);
            Gl.GlAttachShader(shaderProgram, fragmentShader);
            Gl.GlLinkProgram(shaderProgram);

            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);

            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);
        }

        private void Draw(Vector2F pos, Vector2F size)
        {
            // Update the vertex positions based on the given position and size
            float[] vertices =
            {
                pos.X - size.X / 2, pos.Y + size.Y / 2, 0.0f, // Top-left
                pos.X + size.X / 2, pos.Y + size.Y / 2, 0.0f, // Top-right
                pos.X + size.X / 2, pos.Y - size.Y / 2, 0.0f, // Bottom-right
                pos.X - size.X / 2, pos.Y - size.Y / 2, 0.0f // Bottom-left
            };

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            Gl.GlPolygonMode(MaterialFace.FrontAndBack, PolygonModeEnum.Line);
            Gl.GlDrawElements(PrimitiveType.LineLoop, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);
            Gl.GlPolygonMode(MaterialFace.FrontAndBack, PolygonModeEnum.Fill);
        }

        private void FramebufferSizeCallback(Window window, int width, int height)
        {
            Gl.GlViewport(0, 0, width, height);
        }
    }
}