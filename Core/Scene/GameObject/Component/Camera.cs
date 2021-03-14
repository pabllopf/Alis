//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Camera.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Newtonsoft.Json;
    using SFML.Graphics;
    using SFML.System;

    /// <summary>Define a component</summary>
    public class Camera : Component
    {
        private Transform transform;

        private View view;

        private Vector2f center;

        private Vector2f size;

        [JsonConstructor]
        public Camera(Vector2f center, Vector2f size)
        {
            this.center = center;
            this.size = size;
            view = new View(center, size);
        }

        public Vector2f Center { get => center; set => center = value; }

        public Vector2f Size { get => size; set => size = value; }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            transform = this.GetGameObject().Transform;
        }

        public override int Priority()
        {
            return 6;
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            if (Render.Current != null)
            {
                if (Render.Current.RenderWindow != null)
                {
                    if (!Render.Current.RenderWindow.GetView().Equals(view))
                    {
                        Render.Current.RenderWindow.SetView(view);
                    }

                    view.Center = new Vector2f(transform.Position.X, transform.Position.Y);
                }

                if (Render.Current.RenderTexture != null)
                {
                    if (!Render.Current.RenderTexture.GetView().Equals(view))
                    {
                        Render.Current.RenderTexture.SetView(view);
                    }

                    //view.Center = new Vector2f(transform.Position.X, transform.Position.Y);
                }
            }
        }
    }
}