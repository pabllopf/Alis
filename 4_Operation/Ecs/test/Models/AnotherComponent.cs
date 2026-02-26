using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     The another component
    /// </summary>
    internal struct AnotherComponent : IOnInit, IOnUpdate
    {
        public string Name;
        public float X;
        public float Y;
        public void OnInit(IGameObject self)
        {
            
        }

        public void OnUpdate(IGameObject self)
        {
            
        }
    }
}