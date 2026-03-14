using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// Additional GameObject API coverage for methods that had no direct unit tests.
    /// </summary>
    public class GameObjectMissingCoverageTest
    {
        [Fact]
        public void GameObject_TryGetCore_WhenComponentExists_ReturnsWritableReference()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            Ref<Position> positionRef = entity.TryGetCore<Position>(out bool exists);
            positionRef.Value.X = 10;
            positionRef.Value.Y = 20;

            Assert.True(exists);
            Assert.Equal(10, entity.Get<Position>().X);
            Assert.Equal(20, entity.Get<Position>().Y);
        }

        [Fact]
        public void GameObject_TryGetCore_WhenComponentMissing_ReturnsExistsFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            Ref<Velocity> _ = entity.TryGetCore<Velocity>(out bool exists);

            Assert.False(exists);
        }

        [Fact]
        public void GameObject_TryGetCore_WhenEntityDeleted_ReturnsExistsFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            Ref<Position> _ = entity.TryGetCore<Position>(out bool exists);

            Assert.False(exists);
        }

        [Fact]
        public void GameObject_ThrowEntityIsDead_ThrowsInvalidOperationExceptionWithExpectedMessage()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(GameObject.Throw_EntityIsDead);

            Assert.Equal(GameObject.EntityIsDeadMessage, ex.Message);
        }

        [Fact]
        public void GameObject_InitalizeEventRecord_WithOnDeleteHandler_ThenDelete_ThrowsKeyNotFoundException_CurrentBehavior()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            Action<GameObject> handler = _ => { };

            entity.InitalizeEventRecord(handler, GameObjectFlags.OnDelete);

            Assert.True(scene.EntityTable[entity.EntityID].HasEvent(GameObjectFlags.OnDelete));

            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => entity.Delete());
        }

        [Fact]
        public void GameObject_UnsubscribeEvent_WhenInitializedDirectlyWithoutLookup_ThrowsKeyNotFoundException_CurrentBehavior()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            Action<GameObject> handler = _ => { };

            entity.InitalizeEventRecord(handler, GameObjectFlags.OnDelete);
            Assert.True(scene.EntityTable[entity.EntityID].HasEvent(GameObjectFlags.OnDelete));

            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(
                () => entity.UnsubscribeEvent(handler, GameObjectFlags.OnDelete));
        }

        [Fact]
        public void GameObject_UnsubscribeEvent_WithNullOrDeadEntity_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            Action<GameObject> handler = _ => { };

            Exception exNull = Record.Exception(() => entity.UnsubscribeEvent(null, GameObjectFlags.OnDelete));
            entity.Delete();
            Exception exDead = Record.Exception(() => entity.UnsubscribeEvent(handler, GameObjectFlags.OnDelete));

            Assert.Null(exNull);
            Assert.Null(exDead);
        }

        [Fact]
        public void GameObject_InitalizeEventRecord_WithNullOrDeadEntity_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            Action<GameObject> handler = _ => { };

            Exception exNull = Record.Exception(() => entity.InitalizeEventRecord(null, GameObjectFlags.OnDelete));
            entity.Delete();
            Exception exDead = Record.Exception(() => entity.InitalizeEventRecord(handler, GameObjectFlags.OnDelete));

            Assert.Null(exNull);
            Assert.Null(exDead);
        }

        [Fact]
        public void GameObject_OnComponentGenericProperties_OnDeadEntity_ReturnNull()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            Assert.Null(entity.OnComponentAddedGeneric);
            Assert.Null(entity.OnComponentRemovedGeneric);
        }
    }
}

