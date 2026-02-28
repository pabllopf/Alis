using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     The position component
    /// </summary>
    internal struct Position : IOnInit, IOnUpdate
    {
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