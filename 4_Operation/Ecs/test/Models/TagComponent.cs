using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     Tag component for testing
    /// </summary>
    /// <remarks>
    ///     Simple tag component with no data, used for testing tag-based queries.
    /// </remarks>
    public struct TagComponent : IOnInit, IOnUpdate
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