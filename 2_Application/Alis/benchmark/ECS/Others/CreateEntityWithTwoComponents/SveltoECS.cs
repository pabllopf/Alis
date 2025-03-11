﻿using Alis.Benchmark.ECS.Others.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.CreateEntityWithTwoComponents
{
    public partial class CreateEntityWithTwoComponents
    {
        private sealed class SveltoEntity : GenericEntityDescriptor<SveltoECSBaseContext.Component1, SveltoECSBaseContext.Component2>
        { }

        [Context]
        private readonly SveltoECSBaseContext _sveltoECS;

        [BenchmarkCategory(Categories.SveltoECS)]
        [Benchmark]
        public void SveltoECS()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _sveltoECS.Factory.BuildEntity<SveltoEntity>((uint)i, SveltoECSBaseContext.Group);
            }

            _sveltoECS.Scheduler.SubmitEntities();
        }
    }
}
