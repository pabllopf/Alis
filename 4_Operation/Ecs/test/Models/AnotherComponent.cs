using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     The another component
    /// </summary>
    internal struct AnotherComponent : IOnInit, IOnUpdate
    {
        /// <summary>
        /// The name
        /// </summary>
        public string Name;
        /// <summary>
        /// The 
        /// </summary>
        public float X;
        /// <summary>
        /// The 
        /// </summary>
        public float Y;
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