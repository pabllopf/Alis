using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel.Archetype;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The query iteration extensions class
    /// </summary>
    public static partial class QueryIterationExtensions
    {
        /// <summary>
        ///     Executes a delegate for every gameObject in a query, using the specified component types.
        /// </summary>
        /// <param name="query">The query to iterate over.</param>
        /// <param name="action">The behavior to execute on every component set.</param>
        public static void Delegate<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Query query,
            QueryDelegates.Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();
                ref T13 c13 = ref archetype.GetComponentDataReference<T13>();


                //downcounting is faster
                for (nint i = archetype.EntityCount - 1; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11,
                        ref c12, ref c13);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                    c13 = ref Unsafe.Add(ref c13, 1);
                }
            }
        }

        /// <summary>
        ///     Executes a inlinable struct instance method for every gameObject in a query, using the specified component types.
        /// </summary>
        /// <param name="query">The query to iterate over.</param>
        /// <param name="action">The struct behavior to execute on every component set.</param>
        public static void Inline<TAction, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Query query,
            TAction action)
            where TAction : IAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();
                ref T5 c5 = ref archetype.GetComponentDataReference<T5>();
                ref T6 c6 = ref archetype.GetComponentDataReference<T6>();
                ref T7 c7 = ref archetype.GetComponentDataReference<T7>();
                ref T8 c8 = ref archetype.GetComponentDataReference<T8>();
                ref T9 c9 = ref archetype.GetComponentDataReference<T9>();
                ref T10 c10 = ref archetype.GetComponentDataReference<T10>();
                ref T11 c11 = ref archetype.GetComponentDataReference<T11>();
                ref T12 c12 = ref archetype.GetComponentDataReference<T12>();
                ref T13 c13 = ref archetype.GetComponentDataReference<T13>();


                for (nint i = archetype.EntityCount - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8, ref c9, ref c10, ref c11,
                        ref c12, ref c13);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                    c5 = ref Unsafe.Add(ref c5, 1);
                    c6 = ref Unsafe.Add(ref c6, 1);
                    c7 = ref Unsafe.Add(ref c7, 1);
                    c8 = ref Unsafe.Add(ref c8, 1);
                    c9 = ref Unsafe.Add(ref c9, 1);
                    c10 = ref Unsafe.Add(ref c10, 1);
                    c11 = ref Unsafe.Add(ref c11, 1);
                    c12 = ref Unsafe.Add(ref c12, 1);
                    c13 = ref Unsafe.Add(ref c13, 1);
                }
            }
        }
    }
}