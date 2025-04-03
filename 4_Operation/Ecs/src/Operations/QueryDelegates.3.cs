



namespace Alis.Core.Ecs.Operations
{
    public static partial class QueryDelegates
    {

        public delegate void Query<T1, T2, T3>(ref T1 comp1, ref T2 comp2, ref T3 comp3);

    }
}