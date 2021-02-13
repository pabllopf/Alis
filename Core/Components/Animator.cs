//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Animator.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Newtonsoft.Json;
    using SFML.System;

    /// <summary>Define animation of sprite.</summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Animator : IComponent
    {
        /// <summary>The sprite</summary>
        private Sprite sprite;

        /// <summary>The state</summary>
        private int state;

        /// <summary>The clock</summary>
        private Clock clock;

        /// <summary>The animations</summary>
        private List<Animation> animations;

        /// <summary>Initializes a new instance of the <see cref="Animator" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="state">The state.</param>
        /// <param name="animations">The animations.</param>
        [JsonConstructor]
        public Animator(int state, params Animation[] animations)
        {
            this.state = state;
            this.animations = new List<Animation>();
            this.clock = new Clock();
            List<Animation> temp = animations.ToList().OrderBy(o => o.State).ToList();

            foreach (Animation anim in temp) 
            {
                if (this.animations.Any(i => i.State == anim.State))
                {
                    Debug.Warning("Animations in " + GetType() + " with the same state. ");
                }
                else 
                {
                    this.animations.Add(anim);
                }
            }
        }

        /// <summary>Gets or sets the state.</summary>
        /// <value>The state.</value>
        [JsonProperty]
        public int State { get => state; set => state = value; }

        /// <summary>Starts the specified transform.</summary>
        /// <param name="gameObject"></param>
        public void Start(GameObject gameObject)
        {
            if (gameObject.Components.Any(i => i.GetType().Equals(typeof(Sprite))))
            {
                sprite = (Sprite)gameObject.Components.Find(i => i.GetType().Equals(typeof(Sprite)));
                Debug.Log("Init " + GetType() + " of " + gameObject.Name + " gameobject.");
            }
        }

        /// <summary>Updates the specified transform.</summary>
        /// <param name="gameObject"></param>
        public void Update(GameObject gameObject)
        {
            if (sprite != null)
            {
                if (clock.ElapsedTime.AsSeconds() >= animations[state].Speed)
                {
                    sprite.GetSprite.Texture = animations[state].Texture;
                    clock.Restart();
                }
            }
        }

        /// <summary>Gets the debugger display.</summary>
        /// <returns>return display</returns>
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}



/*using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    using Alis.Core;
    using Alis.Tools;
    using Newtonsoft.Json;
    using SFML.Graphics;
    using SFML.System;
    using System.IO;
    using System.Linq;

    /// <summary>Define components.</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Animator : IComponent
    {
        /// <summary>The sprite</summary>
        private Sprite sprite;

        /// <summary>The textures</summary>
        private List<Texture> textures;

        /// <summary>The image files</summary>
        private List<string> imageFiles;

        /// <summary>The clock</summary>
        private Clock clock;

        private int state;

        private float speedAnimation = 1.0f;

        private int index;

        /// <summary>Initializes a new instance of the <see cref="Animator" /> class.</summary>
        /// <param name="imageFiles"></param>
        [JsonConstructor]
        public Animator(List<string> imageFiles, float speed) 
        {
            this.state = 0;
            this.imageFiles = imageFiles;
            this.clock = new Clock();
            textures = new List<Texture>();

            this.index = 0;
            this.speedAnimation = speed;

            foreach (string file in imageFiles) 
            {
                if (File.Exists(Application.AssetsPath + file)) 
                {
                    Debug.Log("Add new image " + file);
                    textures.Add(new Texture(Application.AssetsPath + file));
                }
            }
        }

        /// <summary>Gets or sets the image files.</summary>
        /// <value>The image files.</value>
        [JsonProperty]
        public List<string> ImageFiles { get => imageFiles; set => imageFiles = value; }

        /// <summary>Starts the specified transform.</summary>
        /// <param name="gameObject"></param>
        public void Start(GameObject gameObject)
        {
            if (gameObject.Components.Any(i => i.GetType().Equals(typeof(Sprite)))) 
            {
                sprite = (Sprite)gameObject.Components.Find(i => i.GetType().Equals(typeof(Sprite)));
                Debug.Log("Init " + this.GetType() + " of " + gameObject.Name + " gameobject.");
            }
        }

        /// <summary>Updates the specified transform.</summary>
        /// <param name="gameObject"></param>
        public void Update(GameObject gameObject)
        {
            if (sprite != null) 
            {
                if (clock.ElapsedTime.AsSeconds() > speedAnimation) 
                {
                    index++;
                    if (index >= textures.Count)
                    {
                        index = 0;
                    }

                    sprite.GetSprite.Texture = textures[index];

                    clock.Restart();
                }
            }
        }
    }
}
        /*
        private List<string> render;

        private List<string> images;

        private SFML.Graphics.Sprite sprite;

        private int index = 0;

        private int count = 0;

        [JsonConstructor]
        public Animator(List<string> images) 
        {
            this.images = images;
            this.render = images;
            this.count = images.Count;
        }

        /// <summary>Gets or sets the images.</summary>
        /// <value>The images.</value>
        [JsonProperty]
        public List<string> Images
        {
            get => images; 
            set
            {
                images = value;
                render = images;
            }
        }

        public int Count
        {
            get => count; set
            {
                count = value;
            }
        }

        public void AddNewImage(string name) 
        {
            images.Add(name);
        }

        public void DeletImage(string name)
        {
            images.Remove(name);
        }

        public void Start(GameObject gameObject)
        {
            if (gameObject.Components.Find(i => i.GetType().Equals(typeof(Sprite))) != null) 
            {
                sprite = ((Sprite)gameObject.Components.Find(i => i.GetType().Equals(typeof(Sprite)))).GetSprite;
            }
        }

        public void Update(GameObject gameObject)
        {


            if (sprite != null) 
            {
                index++;             
                if (index == images.Count) 
                {
                    index = 0;
                }
            }
        }
    }
}
*/