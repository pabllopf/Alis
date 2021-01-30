//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Input.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Tools
{
    using SFML.Graphics;
    using SFML.Window;

    using System;

    internal class SfmlCore : RenderCore
    {
        private RenderWindow window;
        private VideoMode videoMode;
        private RenderTexture render;
        private Image frame;

        private CircleShape circle = new CircleShape(50f);

        public bool isClosed;

        internal SfmlCore() 
        {
            videoMode = new VideoMode(640, 480);
            //window = new RenderWindow(videoMode, Application.Name);
            //window.Closed += RenderWindow_Closed;
            isClosed = false;

            render = new RenderTexture(512, 512);
        }

        private void RenderWindow_Closed(object sender, EventArgs e)
        {
            Debug.Warning("Closed the render window");
            Environment.Exit(1);
        }

        public byte[] FramePixels() 
        {
            frame = render.Texture.CopyToImage();
            return frame.Pixels;
        }


        public void Draw()
        {
            
            //window.DispatchEvents();

            //window.Clear();
            render.Clear();

            // Draw some graphical entities
            //window.Draw(circle);
            render.Draw(circle);

            // End the current frame and display its contents on screen
            //window.Display();
            render.Display();
        }
    }
}
