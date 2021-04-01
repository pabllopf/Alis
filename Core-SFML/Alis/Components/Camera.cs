//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Camera.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core.SFML
{
    using System.Numerics;
    using Newtonsoft.Json;
    using global::SFML.Graphics;
    using global::SFML.System;
    
    /// <summary>Define a component</summary>
    public class Camera : Component
    {
        /// <summary>The transform</summary>
        private Core.Transform transform;

        /// <summary>The view</summary>
        private View view;

        /// <summary>The center</summary>
        private Vector2 center;

        /// <summary>The size</summary>
        private Vector2 size;

        /// <summary>
        /// Initializes a new instance of the <see cref="Camera"/> class.
        /// </summary>
        /// <param name="center">The center.</param>
        /// <param name="size">The size.</param>
        [JsonConstructor]
        public Camera(Vector2 center, Vector2 size)
        {
            this.center =center;
            this.size = size;
            view = new View(new Vector2f(this.center.X, this.center.Y), new Vector2f(this.size.X, this.size.Y));

            transform = new Core.Transform();
        }

        /// <summary>Initializes a new instance of the <see cref="Camera" /> class.</summary>
        /// <param name="size">resolution of camera.</param>
        public Camera(Vector2 size)
        {
            center = new Vector2(0f, 0f);
            this.size = size;
            view = new View(new Vector2f(this.center.X, this.center.Y), new Vector2f(this.size.X, this.size.Y));

            transform = new Core.Transform();
        }

        [JsonProperty("_Size")]
        public Vector2 Size { get => size; set => size = value; }

        [JsonProperty("_Center")]
        public Vector2 Center { get => center; set => center = value; }


        /// <summary>Start this instance.</summary>
        public override void Start()
        {
            transform = GetGameObject().Transform;
        }

        /// <summary>Update this instance.</summary>
        /// TODO Correct the camera to fix the movement of sprites. (probaly is the transform).
        public override void Update()
        {
            if (RenderSFML.CurrentRenderSFML != null)
            {
                if (RenderSFML.CurrentRenderSFML.RenderWindow != null)
                {
                    if (!RenderSFML.CurrentRenderSFML.RenderWindow.GetView().Equals(view))
                    {
                        RenderSFML.CurrentRenderSFML.RenderWindow.SetView(view);
                    }

                    view.Center = new Vector2f(transform.Position.X, transform.Position.Y);
                }

                if (RenderSFML.CurrentRenderSFML.RenderTexture != null)
                {
                    if (!RenderSFML.CurrentRenderSFML.RenderTexture.GetView().Equals(view))
                    {
                        RenderSFML.CurrentRenderSFML.RenderTexture.SetView(view);
                    }

                    view.Center = new Vector2f(transform.Position.X, transform.Position.Y);
                }
            }
        }

        /// <summary>this instance.</summary>
        /// <returns>Return order of process.</returns>
        public override int Priority() => 6;
    }
}