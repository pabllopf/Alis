using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     Damage component for testing
    /// </summary>
    /// <remarks>
    ///     Represents damage value for combat testing scenarios.
    /// </remarks>
    public struct Damage : IOnInit, IOnUpdate
    {
        /// <summary>
        ///     The damage amount
        /// </summary>
        public int Amount;


        public void OnInit(IGameObject self)
        {
            
        }

        public void OnUpdate(IGameObject self)
        {
            
        }
    }
}