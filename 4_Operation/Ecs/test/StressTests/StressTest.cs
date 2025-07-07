using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Test.Helpers;
using Alis;
using Alis.Core;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.StressTests
    {
        /// <summary>
        /// The stress test class
        /// </summary>
        public class StressTest
        {
            /// <summary>
            /// Tests that test
            /// </summary>
            /// <param name="seed">The seed</param>
            [Theory]
            [InlineData(0)]
            [InlineData(1)]
            [InlineData(2)]
            [InlineData(3)]
            [InlineData(4)]
            [InlineData(5)]
            [InlineData(6)]
            [InlineData(7)]
            [InlineData(8)]
            [InlineData(9)]
            [InlineData(10)]
            public void Test(int seed)
            {
                const int Steps = 10_000;
                using WorldState state = new WorldState(seed);
    
                for (int i = 0; i < Steps; i++)
                {
                    state.Advance();
                }
            }
        }
    

    /// <summary>
    /// The scene state class
    /// </summary>
    /// <seealso cref="IDisposable"/>
    internal class WorldState : IDisposable
    {
        // Actions:
        // [x] Create
        // [x] Delete
        // [x] Add
        // [x] Remove
        // [ ] Tag
        // [ ] Detach

        /// <summary>
        /// The all deleted entities
        /// </summary>
        private readonly List<GameObject> _allDeletedEntities = [];
        /// <summary>
        /// The component values
        /// </summary>
        private readonly Dictionary<GameObject, List<ComponentHandle>> _componentValues = [];
        /// <summary>
        /// The synced scene
        /// </summary>
        private readonly Scene _syncedScene;
        /// <summary>
        /// The random
        /// </summary>
        private readonly Random _random;
        /// <summary>
        /// The create
        /// </summary>
        private readonly MethodInfo[] _create;
        /// <summary>
        /// The everything query
        /// </summary>
        private readonly Query _everythingQuery;
        /// <summary>
        /// The to array
        /// </summary>
        private readonly int[] _shared = Enumerable.Range(0, 6).ToArray();
        /// <summary>
        /// The rng
        /// </summary>
        private readonly (ComponentId ID, Func<Random, ComponentHandle> Factory)[] _sharedIDs = [
            (Component<C1>.Id, (rng) => ComponentHandle.Create(new C1(rng))), 
            (Component<C2>.Id, (rng) => ComponentHandle.Create(new C2(rng))), 
            (Component<C3>.Id, (rng) => ComponentHandle.Create(new C3(rng))), 
            (Component<S1>.Id, (rng) => ComponentHandle.Create(new S1(rng))), 
            (Component<S2>.Id, (rng) => ComponentHandle.Create(new S2(rng))), 
            (Component<S3>.Id, (rng) => ComponentHandle.Create(new S3(rng)))];

        /// <summary>
        /// The actions
        /// </summary>
        private readonly List<StressTestAction> _actions = [];

        /// <summary>
        /// The unqiue component types
        /// </summary>
        private const int UnqiueComponentTypes = 6;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldState"/> class
        /// </summary>
        /// <param name="seed">The seed</param>
        public WorldState(int seed)
        {
            _syncedScene = new();
            _everythingQuery = _syncedScene.CustomQuery();
            _random = new Random(seed);
            _create = typeof(Scene)
                .GetMethods()
                .Where(m => m.Name == "Create" && m.IsGenericMethod)
                .OrderBy(m => m.GetParameters().Length)
                .ToArray();
        }

        /// <summary>
        /// Advances this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Advance()
        {
            switch(_random.Next(6))
            {
                case 0: CreateEntity(); break;
                case 1: DeleteEntity(); break;
                case 2: AddComponent(); break;
                case 3: RemoveComponent(); break;
                case 4: break;
                case 5: break;

                default: throw new NotImplementedException();
            }

            EnsureStateConsisstent();
        }

        /// <summary>
        /// Deletes the gameObject
        /// </summary>
        public void DeleteEntity()
        {
            if(_componentValues.Count > 0)
            {
                (GameObject entity, List<ComponentHandle> handles) = GetRandomExistingEntity();

                entity.Delete();
                _allDeletedEntities.Add(entity);
                foreach(var handle in handles)
                    handle.Dispose();

                _componentValues.Remove(entity);

                _actions.Add(new StressTestAction(StressTestActionType.Delete, entity));
            }
        }

        /// <summary>
        /// Creates the gameObject
        /// </summary>
        public void CreateEntity()
        {
            int componentCount = _random.Next(UnqiueComponentTypes) + 1;
            object[] componentParams = new object[componentCount];
            _random.Shuffle(_sharedIDs);

            for(int i = 0; i < componentCount; i++)
            {
                using var handle = _sharedIDs[i].Factory(_random);
                componentParams[i] = handle.RetrieveBoxed();
            }
        
            var entity = (_random.Next() & 1) == 0 ? CreateGeneric(componentParams) : CreateBoxed(componentParams);

            Type[] componentTypes = componentParams.Select(p => p.GetType()).ToArray();

            _actions.Add(new StressTestAction(StressTestActionType.Create, entity, componentTypes));
        }

        /// <summary>
        /// Removes the component
        /// </summary>
        public void RemoveComponent()
        {
            if (_componentValues.Count == 0)
                return;
            (GameObject entity, List<ComponentHandle> handles) = GetRandomExistingEntity();
            if(handles.Count == 0)
                return;

            using var compHandleToRemove = handles[_random.Next(handles.Count)];
            entity.Remove(compHandleToRemove.ComponentId);
            handles.Remove(compHandleToRemove);

            _actions.Add(new StressTestAction(StressTestActionType.Remove, entity, compHandleToRemove.Type));
        }

        /// <summary>
        /// Adds the component
        /// </summary>
        public void AddComponent()
        {
            if (_componentValues.Count == 0)
                return;
            (GameObject entity, List<ComponentHandle> handles) = GetRandomExistingEntity();
            if(handles.Count == UnqiueComponentTypes)
                return;
            _random.Shuffle(_sharedIDs);
            foreach(var (id, fac) in _sharedIDs)
            {
                if(!entity.Has(id))
                {
                    var handle = fac(_random);
                    entity.AddAs(handle.Type, handle.RetrieveBoxed());
                    handles.Add(handle);
                    _actions.Add(new StressTestAction(StressTestActionType.Add, entity, handle.Type));
                    break;
                }
            }

        }



        /// <summary>
        /// Gets the random existing gameObject
        /// </summary>
        /// <returns>An gameObject gameObject and list of component handle handles</returns>
        private (GameObject Entity, List<ComponentHandle> Handles) GetRandomExistingEntity()
        {
            var kvp = _componentValues.ElementAt(_random.Next(_componentValues.Count));
            return (kvp.Key, kvp.Value);
        }

       /// <summary>
       /// Crea una entidad genérica usando los objetos especificados
       /// </summary>
       /// <param name="objects">Los objetos</param>
       /// <returns>La entidad</returns>
       private GameObject CreateGeneric(params object[] objects)
       {
           Type[] types = objects.Select(o => o.GetType()).ToArray();
           MethodInfo m = _create[objects.Length - 1].MakeGenericMethod(types);
           object boxedEntity = m.Invoke(_syncedScene, objects);
           Assert.NotNull(boxedEntity);
           var entity = (GameObject)boxedEntity!;
       
           List<ComponentHandle> handles = new(objects.Length);
       
           foreach (var comp in objects)
               handles.Add(ComponentHandle.CreateFromBoxed(comp));
       
           _componentValues.Add(entity, handles);
       
           return entity;
       }

        /// <summary>
        /// Creates the boxed using the specified objects
        /// </summary>
        /// <param name="objects">The objects</param>
        /// <returns>The gameObject</returns>
        private GameObject CreateBoxed(params object[] objects)
        {
            var entity =_syncedScene.CreateFromObjects(objects);
            List<ComponentHandle> handles = new(objects.Length);

            foreach(var comp in objects)
                handles.Add(ComponentHandle.CreateFromBoxed(comp));
        
            _componentValues.Add(entity, handles);
            return entity;
        }
    
        /// <summary>
        /// Asegura que el estado sea consistente
        /// </summary>
        private void EnsureStateConsisstent()
        {
            Assert.All(_allDeletedEntities, e => Assert.False(e.IsAlive));
            foreach ((GameObject entity, List<ComponentHandle> components) in _componentValues)
            {
                Assert.True(entity.IsAlive);
                Assert.False(entity.IsNull);
                foreach (var comp in components)
                {
                    var exp = comp.RetrieveBoxed();
                    var res = entity.Get(comp.ComponentId);
                    if (res is null)
                        continue;
                    Assert.Equal(exp, res);
                    Assert.True(entity.Has(comp.ComponentId));
                }
            }
        
            int entityCount = _everythingQuery.EntityCount();
            Assert.Equal(_componentValues.Count, entityCount);
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _syncedScene.Dispose();
        }



        /// <summary>
        /// The 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct S1(Random Random)
        {
            /// <summary>
            /// The next
            /// </summary>
            public int Value = Random.Next();
            /// <summary>
            /// Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }
        /// <summary>
        /// The 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct S2(Random Random)
        {
            /// <summary>
            /// The next
            /// </summary>
            public int Value = Random.Next();
            /// <summary>
            /// Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }
        /// <summary>
        /// The 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct S3(Random Random)
        {
            /// <summary>
            /// The next
            /// </summary>
            public int Value = Random.Next();
            /// <summary>
            /// Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }

        /// <summary>
        /// The  class
        /// </summary>
        internal class C1(Random Random)
        {
            /// <summary>
            /// The next
            /// </summary>
            public int Value = Random.Next();
            /// <summary>
            /// Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }
        /// <summary>
        /// The  class
        /// </summary>
        internal class C2(Random Random)
        {
            /// <summary>
            /// The next
            /// </summary>
            public int Value = Random.Next();
            /// <summary>
            /// Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }
        /// <summary>
        /// The  class
        /// </summary>
        internal class C3(Random Random)
        {
            /// <summary>
            /// The next
            /// </summary>
            public int Value = Random.Next();
            /// <summary>
            /// Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct StressTestAction(StressTestActionType Type, GameObject GameObject, params Type[] ComponentType);

        /// <summary>
        /// The stress test action type enum
        /// </summary>
        public enum StressTestActionType
        {
            /// <summary>
            /// The create stress test action type
            /// </summary>
            Create,
            /// <summary>
            /// The delete stress test action type
            /// </summary>
            Delete,
            /// <summary>
            /// The add stress test action type
            /// </summary>
            Add,
            /// <summary>
            /// The remove stress test action type
            /// </summary>
            Remove,
            /// <summary>
            /// The tag stress test action type
            /// </summary>
            Tag,
            /// <summary>
            /// The detach stress test action type
            /// </summary>
            Detach,
        }
    }
}