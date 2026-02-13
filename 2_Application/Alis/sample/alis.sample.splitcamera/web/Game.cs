using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Web
{
    public static class Game
    {
        public static VideoGame Create()
        {
             return VideoGame.Create().Build();
        }
    }
}
