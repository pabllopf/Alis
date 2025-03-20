
using System.Runtime.CompilerServices;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    /// The query iteration extensions class
    /// </summary>
    public static partial class QueryIterationExtensions
    {
        /// <summary>
        /// Delegates the query
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Delegate<T>(this Query query, QueryDelegates.Query<T> action)
        {
            foreach (var archetype in query.AsSpan())
            {
                //use ref instead of span to avoid extra locals
                ref T c1 = ref archetype.GetComponentDataReference<T>();

                //downcounting is faster
                for (int i = archetype.EntityCount; i >= 0; i--)
                {
                    action(ref c1);

                    c1 = ref Unsafe.Add(ref c1, 1);
                }
            }
        }

        /// <summary>
        /// Inlines the query
        /// </summary>
        /// <typeparam name="TAction">The action</typeparam>
        /// <typeparam name="T">The </typeparam>
        /// <param name="query">The query</param>
        /// <param name="action">The action</param>
        public static void Inline<TAction, T>(this Query query, TAction action)
            where TAction : IAction<T>
        {
            foreach (var archetype in query.AsSpan())
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
