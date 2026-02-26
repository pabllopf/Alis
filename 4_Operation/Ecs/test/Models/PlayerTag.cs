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
        public void OnInit(IGameObject self)
        {
            
        }

        public void OnUpdate(IGameObject self)
        {
            
        }
    }
}