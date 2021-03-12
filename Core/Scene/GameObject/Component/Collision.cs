//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Collision.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using SFML.Graphics;
    using SFML.System;
    using System;

    /// <summary>Define a component</summary>
    public class Collision : Component
    {
        private bool isDefault;
        
        private Transform transform;

        private RectangleShape rectangle;

        private Vector2f border;




        /// <summary>Initializes a new instance of the <see cref="Collision" /> class.</summary>
        public Collision()
        {
            Logger.Info();
            border = new Vector2f(10, 10);
            rectangle = new RectangleShape(border);
            isDefault = true;
        }

        public Collision(float x, float y) 
        {
            border = new Vector2f(x, y);
            rectangle = new RectangleShape(border);
        }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            transform = this.GetGameObject().Transform;

            if (isDefault) 
            {
                rectangle = new RectangleShape(new Vector2f(GetGameObject().GetComponent<Sprite>().GetDraw().TextureRect.Width, GetGameObject().GetComponent<Sprite>().GetDraw().TextureRect.Height)); ;
            }

            rectangle.FillColor = Color.Transparent;
            rectangle.OutlineColor = Color.Green;
            rectangle.OutlineThickness = 1f;
            Render.Current.AddCollision(rectangle);
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            rectangle.Position = new Vector2f(transform.Position.X, transform.Position.Y);
            foreach(RectangleShape rectangleShape in Render.Current.Collisions)
            {
                if (!rectangleShape.Equals(rectangle)) 
                {
                    if (rectangleShape.GetGlobalBounds().Intersects(rectangle.GetGlobalBounds()))
                    {
                        Console.WriteLine("Collision ON: " + this.GetGameObject().Name);
                        Render.Current.Collisions[Render.Current.Collisions.IndexOf(rectangle)].OutlineColor = Color.Red;
                    }
                    else 
                    {
                        Render.Current.Collisions[Render.Current.Collisions.IndexOf(rectangle)].OutlineColor = Color.Green; 
                    }
                }
            }
        }
    }
}