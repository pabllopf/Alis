

using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact edge test class
    /// </summary>
    public class ContactEdgeTest
    {
        /// <summary>
        ///     Tests that constructor should create instance
        /// </summary>
        [Fact]
        public void Constructor_ShouldCreateInstance()
        {
            ContactEdge edge = new ContactEdge();

            Assert.NotNull(edge);
        }

        /// <summary>
        ///     Tests that contact should get correctly
        /// </summary>
        [Fact]
        public void Contact_ShouldGetCorrectly()
        {
            ContactEdge edge = new ContactEdge();

            Assert.Null(edge.Contact);
        }

        /// <summary>
        ///     Tests that other should get correctly
        /// </summary>
        [Fact]
        public void Other_ShouldGetCorrectly()
        {
            ContactEdge edge = new ContactEdge();

            Assert.Null(edge.Other);
        }

        /// <summary>
        ///     Tests that next should get correctly
        /// </summary>
        [Fact]
        public void Next_ShouldGetCorrectly()
        {
            ContactEdge edge = new ContactEdge();

            Assert.Null(edge.Next);
        }

        /// <summary>
        ///     Tests that prev should get correctly
        /// </summary>
        [Fact]
        public void Prev_ShouldGetCorrectly()
        {
            ContactEdge edge = new ContactEdge();

            Assert.Null(edge.Prev);
        }

        /// <summary>
        ///     Tests that all properties should initialize to null
        /// </summary>
        [Fact]
        public void AllProperties_ShouldInitializeToNull()
        {
            ContactEdge edge = new ContactEdge();

            Assert.Null(edge.Contact);
            Assert.Null(edge.Other);
            Assert.Null(edge.Next);
            Assert.Null(edge.Prev);
        }

        /// <summary>
        ///     Tests that contact edge should be sealed class
        /// </summary>
        [Fact]
        public void ContactEdge_ShouldBeSealedClass()
        {
            ContactEdge edge = new ContactEdge();

            Assert.IsType<ContactEdge>(edge);
        }

        /// <summary>
        ///     Tests that properties should have internal setters
        /// </summary>
        [Fact]
        public void Properties_ShouldHaveInternalSetters()
        {
            ContactEdge edge = new ContactEdge();

            Assert.Null(edge.Contact);
            Assert.Null(edge.Other);
            Assert.Null(edge.Next);
            Assert.Null(edge.Prev);
        }
    }
}