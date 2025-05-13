using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Systems;
    internal class Update<TComp, TArg1, TArg2>(int cap) : ComponentStorage<TComp>(cap)
        where TComp : IComponent<TArg1, TArg2>
    {
        internal override void Run(World world, Archetype b)
        {
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
        ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();


            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                comp.Update(ref arg1, ref arg2);

                comp = ref Unsafe.Add(ref comp, 1);

                arg1 = ref Unsafe.Add(ref arg1, 1);
            arg2 = ref Unsafe.Add(ref arg2, 1);

            }
        }

        internal override void Run(World world, Archetype b, int start, int length)
        {
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start);
        ref TArg2 arg2 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg2>(), start);


            for (int i = length - 1; i >= 0; i--)
            {
                comp.Update(ref arg1, ref arg2);

                comp = ref Unsafe.Add(ref comp, 1);
                arg1 = ref Unsafe.Add(ref arg1, 1);
            arg2 = ref Unsafe.Add(ref arg2, 1);

            }
        }

        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b) =>
            throw new NotImplementedException();
    }
