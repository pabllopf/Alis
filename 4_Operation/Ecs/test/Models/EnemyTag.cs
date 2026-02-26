using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     Enemy tag for testing
    /// </summary>
    /// <remarks>
    ///     Tag to identify enemy entities in tests.
    /// </remarks>
    public struct EnemyTag : IOnInit, IOnUpdate
    {
        /// <summary>
        /// Ons the init using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnInit(IGameObject self)
        {
            
        }

        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            
        }
    }
}