using System.Collections.Generic;
using System.Linq;

namespace Alis.Core.Sfml
{
    /// <summary>Implement the render system of SFML library.</summary>
    public class RenderManager : RenderSystem
    {
        private static List<Sprite> sprites;

        /// <summary>The render window</summary>
        private SFML.Graphics.RenderWindow? renderWindow;

        static RenderManager() => sprites = new List<Sprite>();

        /// <summary>Initializes a new instance of the <see cref="RenderManager" /> class.</summary>
        /// <param name="configuration">The configuration.</param>
        public RenderManager(Configuration configuration) : base(configuration)
        {
            renderWindow = new SFML.Graphics.RenderWindow(
                new SFML.Window.VideoMode(512, 512),
                $"{Configuration.General.Name} | {Configuration.General.Author}",
                SFML.Window.Styles.Default);

            renderWindow.Closed += RenderWindow_Closed;
        }

        /// <summary>Awakes this instance.</summary>
        public override void Awake()
        {
        }

        /// <summary>Befores the update.</summary>
        public override void BeforeUpdate() => renderWindow?.Clear();

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            for (int index = 0; index < sprites.Count; index++)
            {
                renderWindow?.Draw(sprites[index].Drawable);
            }
        }

        /// <summary>Afters the update.</summary>
        public override void AfterUpdate() => renderWindow?.Display();

        /// <summary>Dispatches the events.</summary>
        public override void DispatchEvents() => renderWindow?.DispatchEvents();

        /// <summary>Renders the window closed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void RenderWindow_Closed(object? sender, System.EventArgs e) => renderWindow?.Close();

        /// <summary>Attaches the specified sprite.</summary>
        /// <param name="sprite">The sprite.</param>
        public static void Attach(Sprite sprite)
        {
            sprites.Add(sprite);
            sprites.OrderBy(o => o.Depth);
        }
    }
}