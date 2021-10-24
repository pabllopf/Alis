using System;

namespace Alis.Core.Sfml
{
    public class Sprite : Component
    {
        private string texturePath;

        private SFML.Graphics.Sprite sprite;

        private int depth = 0;

        public Sprite(string texturePath) 
        {
            this.texturePath = texturePath;

            sprite = new SFML.Graphics.Sprite(new SFML.Graphics.Texture(texturePath));
            System.Console.WriteLine($"Print component {texturePath}");
            RenderManager.Attach(this);
        }

        public override void Start()
        {
            Console.WriteLine("name object=" + this.GameObject.Name.Value);
        }

        public override void Update()
        {
            sprite.Position = new SFML.System.Vector2f(Transform.Position.X, Transform.Position.Y);
            sprite.Rotation = Transform.Rotation.Y;
            sprite.Scale = new SFML.System.Vector2f(Transform.Scale.X, Transform.Scale.Y);
        }

        public SFML.Graphics.Drawable Drawable => sprite;

        public int Depth { get => depth; set => depth = value; }
    }
}