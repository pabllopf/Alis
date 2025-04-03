





namespace Alis.Core.Ecs.Operations
{
    public static partial class QueryDelegates
    {

        public delegate void Query<T1, T2>(ref T1 comp1, ref T2 comp2);

    }
}