using System;
using System.Text;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Sample.Web
{
    /// <summary>
    /// Ejemplo mínimo: triángulo rojo 2D
    /// </summary>
    public class MeshDemo
    {
        /// <summary>
        /// The shader program
        /// </summary>
        private uint shaderProgram;
        /// <summary>
        /// The vao
        /// </summary>
        private uint vao;

        // Vértices del triángulo (posición 2D)
        /// <summary>
        /// The vertices
        /// </summary>
        private static readonly float[] Vertices =
        {
            -0.5f, -0.5f,
             0.5f, -0.5f,
             0.0f,  0.5f
        };

        // Vertex shader: WebGL2 compatible
        /// <summary>
        /// The vertex shader source
        /// </summary>
        private const string VertexShaderSource = @"#version 300 es
            layout(location = 0) in vec2 in_xy;
            void main() {
            gl_Position = vec4(in_xy, 0.0, 1.0);
        }";

        // Fragment shader: color rojo fijo
        /// <summary>
        /// The fragment shader source
        /// </summary>
        private const string FragmentShaderSource = @"#version 300 es
            precision mediump float;
            out vec4 outColor;
            void main() {
            outColor = vec4(1.0, 0.0, 0.0, 1.0);
        }";

        /// <summary>
        /// Loads
        /// </summary>
        /// <returns>The mesh demo</returns>
        public static MeshDemo Load()
        {
            return new MeshDemo();
        }

        /// <summary>
        /// Checks the shader using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="type">The type</param>
        /// <exception cref="Exception">{type} shader failed to compile</exception>
        private static void CheckShader(uint shader, string type)
        {
            Gl.GlGetShader(shader, ShaderParameter.CompileStatus, out int status);
            if (status == 0)
            {
                Gl.GlGetShader(shader, ShaderParameter.InfoLogLength, out int logLen);
                if (logLen > 1)
                {
                    StringBuilder log = new System.Text.StringBuilder(logLen);
                    Gl.GlGetShaderInfoLog(shader, logLen, null, log);
                    Console.WriteLine($"[MeshDemo] {type} shader compilation error: {log}");
                }
                throw new Exception($"{type} shader failed to compile");
            }
        }

        /// <summary>
        /// Checks the program using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <exception cref="Exception">Shader program failed to link</exception>
        private static void CheckProgram(uint program)
        {
            Gl.GlGetProgram(program, ProgramParameter.LinkStatus, out int status);
            if (status == 0)
            {
                Gl.GlGetProgram(program, ProgramParameter.InfoLogLength, out int logLen);
                if (logLen > 1)
                {
                    StringBuilder log = new System.Text.StringBuilder(logLen);
                    Gl.GlGetProgramInfoLog(program, logLen, null, log);
                    Console.WriteLine($"[MeshDemo] Program link error: {log}");
                }
                throw new Exception("Shader program failed to link");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeshDemo"/> class
        /// </summary>
        private MeshDemo()
        {
            // Crear y compilar shaders
            shaderProgram = Gl.GlCreateProgram();
            uint vert = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vert, VertexShaderSource);
            Gl.GlCompileShader(vert);
            CheckShader(vert, "Vertex");
            Gl.GlAttachShader(shaderProgram, vert);

            uint frag = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(frag, FragmentShaderSource);
            Gl.GlCompileShader(frag);
            CheckShader(frag, "Fragment");
            Gl.GlAttachShader(shaderProgram, frag);

            Gl.GlLinkProgram(shaderProgram);
            CheckProgram(shaderProgram);

            // Crear VAO y VBO
            vao = Gl.GenVertexArray();
            Gl.GlBindVertexArray(vao);
            uint[] vbos = new uint[1];
            Gl.GlGenBuffers(1, vbos);
            uint vbo = vbos[0];
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            unsafe
            {
                fixed (float* ptr = Vertices)
                {
                    Gl.GlBufferData(BufferTarget.ArrayBuffer, sizeof(float) * Vertices.Length, (IntPtr)ptr, BufferUsageHint.StaticDraw);
                }
            }
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), IntPtr.Zero);
            Gl.GlBindVertexArray(0);
        }

        /// <summary>
        /// Renders this instance
        /// </summary>
        public void Render()
        {
            Gl.GlClearColor(1f, 1f, 1f, 1f); // Fondo blanco
            Gl.GlClear(ClearBufferMask.ColorBufferBit);
            Gl.GlUseProgram(shaderProgram);
            Gl.GlBindVertexArray(vao);
            Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3);
            Gl.GlBindVertexArray(0);
        }

        /// <summary>
        /// Canvases the resized using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void CanvasResized(int width, int height)
        {
            Gl.GlViewport(0, 0, width, height);
        }
    }
}
