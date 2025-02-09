using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Graphic.GlfwLib;
using Alis.Core.Graphic.GlfwLib.Enums;
using Alis.Core.Graphic.GlfwLib.Structs;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Exception = System.Exception;

namespace Alis.Core.Graphic.Sample
{
    /// <summary>
    /// The load bmp imagen sample class
    /// </summary>
    public class LoadBmpImagenSample
    {
        /// <summary>
        /// The running
        /// </summary>
        private bool running = true;
        /// <summary>
        /// The sprite
        /// </summary>
        private Sprite sprite1;
        /// <summary>
        /// The sprite
        /// </summary>
        private Sprite sprite2;
        /// <summary>
        /// The sprite
        /// </summary>
        private Sprite sprite3;
        /// <summary>
        /// The window
        /// </summary>
        private Window window;

        /// <summary>
        /// Runs this instance
        /// </summary>
        /// <exception cref="Exception">Failed to create GLFW window</exception>
        /// <exception cref="Exception">Failed to initialize GLFW</exception>
        public void Run()
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
            Glfw.SetKeyCallback(window, KeyCallback);

            int scaleTexture = 1;
            int imageWidth = 32 * scaleTexture;
            int imageHeight = 32 * scaleTexture;

            sprite1 = new Sprite(AssetManager.Find("tile000.bmp"), -0.5f, 0.5f);
            sprite2 = new Sprite(AssetManager.Find("tile000.jpeg"), 0.5f, 0.5f);
            sprite3 = new Sprite(AssetManager.Find("tile000.jpeg"), 0.0f, -0.5f);

            Gl.GlUseProgram(sprite1.ShaderProgram);
            Gl.GlUniform1F(Gl.GlGetUniformLocation(sprite1.ShaderProgram, "texture1"), 0);

            while (running)
            {
                Glfw.PollEvents();
                if (Glfw.WindowShouldClose(window))
                {
                    running = false;
                }

                Gl.GlClear(ClearBufferMask.ColorBufferBit);

                sprite1.Draw();
                sprite2.Draw();
                sprite3.Draw();

                Gl.GlClearColor(0.2f, 0.3f, 0.3f, 1.0f);
                Glfw.SwapBuffers(window);
            }

            Gl.DeleteVertexArray(sprite1.Vao);
            Gl.DeleteBuffer(sprite1.Vbo);
            Gl.DeleteBuffer(sprite1.Ebo);
            Gl.GlDeleteProgram(sprite1.ShaderProgram);
            Gl.DeleteTexture(sprite1.Texture);

            Gl.DeleteVertexArray(sprite2.Vao);
            Gl.DeleteBuffer(sprite2.Vbo);
            Gl.DeleteBuffer(sprite2.Ebo);
            Gl.GlDeleteProgram(sprite2.ShaderProgram);
            Gl.DeleteTexture(sprite2.Texture);

            Gl.DeleteVertexArray(sprite3.Vao);
            Gl.DeleteBuffer(sprite3.Vbo);
            Gl.DeleteBuffer(sprite3.Ebo);
            Gl.GlDeleteProgram(sprite3.ShaderProgram);
            Gl.DeleteTexture(sprite3.Texture);
        }

        /// <summary>
        /// Framebuffers the size callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        private void FramebufferSizeCallback(Window window, int width, int height)
        {
            Gl.GlViewport(0, 0, width, height);
        }

        /// <summary>
        /// Keys the callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="key">The key</param>
        /// <param name="scancode">The scancode</param>
        /// <param name="state">The state</param>
        /// <param name="mods">The mods</param>
        private void KeyCallback(Window window, Keys key, int scancode, InputState state, ModifierKeys mods)
        {
            if (state == InputState.Press || state == InputState.Repeat)
            {
                float moveSpeed = 0.05f;
                switch (key)
                {
                    case Keys.W:
                        sprite1.Y += moveSpeed;
                        break;
                    case Keys.S:
                        sprite1.Y -= moveSpeed;
                        break;
                    case Keys.A:
                        sprite1.X -= moveSpeed;
                        break;
                    case Keys.D:
                        sprite1.X += moveSpeed;
                        break;
                }
            }
        }
    }
}