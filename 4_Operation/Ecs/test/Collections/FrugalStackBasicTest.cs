

using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The frugal stack basic test class
    /// </summary>
    /// <remarks>
    ///     Tests basic functionality of <see cref="FrugalStack{T}" /> which is a
    ///     memory-efficient stack implementation optimized for small collections.
    ///     The frugal stack uses lazy initialization and grows dynamically as needed.
    /// </remarks>
    public class FrugalStackBasicTest
    {
        /// <summary>
        ///     Tests that frugal stack can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that a FrugalStack can be instantiated with the default constructor.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanBeCreated()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Assert.NotNull(stack);
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that values can be pushed to frugal stack
        /// </summary>
        /// <remarks>
        ///     Validates that items can be added to the stack and the Any property reflects this.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanPushValues()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack initially has no elements
        /// </summary>
        /// <remarks>
        ///     Verifies that a newly created FrugalStack reports having no elements.
        /// </remarks>
        [Fact]
        public void FrugalStack_InitiallyEmpty()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can store reference types
        /// </summary>
        /// <remarks>
        ///     Validates that FrugalStack works correctly with reference type values.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanStoreReferenceTypes()
        {
            FrugalStack<string> stack = new FrugalStack<string>();

            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");

            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can store value types
        /// </summary>
        /// <remarks>
        ///     Verifies that FrugalStack handles value types correctly.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanStoreValueTypes()
        {
            FrugalStack<Position> stack = new FrugalStack<Position>();
            Position pos1 = new Position {X = 1, Y = 2};
            Position pos2 = new Position {X = 3, Y = 4};

            stack.Push(pos1);
            stack.Push(pos2);

            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can handle many pushes
        /// </summary>
        /// <remarks>
        ///     Validates that FrugalStack can grow dynamically to accommodate
        ///     many items beyond initial capacity.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanHandleManyPushes()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }

            Assert.True(stack.Any);
        }
    }
}