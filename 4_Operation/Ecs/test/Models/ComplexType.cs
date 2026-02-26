using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     Complex type for advanced testing
    /// </summary>
    /// <remarks>
    ///     Complex struct with multiple field types including arrays.
    ///     Used to test handling of complex data structures.
    /// </remarks>
    public struct ComplexType : IOnInit, IOnUpdate
    {
        /// <summary>
        ///     The identifier
        /// </summary>
        public int Id;
        
        /// <summary>
        ///     The name
        /// </summary>
        public string Name;
        
        /// <summary>
        ///     Array of values
        /// </summary>
        public double[] Values;

        public void OnInit(IGameObject self)
        {
            
        }

        public void OnUpdate(IGameObject self)
        {
            
        }
    }
}