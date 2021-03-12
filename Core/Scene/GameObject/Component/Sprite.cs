//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Camera.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>Define a component</summary>
    public class Sprite : Component
    {
        /// <summary>The depth</summary>
        [NotNull]
        private int depth;

        private SFML.Graphics.Sprite sprite;

        /// <summary>Initializes a new instance of the <see cref="Sprite" /> class.</summary>
        public Sprite()
        {
            this.depth = 0;
            sprite = new SFML.Graphics.Sprite(new SFML.Graphics.Texture("C:/Users/wwwam/Documents/Repositorios/Alis/Example/bin/Windows/netcoreapp3.1/Assets/tile000.png"));
        }

        /// <summary>Initializes a new instance of the <see cref="Camera" /> class.</summary>
        public Sprite([NotNull] int depth)
        {
            this.depth = depth;
            sprite = new SFML.Graphics.Sprite(new SFML.Graphics.CircleShape(50F).Texture);
        }

        /// <summary>Initializes a new instance of the <see cref="Sprite" /> class.</summary>
        /// <param name="image">The image.</param>
        /// <param name="depth">The depth.</param>
        public Sprite([NotNull] string image, [NotNull] int depth)
        {
            sprite = new SFML.Graphics.Sprite(new SFML.Graphics.Texture(image));
            this.depth = depth;
        }

        /// <summary>Gets or sets the depth.</summary>
        /// <value>The depth.</value>
        [NotNull]
        public int Depth { get => depth; set => depth = value; }

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
        }

        internal SFML.Graphics.Drawable GetDraw()
        {
            return sprite;
        }
    }
}