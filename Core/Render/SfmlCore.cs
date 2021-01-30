//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="SfmlCore.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using SFML.Graphics;
    using SFML.Window;

    /// <summary>Core render</summary>
    internal class SfmlCore : IRenderCore
    {
        /// <summary>The video mode</summary>
        private VideoMode videoMode;
        
        /// <summary>The render</summary>
        private RenderTexture render;
        
        /// <summary>The frame</summary>
        private Image frame;

        /// <summary>The circle</summary>
        private CircleShape circle = new CircleShape(100f);

        /// <summary>The is closed</summary>
        private bool isClosed;

        /// <summary>Initializes a new instance of the <see cref="SfmlCore" /> class.</summary>
        public SfmlCore() 
        {
            videoMode = new VideoMode(640, 480);
            isClosed = false;
            render = new RenderTexture(512, 512);
        }

        /// <summary>Gets or sets a value indicating whether this instance is closed.</summary>
        /// <value>
        /// <c>true</c> if this instance is closed; otherwise, <c>false</c>.</value>
        public bool IsClosed { get => isClosed; set => isClosed = value; }

        /// <summary>Frames the pixels.</summary>
        /// <returns>Return data</returns>
        public byte[] FramePixels() 
        {
            frame = render.Texture.CopyToImage();
            return frame.Pixels;
        }

        /// <summary>Draws this instance.</summary>
        public void Draw()
        {
            render.Clear();
            render.Draw(circle);
            render.Display();
        }

        /// <summary>Handles the Closed event of the RenderWindow control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RenderWindow_Closed(object sender, EventArgs e)
        {
            Debug.Warning("Closed the render window");
            Environment.Exit(1);
        }
    }
}
