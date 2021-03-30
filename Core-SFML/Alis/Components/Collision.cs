//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Collision.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using global::SFML.Graphics;
    using global::SFML.System;
    using Newtonsoft.Json;
    using System.Numerics;

    /// <summary>Define a component</summary>
    public class Collision : Component
    {
        private bool isDefault;
        
        private Transform transform;

        private RectangleShape rectangle;

        private Vector2 border;

        private bool isTrigger;

        private bool update = true;

        public Vector2 Border
        {
            get => border; 
            set
            {
                update = false;
                border = value;
               /* if (Render.Current.Collisions.Contains(rectangle))
                {
                    Render.Current.Collisions[Render.Current.Collisions.IndexOf(rectangle)].Size = new Vector2f(value.X, value.Y);
                }
                else 
                {
                    rectangle.Size = new Vector2f(value.X, value.Y);
                    Render.Current.Collisions.Add(rectangle);
                }

                update = true;*/
            }
        }


        public bool IsTrigger { get => isTrigger; set => isTrigger = value; }

        /// <summary>Initializes a new instance of the <see cref="Collision" /> class.</summary>
        /// <param name="border">The border.</param>
        /// <param name="isTrigger">if set to <c>true</c> [is trigger].</param>
        [JsonConstructor]
        public Collision(Vector2 border, bool isTrigger)
        {
            this.border = border;
            this.isTrigger = isTrigger;

            rectangle = new RectangleShape(new Vector2f(border.X, border.Y));

            rectangle.FillColor = Color.Transparent;
            rectangle.OutlineColor = Color.Green;
            rectangle.OutlineThickness = 1f;
        }

        /// <summary>Initializes a new instance of the <see cref="Collision" /> class.</summary>
        public Collision()
        {
            border = new Vector2(1, 1);
            rectangle = new RectangleShape(new Vector2f(border.X, border.Y));

            rectangle.FillColor = Color.Transparent;
            rectangle.OutlineColor = Color.Green;
            rectangle.OutlineThickness = 1f;
            isTrigger = false;
        }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            transform = GetGameObject().Transform;

            var texture = GetGameObject().GetComponent<Sprite>().GetDraw().Texture;
            border = new Vector2(texture.Size.X, texture.Size.Y);
            rectangle = new RectangleShape(new Vector2f(border.X * transform.Size.X, border.Y * transform.Size.Y));

            rectangle.FillColor = Color.Transparent;
            rectangle.OutlineColor = Color.Green;
            rectangle.OutlineThickness = 1f;

            rectangle.Position = new Vector2f(transform.Position.X, transform.Position.Y);

            //Render.Current.AddCollision(rectangle);
        }

        public override int Priority()
        {
            return 1;
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            /*if (rectangle != null && update)
            {
                if (!Render.Current.Collisions.Contains(rectangle)) 
                {
                    Render.Current.AddCollision(rectangle);
                }

                rectangle.Position = new Vector2f(GetGameObject().Transform.Position.X, GetGameObject().Transform.Position.Y);
                foreach (RectangleShape rectangleShape in Render.Current.Collisions)
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
                                    this.GetGameObject().Transform.CanGoUp = false;
                                }

                                if (rectangleShape.GetGlobalBounds().Contains(midleDown.X, midleDown.Y))
                                {
                                    this.GetGameObject().Transform.CanGoDown = false;
                                }

                                if (rectangleShape.GetGlobalBounds().Contains(midleLeft.X, midleLeft.Y))
                                {
                                    this.GetGameObject().Transform.CanGoLeft = false;
                                }

                                if (rectangleShape.GetGlobalBounds().Contains(midleRight.X, midleRight.Y))
                                {
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
            }*/
        }
    }
}