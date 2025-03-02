using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;

namespace Alis.Sample.King.Platform
{
    public class PlayerMovement : AComponent
    {
        private const float JumpForce = 10;
        private const float VelocityPlayer = 5f;
        private const float ResetCoolDownJump = 0.8f;

        private Animator animator;
        private BoxCollider boxCollider;
        private Vector2F directionPlayer = new Vector2F(0, 0);
        private Sprite sprite;
        private bool isJumping = false;

        public override void OnStart()
        {
            animator = GameObject.Get<Animator>();
            boxCollider = GameObject.Get<BoxCollider>();
            sprite = GameObject.Get<Sprite>();
        }

        public override void OnUpdate()
        {
            // Apply movement
            boxCollider.Body.LinearVelocity = new Vector2F(directionPlayer.X * VelocityPlayer, boxCollider.Body.LinearVelocity.Y);

            // Update animation based on movement
            if (directionPlayer.X != 0 && !isJumping)
            {
                animator.ChangeAnimationTo("Run");
                if (directionPlayer.X < 0)
                {
                    sprite.Flip = true; 
                }
                else
                {
                    sprite.Flip = false;
                }
                
            }
            else if (!isJumping)
            {
                animator.ChangeAnimationTo("Idle");
            }
        }

        public override void OnReleaseKey(Keys key)
        {
            if ((key == Keys.A && directionPlayer.X == -1) || (key == Keys.D && directionPlayer.X == 1))
            {
                directionPlayer.X = 0;
            }
        }

        public override void OnPressKey(Keys key)
        {
            if (key == Keys.Space && !isJumping)
            {
                boxCollider.Body.ApplyLinearImpulse(new Vector2F(0, JumpForce));
                isJumping = true;
                animator.ChangeAnimationTo("Jump");
            }

            if (key == Keys.A)
            {
                directionPlayer.X = -1;
            }

            if (key == Keys.D)
            {
                directionPlayer.X = 1;
            }
        }

        public override void OnCollisionEnter(GameObject gameObject)
        {
            if (gameObject.Tag == "Floor")
            {
                isJumping = false;
            }
        }
    }
}