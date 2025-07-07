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
        public static void Delegate<T1, T2, T3, T4>(this Query query, QueryDelegates.Query<T1, T2, T3, T4> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();


                //downcounting is faster
                for (nint i = archetype.EntityCount - 1; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3, ref c4);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                }
            }
        }

        /// <summary>
        ///     Executes a inlinable struct instance method for every gameObject in a query, using the specified component types.
        /// </summary>
        /// <param name="query">The query to iterate over.</param>
        /// <param name="action">The struct behavior to execute on every component set.</param>
        public static void Inline<TAction, T1, T2, T3, T4>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3, T4>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();
                ref T4 c4 = ref archetype.GetComponentDataReference<T4>();


                for (nint i = archetype.EntityCount - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3, ref c4);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                    c4 = ref Unsafe.Add(ref c4, 1);
                }
            }
        }
    }
}