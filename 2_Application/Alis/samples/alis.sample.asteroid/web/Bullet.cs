

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components;

namespace Alis.Sample.Asteroid.Web
{
    /// <summary>
    ///     The bullet class
    /// </summary>
    public struct Bullet : IOnCollisionEnter
    {
        /// <summary>
        ///     Ons the collision enter using the specified other
        /// </summary>
        /// <param name="other">The other</param>
        public void OnCollisionEnter(IGameObject other)
        {
            if (other.Has<Info>())
            {
                ref Info gameObject = ref other.Get<Info>();

                if (gameObject.Tag == "Asteroid")
                {
                    other.Get<Asteroid>().DecreaseHealth();
                }

                if (gameObject.Tag == "Wall")
                {
                }
            }
        }
    }
}