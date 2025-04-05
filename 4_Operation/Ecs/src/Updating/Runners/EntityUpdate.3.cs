using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Alis.Core.Ecs.Arch;
using Alis.Core.Ecs.Operations;

namespace Alis.Core.Ecs.Updating.Runners
{
    internal class EntityUpdate<TComp, TArg1, TArg2, TArg3>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IEntityComponent<TArg1, TArg2, TArg3>
    {
        internal override void Run(Scene scene, Archetype b)
        {
            ref EntityIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();
            ref TArg3 arg3 = ref b.GetComponentDataReference<TArg3>();


            GameObject gameObject = scene.DefaultWorldGameObject;

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2, ref arg3);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);

                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);

            }
        }
    
        internal override void MultithreadedRun(CountdownEvent countdown, Scene scene, Archetype b)
            => throw new NotImplementedException();
    }
}
