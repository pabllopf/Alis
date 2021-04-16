// -------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Animation.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core.SFML
{
    using Alis.Tools;
    using global::SFML.Graphics;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>Define animation of sprite.</summary>
    public class Animation
    {
        /// <summary>The name</summary>
        [NotNull]
        private string name;

        /// <summary>The state</summary>
        [NotNull]
        private int state;

        /// <summary>The images</summary>
        [NotNull]
        private List<string> images;

        /// <summary>The textures</summary>
        [NotNull]
        private List<Texture> textures;

        /// <summary>The index</summary>
        [NotNull]
        private int index;

        /// <summary>The speed</summary>
        [NotNull]
        private float speed;

        public Animation() 
        {
            this.name = "";
            this.state = 0;
            this.speed = 1;
            this.images = new List<string>();            
            this.textures = new List<Texture>();
        }

        [JsonConstructor]
        public Animation([NotNull] string name, [NotNull] int state, [NotNull] float speed, [NotNull] List<string> images)
        {
            this.name = name;
            this.state = state;
            this.speed = speed;

            this.textures = new List<Texture>();

            this.images = images;

            foreach (string image in images)
            {
                if (Asset.Load(image) != null)
                {
                    textures.Add(new Texture(Asset.Load(image)));
                }
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Animation" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="state">The state.</param>
        /// <param name="speed">The speed.</param>
        /// <param name="images">The images.</param>
        public Animation([NotNull] string name, [NotNull] int state, [NotNull] float speed, [NotNull] params string[] images)
        {
            this.name = name;
            this.state = state;
            this.speed = speed;

            this.textures = new List<Texture>();

            this.images = new List<string>(images);

            foreach (string image in images)
            {
                if (Asset.Load(image) != null) 
                {
                    textures.Add(new Texture(Asset.Load(image)));
                }            
            }
        }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [JsonProperty]
        [NotNull]
        public string Name { get => name; set => name = value; }

        /// <summary>Gets or sets the state.</summary>
        /// <value>The state.</value>
        [JsonProperty]
        [NotNull]
        public int State { get => state; set => state = value; }

        /// <summary>Gets or sets the speed.</summary>
        /// <value>The speed.</value>
        [JsonProperty]
        [NotNull]
        public float Speed { get => speed; set => speed = value; }

        /// <summary>Gets the texture.</summary>
        /// <value>The texture.</value>
        [JsonIgnore]
        [NotNull]
        public Texture Texture
        {
            get
            {
                index++;
                if (index >= textures.Count)
                {
                    index = 0;
                }
                return textures[index];
            }
        }

        public List<string> Images { get => images; set => images = value; }
    }
}