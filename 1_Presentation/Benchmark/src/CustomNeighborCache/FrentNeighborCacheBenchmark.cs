using Alis.Benchmark.CustomEcs.Components;
using BenchmarkDotNet.Attributes;
using Frent;
using Frent.Core;

namespace Alis.Benchmark.CustomNeighborCache
{
    public partial class CustomNeighborCacheBenchmark
    {
        private static readonly EntityType _frentBaseType =
            Entity.EntityTypeOf([Component<Component16>.ID], []);

        private World _frentWorld;
        private Entity[] _frentEntities;

        private void SetupFrent()
        {
            _frentWorld = new World();
            _frentWorld.EnsureCapacity(_frentBaseType, EntityCount);

            _frentEntities = new Entity[EntityCount];
            for (int i = 0; i < EntityCount; i++)
            {
                _frentEntities[i] = _frentWorld.Create(default(Component16));
            }
        }

        private void DisposeFrent() => _frentWorld.Dispose();

        [Benchmark(Baseline = true)]
        public void Frent_Neighbor_AddRemove()
        {
            switch (Arity)
            {
                case 1: RunFrent1(); break;
                case 2: RunFrent2(); break;
                case 3: RunFrent3(); break;
                case 4: RunFrent4(); break;
                case 5: RunFrent5(); break;
                case 6: RunFrent6(); break;
                case 7: RunFrent7(); break;
                default: RunFrent8(); break;
            }
        }

        private void RunFrent1()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1));
                entity.Remove<Component1>();
            }
        }

        private void RunFrent2()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2));
                entity.Remove<Component1, Component2>();
            }
        }

        private void RunFrent3()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3));
                entity.Remove<Component1, Component2, Component3>();
            }
        }

        private void RunFrent4()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4));
                entity.Remove<Component1, Component2, Component3, Component4>();
            }
        }

        private void RunFrent5()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5));
                entity.Remove<Component1, Component2, Component3, Component4, Component5>();
            }
        }

        private void RunFrent6()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5),
                    default(Component6));
                entity.Remove<Component1, Component2, Component3, Component4, Component5, Component6>();
            }
        }

        private void RunFrent7()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5),
                    default(Component6), default(Component7));
                entity.Remove<Component1, Component2, Component3, Component4, Component5, Component6, Component7>();
            }
        }

        private void RunFrent8()
        {
            for (int i = 0; i < _frentEntities.Length; i++)
            {
                Entity entity = _frentEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5),
                    default(Component6), default(Component7), default(Component8));
                entity.Remove<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8>();
            }
        }
    }
}

