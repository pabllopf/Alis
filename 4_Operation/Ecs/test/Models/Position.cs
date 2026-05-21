

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     The position component
    /// </summary>
    internal struct Position : IOnInit, IOnUpdate
    {
        /// <summary>
        ///     The
        /// </summary>
        public float X;

        /// <summary>
        ///     The
        /// </summary>
        public float Y;


        /// <summary>
        ///     Ons the init using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnInit(IGameObject self)
        {
        }

        /// <summary>
        ///     Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        [UpdateOrder(1)]
        public void OnUpdate(IGameObject self)
        {
        }
    }
}