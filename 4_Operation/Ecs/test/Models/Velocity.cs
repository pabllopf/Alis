using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    ///     The velocity component
    /// </summary>
    internal struct Velocity: IOnInit, IOnUpdate
    {
        public float VX;
        public float VY;


        public void OnInit(IGameObject self)
        {
            
        }

        public void OnUpdate(IGameObject self)
        {
            
        }
    }
}