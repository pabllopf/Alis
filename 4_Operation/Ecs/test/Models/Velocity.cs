

using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     The velocity component
    /// </summary>
    internal struct Velocity : IOnInit, IOnUpdate
    {
        /// <summary>
        ///     The vx
        /// </summary>
        public float X;

        /// <summary>
        ///     The vy
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
        public void OnUpdate(IGameObject self)
        {
        }
    }
}