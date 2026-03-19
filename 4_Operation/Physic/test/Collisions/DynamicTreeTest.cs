using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class DynamicTreeTest
    {
        [Fact]
        public void AddProxy_SetUserData_GetUserData_ShouldRoundTrip()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(1.0f, 1.0f));

            int proxyId = tree.AddProxy(ref aabb);
            tree.SetUserData(proxyId, 123);

            Assert.Equal(123, tree.GetUserData(proxyId));
            Assert.True(tree.Height >= 0);
        }

        [Fact]
        public void Query_ShouldReturnInsertedProxy()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            int proxyId = tree.AddProxy(ref aabb);
            tree.SetUserData(proxyId, 7);

            List<int> hits = new List<int>();
            tree.Query(id =>
            {
                hits.Add(id);
                return true;
            }, ref aabb);

            Assert.Contains(proxyId, hits);
        }

        [Fact]
        public void MoveProxy_ShouldReturnFalse_WhenNewAabbIsInsideFatAabb()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = tree.AddProxy(ref aabb);

            bool moved = tree.MoveProxy(proxyId, ref aabb, Vector2F.Zero);

            Assert.False(moved);
        }

        [Fact]
        public void RemoveProxy_ShouldKeepTreeOperational()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = tree.AddProxy(ref aabb);

            tree.RemoveProxy(proxyId);

            Assert.Equal(0, tree.Height);
        }
    }
}

