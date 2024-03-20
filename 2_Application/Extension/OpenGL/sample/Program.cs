using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Extension.OpenGL.Enums;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.OpenGL.Sample
{
    public static class Program
    {
        public static void Main()
        {
            // Initialize SDL and create a window
            Sdl.Init(InitSettings.InitVideo);
            
            // GET VERSION SDL2
            Version version = Sdl.GetVersion();
            Console.WriteLine(@$"SDL2 VERSION {version.major}.{version.minor}.{version.patch}");

            // CONFIG THE SDL2 AN OPENGL CONFIGURATION
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextFlags, (int) GlContexts.SdlGlContextForwardCompatibleFlag);
            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMajorVersion, 3);
            Sdl.SetAttributeByInt(GlAttr.SdlGlContextMinorVersion, 2);

            Sdl.SetAttributeByProfile(GlAttr.SdlGlContextProfileMask, GlProfiles.SdlGlContextProfileCore);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDoubleBuffer, 1);
            Sdl.SetAttributeByInt(GlAttr.SdlGlDepthSize, 24);
            Sdl.SetAttributeByInt(GlAttr.SdlGlAlphaSize, 8);
            Sdl.SetAttributeByInt(GlAttr.SdlGlStencilSize, 8);
            
            IntPtr window = Sdl.CreateWindow("OpenGL Window", 100, 100, 800, 600, WindowSettings.WindowOpengl | WindowSettings.WindowResizable);
            
            // Initialize OpenGL context
            IntPtr context = Sdl.CreateContext(window);

            // Define the vertices for the triangle
            float[] vertices =
            {
                0.0f, 0.5f, 0.0f, // Top
                -0.5f, -0.5f, 0.0f, // Bottom Left
                0.5f, -0.5f, 0.0f // Bottom Right
            };

            // Create a vertex buffer object (VBO) and a vertex array object (VAO)
            uint vbo = Gl.GenBuffer();
            uint vao = Gl.GenVertexArray();

            // Bind the VAO and VBO
            Gl.GlBindVertexArray(vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);

            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, (IntPtr) (vertices.Length * sizeof(float)), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }
            
            // Update vertex shader source code
            string vertexShaderSource = @"
            #version 330 core
            layout (location = 0) in vec3 aPos;
            uniform mat4 transform;
            void main()
            {
                gl_Position = transform * vec4(aPos.x, aPos.y, aPos.z, 1.0);
            }
            ";

            string fragmentShaderSource = @"
            #version 330 core
            out vec4 FragColor;
            void main()
            {
                FragColor = vec4(1.0f, 1.0f, 1.0f, 1.0f); // white color
            }
        ";

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, fragmentShaderSource);
            Gl.GlCompileShader(fragmentShader);

            uint shaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(shaderProgram, vertexShader);
            Gl.GlAttachShader(shaderProgram, fragmentShader);
            Gl.GlLinkProgram(shaderProgram);

            // Delete the shaders as they're linked into our program now and no longer necessary
            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);

            // Bind the VAO and shader program
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);

            // Enable the vertex attribute array
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);

            // Main loop
            bool running = true;
            while (running)
            {
                // Event handling
                while (Sdl.PollEvent(out Event evt) != 0)
                {
                    if (evt.type == EventType.Quit)
                    {
                        running = false;
                    }
                }

                // Clear the screen
                Gl.GlClear(ClearBufferMask.ColorBufferBit);
                
                // Create a rotation matrix
                Matrix4X4 transform = Matrix4X4.CreateRotationZ((float)DateTime.Now.TimeOfDay.TotalSeconds); // Rotate around Z-axis

                // Get the location of the "transform" uniform variable
                int transformLocation = Gl.GlGetUniformLocation(shaderProgram, "transform");

                // Set the value of the "transform" uniform variable
                Gl.UniformMatrix4Fv(transformLocation, transform);

                // Draw the triangle
                Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3);
                
                // Swap the buffers to display the triangle
                Sdl.SwapWindow(window);
            }

            // Cleanup
            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.GlDeleteProgram(shaderProgram);

            Sdl.DeleteContext(context);
            Sdl.DestroyWindow(window);
            Sdl.Quit();
        }
    }
}