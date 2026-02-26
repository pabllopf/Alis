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
        public void OnInit(IGameObject self)
        {
            
        }

        public void OnUpdate(IGameObject self)
        {
            
        }
    }
}