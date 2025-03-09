using Alis.Benchmark.ECS.Others.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.CreateEntityWithOneComponent
{
    public partial class CreateEntityWithOneComponent
    {
        [Context]
        private readonly LeopotamEcsLiteBaseContext _leopotamEcsLite;

        [BenchmarkCategory(Categories.LeopotamEcsLite)]
        [Benchmark]
        public void LeopotamEcsLite()
        {
            EcsPool<LeopotamEcsLiteBaseContext.Component1> c1 = _leopotamEcsLite.World.GetPool<LeopotamEcsLiteBaseContext.Component1>();

            for (int i = 0; i < EntityCount; ++i)
            {
                c1.Add(_leopotamEcsLite.World.NewEntity());
            }
        }
    }
}
