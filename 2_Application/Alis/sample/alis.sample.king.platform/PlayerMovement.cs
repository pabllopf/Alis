using System;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Sample.King.Platform
{
    /// <summary>
    /// The player movement
    /// </summary>
    public struct PlayerMovement : IInitable, IGameObjectComponent, IOnPressKey
    {
        /// <summary>
        /// The jump force
        /// </summary>
        private const float JumpForce = 10;
        /// <summary>
        /// The velocity player
        /// </summary>
        private const float VelocityPlayer = 5f;
        /// <summary>
        /// The reset cool down jump
        /// </summary>
        private const float ResetCoolDownJump = 0.8f;

        /// <summary>
        /// The animator
        /// </summary>
        private Animator animator;
        /// <summary>
        /// The box collider
        /// </summary>
        private BoxCollider boxCollider;
        /// <summary>
        /// The vector
        /// </summary>
        private Vector2F directionPlayer = new Vector2F(0, 0);
        /// <summary>
        /// The sprite
        /// </summary>
        private Sprite sprite;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerMovement"/> class
        /// </summary>
        public PlayerMovement()
        {
            animator = default;
            boxCollider = null;
            sprite = default;
        }

        /// <summary>
        /// Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <exception cref="ArgumentNullException">GameObject cannot be null</exception>
        /// <exception cref="InvalidOperationException">GameObject must have a BoxCollider component</exception>
        /// <exception cref="InvalidOperationException">GameObject must have a Sprite component</exception>
        /// <exception cref="InvalidOperationException">GameObject must have an Animator component</exception>
        public void Init(IGameObject self)
        {
            if (self == null)
            {
                throw new ArgumentNullException(nameof(self), "GameObject cannot be null");
            }

            if (!self.Has<Animator>())
            {
                throw new InvalidOperationException("GameObject must have an Animator component");
            }

            if (!self.Has<BoxCollider>())
            {
                throw new InvalidOperationException("GameObject must have a BoxCollider component");
            }

            if (!self.Has<Sprite>())
            {
                throw new InvalidOperationException("GameObject must have a Sprite component");
            }

            animator = self.Get<Animator>();
            boxCollider = self.Get<BoxCollider>();
            sprite = self.Get<Sprite>();
        }

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Update(IGameObject self)
        {
            
        }

        public void OnPressKey(ConsoleKey key)
        {
            if (key == ConsoleKey.A)
            {
                directionPlayer.X = -1;
                boxCollider.Body.ApplyLinearImpulse(new Vector2F(-0.1f, 0));
            }

            if (key == ConsoleKey.D)
            {
                directionPlayer.X = 1;
                boxCollider.Body.ApplyLinearImpulse(new Vector2F(0.1f, 0));
            }
            
            if (key == ConsoleKey.Spacebar)
            {
                 boxCollider.Body.ApplyLinearImpulse(new Vector2F(0, JumpForce));
            }
        }

        public void Update()
        {
            
        }
    }
}