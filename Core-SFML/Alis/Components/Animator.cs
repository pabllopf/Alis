//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Animator.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core.SFML
{
    using global::SFML.System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>Define a component</summary>
    public class Animator : Component
    {
        private string icon = "\uf01d";

        /// <summary>The sprite</summary>
        [AllowNull]
        [JsonIgnore]
        private Sprite sprite;

        /// <summary>The state</summary>
        [NotNull]
        private int state;

        /// <summary>The clock</summary>
        [NotNull]
        [JsonIgnore]
        private Clock clock;

        /// <summary>The animations</summary>
        [NotNull]
        private List<Animation> animations;

        public Animator() 
        {
            this.state = 0;
            this.animations = new List<Animation>();
            clock = new Clock();
        }

        [JsonConstructor]
        public Animator([NotNull] int state, [NotNull] List<Animation> animations) 
        {

            this.state = state;
            this.animations = animations.OrderBy(o => o.State).ToList();
            clock = new Clock();
        }


        /// <summary>Initializes a new instance of the <see cref="Animator" /> class.</summary>
        /// <param name="name">The name.</param>
        /// <param name="state">The state.</param>
        /// <param name="animations">The animations.</param>
        public Animator([NotNull] int state, [NotNull] params Animation[] animations)
        {
            this.state = state;
            this.animations = animations.ToList().OrderBy(o => o.State).ToList();
            clock = new Clock();
        }

        /// <summary>Gets or sets the state.</summary>
        /// <value>The state.</value>
        public int State { get => state; set => state = value; }

        /// <summary>Gets or sets the animations.</summary>
        /// <value>The animations.</value>
        public List<Animation> Animations { get => animations; set => animations = value; }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            if (GameObject != null) 
            {
                if (GameObject.Get<Sprite>() != null)
                {
                    sprite = GameObject.Get<Sprite>();
                    this.state = 0;
                }
            }
        }

        public override string GetIcon()
        {
            return icon;
        }

        private int index = 0;

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            if (sprite != null) 
            {
                if (!sprite.Image.Equals(string.Empty)) 
                {
                    if (animations.Count > 0)
                    {
                        if (animations[state] != null) 
                        {
                            if (clock.ElapsedTime.AsSeconds() >= animations[state].Speed)
                            {
                                if (index < animations[state].Textures.Count)
                                {
                                    index++;
                                }
                                else 
                                {
                                    index = 0;
                                }

                                sprite.GetDraw().Texture = animations[state].Textures[index];
                                clock.Restart();
                            }
                        }
                    }               
                }
            }
        }

        public override void Exit()
        {
            if (GameObject != null)
            {
                if (GameObject.Get<Sprite>() != null)
                {
                    sprite = null;
                }
            }
        }
    }
}