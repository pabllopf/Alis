using System.Collections.Generic;
using System.IO;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    /// The animator
    /// </summary>
    public struct Animator : IAnimator
    {
        /// <summary>
        /// Gets or sets the value of the animations
        /// </summary>
        public List<Animation> Animations { get; set; }
        /// <summary>
        /// Gets or sets the value of the current animation index
        /// </summary>
        public int CurrentAnimationIndex { get; set; }
        /// <summary>
        /// Gets or sets the value of the current frame index
        /// </summary>
        public int CurrentFrameIndex { get; set; }
    
        /// <summary>
        /// The clock
        /// </summary>
        private Clock _clock;
        /// <summary>
        /// The elapsed time
        /// </summary>
        private float _elapsedTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator"/> class
        /// </summary>
        public Animator()
        {
            Animations = new List<Animation>();
            _clock = new Clock();
            CurrentAnimationIndex = 0;
            CurrentFrameIndex = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator"/> class
        /// </summary>
        /// <param name="animations">The animations</param>
        public Animator(List<Animation> animations)
        {
            Animations = animations;
            CurrentAnimationIndex = 0;
            CurrentFrameIndex = 0;
        }

        /// <summary>
        /// Gets the value of the current animation
        /// </summary>
        public Animation CurrentAnimation =>
            Animations.Count > 0 ? Animations[CurrentAnimationIndex] : default;

        /// <summary>
        /// Adds the animation using the specified animation
        /// </summary>
        /// <param name="animation">The animation</param>
        public void AddAnimation(Animation animation)
        {
            Animations.Add(animation);
        }

        /// <summary>
        /// Plays the animation name
        /// </summary>
        /// <param name="animationName">The animation name</param>
        public void Play(string animationName)
        {
            int index = Animations.FindIndex(a => a.Name == animationName);
            if (index >= 0)
            {
                CurrentAnimationIndex = index;
                CurrentFrameIndex = 0;
            }
        }

        /// <summary>
        /// Nexts the frame
        /// </summary>
        public void NextFrame()
        {
            List<Frame> frames = CurrentAnimation.Frames;
            if (frames != null && frames.Count > 0)
            {
                CurrentFrameIndex = (CurrentFrameIndex + 1) % frames.Count;
            }
        }

        /// <summary>
        /// Gets the current frame
        /// </summary>
        /// <returns>The frame</returns>
        public Frame GetCurrentFrame()
        {
            List<Frame> frames = CurrentAnimation.Frames;
            if (frames != null && frames.Count > 0)
            {
                return frames[CurrentFrameIndex];
            }

            return default;
        }

        /// <summary>
        /// Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            _clock.Start();
            _elapsedTime = 0f;
        }

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            if (_clock == null)
            {
                return;
            }

            float deltaTime = _clock.ElapsedMilliseconds / 1000f;
            _clock.Restart();
    
            _elapsedTime += deltaTime;
    
            // Suponiendo que el target de fps es 60
            float targetFps = 60f;
            float frameDuration = CurrentAnimation.Speed > 0 ? 1f / (CurrentAnimation.Speed * targetFps) : float.MaxValue;
    
            if (_elapsedTime >= frameDuration)
            {
                NextFrame();
                _elapsedTime -= frameDuration;
            }
        }

        /// <summary>
        /// Draws the animation using the specified sprite
        /// </summary>
        /// <param name="sprite">The sprite</param>
        public void DrawAnimation(ref Sprite sprite)
        {
            string textureName = GetCurrentFrame().NameFile;
        
            if (sprite.NameFile != textureName)
            {
                sprite.LoadTexture(textureName);
            }
        }

        /// <summary>
        /// Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; }
        /// <summary>
        /// Ons the exit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnExit(IGameObject self)
        {
            _clock.Stop();
            _elapsedTime = 0f;
            _clock.Reset();
        }
    }
}