//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Camera.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Newtonsoft.Json;
    using SFML.Graphics;
    using SFML.System;

    /// <summary>Define a camera</summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Camera : IComponent
    {
        /// <summary>The icon</summary>
        private readonly string icon = "\uf1fc";

        private View view;

        private Vector2f center;

        private Vector2f size;

        [JsonConstructor]
        public Camera(Vector2f center, Vector2f size)
        {
            view = new View(center, size);
        }

        [JsonProperty]
        public Vector2f Center { get => center; set => center = value; }

        [JsonProperty]
        public Vector2f Size { get => size; set => size = value; }

        public string Icon => icon;

        public void Start(GameObject gameObject)
        {
            Debug.Log("Define a camera on " + gameObject.Name + " gameobject");
        }

        public void Update(GameObject gameObject)
        {
            
            if (Render.Current != null)
            {

                if (Render.Current.RenderWindow != null)
                {
                    if (!Render.Current.RenderWindow.GetView().Equals(view))
                    {
                        Render.Current.RenderWindow.SetView(view);
                    }
                    else
                    {
                        var posObj = new Vector2f(gameObject.Transform.Position.X, gameObject.Transform.Position.Y);
                        var posCamera = view.Center;
                        view.Center = posObj;
                    }
                }

                if (Render.Current.RenderTexture != null)
                {
                    if (!Render.Current.RenderTexture.GetView().Equals(view))
                    {
                        Render.Current.RenderTexture.SetView(view);
                    }
                    else
                    {
                        var posObj = new Vector2f(gameObject.Transform.Position.X, gameObject.Transform.Position.Y);
                        var posCamera = view.Center;
                        view.Center = posObj;
                    }
                }
            }

        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}