using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    /// The entity update coverage test class
    /// </summary>
    public class EntityUpdateCoverageTest
    {
        /// <summary>
        ///     Constructor_CreatesInstance
        /// </summary>
        [Fact] public void Constructor_CreatesInstance()
        {
            EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5> update =
                new EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>(8);

            Assert.NotNull(update);
        }

        /// <summary>
        ///     Constructor_ZeroCapacity_CreatesInstance
        /// </summary>
        [Fact] public void Constructor_ZeroCapacity_CreatesInstance()
        {
            EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5> update =
                new EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>(0);

            Assert.NotNull(update);
        }

        /// <summary>
        ///     Constructor_NegativeCapacity_ThrowsOverflowException
        /// </summary>
        [Fact] public void Constructor_NegativeCapacity_ThrowsOverflowException()
        {
            Assert.Throws<System.OverflowException>(() =>
                new EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>(-1));
        }

        /// <summary>
        ///     AsSpan_ReturnsSpan
        /// </summary>
        [Fact] public void AsSpan_ReturnsSpan()
        {
            EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5> update =
                new EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>(8);

            System.Span<StubComp> span = update.AsSpan();

            Assert.Equal(8, span.Length);
        }

        /// <summary>
        ///     AsSpanLength_ReturnsSpanWithSpecifiedLength
        /// </summary>
        [Fact] public void AsSpanLength_ReturnsSpanWithSpecifiedLength()
        {
            EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5> update =
                new EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>(8);

            System.Span<StubComp> span = update.AsSpanLength(4);

            Assert.Equal(4, span.Length);
        }

        /// <summary>
        ///     GetComponentStorageDataReference_ReturnsReference
        /// </summary>
        [Fact] public void GetComponentStorageDataReference_ReturnsReference()
        {
            EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5> update =
                new EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>(8);

            ref StubComp comp = ref update.GetComponentStorageDataReference();
        }

        /// <summary>
        ///     Indexer_Get_Set_Works
        /// </summary>
        [Fact] public void Indexer_Get_Set_Works()
        {
            EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5> update =
                new EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>(8);

            StubComp value = new StubComp();
            update[0] = value;
            ref StubComp result = ref update[0];
        }

        /// <summary>
        ///     Dispose_DoesNotThrow
        /// </summary>
        [Fact] public void Dispose_DoesNotThrow()
        {
            EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5> update =
                new EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>(8);

            update.Dispose();
        }

        /// <summary>
        ///     Run_WithEmptyArchetype_ThrowsComponentNotFound
        /// </summary>
        [Fact] public void Run_WithEmptyArchetype_ThrowsComponentNotFound()
        {
            using (Scene scene = new Scene())
            {
                Archetype archetype = new Archetype(default, [], false);

                EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5> update =
                    new EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>(8);

                Assert.Throws<ComponentNotFoundException>(() => update.Run(scene, archetype));
            }
        }

        /// <summary>
        ///     Run_WithStartAndLength_ThrowsComponentNotFound
        /// </summary>
        [Fact] public void Run_WithStartAndLength_ThrowsComponentNotFound()
        {
            using (Scene scene = new Scene())
            {
                Archetype archetype = new Archetype(default, [], false);

                EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5> update =
                    new EntityUpdate<StubComp, StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>(8);

                Assert.Throws<ComponentNotFoundException>(() => update.Run(scene, archetype, 0, 0));
            }
        }
    }

    /// <summary>
    /// The stub comp
    /// </summary>
    internal struct StubComp : IOnUpdate<StubArg1, StubArg2, StubArg3, StubArg4, StubArg5>
    {
        /// <summary>
        ///     Update
        /// </summary>
        public void Update(IGameObject self, ref StubArg1 arg1, ref StubArg2 arg2, ref StubArg3 arg3, ref StubArg4 arg4, ref StubArg5 arg5)
        {
        }
    }

    /// <summary>
    /// The stub arg
    /// </summary>
    internal struct StubArg1 { }
    /// <summary>
    /// The stub arg
    /// </summary>
    internal struct StubArg2 { }
    /// <summary>
    /// The stub arg
    /// </summary>
    internal struct StubArg3 { }
    /// <summary>
    /// The stub arg
    /// </summary>
    internal struct StubArg4 { }
    /// <summary>
    /// The stub arg
    /// </summary>
    internal struct StubArg5 { }
}
