

using System;
using System.Collections.Generic;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests for InvokePerEntityEvents<...> methods (arities 1..3).
    /// </summary>
    public class GameObjectInvokePerEntityEventsTest
    {
        /// <summary>
        ///     Tests that invoke per entity events arity 1 invokes generic event
        /// </summary>
        [Fact]
        public void InvokePerEntityEvents_Arity1_InvokesGenericEvent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 5, Y = 15});

            CaptureGenericAction captureAction = new CaptureGenericAction();
            entity.OnComponentAddedGeneric += captureAction;

            entity.Add(new Health {Value = 50});

            Assert.True(entity.Has<Health>());
            Assert.Contains(typeof(Health), captureAction.SeenTypes);
        }


        /// <summary>
        ///     Tests that invoke per entity events arity 2 invokes generic events for both
        /// </summary>
        [Fact]
        public void InvokePerEntityEvents_Arity2_InvokesGenericEventsForBoth()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            CaptureGenericAction captureAction = new CaptureGenericAction();
            entity.OnComponentAddedGeneric += captureAction;

            entity.Add(new Velocity {X = 3, Y = 4});
            entity.Add(new Health {Value = 1});

            Assert.Contains(typeof(Velocity), captureAction.SeenTypes);
            Assert.Contains(typeof(Health), captureAction.SeenTypes);
        }


        /// <summary>
        ///     The capture generic action class
        /// </summary>
        private sealed class CaptureGenericAction : IGenericAction<GameObject>
        {
            /// <summary>
            ///     Gets the seen types
            /// </summary>
            internal HashSet<Type> SeenTypes { get; } = new HashSet<Type>();

            /// <summary>
            ///     Invokes the specified param with generic type
            /// </summary>
            public void Invoke<T>(GameObject param, ref T type)
            {
                SeenTypes.Add(typeof(T));
            }
        }
    }
}