// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Windows.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Alis.Template.Game.Desktop
{
    // Be warned, there is a LOT of stuff here. It might seem complicated, but just take it slow and you'll be fine.
    // OpenGL's initial hurdle is quite large, but once you get past that, things will start making more sense.
    /// <summary>
    ///     The window class
    /// </summary>
    /// <seealso cref="GameWindow" />
    public class Window : GameWindow
    {
        // Create the vertices for our triangle. These are listed in normalized device coordinates (NDC)
        // In NDC, (0, 0) is the center of the screen.
        // Negative X coordinates move to the left, positive X move to the right.
        // Negative Y coordinates move to the bottom, positive Y move to the top.
        // OpenGL only supports rendering in 3D, so to create a flat triangle, the Z coordinate will be kept as 0.
        /// <summary>
        ///     The vertices
        /// </summary>
        private readonly float[] _vertices =
        {
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
            0.5f, -0.5f, 0.0f, // Bottom-right vertex
            0.0f, 0.5f, 0.0f // Top vertex
        };

        /// <summary>
        ///     The vertex array object
        /// </summary>
        private int _vertexArrayObject;

        // These are the handles to OpenGL objects. A handle is an integer representing where the object lives on the
        // graphics card. Consider them sort of like a pointer; we can't do anything with them directly, but we can
        // send them to OpenGL functions that need them.

        // What these objects are will be explained in OnLoad.
        /// <summary>
        ///     The vertex buffer object
        /// </summary>
        private int _vertexBufferObject;


        /// <summary>
        ///     Initializes a new instance of the <see cref="Window" /> class
        /// </summary>
        /// <param name="gameWindowSettings">The game window settings</param>
        /// <param name="nativeWindowSettings">The native window settings</param>
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        // Now, we start initializing OpenGL.
        /// <summary>
        ///     Ons the load
        /// </summary>
        protected override void OnLoad()
        {
            base.OnLoad();

            // This will be the color of the background after we clear it, in normalized colors.
            // Normalized colors are mapped on a range of 0.0 to 1.0, with 0.0 representing black, and 1.0 representing
            // the largest possible value for that channel.
            // This is a deep green.
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            // We need to send our vertices over to the graphics card so OpenGL can use them.
            // To do this, we need to create what's called a Vertex Buffer Object (VBO).
            // These allow you to upload a bunch of data to a buffer, and send the buffer to the graphics card.
            // This effectively sends all the vertices at the same time.

            // First, we need to create a buffer. This function returns a handle to it, but as of right now, it's empty.
            _vertexBufferObject = GL.GenBuffer();

            // Now, bind the buffer. OpenGL uses one global state, so after calling this,
            // all future calls that modify the VBO will be applied to this buffer until another buffer is bound instead.
            // The first argument is an enum, specifying what type of buffer we're binding. A VBO is an ArrayBuffer.
            // There are multiple types of buffers, but for now, only the VBO is necessary.
            // The second argument is the handle to our buffer.
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            // Finally, upload the vertices to the buffer.
            // Arguments:
            //   Which buffer the data should be sent to.
            //   How much data is being sent, in bytes. You can generally set this to the length of your array, multiplied by sizeof(array type).
            //   The vertices themselves.
            //   How the buffer will be used, so that OpenGL can write the data to the proper memory space on the GPU.
            //   There are three different BufferUsageHints for drawing:
            //     StaticDraw: This buffer will rarely, if ever, update after being initially uploaded.
            //     DynamicDraw: This buffer will change frequently after being initially uploaded.
            //     StreamDraw: This buffer will change on every frame.
            //   Writing to the proper memory space is important! Generally, you'll only want StaticDraw,
            //   but be sure to use the right one for your use case.
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            // One notable thing about the buffer we just loaded data into is that it doesn't have any structure to it. It's just a bunch of floats (which are actaully just bytes).
            // The opengl driver doesn't know how this data should be interpreted or how it should be divided up into vertices. To do this opengl introduces the idea of a 
            // Vertex Array Obejct (VAO) which has the job of keeping track of what parts or what buffers correspond to what data. In this example we want to set our VAO up so that 
            // it tells opengl that we want to interpret 12 bytes as 3 floats and divide the buffer into vertices using that.
            // To do this we generate and bind a VAO (which looks deceptivly similar to creating and binding a VBO, but they are different!).
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            // Now, we need to setup how the vertex shader will interpret the VBO data; you can send almost any C datatype (and a few non-C ones too) to it.
            // While this makes them incredibly flexible, it means we have to specify how that data will be mapped to the shader's input variables.

            // To do this, we use the GL.VertexAttribPointer function
            // This function has two jobs, to tell opengl about the format of the data, but also to associate the current array buffer with the VAO.
            // This means that after this call, we have setup this attribute to source data from the current array buffer and interpret it in the way we specified.
            // Arguments:
            //   Location of the input variable in the shader. the layout(location = 0) line in the vertex shader explicitly sets it to 0.
            //   How many elements will be sent to the variable. In this case, 3 floats for every vertex.
            //   The data type of the elements set, in this case float.
            //   Whether or not the data should be converted to normalized device coordinates. In this case, false, because that's already done.
            //   The stride; this is how many bytes are between the last element of one vertex and the first element of the next. 3 * sizeof(float) in this case.
            //   The offset; this is how many bytes it should skip to find the first element of the first vertex. 0 as of right now.
            // Stride and Offset are just sort of glossed over for now, but when we get into texture coordinates they'll be shown in better detail.
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            // Enable variable 0 in the shader.
            GL.EnableVertexAttribArray(0);


            // Setup is now complete! Now we move to the OnRenderFrame function to finally draw the triangle.
        }

        // Now that initialization is done, let's create our render loop.
        /// <summary>
        ///     Ons the render frame using the specified e
        /// </summary>
        /// <param name="e">The </param>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            // This clears the image, using what you set as GL.ClearColor earlier.
            // OpenGL provides several different types of data that can be rendered.
            // You can clear multiple buffers by using multiple bit flags.
            // However, we only modify the color, so ColorBufferBit is all we need to clear.
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // To draw an object in OpenGL, it's typically as simple as binding your shader,
            // setting shader uniforms (not done here, will be shown in a future tutorial)
            // binding the VAO,
            // and then calling an OpenGL function to render.


            // Bind the VAO
            GL.BindVertexArray(_vertexArrayObject);

            // And then call our drawing function.
            // For this tutorial, we'll use GL.DrawArrays, which is a very simple rendering function.
            // Arguments:
            //   Primitive type; What sort of geometric primitive the vertices represent.
            //     OpenGL used to support many different primitive types, but almost all of the ones still supported
            //     is some variant of a triangle. Since we just want a single triangle, we use Triangles.
            //   Starting index; this is just the start of the data you want to draw. 0 here.
            //   How many vertices you want to draw. 3 for a triangle.
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            // OpenTK windows are what's known as "double-buffered". In essence, the window manages two buffers.
            // One is rendered to while the other is currently displayed by the window.
            // This avoids screen tearing, a visual artifact that can happen if the buffer is modified while being displayed.
            // After drawing, call this function to swap the buffers. If you don't, it won't display what you've rendered.
            SwapBuffers();

            // And that's all you have to do for rendering! You should now see a yellow triangle on a black screen.
        }

        /// <summary>
        ///     Ons the update frame using the specified e
        /// </summary>
        /// <param name="e">The </param>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }

        /// <summary>
        ///     Ons the resize using the specified e
        /// </summary>
        /// <param name="e">The </param>
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            // When the window gets resized, we have to call GL.Viewport to resize OpenGL's viewport to match the new size.
            // If we don't, the NDC will no longer be correct.
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        // Now, for cleanup.
        // You should generally not do cleanup of opengl resources when exiting an application
        // as that is handled by the driver and operating system when the application exits.
        // 
        // There are reasons to delete opengl resources but exiting the application is not one of them.
        // This is provided here as a reference on how resoruce cleanup is done in opengl but
        // should not be done when exiting the application.
        //
        // Places where cleanup is appropriate would be to delete textures that are no
        // longer used for whatever reason (e.g. a new scene is loaded that doesn't use a texture).
        // This would free up video ram (VRAM) that can be used for new textures.
        //
        // The comming chapters will not have this code.
        /// <summary>
        ///     Ons the unload
        /// </summary>
        protected override void OnUnload()
        {
            // Unbind all the resources by binding the targets to 0/null.
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            // Delete all the resources.
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_vertexArrayObject);

            base.OnUnload();
        }
    }
}