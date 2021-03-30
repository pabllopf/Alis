//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Animator.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using global::SFML.System;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>Define a component</summary>
    public class Animator : Component
    {
        /// <summary>The sprite</summary>
        [NotNull]
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
            sprite = GetGameObject().GetComponent<Sprite>() ?? throw new System.Exception("GameObject " + this.GetGameObject().Name + "dont content a Sprite");
        }

        public override int Priority()
        {
            return 2;
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
            if (sprite != null && sprite.Image != string.Empty)
            {
                if (state < animations.Count)
                {
                    if (animations.Count > 0) 
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
    }
}