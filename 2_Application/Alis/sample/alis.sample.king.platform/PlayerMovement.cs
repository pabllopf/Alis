using System;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;

namespace Alis.Sample.King.Platform
{
    public struct PlayerMovement : IInitable, IGameObjectComponent
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

        public PlayerMovement()
        {
            animator = default;
            boxCollider = null;
            sprite = default;
        }

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

        public void Update(IGameObject self)
        {
            
        }
    }
}