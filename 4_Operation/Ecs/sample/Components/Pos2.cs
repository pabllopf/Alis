using System;
using Alis;

using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Sample.Components
{
    record struct Pos2(float X = 0) : IInitable, IEntityComponent
    {
        private Entity entity;
    
        public void Update(Entity self)
        {
            Console.WriteLine(entity.Has<Vel2>() ?
                "I have velocity!" :
                "No velocity here!");
        }

        public void Init(Entity self)
        {
            entity = self;
            Console.WriteLine("I am initialized!");
        }
    }
}