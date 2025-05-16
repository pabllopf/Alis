using System;
using Alis;

using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    record struct Pos(float X) : IEntityComponent
    {
        public void Update(Entity entity)
        {
            Console.WriteLine(entity.Has<Vel>() ?
                "I have velocity!" :
                "No velocity here!");
        }
    }
}