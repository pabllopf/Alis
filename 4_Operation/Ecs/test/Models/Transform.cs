using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     Transform component for testing
    /// </summary>
    /// <remarks>
    ///     Represents a 2D transformation with position and rotation.
    /// </remarks>
    public struct Transform : IOnInit, IOnUpdate
    {
        /// <summary>
        ///     The X position
        /// </summary>
        public float X;
        
        /// <summary>
        ///     The Y position
        /// </summary>
        public float Y;
        
        /// <summary>
        ///     The rotation angle
        /// </summary>
        public float Rotation;

        public void OnInit(IGameObject self)
        {
            
        }

        public void OnUpdate(IGameObject self)
        {
            
        }
    }
}