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
        public void OnInit(IGameObject self)
        {
            
        }

        public void OnUpdate(IGameObject self)
        {
            
        }
    }
}