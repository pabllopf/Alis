using Alis.Benchmark.CustomEcs.Components;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Kernel;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomNeighborCache
{
    public partial class CustomNeighborCacheBenchmark
    {
        private static readonly GameObjectType _alisBaseType =
            GameObject.EntityTypeOf([Component<Component16>.Id]);

        private Scene _alisScene;
        private GameObject[] _alisEntities;

        private void SetupAlis()
        {
            _alisScene = new Scene();
            _alisScene.EnsureCapacity(_alisBaseType, EntityCount);

            _alisEntities = new GameObject[EntityCount];
            for (int i = 0; i < EntityCount; i++)
            {
                _alisEntities[i] = _alisScene.Create(default(Component16));
            }
        }

        private void DisposeAlis() => _alisScene.Dispose();

        [Benchmark]
        public void Alis_Neighbor_AddRemove()
        {
            switch (Arity)
            {
                case 1: RunAlis1(); break;
                case 2: RunAlis2(); break;
                case 3: RunAlis3(); break;
                case 4: RunAlis4(); break;
                case 5: RunAlis5(); break;
                case 6: RunAlis6(); break;
                case 7: RunAlis7(); break;
                default: RunAlis8(); break;
            }
        }

        private void RunAlis1()
        {
            for (int i = 0; i < _alisEntities.Length; i++)
            {
                GameObject entity = _alisEntities[i];
                entity.Add(default(Component1));
                entity.Remove<Component1>();
            }
        }

        private void RunAlis2()
        {
            for (int i = 0; i < _alisEntities.Length; i++)
            {
                GameObject entity = _alisEntities[i];
                entity.Add(default(Component1), default(Component2));
                entity.Remove<Component1, Component2>();
            }
        }

        private void RunAlis3()
        {
            for (int i = 0; i < _alisEntities.Length; i++)
            {
                GameObject entity = _alisEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3));
                entity.Remove<Component1, Component2, Component3>();
            }
        }

        private void RunAlis4()
        {
            for (int i = 0; i < _alisEntities.Length; i++)
            {
                GameObject entity = _alisEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4));
                entity.Remove<Component1, Component2, Component3, Component4>();
            }
        }

        private void RunAlis5()
        {
            for (int i = 0; i < _alisEntities.Length; i++)
            {
                GameObject entity = _alisEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5));
                entity.Remove<Component1, Component2, Component3, Component4, Component5>();
            }
        }

        private void RunAlis6()
        {
            for (int i = 0; i < _alisEntities.Length; i++)
            {
                GameObject entity = _alisEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5),
                    default(Component6));
                entity.Remove<Component1, Component2, Component3, Component4, Component5, Component6>();
            }
        }

        private void RunAlis7()
        {
            for (int i = 0; i < _alisEntities.Length; i++)
            {
                GameObject entity = _alisEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5),
                    default(Component6), default(Component7));
                entity.Remove<Component1, Component2, Component3, Component4, Component5, Component6, Component7>();
            }
        }

        private void RunAlis8()
        {
            for (int i = 0; i < _alisEntities.Length; i++)
            {
                GameObject entity = _alisEntities[i];
                entity.Add(default(Component1), default(Component2), default(Component3), default(Component4), default(Component5),
                    default(Component6), default(Component7), default(Component8));
                entity.Remove<Component1, Component2, Component3, Component4, Component5, Component6, Component7, Component8>();
            }
        }
    }
}

