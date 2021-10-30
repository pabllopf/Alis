namespace Alis.Core.Sfml
{
    using Core.Systems;
    using Core.Settings;

    /// <summary>Implement the render system of SFML library.</summary>
    public class RenderManager : RenderSystem
    {
        /// <summary>The sprites</summary>
        private static global::System.Memory<Sprite> sprites;

        /// <summary>The render window</summary>
        private readonly SFML.Graphics.RenderWindow renderWindow;

        /// <summary>Initializes the <see cref="RenderManager" /> class.</summary>
        static RenderManager() => sprites = new global::System.Memory<Sprite>(new Sprite[1024]);

        /// <summary>Initializes a new instance of the <see cref="RenderManager" /> class.</summary>
        /// <param name="configuration">The configuration.</param>
        public RenderManager() : base()
        {
            /*renderWindow = new SFML.Graphics.RenderWindow(
                new SFML.Window.VideoMode(512, 512),
                $"{Configuration.General.Name} | {Configuration.General.Author}",
                SFML.Window.Styles.Default);
            */
            renderWindow.Closed += RenderWindow_Closed;
        }

        /// <summary>Befores the update.</summary>
        public override void BeforeUpdate() => renderWindow.Clear();

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            if (!sprites.IsEmpty) 
            {
                for (int index = 0; index < sprites.Span.Length; index++) 
                {
                    if (sprites.Span[index] is not null) 
                    {
                        renderWindow.Draw(sprites.Span[index].Drawable);
                    }
                }
            }
        }

        /// <summary>Afters the update.</summary>
        public override void AfterUpdate() => renderWindow.Display();

        /// <summary>Dispatches the events.</summary>
        public override void DispatchEvents() => renderWindow.DispatchEvents();

        /// <summary>Renders the window closed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="global::System.EventArgs" /> instance containing the event data.</param>
        private void RenderWindow_Closed(object? sender, global::System.EventArgs e) => renderWindow.Close();

        /// <summary>Attaches the specified sprite.</summary>
        /// <param name="sprite">The sprite.</param>
        public static void Attach(Sprite sprite)
        {
            if (!sprites.IsEmpty)
            {
                for (int index = 0; index < sprites.Span.Length; index++)
                {
                    if (sprites.Span[index] is null)
                    {
                        sprites.Span[index] = sprite;
                        return;
                    }
                }
            }
        }

        public static void UnAttach(Sprite sprite) 
        {
        }
    }
}