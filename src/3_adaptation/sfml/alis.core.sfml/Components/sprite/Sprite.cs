using Alis.Core.Entities;
using Alis.Core.Sfml.Managers;
using SFML.Graphics;
using SFML.System;
using Transform = Alis.Core.Entities.Transform;

namespace Alis.Core.Sfml.Components
{
    /// <summary>
    /// The sprite class
    /// </summary>
    /// <seealso cref="Component"/>
    public class Sprite : Component
    {
        /// <summary>
        /// The sprite
        /// </summary>
        private readonly SFML.Graphics.Sprite sprite;
        /// <summary>
        /// The texture path
        /// </summary>
        private string texturePath;

        /// <summary>
        /// The transform
        /// </summary>
        private Transform Transform;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sprite"/> class
        /// </summary>
        /// <param name="texturePath">The texture path</param>
        public Sprite(string texturePath)
        {
            this.texturePath = texturePath;

            sprite = new SFML.Graphics.Sprite(new Texture(texturePath));
            RenderManager.Attach(this);
        }

        /// <summary>
        /// Gets the value of the drawable
        /// </summary>
        public Drawable Drawable => sprite;

        /// <summary>
        /// Gets or sets the value of the depth
        /// </summary>
        public int Depth { get; set; } = 0;

        /// <summary>
        /// Starts this instance
        /// </summary>
        public override void Start()
        {
            Transform = GameObject.Transform;
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public override void Update()
        {
            sprite.Position = new Vector2f(Transform.Position.X, Transform.Position.Y);
            sprite.Rotation = Transform.Rotation.Y;
            sprite.Scale = new Vector2f(Transform.Scale.X, Transform.Scale.Y);
        }
    }
}