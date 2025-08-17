using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using System.Numerics;
using Alis.Core.Aspect.Math.Matrix;

namespace Alis.Core.Graphic.Sample.Samples
{
    /// <summary>
    /// The cube example class
    /// </summary>
    /// <seealso cref="IExample"/>
    class CubeExample : IExample
    {
        private uint vao, vbo, ebo, shaderProgram;
        private float[] vertices = {
            // positions          // colors
            -0.5f, -0.5f, -0.5f, 1.0f, 0.0f, 0.0f,
             0.5f, -0.5f, -0.5f, 0.0f, 1.0f, 0.0f,
             0.5f,  0.5f, -0.5f, 0.0f, 0.0f, 1.0f,
            -0.5f,  0.5f, -0.5f, 1.0f, 1.0f, 0.0f,
            -0.5f, -0.5f,  0.5f, 0.0f, 1.0f, 1.0f,
             0.5f, -0.5f,  0.5f, 1.0f, 0.0f, 1.0f,
             0.5f,  0.5f,  0.5f, 1.0f, 1.0f, 1.0f,
            -0.5f,  0.5f,  0.5f, 0.0f, 0.0f, 0.0f
        };
        private uint[] indices = {
            0, 1, 3, 1, 2, 3,
            1, 5, 2, 5, 6, 2,
            5, 4, 6, 4, 7, 6,
            4, 0, 7, 0, 3, 7,
            3, 2, 7, 2, 6, 7,
            4, 5, 0, 5, 1, 0
        };
        private string vertexShaderSource = @"#version 150 core
in vec3 aPos;
in vec3 aColor;
out vec3 ourColor;
uniform mat4 transform;
void main()
{
    gl_Position = transform * vec4(aPos, 1.0);
    ourColor = aColor;
}";
        private string fragmentShaderSource = @"#version 150 core
in vec3 ourColor;
out vec4 FragColor;
void main()
{
    FragColor = vec4(ourColor, 1.0);
}";
        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize()
        {
            vao = Gl.GenVertexArray();
            vbo = Gl.GenBuffer();
            ebo = Gl.GenBuffer();
            Gl.GlBindVertexArray(vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            GCHandle vHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            vHandle.Free();
            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GCHandle iHandle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), iHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            iHandle.Free();
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
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), IntPtr.Zero);
            Gl.EnableVertexAttribArray(1);
            Gl.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
        }
        /// <summary>
        /// Draws this instance
        /// </summary>
        public void Draw()
        {
            Gl.GlClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);
            // Matriz de rotación animada
            float time = (float)DateTime.Now.TimeOfDay.TotalSeconds;
            Matrix4x4 rotZ = Matrix4x4.CreateRotationZ(time);
            Matrix4x4 rotX = Matrix4x4.CreateRotationX(time);
            Matrix4x4 transform = rotZ * rotX;
            int transformLocation = Gl.GlGetUniformLocation(shaderProgram, "transform");
            // Enviar la matriz al shader
            float[] mat = new float[16];
            mat[0] = transform.M11; mat[1] = transform.M12; mat[2] = transform.M13; mat[3] = transform.M14;
            mat[4] = transform.M21; mat[5] = transform.M22; mat[6] = transform.M23; mat[7] = transform.M24;
            mat[8] = transform.M31; mat[9] = transform.M32; mat[10] = transform.M33; mat[11] = transform.M34;
            mat[12] = transform.M41; mat[13] = transform.M42; mat[14] = transform.M43; mat[15] = transform.M44;
            
            
            Gl.UniformMatrix4Fv(transformLocation, new Matrix4X4(mat[0], mat[1], mat[2], mat[3],
                mat[4], mat[5], mat[6], mat[7],
                mat[8], mat[9], mat[10], mat[11],
                mat[12], mat[13], mat[14], mat[15]));
            Gl.GlDrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }
        /// <summary>
        /// Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.DeleteBuffer(ebo);
            Gl.GlDeleteProgram(shaderProgram);
        }
    }
}