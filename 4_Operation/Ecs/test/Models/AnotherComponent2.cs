using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     The another component
    /// </summary>
    internal struct AnotherComponent2 : IOnInit, IOnUpdate
    {
        public string Name;
        public void OnInit(IGameObject self)
        {
            
        }

        public void OnUpdate(IGameObject self)
        {
            
        }
    }
}