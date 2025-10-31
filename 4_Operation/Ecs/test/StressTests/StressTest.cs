// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StressTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Helpers;
using Xunit;

namespace Alis.Core.Ecs.Test.StressTests
{
    /// <summary>
    ///     The stress test class
    /// </summary>
    public class StressTest
    {
        /// <summary>
        ///     Tests that test
        /// </summary>
        /// <param name="seed">The seed</param>
        [Theory, InlineData(0), InlineData(1), InlineData(2), InlineData(3), InlineData(4), InlineData(5), InlineData(6), InlineData(7), InlineData(8), InlineData(9), InlineData(10)]
        public void Test(int seed)
        {
            const int Steps = 10_000;

            using (WorldState state = new WorldState(seed))
            {
                for (int i = 0; i < Steps; i++)
                {
                    state.Advance();
                }
            }
        }
    }


    /// <summary>
    ///     The scene state class
    /// </summary>
    /// <seealso cref="IDisposable" />
    internal class WorldState : IDisposable
    {
        /// <summary>
        ///     The stress test action type enum
        /// </summary>
        public enum StressTestActionType
        {
            /// <summary>
            ///     The create stress test action type
            /// </summary>
            Create,

            /// <summary>
            ///     The delete stress test action type
            /// </summary>
            Delete,

            /// <summary>
            ///     The add stress test action type
            /// </summary>
            Add,

            /// <summary>
            ///     The remove stress test action type
            /// </summary>
            Remove,

            /// <summary>
            ///     The tag stress test action type
            /// </summary>
            Tag,

            /// <summary>
            ///     The detach stress test action type
            /// </summary>
            Detach
        }

        /// <summary>
        ///     The unqiue component types
        /// </summary>
        private const int UnqiueComponentTypes = 6;

        /// <summary>
        ///     The actions
        /// </summary>
        private readonly List<StressTestAction> _actions = [];
        
        /// <summary>
        ///     The all deleted entities
        /// </summary>
        private readonly List<GameObject> _allDeletedEntities = [];

        /// <summary>
        ///     The component values
        /// </summary>
        private readonly Dictionary<GameObject, List<ComponentHandle>> _componentValues = [];

        /// <summary>
        ///     The create
        /// </summary>
        private readonly MethodInfo[] _create;

        /// <summary>
        ///     The everything query
        /// </summary>
        private readonly Query _everythingQuery;

        /// <summary>
        ///     The random
        /// </summary>
        private readonly Random _random;

        /// <summary>
        ///     The to array
        /// </summary>
        private readonly int[] _shared = Enumerable.Range(0, 6).ToArray();

        /// <summary>
        ///     The rng
        /// </summary>
        private readonly (ComponentId ID, Func<Random, ComponentHandle> Factory)[] _sharedIDs =
        [
            (Component<C1>.Id, rng => ComponentHandle.Create(new C1(rng))),
            (Component<C2>.Id, rng => ComponentHandle.Create(new C2(rng))),
            (Component<C3>.Id, rng => ComponentHandle.Create(new C3(rng))),
            (Component<S1>.Id, rng => ComponentHandle.Create(new S1(rng))),
            (Component<S2>.Id, rng => ComponentHandle.Create(new S2(rng))),
            (Component<S3>.Id, rng => ComponentHandle.Create(new S3(rng)))
        ];

        /// <summary>
        ///     The synced scene
        /// </summary>
        private readonly Scene _syncedScene;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WorldState" /> class
        /// </summary>
        /// <param name="seed">The seed</param>
        public WorldState(int seed)
        {
            _syncedScene = new Scene();
            _everythingQuery = _syncedScene.CustomQuery();
            _random = new Random(seed);
            _create = typeof(Scene)
                .GetMethods()
                .Where(m => (m.Name == "Create") && m.IsGenericMethod)
                .OrderBy(m => m.GetParameters().Length)
                .ToArray();
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _syncedScene.Dispose();
        }

        /// <summary>
        ///     Advances this instance
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Advance()
        {
            switch (_random.Next(6))
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
        ///     Deletes the gameObject
        /// </summary>
        public void DeleteEntity()
        {
            if (_componentValues.Count > 0)
            {
                (GameObject entity, List<ComponentHandle> handles) = GetRandomExistingEntity();

                entity.Delete();
                _allDeletedEntities.Add(entity);
                foreach (ComponentHandle handle in handles)
                {
                    handle.Dispose();
                }

                _componentValues.Remove(entity);

                _actions.Add(new StressTestAction(StressTestActionType.Delete, entity));
            }
        }

        /// <summary>
        ///     Creates the gameObject
        /// </summary>
        public void CreateEntity()
        {
            int componentCount = _random.Next(UnqiueComponentTypes) + 1;
            object[] componentParams = new object[componentCount];
            _random.Shuffle(_sharedIDs);

            for (int i = 0; i < componentCount; i++)
            {
                using (ComponentHandle handle = _sharedIDs[i].Factory(_random))
                {
                    componentParams[i] = handle.RetrieveBoxed();
                }
            }

            GameObject entity = CreateBoxed(componentParams);

            Type[] componentTypes = componentParams.Select(p => p.GetType()).ToArray();

            _actions.Add(new StressTestAction(StressTestActionType.Create, entity, componentTypes));
        }

        /// <summary>
        ///     Removes the component
        /// </summary>
        public void RemoveComponent()
        {
            if (_componentValues.Count == 0)
            {
                return;
            }

            (GameObject entity, List<ComponentHandle> handles) = GetRandomExistingEntity();
            if (handles.Count == 0)
            {
                return;
            }

            using (ComponentHandle compHandleToRemove = handles[_random.Next(handles.Count)])
            {
                entity.Remove(compHandleToRemove.ComponentId);
                handles.Remove(compHandleToRemove);

                _actions.Add(new StressTestAction(StressTestActionType.Remove, entity, compHandleToRemove.Type));
            }
        }

        /// <summary>
        ///     Adds the component
        /// </summary>
        public void AddComponent()
        {
            if (_componentValues.Count == 0)
            {
                return;
            }

            (GameObject entity, List<ComponentHandle> handles) = GetRandomExistingEntity();
            if (handles.Count == UnqiueComponentTypes)
            {
                return;
            }

            _random.Shuffle(_sharedIDs);
            foreach ((ComponentId id, Func<Random, ComponentHandle> fac) in _sharedIDs)
            {
                if (!entity.Has(id))
                {
                    ComponentHandle handle = fac(_random);
                    entity.AddAs(handle.Type, handle.RetrieveBoxed());
                    handles.Add(handle);
                    _actions.Add(new StressTestAction(StressTestActionType.Add, entity, handle.Type));
                    break;
                }
            }
        }


        /// <summary>
        ///     Gets the random existing gameObject
        /// </summary>
        /// <returns>An gameObject gameObject and list of component handle handles</returns>
        private (GameObject Entity, List<ComponentHandle> Handles) GetRandomExistingEntity()
        {
            KeyValuePair<GameObject, List<ComponentHandle>> kvp = _componentValues.ElementAt(_random.Next(_componentValues.Count));
            return (kvp.Key, kvp.Value);
        }

        /// <summary>
        ///     Creates the boxed using the specified objects
        /// </summary>
        /// <param name="objects">The objects</param>
        /// <returns>The gameObject</returns>
        private GameObject CreateBoxed(params object[] objects)
        {
            GameObject entity = _syncedScene.CreateFromObjects(objects);
            List<ComponentHandle> handles = new List<ComponentHandle>(objects.Length);

            foreach (object comp in objects)
            {
                handles.Add(ComponentHandle.CreateFromBoxed(comp));
            }

            _componentValues.Add(entity, handles);
            return entity;
        }

        /// <summary>
        ///     Asegura que el estado sea consistente
        /// </summary>
        private void EnsureStateConsisstent()
        {
            Assert.All(_allDeletedEntities, e => Assert.False(e.IsAlive));
            foreach ((GameObject entity, List<ComponentHandle> components) in _componentValues)
            {
                Assert.True(entity.IsAlive);
                Assert.False(entity.IsNull);
                foreach (ComponentHandle comp in components)
                {
                    object exp = comp.RetrieveBoxed();
                    object res = entity.Get(comp.ComponentId);
                    if (res is null)
                    {
                        continue;
                    }

                    Assert.Equal(exp, res);
                    Assert.True(entity.Has(comp.ComponentId));
                }
            }

            int entityCount = _everythingQuery.EntityCount();
            Assert.Equal(_componentValues.Count, entityCount);
        }


        /// <summary>
        ///     The
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct S1(Random Random)
        {
            /// <summary>
            ///     The next
            /// </summary>
            public int Value = Random.Next();

            /// <summary>
            ///     Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }

        /// <summary>
        ///     The
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct S2(Random Random)
        {
            /// <summary>
            ///     The next
            /// </summary>
            public int Value = Random.Next();

            /// <summary>
            ///     Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }

        /// <summary>
        ///     The
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct S3(Random Random)
        {
            /// <summary>
            ///     The next
            /// </summary>
            public int Value = Random.Next();

            /// <summary>
            ///     Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }

        /// <summary>
        ///     The  class
        /// </summary>
        internal class C1(Random Random)
        {
            /// <summary>
            ///     The next
            /// </summary>
            public int Value = Random.Next();

            /// <summary>
            ///     Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }

        /// <summary>
        ///     The  class
        /// </summary>
        internal class C2(Random Random)
        {
            /// <summary>
            ///     The next
            /// </summary>
            public int Value = Random.Next();

            /// <summary>
            ///     Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }

        /// <summary>
        ///     The  class
        /// </summary>
        internal class C3(Random Random)
        {
            /// <summary>
            ///     The next
            /// </summary>
            public int Value = Random.Next();

            /// <summary>
            ///     Returns the string
            /// </summary>
            /// <returns>The string</returns>
            public override string ToString() => Value.ToString();
        }


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public record struct StressTestAction(StressTestActionType Type, GameObject GameObject, params Type[] ComponentType);
    }
}