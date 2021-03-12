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
            rectangle.Position = new Vector2f(transform.Position.X, transform.Position.Y);
            foreach(RectangleShape rectangleShape in Render.Current.Collisions)
            {
                if (!rectangleShape.Equals(rectangle)) 
                {
                    if (rectangleShape.GetGlobalBounds().Intersects(rectangle.GetGlobalBounds()))
                    {
                        Render.Current.Collisions[Render.Current.Collisions.IndexOf(rectangle)].OutlineColor = Color.Red;
                        GetGameObject().Components.ForEach(i => i.OnCollionStay(this));

                        if (!isTrigger) 
                        {
                            

                            //Console.WriteLine("leftTop: " + leftTop.X + ":" + leftTop.Y );
                            //Console.WriteLine("rightTop: " + rightTop.X + ":" + rightTop.Y);
                            //Console.WriteLine("midleTop: " + midleTop.X + ":" + midleTop.Y);

                            if (!isTrigger) 
                            {
                                var leftTop = new Vector2f(rectangle.GetGlobalBounds().Left, rectangle.GetGlobalBounds().Top);
                                var rightTop = new Vector2f(rectangle.GetGlobalBounds().Left + rectangle.GetGlobalBounds().Width, rectangle.GetGlobalBounds().Top);
                                var downLeft = new Vector2f(rectangle.GetGlobalBounds().Left, rectangle.GetGlobalBounds().Top + rectangle.GetGlobalBounds().Height);
                                var downRight = new Vector2f(rectangle.GetGlobalBounds().Left + rectangle.GetGlobalBounds().Width, rectangle.GetGlobalBounds().Top + rectangle.GetGlobalBounds().Height);

                                var midleTop = new Vector2f(((rightTop.X - leftTop.X) / 2) + leftTop.X, leftTop.Y);

                                if (rectangleShape.GetGlobalBounds().Contains(midleTop.X, midleTop.Y)) 
                                {
                                    Console.WriteLine("Chocando la parte de arriba de " + this.GetGameObject().Name);
                                    this.GetGameObject().Transform.GoUp = false;
                                }

                                var midleDown = new Vector2f(((downRight.X - downLeft.X) / 2) + downLeft.X, downLeft.Y);

                                if (rectangleShape.GetGlobalBounds().Contains(midleDown.X, midleDown.Y))
                                {
                                    Console.WriteLine("Chocando la parte de abajo de " + this.GetGameObject().Name);
                                    this.GetGameObject().Transform.GoDown = false;
                                }

                                var midleLeft = new Vector2f(downLeft.X, ((downLeft.Y - leftTop.Y) / 2) + leftTop.Y);

                                if (rectangleShape.GetGlobalBounds().Contains(midleLeft.X, midleLeft.Y))
                                {
                                    Console.WriteLine("Chocando la parte izquierda de " + this.GetGameObject().Name);
                                    this.GetGameObject().Transform.GoLeft = false;
                                }

                                var midleRight = new Vector2f(downRight.X, ((downRight.Y - rightTop.Y) / 2) + rightTop.Y);

                                if (rectangleShape.GetGlobalBounds().Contains(midleRight.X, midleRight.Y))
                                {
                                    Console.WriteLine("Chocando la parte derecha de " + this.GetGameObject().Name);
                                    this.GetGameObject().Transform.GoRight = false;
                                }

                            }


                            Console.WriteLine("\n \n");

                        }

                    }
                    else 
                    {
                        this.GetGameObject().Transform.GoUp = true;
                        this.GetGameObject().Transform.GoDown = true;
                        this.GetGameObject().Transform.GoLeft = true;
                        this.GetGameObject().Transform.GoRight = true;
                        Render.Current.Collisions[Render.Current.Collisions.IndexOf(rectangle)].OutlineColor = Color.Green;
                    }
                }
            }
        }
    }
}