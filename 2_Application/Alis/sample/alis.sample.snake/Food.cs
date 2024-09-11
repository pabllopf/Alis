using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Entity;

namespace Alis.Sample.Snake
{
    /// <summary>
    /// The food class
    /// </summary>
    /// <seealso cref="AComponent"/>
    public class Food : AComponent
    {
        /// <summary>
        /// The box collider
        /// </summary>
        private BoxCollider _boxCollider;
        
        /// <summary>
        /// The player
        /// </summary>
        private GameObject _player;

        /// <summary>
        /// Ons the start
        /// </summary>
        public override void OnStart()
        {
            _boxCollider = GameObject.Get<BoxCollider>();
        }

        /// <summary>
        /// Consumes this instance
        /// </summary>
        public void Consume()
        {
            GameObject.IsEnable = false;
            _player.Get<PlayerController>().Grow();
        }

        /// <summary>
        /// Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public override void OnCollisionEnter(GameObject gameObject)
        {
            if (gameObject.Tag == "Player")
            {
                _player ??= gameObject;
                Consume();
            }
        }
    }
}