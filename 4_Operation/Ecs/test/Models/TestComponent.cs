

using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     The test component
    /// </summary>
    internal struct TestComponent : IOnInit, IOnUpdate
    {
        /// <summary>
        ///     The value
        /// </summary>
        public int Value;

        /// <summary>
        ///     The name
        /// </summary>
        public string Name;

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