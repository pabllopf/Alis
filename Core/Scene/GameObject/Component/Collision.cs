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

        private bool isTrigger;




        /// <summary>Initializes a new instance of the <see cref="Collision" /> class.</summary>
        public Collision()
        {
            Logger.Info();
            border = new Vector2f(10, 10);
            rectangle = new RectangleShape(border);
            isDefault = true;
            isTrigger = false;
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
            if (!Render.Current.Collisions.Contains(rectangle)) 
            {
                Render.Current.AddCollision(rectangle);
            }
            
            rectangle.Position = new Vector2f(transform.Position.X, transform.Position.Y);
            foreach(RectangleShape rectangleShape in Render.Current.Collisions)
            {
                if (!rectangleShape.Equals(rectangle)) 
                {
                    var leftTop = new Vector2f(rectangle.GetGlobalBounds().Left, rectangle.GetGlobalBounds().Top);
                    var rightTop = new Vector2f(rectangle.GetGlobalBounds().Left + rectangle.GetGlobalBounds().Width, rectangle.GetGlobalBounds().Top);
                    var downLeft = new Vector2f(rectangle.GetGlobalBounds().Left, rectangle.GetGlobalBounds().Top + rectangle.GetGlobalBounds().Height);
                    var downRight = new Vector2f(rectangle.GetGlobalBounds().Left + rectangle.GetGlobalBounds().Width, rectangle.GetGlobalBounds().Top + rectangle.GetGlobalBounds().Height);

                    var midleTop = new Vector2f(((rightTop.X - leftTop.X) / 2) + leftTop.X, leftTop.Y);
                    var midleDown = new Vector2f(((downRight.X - downLeft.X) / 2) + downLeft.X, downLeft.Y);
                    var midleLeft = new Vector2f(downLeft.X, ((downLeft.Y - leftTop.Y) / 2) + leftTop.Y);
                    var midleRight = new Vector2f(downRight.X, ((downRight.Y - rightTop.Y) / 2) + rightTop.Y);


                    if (Render.Current.Collisions.Find(i => (i != rectangle) && i.GetGlobalBounds().Intersects(rectangle.GetGlobalBounds())) != null)
                    {
                        GetGameObject().Components.ForEach(i => i.OnCollionStay(this));

                        if (!isTrigger)
                        {
                            if (rectangleShape.GetGlobalBounds().Contains(midleTop.X, midleTop.Y))
                            {
                                Console.WriteLine("Chocando la parte de arriba de " + this.GetGameObject().Name);
                                this.GetGameObject().Transform.CanGoUp = false;
                            }

                            if (rectangleShape.GetGlobalBounds().Contains(midleDown.X, midleDown.Y))
                            {
                                Console.WriteLine("Chocando la parte de abajo de " + this.GetGameObject().Name);
                                this.GetGameObject().Transform.CanGoDown = false;
                            }

                            if (rectangleShape.GetGlobalBounds().Contains(midleLeft.X, midleLeft.Y))
                            {
                                Console.WriteLine("Chocando la parte izquierda de " + this.GetGameObject().Name);
                                this.GetGameObject().Transform.CanGoLeft = false;
                            }

                            if (rectangleShape.GetGlobalBounds().Contains(midleRight.X, midleRight.Y))
                            {
                                Console.WriteLine("Chocando la parte derecha de " + this.GetGameObject().Name);
                                this.GetGameObject().Transform.CanGoRight = false;
                            }
                        }
                    }
                    else 
                    {
                        if (!rectangleShape.GetGlobalBounds().Contains(midleTop.X, midleTop.Y))
                        {
                            this.GetGameObject().Transform.CanGoUp = true;
                        }

                        if (!rectangleShape.GetGlobalBounds().Contains(midleDown.X, midleDown.Y))
                        {
                            this.GetGameObject().Transform.CanGoDown = true;
                        }

                        if (!rectangleShape.GetGlobalBounds().Contains(midleLeft.X, midleLeft.Y))
                        {
                            this.GetGameObject().Transform.CanGoLeft = true;
                        }

                        if (!rectangleShape.GetGlobalBounds().Contains(midleRight.X, midleRight.Y))
                        {
                            this.GetGameObject().Transform.CanGoRight = true;
                        }
                    }
                }
            }
        }
    }
}