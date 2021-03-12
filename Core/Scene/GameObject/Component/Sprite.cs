//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Sprite.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>Define a component</summary>
    public class Sprite : Component
    {
        /// <summary>The image</summary>
        [NotNull]
        private string image;

        /// <summary>The depth</summary>
        [NotNull]
        private int depth;

        /// <summary>The sprite</summary>
        [NotNull]
        private SFML.Graphics.Sprite sprite;

        /// <summary>Initializes a new instance of the <see cref="Sprite" /> class.</summary>
        public Sprite()
        {
            depth = 0;
            sprite = new SFML.Graphics.Sprite(new SFML.Graphics.Texture("C:/Users/wwwam/Documents/Repositorios/Alis/Example/bin/Windows/netcoreapp3.1/Assets/tile000.png"));
            image = string.Empty;
        }

        /// <summary>Initializes a new instance of the <see cref="Sprite" /> class.</summary>
        /// <param name="depth">The depth.</param>
        public Sprite([NotNull] int depth)
        {
            this.depth = depth;
            sprite = new SFML.Graphics.Sprite(new SFML.Graphics.CircleShape(50F).Texture);
            image = string.Empty;
        }

        /// <summary>Initializes a new instance of the <see cref="Sprite" /> class.</summary>
        /// <param name="image">The image.</param>
        /// <param name="depth">The depth.</param>
        public Sprite([NotNull] string image, [NotNull] int depth)
        {
            this.depth = depth;
            this.image = image;
            sprite = new SFML.Graphics.Sprite(new SFML.Graphics.Texture(image));

            OnDraw += Sprite_OnDraw;
        }

        /// <summary>Occurs when [on draw].</summary>
        public event EventHandler<bool> OnDraw;

        /// <summary>Gets or sets the depth.</summary>
        /// <value>The depth.</value>
        [NotNull]
        public int Depth { get => depth; set => depth = value; }
        
        /// <summary>Gets or sets the image.</summary>
        /// <value>The image.</value>
        [NotNull]
        public string Image { get => image; set => image = value; }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            var pos = GetGameObject().Transform.Position;
            sprite.Position = new SFML.System.Vector2f(pos.X, pos.Y);

            var rot = GetGameObject().Transform.Rotation;
            sprite.Rotation = rot.Y;

            var size = GetGameObject().Transform.Size;
            sprite.Scale = new SFML.System.Vector2f(size.X, size.Y);

            Render.Current.AddSprite(this);
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            if (!Render.Current.Sprites.Contains(this))
            {
                Render.Current.AddSprite(this);
            }

            var pos = GetGameObject().Transform.Position;
            sprite.Position = new SFML.System.Vector2f(pos.X, pos.Y);

            var rot = GetGameObject().Transform.Rotation;
            sprite.Rotation = rot.Y;

            var size = GetGameObject().Transform.Size;
            sprite.Scale = new SFML.System.Vector2f(size.X, size.Y);
        }

        /// <summary>Gets the draw.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal SFML.Graphics.Sprite GetDraw()
        {
            return sprite;
        }

        #region DefineEvents

        /// <summary>Sprites the on draw.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Sprite_OnDraw([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}