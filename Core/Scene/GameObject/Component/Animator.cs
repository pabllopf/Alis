//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Animator.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using Newtonsoft.Json;
    using SFML.System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Define a component</summary>
    public class Animator : Component
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
        public Animator()
        {
        }

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
            List<Animation> temp = animations != null ? animations.ToList().OrderBy(o => o.State).ToList() : new List<Animation>();

            foreach (Animation anim in temp)
            {
                this.animations.Add(anim);
            }
        }

        /// <summary>Gets or sets the state.</summary>
        /// <value>The state.</value>
        [JsonProperty]
        public int State { get => state; set => state = value; }

        /// <summary>Gets or sets the animations.</summary>
        /// <value>The animations.</value>
        [JsonProperty]
        public List<Animation> Animations { get => animations; set => animations = value; }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            sprite = GetGameObject().GetComponent<Sprite>();
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            if (sprite != null)
            {
                if (clock.ElapsedTime.AsSeconds() >= animations[state].Speed)
                {
                    sprite.GetDraw().Texture = animations[state].Texture;
                    clock.Restart();
                }
            }
        }
    }
}