using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Core.Archetype;

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
        public static void Delegate<T1, T2, T3>(this Query query, QueryDelegates.Query<T1, T2, T3> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();


                //downcounting is faster
                for (nint i = archetype.EntityCount - 1; i >= 0; i--)
                {
                    action(ref c1, ref c2, ref c3);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                }
            }
        }

        /// <summary>
        ///     Executes a inlinable struct instance method for every gameObject in a query, using the specified component types.
        /// </summary>
        /// <param name="query">The query to iterate over.</param>
        /// <param name="action">The struct behavior to execute on every component set.</param>
        public static void Inline<TAction, T1, T2, T3>(this Query query, TAction action)
            where TAction : IAction<T1, T2, T3>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T1 c1 = ref archetype.GetComponentDataReference<T1>();
                ref T2 c2 = ref archetype.GetComponentDataReference<T2>();
                ref T3 c3 = ref archetype.GetComponentDataReference<T3>();


                for (nint i = archetype.EntityCount - 1; i >= 0; i--)
                {
                    action.Run(ref c1, ref c2, ref c3);

                    c1 = ref Unsafe.Add(ref c1, 1);
                    c2 = ref Unsafe.Add(ref c2, 1);
                    c3 = ref Unsafe.Add(ref c3, 1);
                }
            }
        }
    }
}