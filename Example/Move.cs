//----------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Info.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//----------------------------------------------------------------------------------------------------
namespace Example
{
    using Alis.Core;
    using Alis.Core.SFML;
  
    /// <summary>Define a component to move player.</summary>
    public class Move : Component
    {
        /// <summary>The transform is will use to control position of player</summary>
        private Transform transform;

        /// <summary>The animator will control animations</summary>
        private Animator animator;

        /// <summary>The speed of movement.</summary>
        private int speed = 1;

        /// <summary>Start this instance. Init all that you need.</summary>
        public override void Start()
        {
            // Define a event control to check input and move player.
            Input.OnPressKey += Input_OnPressKey;

            // Load the animator of player.
            animator = GameObject.Get<Animator>();

            // Load transform of player 
            transform = GameObject.Transform;
        }

        /// <summary>Inputs the on press key1.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="key">The key.</param>
        private void Input_OnPressKey(object sender, Keyboard key)
        {
            if (key.Equals(Keyboard.S))
            {
                animator.State = 0;
                transform.YPos += 1 * speed;
            }

            if (key.Equals(Keyboard.D))
            {
                animator.State = 1;
                transform.XPos += 1 * speed;
            }

            if (key.Equals(Keyboard.W))
            {
                animator.State = 2;
                transform.YPos -= 1 * speed;
            }

            if (key.Equals(Keyboard.A))
            {
                animator.State = 3;
                transform.XPos -= 1 * speed;
            }
        }

        /// <summary>Update this instance. This will execute every frame.</summary>
        public override void Update()
        {
        }
    }
}