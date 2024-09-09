using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Entity;

namespace Alis.Sample.Snake
{
    public class Food : AComponent
    {
        private BoxCollider _boxCollider;

        public override void OnStart()
        {
            _boxCollider = GameObject.Get<BoxCollider>();
        }

        public void Consume()
        {
            GameObject.IsEnable = false;
        }

        public override void OnCollisionEnter(GameObject gameObject)
        {
            if (gameObject.Tag == "Player")
            {
                Consume();
            }
        }
    }
}