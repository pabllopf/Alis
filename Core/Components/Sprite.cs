//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Sprite.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Diagnostics;
    using System.IO;
    using System.Numerics;
    using Alis.Tools;
    using Newtonsoft.Json;
    using SFML.Graphics;

    /// <summary>Define sprite to draw on game.</summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    [JsonObject(MemberSerialization.OptIn)]
    public class Sprite : IComponent
    {
        /// <summary>The image file</summary>
        private string imageFile;

        /// <summary>The path</summary>
        private string path;

        /// <summary>The sprite</summary>
        private SFML.Graphics.Sprite sprite;

        /// <summary>The texture</summary>
        private SFML.Graphics.Texture texture;

        /// <summary>The invalid file</summary>
        private bool invalidFile = false;

        /// <summary>Initializes a new instance of the <see cref="Sprite" /> class.</summary>
        /// <param name="imageFile">The image file.</param>
        /// <param name="path"></param>
        [JsonConstructor]
        public Sprite(string imageFile, string path)
        {
            this.imageFile = imageFile;
            this.path = path;
            CheckTexture();
        }

        /// <summary>Gets or sets the image file.</summary>
        /// <value>The image file.</value>
        [JsonProperty]
        public string ImageFile
        {
            get => imageFile;
            set
            {
                imageFile = value;
                if (!File.Exists(path + imageFile)) 
                {
                    Debug.Log("invalidFile name file to: " + path + imageFile);
                    if (sprite != null && texture != null)
                    {
                        if (Render.Current != null)
                        {
                            if (Render.Current.Exits(sprite))
                            {
                                Render.Current.DeleteSprite(sprite);
                                sprite = null;
                                texture = null;
                            }
                        }
                    }

                }
            }
        }

        /// <summary>Gets or sets the path.</summary>
        /// <value>The path.</value>
        [JsonProperty]
        public string Path
        {
            get => path;
            set
            {
                path = value;
                if (!File.Exists(path + imageFile))
                {
                    Debug.Log("invalidFile name file to: " + path + imageFile);
                    if (sprite != null && texture != null)
                    {
                        if (Render.Current != null)
                        {
                            if (Render.Current.Exits(sprite))
                            {
                                Render.Current.DeleteSprite(sprite);
                                sprite = null;
                                texture = null;
                            }
                        }
                    }
                }
            }
        }

        public SFML.Graphics.Sprite GetSprite { get => sprite; set => sprite = value; }

        /// <summary>Starts this instance.</summary>
        public void Start()
        {
            CheckTexture();
        }

        /// <summary>Starts this instance.</summary>
        public void Start(GameObject gameObject)
        {
        }

        /// <summary>Updates the specified transform.</summary>
        /// <param name="gameObject"></param>
        public void Update(GameObject gameObject)
        {
            CheckTexture();
            if (sprite != null && texture != null) 
            {
                sprite.Position = new SFML.System.Vector2f(gameObject.Transform.Position.X, gameObject.Transform.Position.Y);
                sprite.Scale = new SFML.System.Vector2f(gameObject.Transform.Size.X, gameObject.Transform.Size.Y);
                sprite.Rotation = gameObject.Transform.Rotation.Y;
            }
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>Debug string</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        /// <summary>Checks the texture.</summary>
        private void CheckTexture() 
        {
            if (File.Exists(path + imageFile))
            {
                if ((sprite == null && texture == null))
                {
                    Debug.Warning("Sprite exits: " + path + imageFile);
                    texture = new SFML.Graphics.Texture(path + imageFile);
                    sprite = new SFML.Graphics.Sprite(texture);

                    if (Render.Current != null)
                    {
                        if (Render.Current.Exits(sprite))
                        {
                            Render.Current.DeleteSprite(sprite);
                        }

                        Render.Current.AddNewSprite(sprite);
                    }

                    return;
                }
                else
                {
                    if (Render.Current != null)
                    {
                        if (!Render.Current.Exits(sprite))
                        {
                            Render.Current.AddNewSprite(sprite);
                        }
                    }
                }
            }

            if (File.Exists(Application.AssetsPath + imageFile)) 
            {
                if ((sprite == null && texture == null)) 
                {
                    path = Application.AssetsPath;
                    Debug.Warning("Sprite exits: " + path + imageFile);
                    texture = new SFML.Graphics.Texture(path + imageFile);
                    sprite = new SFML.Graphics.Sprite(texture);

                    if (Render.Current != null) 
                    {
                        if (Render.Current.Exits(sprite))
                        {
                            Render.Current.DeleteSprite(sprite);
                        }

                        Render.Current.AddNewSprite(sprite);
                    }

                    return;
                }
                else
                {
                    if (Render.Current != null)
                    {
                        if (!Render.Current.Exits(sprite))
                        {
                            Render.Current.AddNewSprite(sprite);
                        }
                    }
                }
            }
        }
    }
}