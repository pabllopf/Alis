using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel.Archetype;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12,
        TArg13>(int cap) : ComponentStorage<TComp>(cap)
        where TComp : IComponent<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10,
            TArg11, TArg12, TArg13>
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();
            ref TArg3 arg3 = ref b.GetComponentDataReference<TArg3>();
            ref TArg4 arg4 = ref b.GetComponentDataReference<TArg4>();
            ref TArg5 arg5 = ref b.GetComponentDataReference<TArg5>();
            ref TArg6 arg6 = ref b.GetComponentDataReference<TArg6>();
            ref TArg7 arg7 = ref b.GetComponentDataReference<TArg7>();
            ref TArg8 arg8 = ref b.GetComponentDataReference<TArg8>();
            ref TArg9 arg9 = ref b.GetComponentDataReference<TArg9>();
            ref TArg10 arg10 = ref b.GetComponentDataReference<TArg10>();
            ref TArg11 arg11 = ref b.GetComponentDataReference<TArg11>();
            ref TArg12 arg12 = ref b.GetComponentDataReference<TArg12>();
            ref TArg13 arg13 = ref b.GetComponentDataReference<TArg13>();


            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                comp.Update(ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6, ref arg7, ref arg8, ref arg9,
                    ref arg10, ref arg11, ref arg12, ref arg13);

                comp = ref Unsafe.Add(ref comp, 1);

                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
                arg4 = ref Unsafe.Add(ref arg4, 1);
                arg5 = ref Unsafe.Add(ref arg5, 1);
                arg6 = ref Unsafe.Add(ref arg6, 1);
                arg7 = ref Unsafe.Add(ref arg7, 1);
                arg8 = ref Unsafe.Add(ref arg8, 1);
                arg9 = ref Unsafe.Add(ref arg9, 1);
                arg10 = ref Unsafe.Add(ref arg10, 1);
                arg11 = ref Unsafe.Add(ref arg11, 1);
                arg12 = ref Unsafe.Add(ref arg12, 1);
                arg13 = ref Unsafe.Add(ref arg13, 1);
            }
        }

        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        internal override void Run(Scene scene, Archetype b, int start, int length)
        {
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start);
            ref TArg2 arg2 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg2>(), start);
            ref TArg3 arg3 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg3>(), start);
            ref TArg4 arg4 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg4>(), start);
            ref TArg5 arg5 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg5>(), start);
            ref TArg6 arg6 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg6>(), start);
            ref TArg7 arg7 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg7>(), start);
            ref TArg8 arg8 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg8>(), start);
            ref TArg9 arg9 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg9>(), start);
            ref TArg10 arg10 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg10>(), start);
            ref TArg11 arg11 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg11>(), start);
            ref TArg12 arg12 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg12>(), start);
            ref TArg13 arg13 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg13>(), start);


            for (int i = length - 1; i >= 0; i--)
            {
                comp.Update(ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6, ref arg7, ref arg8, ref arg9,
                    ref arg10, ref arg11, ref arg12, ref arg13);

                comp = ref Unsafe.Add(ref comp, 1);
                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
                arg4 = ref Unsafe.Add(ref arg4, 1);
                arg5 = ref Unsafe.Add(ref arg5, 1);
                arg6 = ref Unsafe.Add(ref arg6, 1);
                arg7 = ref Unsafe.Add(ref arg7, 1);
                arg8 = ref Unsafe.Add(ref arg8, 1);
                arg9 = ref Unsafe.Add(ref arg9, 1);
                arg10 = ref Unsafe.Add(ref arg10, 1);
                arg11 = ref Unsafe.Add(ref arg11, 1);
                arg12 = ref Unsafe.Add(ref arg12, 1);
                arg13 = ref Unsafe.Add(ref arg13, 1);
            }
        }

        
    }
}