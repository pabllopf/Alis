//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Render.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using SFML.Graphics;
    using SFML.Window;
    using Newtonsoft.Json;
    using System.Linq;
    using Alis.Tools;

    /// <summary>Render define</summary>
    public class Render
    {
        /// <summary>The current</summary>
        private static Render current;

        /// <summary>The configuration</summary>
        [JsonProperty]
        [NotNull]
        private readonly Config config;

        /// <summary>The window</summary>
        [NotNull]
        private RenderWindow renderWindow;

        /// <summary>The render texture</summary>
        [NotNull]
        private RenderTexture renderTexture;

        /// <summary>The frame</summary>
        [NotNull]
        private SFML.Graphics.Image frame;

        /// <summary>The video mode</summary>
        [NotNull]
        private VideoMode videoMode;

        /// <summary>The sprites</summary>
        [NotNull]
        private List<Sprite> sprites;

        private List<RectangleShape> collisions;

        /// <summary>Initializes a new instance of the <see cref="Render" /> class.</summary>
        /// <param name="config">The configuration.</param>
        [JsonConstructor]
        public Render([NotNull] Config config)
        {
            this.config = config;
            videoMode = new VideoMode(512, 320);
            sprites = new List<Sprite>();
            collisions = new List<RectangleShape>();

            OnCreate += Render_OnCreate;
            OnStart += Render_OnStart;
            OnUpdate += Render_OnUpdate;
            OnDestroy += Render_OnDestroy;

            current = this;
        }

        /// <summary>Finalizes an instance of the <see cref="Render" /> class.</summary>
        ~Render() => OnDestroy.Invoke(this, true);

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnCreate;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnStart;

        /// <summary>Occurs when [on update].</summary>
        public event EventHandler<bool> OnUpdate;

        /// <summary>Occurs when [change].</summary>
        public event EventHandler<bool> OnDestroy;

        /// <summary>Gets or sets the sprites.</summary>
        /// <value>The sprites.</value>
        public List<Sprite> Sprites { get => sprites; set => sprites = value; }

        /// <summary>Gets or sets the current.</summary>
        /// <value>The current.</value>
        public static Render Current { get => current; set => current = value; }

        /// <summary>Gets or sets the render texture.</summary>
        /// <value>The render texture.</value>
        public RenderTexture RenderTexture { get => renderTexture; set => renderTexture = value; }

        /// <summary>Gets or sets the render window.</summary>
        /// <value>The render window.</value>
        public RenderWindow RenderWindow { get => renderWindow; set => renderWindow = value; }

        /// <summary>Gets or sets the collisions.</summary>
        /// <value>The collisions.</value>
        public List<RectangleShape> Collisions { get => collisions; set => collisions = value; }

        /// <summary>Frames the bytes.</summary>
        /// <returns>Return none</returns>
        public byte[] FrameBytes()
        {
            if (renderTexture is null) 
            {
                renderTexture = new RenderTexture(512, 512);
            }

            renderTexture.Clear();

            if (sprites.Count > 0)
            {
                sprites = sprites.OrderBy(o => o.Depth).ToList();
                foreach (Sprite sprite in sprites)
                {
                    renderTexture.Draw(sprite.GetDraw());
                }
            }

            if (collisions.Count > 0)
            {
                foreach (RectangleShape rectangle in collisions)
                {
                    renderTexture.Draw(rectangle);
                }
            }

            renderTexture.Display();


            frame = renderTexture.Texture.CopyToImage();
            return frame.Pixels;
        }

        /// <summary>Adds the sprite.</summary>
        /// <param name="sprite">The sprite.</param>
        internal void AddSprite(Sprite sprite) 
        {
            sprites.Add(sprite);
        }

        internal void AddCollision(RectangleShape rectangle)
        {
            if (!collisions.Contains(rectangle))
            {
                collisions.Add(rectangle);
            }
        }

        /// <summary>Deletes the sprite.</summary>
        /// <param name="sprite">The sprite.</param>
        internal void DeleteSprite(Sprite sprite)
        {
            if (sprites.Contains(sprite))
            {
                sprites.Remove(sprite);
            }
        }

        internal bool Awake()
        {
            return Task.Run(() =>
            {
            }).IsCompletedSuccessfully;
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        internal bool Start()
        {
            return Task.Run(() =>
            {

            }).IsCompleted;
        }

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        internal bool Update()
        {
            if (renderWindow is null) 
            {
                renderWindow = new RenderWindow(videoMode, config.Name);
                renderWindow.Closed += RenderWindow_Closed;
            }

            renderWindow.DispatchEvents();
            renderWindow.Clear();

            if (sprites.Count > 0)
            {
                sprites = sprites.OrderBy(o => o.Depth).ToList();
                foreach (Sprite sprite in sprites)
                {
                    renderWindow.Draw(sprite.GetDraw());
                }
            }

            if (collisions.Count > 0)
            {
                foreach (RectangleShape rectangle in collisions)
                {
                    renderWindow.Draw(rectangle);
                }
            }

            renderWindow.Display();

            OnUpdate.Invoke(this, true);

            return true;
        }

        /// <summary>Exits this instance.</summary>
        internal void Exit()
        {
            if (renderWindow != null)
            {
                if (renderWindow.IsOpen)
                {
                    renderWindow.Clear();
                    renderWindow.Close();
                    renderWindow.Dispose();
                }
            }
        }

        internal void Stop()
        {

        }

        /// <summary>Handles the Closed event of the RenderWindow control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RenderWindow_Closed(object sender, EventArgs e)
        {
            Exit();
            Environment.Exit(0);
        }


        #region DefineEvents

        /// <summary>Renders the on create.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Render_OnCreate(object sender, bool e) => Logger.Info();

        /// <summary>Renders the on start.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Render_OnStart(object sender, bool e) => Logger.Info();

        /// <summary>Renders the on update.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Render_OnUpdate(object sender, bool e) => Logger.Info();

        /// <summary>Renders the on destroy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Render_OnDestroy(object sender, bool e) => Logger.Info();

        #endregion
    }
}