//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Collision.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core.SFML
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Numerics;
    using Alis.Tools;
    using Newtonsoft.Json;

    /// <summary>Define a component</summary>
    public class Collision : Component
    {
        private string icon = "\uf1b2";

        /// <summary>The is trigger</summary>
        [NotNull]
        private bool isTrigger;

        private Core.Transform transform;

        private System.Numerics.Vector2 border;

        private global::SFML.Graphics.RectangleShape rectangle;

        private System.Collections.Generic.List<Collision> collisions = new System.Collections.Generic.List<Collision>();

        private global::SFML.System.Vector2f leftTop;
        private global::SFML.System.Vector2f rightTop;
        private global::SFML.System.Vector2f downLeft;
        private global::SFML.System.Vector2f downRight;
        private global::SFML.System.Vector2f midleTop;
        private global::SFML.System.Vector2f midleDown;
        private global::SFML.System.Vector2f midleLeft;
        private global::SFML.System.Vector2f midleRight;


        /*
        /// <summary>Initializes a new instance of the <see cref="Collision" /> class.</summary>
        /// <param name="border">The border.</param>
        public Collision(System.Numerics.Vector2 border)
        {
            this.border = border;
            isTrigger = false;

            rectangle = new RectangleShape(new Vector2f(this.border.X, this.border.Y));

            rectangle.FillColor = Color.Transparent;
            rectangle.OutlineColor = Color.Green;
            rectangle.OutlineThickness = 1f;

            Logger.Info();
        }*/



        public override string GetIcon()
        {
            return icon;
        }
        public Collision()
        {
            this.border = new Vector2(1, 1);
            this.isTrigger = false;

            rectangle = new global::SFML.Graphics.RectangleShape(new global::SFML.System.Vector2f(this.border.X, this.border.Y));

            rectangle.FillColor = global::SFML.Graphics.Color.Transparent;
            rectangle.OutlineColor = global::SFML.Graphics.Color.Green;
            rectangle.OutlineThickness = 1f;

            Logger.Info();
        }

        /// <summary>Initializes a new instance of the <see cref="Collision" /> class.</summary>
        /// <param name="border">The border.</param>
        /// <param name="isTrigger">if set to <c>true</c> [is trigger].</param>
        [JsonConstructor]
        public Collision(Vector2 border, bool isTrigger)
        {
            this.border = border;
            this.isTrigger = isTrigger;

            rectangle = new global::SFML.Graphics.RectangleShape(new global::SFML.System.Vector2f(this.border.X, this.border.Y));

            rectangle.FillColor = global::SFML.Graphics.Color.Transparent;
            rectangle.OutlineColor = global::SFML.Graphics.Color.Green;
            rectangle.OutlineThickness = 1f;

            Logger.Info();
        }

        /// <summary>Gets or sets a value indicating whether this instance is trigger.</summary>
        /// <value>
        /// <c>true</c> if this instance is trigger; otherwise, <c>false</c>.</value>
        [NotNull]
        [JsonProperty("_IsTrigger")]
        public bool IsTrigger { get => isTrigger; set => isTrigger = value; }

        [NotNull]
        [JsonProperty("_Border")]
        public Vector2 Border
        {
            get => border; 
            set
            {
                border = value;

                if (border != null) 
                {
                    rectangle.Size = new global::SFML.System.Vector2f(this.border.X, this.border.Y);
                }
            }
        }

        public global::SFML.Graphics.RectangleShape Rectangle { get => rectangle; set => rectangle = value; }

        public override void Exit()
        {
            if (RenderSFML.CurrentRenderSFML != null)
            {
                if (RenderSFML.CurrentRenderSFML.Collisions.Contains(this))
                {
                    Logger.Log("DELETE collision");
                    RenderSFML.CurrentRenderSFML.Collisions.Remove(this);
                }
            }
        }

        /// <summary>Start this instance.</summary>
        public override void Start()
        {
            transform = GameObject.Transform;
            rectangle.Position = new global::SFML.System.Vector2f(transform.Position.X, transform.Position.Y);

            RenderSFML.CurrentRenderSFML.Collisions.Add(this);

            collisions = RenderSFML.CurrentRenderSFML.Collisions;
        }

        private bool onCollionEnter = false;

        /// <summary>Update this instance.</summary>
        public override void Update()
        {
            if (!RenderSFML.CurrentRenderSFML.Collisions.Contains(this)) 
            {
                transform = GameObject.Transform;
                rectangle.Position = new global::SFML.System.Vector2f(transform.Position.X, transform.Position.Y);

                RenderSFML.CurrentRenderSFML.Collisions.Add(this);
            }

            rectangle.Position = new global::SFML.System.Vector2f(transform.Position.X, transform.Position.Y);
            rectangle.Rotation = GameObject.Transform.Rotation.Y;

            if (!isTrigger)
            {
                for (int i = 0; i < collisions.ToList().Count; i++)
                {
                    if (!rectangle.Equals(collisions[i].rectangle))
                    {
                        if (collisions[i].isTrigger)
                        {
                            if (collisions.Find(i => (i.Rectangle != rectangle) && i.rectangle.GetGlobalBounds().Intersects(rectangle.GetGlobalBounds())) != null)
                            {
                                this.GameObject.Transform.CanGoUp = true;
                                this.GameObject.Transform.CanGoDown = true;
                                this.GameObject.Transform.CanGoLeft = true;
                                this.GameObject.Transform.CanGoRight = true;
                                GameObject.OnCollionStay(collisions[i]);
                                return;
                            }
                        }


                        leftTop = new global::SFML.System.Vector2f(rectangle.GetGlobalBounds().Left, rectangle.GetGlobalBounds().Top);
                        rightTop = new global::SFML.System.Vector2f(rectangle.GetGlobalBounds().Left + rectangle.GetGlobalBounds().Width, rectangle.GetGlobalBounds().Top);
                        downLeft = new global::SFML.System.Vector2f(rectangle.GetGlobalBounds().Left, rectangle.GetGlobalBounds().Top + rectangle.GetGlobalBounds().Height);
                        downRight = new global::SFML.System.Vector2f(rectangle.GetGlobalBounds().Left + rectangle.GetGlobalBounds().Width, rectangle.GetGlobalBounds().Top + rectangle.GetGlobalBounds().Height);

                        midleTop = new global::SFML.System.Vector2f(((rightTop.X - leftTop.X) / 2) + leftTop.X, leftTop.Y);
                        midleDown = new global::SFML.System.Vector2f(((downRight.X - downLeft.X) / 2) + downLeft.X, downLeft.Y);
                        midleLeft = new global::SFML.System.Vector2f(downLeft.X, ((downLeft.Y - leftTop.Y) / 2) + leftTop.Y);
                        midleRight = new global::SFML.System.Vector2f(downRight.X, ((downRight.Y - rightTop.Y) / 2) + rightTop.Y);

                        if (collisions.Find(i => (i.Rectangle != rectangle) && i.rectangle.GetGlobalBounds().Intersects(rectangle.GetGlobalBounds())) != null)
                        {
                            if (collisions[i].rectangle.GetGlobalBounds().Contains(midleTop.X, midleTop.Y))
                            {
                                this.GameObject.Transform.CanGoUp = false;
                            }

                            if (collisions[i].rectangle.GetGlobalBounds().Contains(midleDown.X, midleDown.Y))
                            {
                                this.GameObject.Transform.CanGoDown = false;
                            }

                            if (collisions[i].rectangle.GetGlobalBounds().Contains(midleLeft.X, midleLeft.Y))
                            {
                                this.GameObject.Transform.CanGoLeft = false;
                            }

                            if (collisions[i].rectangle.GetGlobalBounds().Contains(midleRight.X, midleRight.Y))
                            {
                                this.GameObject.Transform.CanGoRight = false;
                            }
                        }
                        else
                        {
                            if (!collisions[i].rectangle.GetGlobalBounds().Contains(midleTop.X, midleTop.Y))
                            {
                                this.GameObject.Transform.CanGoUp = true;
                            }

                            if (!collisions[i].rectangle.GetGlobalBounds().Contains(midleDown.X, midleDown.Y))
                            {
                                this.GameObject.Transform.CanGoDown = true;
                            }

                            if (!collisions[i].rectangle.GetGlobalBounds().Contains(midleLeft.X, midleLeft.Y))
                            {
                                this.GameObject.Transform.CanGoLeft = true;
                            }

                            if (!collisions[i].rectangle.GetGlobalBounds().Contains(midleRight.X, midleRight.Y))
                            {
                                this.GameObject.Transform.CanGoRight = true;
                            }
                        }

                        if ((!GameObject.Transform.CanGoRight || !GameObject.Transform.CanGoLeft || !GameObject.Transform.CanGoDown || !GameObject.Transform.CanGoUp) && !onCollionEnter)
                        {
                            onCollionEnter = true;
                            GameObject.OnCollionEnter(collisions[i]);
                            return;
                        }

                        if ((GameObject.Transform.CanGoRight && GameObject.Transform.CanGoLeft && GameObject.Transform.CanGoDown && GameObject.Transform.CanGoUp) && onCollionEnter)
                        {
                            onCollionEnter = false;
                            GameObject.OnCollionExit(collisions[i]);
                            return;
                        }
                    }
                }
            }
            else
            {

                for (int i = 0; i < collisions.ToList().Count; i++)
                {
                    if (!rectangle.Equals(collisions[i]))
                    {
                        if (collisions.Find(i => (i.rectangle != rectangle) && i.rectangle.GetGlobalBounds().Intersects(rectangle.GetGlobalBounds())) != null)
                        {
                            GameObject.OnCollionStay(this);
                        }
                    }
                }
            }
        }
    }
}
       