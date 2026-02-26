using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     Simple struct for testing
    /// </summary>
    /// <remarks>
    ///     Basic struct with two integer fields used for collection testing.
    /// </remarks>
    public struct TestStruct : IOnInit, IOnUpdate
    {
        /// <summary>
        ///     The X coordinate
        /// </summary>
        public int X;
        
        /// <summary>
        ///     The Y coordinate
        /// </summary>
        public int Y;

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