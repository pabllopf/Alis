using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class EntityUpdate<TComp, TArg1, TArg2, TArg3, TArg4, TArg5>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IGameObjectComponent<TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref GameObjectIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();
            ref TArg3 arg3 = ref b.GetComponentDataReference<TArg3>();
            ref TArg4 arg4 = ref b.GetComponentDataReference<TArg4>();
            ref TArg5 arg5 = ref b.GetComponentDataReference<TArg5>();


            GameObject gameObject = scene.DefaultWorldGameObject;

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);

                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
                arg4 = ref Unsafe.Add(ref arg4, 1);
                arg5 = ref Unsafe.Add(ref arg5, 1);
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
            ref GameObjectIdOnly entityIds = ref Unsafe.Add(ref b.GetEntityDataReference(), start);
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start);
            ref TArg2 arg2 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg2>(), start);
            ref TArg3 arg3 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg3>(), start);
            ref TArg4 arg4 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg4>(), start);
            ref TArg5 arg5 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg5>(), start);


            GameObject gameObject = scene.DefaultWorldGameObject;

            for (int i = length - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);

                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
                arg4 = ref Unsafe.Add(ref arg4, 1);
                arg5 = ref Unsafe.Add(ref arg5, 1);
            }
        }
    }
}