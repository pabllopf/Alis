using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     Player tag for testing
    /// </summary>
    /// <remarks>
    ///     Tag to identify player entities in tests.
    /// </remarks>
    public struct PlayerTag : IOnInit, IOnUpdate
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