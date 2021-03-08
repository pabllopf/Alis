//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Render.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
using Alis.Tools;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Core
{
    /// <summary>Render define</summary>
    public class Render
    {
        public Render()
        {
        }

        internal Task Start()
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                watch.Stop();
                Console.WriteLine($"  Time to Start render: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        public Task Update()
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                watch.Stop();
                Console.WriteLine($"    Time to RENDER: " + watch.ElapsedMilliseconds + " ms");
            });
        }
    }
}
        /*
        /// <summary>The current</summary>
        private static Render current;

        /// <summary>The title</summary>
        private string title;

        /// <summary>The window</summary>
        private RenderWindow renderWindow;

        /// <summary>The window</summary>
        private RenderTexture renderTexture;

        /// <summary>The video mode</summary>
        private VideoMode videoMode;

        /// <summary>The frame</summary>
        private SFML.Graphics.Image frame;

        /// <summary>The sprites</summary>
        private List<SFML.Graphics.Sprite> sprites;

        /// <summary>Gets or sets the current.</summary>
        /// <value>The current.</value>
        public static Render Current { get => current; set => current = value; }
        public RenderTexture RenderTexture { get => renderTexture; set => renderTexture = value; }
        public RenderWindow RenderWindow { get => renderWindow; set => renderWindow = value; }

        /// <summary>Initializes a new instance of the <see cref="Render" /> class.</summary>
        public Render() 
        {
            this.title = "Example";
            this.videoMode = new VideoMode(512, 320);
            this.renderTexture = new RenderTexture(512, 512);
            this.sprites = new List<SFML.Graphics.Sprite>();
            


            Logger.Info();
        }

        /// <summary>Frames the bytes.</summary>
        /// <returns>Return the frame.</returns>
        public byte[] FrameBytes()
        {
            renderTexture.Clear(Color.Black);

            if (sprites.Count > 0) 
            {
                sprites = sprites.OrderBy(o => o.Depth).ToList();
                foreach (SFML.Graphics.Sprite sprite in sprites)
                {
                    renderTexture.Draw(sprite.GetSprite);
                }
            }

            renderTexture.Smooth = true;
            renderTexture.Display();

            frame = renderTexture.Texture.CopyToImage();
            return frame.Pixels;
        }

        /// <summary>Renders the display.</summary>
        public void RenderDisplay() 
        {
            if (renderWindow == null) 
            {
                renderWindow = new RenderWindow(videoMode, title);
                //renderWindow.Closed += Window_Closed;
                Logger.Log("Create window");
            }

            renderWindow.DispatchEvents();
            renderWindow.Clear();

            if (sprites.Count > 0)
            {
                sprites = sprites.OrderBy(o => o.Depth).ToList();
                foreach (SFML.Graphics.Sprite sprite in sprites)
                {
                    //Debug.Log("sprite:::" + sprite.ImageFile + " " + sprite.Depth);
                    renderWindow.Draw(sprite.GetSprite);
                }
            }

            renderWindow.Display();
        }

        /// <summary>Handles the Closed event of the Window control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Window_Closed(object sender, EventArgs e)
        {
            renderWindow.Close();
            Environment.Exit(0);
            Logger.Log("EVENT: Close render window. ");
        }

        /// <summary>Adds the new sprite.</summary>
        /// <param name="sprite">The sprite.</param>
        public void AddNewSprite(SFML.Graphics.Sprite sprite) 
        {
            List<SFML.Graphics.Sprite> spir = sprites;

            if (!spir.Contains(sprite))
            {
                spir.Add(sprite);
                Logger.Warning("Add a sprite " + sprite.ToString());
                renderTexture.Clear();
                //renderTexture.Draw(sprite.GetSprite);
                renderTexture.Display();
            }
            else
            {
                Logger.Warning("Sprite alredy exits." + " Sprite: "  );//sprite.GetSprite.Texture.ToString());
            }

            sprites = spir;
        }

        internal SFML.Graphics.Sprite GetSprite(SFML.Graphics.Sprite sprite)
        {
            return sprites[sprites.IndexOf(sprite)];
        }

        internal async Task Update() => await Task.Run(() => Logger.Info());

        /// <summary>Deletes the sprite.</summary>
        /// <param name="sprite">The sprite.</param>
        public void DeleteSprite(SFML.Graphics.Sprite sprite) 
        {
            List<SFML.Graphics.Sprite> spir = sprites;
            
            if (spir.Count > 0)
            {
                if (spir.Contains(sprite))
                {
                    spir.Remove(sprite);
                    Logger.Log("Delete a sprite " + sprite.ToString());
                    renderTexture.Clear();
                    renderTexture.Display();
                }
            }

            sprites = spir;
        }

        /// <summary>Exitses the specified sprite.</summary>
        /// <param name="sprite">The sprite.</param>
        /// <returns>Return</returns>
        public bool Exits(SFML.Graphics.Sprite sprite)
        {
            if (sprites == null || sprites.Count == 0) 
            {
                return false;
            }

            return sprites.Contains(sprite);
        }
    }
}
*/