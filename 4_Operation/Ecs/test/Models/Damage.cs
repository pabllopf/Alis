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