using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Sample.Samples
{
    /// <summary>
    /// Ejemplo: Renderiza dos cuadrados sin rellenar en rojo
    /// </summary>
    public class SquareUnfilledExample : IExample
    {
        private uint shaderProgram;
        private uint vao;
        private uint vbo;

        public void Initialize()
        {
            float[] vertices =
            {
                // Top-left
                -0.5f,  0.5f, 0.0f,
                // Top-right
                 0.5f,  0.5f, 0.0f,
                // Bottom-right
                 0.5f, -0.5f, 0.0f,
                // Bottom-left
                -0.5f, -0.5f, 0.0f
            };

            vbo = Gl.GenBuffer();
            vao = Gl.GenVertexArray();

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
                    handle.Free();
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
                  FragColor = vec4(1.0, 1.0, 1.0, 1.0); // Blanco
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

            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);

            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);
        }

        public void Draw()
        {
            Gl.GlDisable(EnableCap.DepthTest); // Desactiva el buffer de profundidad
            Gl.GlClearColor(0f, 0f, 0f, 1f); // Fondo negro
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // Limpia color y profundidad
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);
            Gl.GlLineWidth(1.0f); // Usar el valor seguro para Core Profile
            Gl.GlDrawArrays(PrimitiveType.LineLoop, 0, 4); // Dibuja el contorno del cuadrado
        }

        public void Cleanup()
        {
            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.GlDeleteProgram(shaderProgram);
        }
    }
}
