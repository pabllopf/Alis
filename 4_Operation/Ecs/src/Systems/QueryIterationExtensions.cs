using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    /// The query iteration extensions class
    /// </summary>
    public static partial class QueryIterationExtensions
    {
        /// <summary>
        ///     Executes a delegate for every gameObject in a query, using the specified component types.
        /// </summary>
        /// <param name="query">The query to iterate over.</param>
        /// <param name="action">The behavior to execute on every component set.</param>
        public static void Delegate<T>(this Query query, QueryDelegates.Query<T> action)
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T c1 = ref archetype.GetComponentDataReference<T>();

                //downcounting is faster
                for (nint i = archetype.EntityCount - 1; i >= 0; i--)
                {
                    action(ref c1);

                    c1 = ref Unsafe.Add(ref c1, 1);
                }
            }
        }

        /// <summary>
        ///     Executes a inlinable struct instance method for every gameObject in a query, using the specified component types.
        /// </summary>
        /// <param name="query">The query to iterate over.</param>
        /// <param name="action">The struct behavior to execute on every component set.</param>
        public static void Inline<TAction, T>(this Query query, TAction action)
            where TAction : IAction<T>
        {
            foreach (Archetype archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T c1 = ref archetype.GetComponentDataReference<T>();

                for (nint i = archetype.EntityCount - 1; i >= 0; i--)
                {
                    action.Run(ref c1);

                    c1 = ref Unsafe.Add(ref c1, 1);
                }
            }
        }
    }
}