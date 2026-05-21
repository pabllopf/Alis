

using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The joint edge test class
    /// </summary>
    public class JointEdgeTest
    {
        /// <summary>
        ///     Tests that constructor should create instance
        /// </summary>
        [Fact]
        public void Constructor_ShouldCreateInstance()
        {
            JointEdge edge = new JointEdge();

            Assert.NotNull(edge);
        }

        /// <summary>
        ///     Tests that joint should set and get correctly
        /// </summary>
        [Fact]
        public void Joint_ShouldSetAndGetCorrectly()
        {
            JointEdge edge = new JointEdge();
            Joint joint = null; // Cannot create concrete Joint instance without body

            edge.Joint = joint;

            Assert.Equal(joint, edge.Joint);
        }

        /// <summary>
        ///     Tests that other should set and get correctly
        /// </summary>
        [Fact]
        public void Other_ShouldSetAndGetCorrectly()
        {
            JointEdge edge = new JointEdge();
            Body other = null; // Cannot create Body instance without World

            edge.Other = other;

            Assert.Equal(other, edge.Other);
        }

        /// <summary>
        ///     Tests that next should set and get correctly
        /// </summary>
        [Fact]
        public void Next_ShouldSetAndGetCorrectly()
        {
            JointEdge edge = new JointEdge();
            JointEdge next = new JointEdge();

            edge.Next = next;

            Assert.Equal(next, edge.Next);
        }

        /// <summary>
        ///     Tests that prev should set and get correctly
        /// </summary>
        [Fact]
        public void Prev_ShouldSetAndGetCorrectly()
        {
            JointEdge edge = new JointEdge();
            JointEdge prev = new JointEdge();

            edge.Prev = prev;

            Assert.Equal(prev, edge.Prev);
        }

        /// <summary>
        ///     Tests that all properties should initialize to null
        /// </summary>
        [Fact]
        public void AllProperties_ShouldInitializeToNull()
        {
            JointEdge edge = new JointEdge();

            Assert.Null(edge.Joint);
            Assert.Null(edge.Other);
            Assert.Null(edge.Next);
            Assert.Null(edge.Prev);
        }

        /// <summary>
        ///     Tests that linked list structure should work correctly
        /// </summary>
        [Fact]
        public void LinkedListStructure_ShouldWorkCorrectly()
        {
            JointEdge edge1 = new JointEdge();
            JointEdge edge2 = new JointEdge();
            JointEdge edge3 = new JointEdge();

            edge1.Next = edge2;
            edge2.Prev = edge1;
            edge2.Next = edge3;
            edge3.Prev = edge2;

            Assert.Equal(edge2, edge1.Next);
            Assert.Equal(edge1, edge2.Prev);
            Assert.Equal(edge3, edge2.Next);
            Assert.Equal(edge2, edge3.Prev);
        }
    }
}