namespace Alis.Core.SFML
{
    using global::SFML.Graphics;
    using global::SFML.Window;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>Implement the render. </summary>
    public class RenderSFML : Render
    {
        /// <summary>The render SFML</summary>
        private static RenderSFML renderSFML;

        /// <summary>The configuration</summary>
        [NotNull]
        private Config config;

        /// <summary>The render window</summary>
        [NotNull]
        private RenderWindow renderWindow;

        /// <summary>The render texture</summary>
        [NotNull]
        private RenderTexture renderTexture;

        /// <summary>The frame</summary>
        [NotNull]
        private Image frame;

        /// <summary>The video mode</summary>
        [NotNull]
        private VideoMode videoMode;

        /// <summary>The sprites</summary>
        [NotNull]
        private static List<Sprite> sprites;

        /// <summary>The collisions</summary>
        [NotNull]
        private List<RectangleShape> collisions;

        /// <summary>Gets or sets the collisions.</summary>
        /// <value>The collisions.</value>
        public List<RectangleShape> Collisions { get => collisions; set => collisions = value; }
       
        /// <summary>Gets the render window.</summary>
        /// <value>The render window.</value>
        public RenderWindow RenderWindow { get => renderWindow;  }

        /// <summary>Gets the render texture.</summary>
        /// <value>The render texture.</value>
        public RenderTexture RenderTexture { get => renderTexture; }
        
        /// <summary>Gets or sets the render SFML.</summary>
        /// <value>The render SFML.</value>
        public static RenderSFML CurrentRenderSFML { get => renderSFML; set => renderSFML = value; }

        /// <summary>Initializes a new instance of the <see cref="RenderSFML" /> class.</summary>
        /// <param name="config">The configuration.</param>
        public RenderSFML([NotNull] Config config) : base(config)
        {
            this.config = config;

            videoMode = new VideoMode(512, 320);
            sprites = new List<Sprite>();
            collisions = new List<RectangleShape>();

            Current = this;
            renderSFML = this;
        }

        /// <summary>Awakes this instance.</summary>
        /// <returns>Return none</returns>
        public override void Awake()
        {
        }

        /// <summary>Starts this instance.</summary>
        /// <returns>Return none</returns>
        public override void Start()
        {
        }

        /// <summary>Fixed the update.</summary>
        public override void FixedUpdate()
        {
        }

        /// <summary>Updates this instance.</summary>
        /// <returns>Return none</returns>
        public override void Update()
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
                foreach (Sprite sprite in sprites)
                {
                    renderWindow.Draw(sprite.GetDraw());
                }
            }

            renderWindow.Display();
        }

        /// <summary>Stops this instance.</summary>
        /// <returns>Return none</returns>
        public override void Stop()
        {
        }

        /// <summary>Exits this instance.</summary>
        /// <returns>Return none</returns>
        public override void Exit()
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

        /// <summary>Frames the bytes.</summary>
        /// <returns>Return the frame in bytes.</returns>
        public override byte[] FrameBytes()
        {
            if (renderTexture is null)
            {
                renderTexture = new RenderTexture(512, 512);
            }

            renderTexture.Clear();

            if (sprites.Count > 0)
            {
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

        /// <summary>Adds the draw.</summary>
        /// <param name="draw">The draw.</param>
        public override void AddDraw([NotNull] Component draw)
        {
            if(sprites != null) 
            {
                sprites.Add((Sprite)draw);
                sprites = sprites.OrderBy(o => o.Depth).ToList();
            }          
        }

        /// <summary>Removes the specified draw.</summary>
        /// <param name="draw">The draw.</param>
        public override void Remove(Component draw)
        {
            if (sprites != null)
            {
                sprites.Remove(sprites.Find(i => i.GetType().Equals(draw)));
                sprites = sprites.OrderBy(o => o.Depth).ToList();
            }
        }

        /// <summary>Gets the draws.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Return a list</returns>
        public override List<T> GetDraws<T>() => new((IEnumerable<T>)sprites);

        /// <summary>Handles the Closed event of the RenderWindow control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void RenderWindow_Closed(object sender, EventArgs e)
        {
            Exit();
            Environment.Exit(0);
        }
    }
}