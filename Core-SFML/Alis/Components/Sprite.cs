//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Sprite.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core.SFML
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using Alis.Tools;
    using Newtonsoft.Json;
   
    /// <summary>Define a component</summary>
    public class Sprite : Component
    {
        /// <summary>The image</summary>
        [NotNull]
        private string image;

        /// <summary>The path image</summary>
        [AllowNull]
        private string pathImage;

        /// <summary>The depth</summary>
        [NotNull]
        private int depth;

        /// <summary>The sprite</summary>
        [AllowNull]
        [JsonIgnore]
        private global::SFML.Graphics.Sprite sprite;

        /// <summary>The transform</summary>
        [JsonIgnore]
        [AllowNull]
        private Transform transform;

        /// <summary>Initializes a new instance of the <see cref="Sprite" /> class.</summary>
        public Sprite()
        {
            this.image = string.Empty;
            depth = 0;

            Check();

            OnDraw += Sprite_OnDraw;
        }

        /// <summary>Initializes a new instance of the <see cref="Sprite" /> class.</summary>
        /// <param name="image">The image.</param>
        public Sprite([NotNull] string image)
        {
            this.image = image;
            depth = 0;

            Check();

            OnDraw += Sprite_OnDraw;
        }

        /// <summary>Initializes a new instance of the <see cref="Sprite" /> class.</summary>
        /// <param name="image">The image.</param>
        /// <param name="depth">The depth.</param>
        [JsonConstructor]
        public Sprite([NotNull] string image, [NotNull] int depth)
        {
            this.image = image;
            this.depth = depth;


            Check();
            OnDraw += Sprite_OnDraw;
        }

        /// <summary>Occurs when [on draw].</summary>
        public event EventHandler<bool> OnDraw;

        /// <summary>Gets or sets the image.</summary>
        /// <value>The image.</value>
        [NotNull]
        [JsonProperty]
        public string Image
        {
            get 
            { 
                return image; 
            }
            set
            {
                Logger.Warning("change value to: " + value);
                image = value;
                Check();
            }
        }

        /// <summary>Gets or sets the depth.</summary>
        /// <value>The depth.</value>
        [NotNull]
        [JsonProperty]
        public int Depth { get => depth; set => depth = value; }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            if (GameObject != null && transform == null)
            {
                transform = GameObject.Transform;
            }

            if (GameObject != null && sprite != null)
            {
                sprite.Position = new global::SFML.System.Vector2f(transform.Position.X, transform.Position.Y);
                sprite.Rotation = transform.Rotation.Y;
                sprite.Scale = new global::SFML.System.Vector2f(transform.Size.X, transform.Size.Y);

                if (!RenderSFML.CurrentRenderSFML.GetDraws<Sprite>().Contains(this))
                {
                    Logger.Log("Add: " + Path.GetFileName(pathImage));
                    Render.Current.AddDraw(this);
                }
            }
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            if (GameObject != null && transform == null) 
            {
                transform = GameObject.Transform;
            }

            if (GameObject != null && sprite != null)
            {
                sprite.Position = new global::SFML.System.Vector2f(transform.Position.X, transform.Position.Y);
                sprite.Rotation = transform.Rotation.Y;
                sprite.Scale = new global::SFML.System.Vector2f(transform.Size.X, transform.Size.Y);
            }
            else 
            {
                Check();
            }
        }

        /// <summary>Gets the draw.</summary>
        /// <returns>Return none</returns>
        [return: NotNull]
        internal global::SFML.Graphics.Sprite GetDraw()
        {
            OnDraw.Invoke(this, true);
            return sprite;
        }

        /// <summary>Checks this instance.</summary>
        private void Check()
        {
            pathImage = Asset.Load(image) ?? string.Empty;
            if (!pathImage.Equals(string.Empty))
            {
                Logger.Log("PATH: " + pathImage);

                if (RenderSFML.CurrentRenderSFML != null)
                {
                    sprite = new global::SFML.Graphics.Sprite(new global::SFML.Graphics.Texture(pathImage));

                    if (!RenderSFML.CurrentRenderSFML.GetDraws<Sprite>().Contains(this))
                    {
                        Logger.Log("Add: " + Path.GetFileName(pathImage));
                        RenderSFML.CurrentRenderSFML.AddDraw(this);
                    }
                }
            }
            else 
            {
                if (RenderSFML.CurrentRenderSFML != null)
                {
                    if (RenderSFML.CurrentRenderSFML.GetDraws<Sprite>().Contains(this))
                    {
                        Logger.Log("DELETE SPRITE");
                        RenderSFML.CurrentRenderSFML.Remove(this);
                    }
                }

                sprite = null;
            }
        }

        #region DefineEvents

        /// <summary>Sprites the on draw.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">if set to <c>true</c> [e].</param>
        private void Sprite_OnDraw([NotNull] object sender, [NotNull] bool e) => Logger.Info();

        #endregion
    }
}