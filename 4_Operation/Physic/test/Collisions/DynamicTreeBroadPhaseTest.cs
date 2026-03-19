using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class DynamicTreeBroadPhaseTest
    {
        [Fact]
        public void AddProxy_SetProxy_GetProxy_ShouldRoundTripUserData()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabb = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(1.0f, 1.0f));

            int proxyId = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(proxyId, ref proxyId);

            Assert.Equal(1, broadPhase.ProxyCount);
            Assert.Equal(proxyId, broadPhase.GetProxy(proxyId));
        }

        [Fact]
        public void UpdatePairs_ShouldReportOverlapPair()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(1.0f, 1.0f), new Vector2F(3.0f, 3.0f));

            int proxyA = broadPhase.AddProxy(ref aabbA);
            int proxyB = broadPhase.AddProxy(ref aabbB);
            broadPhase.SetProxy(proxyA, ref proxyA);
            broadPhase.SetProxy(proxyB, ref proxyB);

            List<(int, int)> pairs = new List<(int, int)>();
            broadPhase.UpdatePairs((idA, idB) => pairs.Add((idA, idB)));

            Assert.Contains((proxyA < proxyB ? proxyA : proxyB, proxyA < proxyB ? proxyB : proxyA), pairs);
        }

        [Fact]
        public void Query_ShouldReturnOverlappingProxyIds()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(10.0f, 10.0f), new Vector2F(12.0f, 12.0f));
            int proxyA = broadPhase.AddProxy(ref aabbA);
            int proxyB = broadPhase.AddProxy(ref aabbB);

            Aabb query = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(3.0f, 3.0f));
            List<int> hits = new List<int>();
            broadPhase.Query(id =>
            {
                hits.Add(id);
                return true;
            }, ref query);

            Assert.Contains(proxyA, hits);
            Assert.DoesNotContain(proxyB, hits);
        }
    }
}

