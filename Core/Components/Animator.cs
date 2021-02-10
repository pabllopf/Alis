using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    using Alis.Core;
    using Newtonsoft.Json;

    /// <summary>Define components.</summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class Animator : IComponent
    {
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
            /*if (gameObject.Components.Find(i => i.GetType().Equals(typeof(Sprite))) != null) 
            {
                sprite = ((Sprite)gameObject.Components.Find(i => i.GetType().Equals(typeof(Sprite)))).GetSprite;
            }*/
        }

        public void Update(GameObject gameObject)
        {


            /*if (sprite != null) 
            {
                index++;             
                if (index == images.Count) 
                {
                    index = 0;
                }
            }*/
        }
    }
}
