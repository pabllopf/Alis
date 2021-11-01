using Alis.Core.Entities;
using Alis.Core.Sfml.Managers;
using SFML.Graphics;
using SFML.System;
using Transform = Alis.Core.Entities.Transform;

namespace Alis.Core.Sfml.Components
{
    public class Sprite : Component
    {
        private readonly SFML.Graphics.Sprite sprite;
        private string texturePath;

        private Transform Transform;

        public Sprite(string texturePath)
        {
            this.texturePath = texturePath;

            sprite = new SFML.Graphics.Sprite(new Texture(texturePath));
            RenderManager.Attach(this);
        }

        public Drawable Drawable => sprite;

        public int Depth { get; set; } = 0;

        public override void Start()
        {
            Transform = GameObject.Transform;
        }

        public override void Update()
        {
            sprite.Position = new Vector2f(Transform.Position.X, Transform.Position.Y);
            sprite.Rotation = Transform.Rotation.Y;
            sprite.Scale = new Vector2f(Transform.Scale.X, Transform.Scale.Y);
        }
    }
}