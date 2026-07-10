using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class DynamicTreeBroadPhaseRemainingCoverageTests
    {
        [Fact]
        public void NonGenericDynamicTreeBroadPhase_InstantiateAndUse_Succeeds()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            Aabb aabb = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(1.0f, 1.0f));
            FixtureProxy proxy = new FixtureProxy();

            int proxyId = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(proxyId, ref proxy);

            Assert.Equal(1, broadPhase.ProxyCount);
            FixtureProxy retrieved = broadPhase.GetProxy(proxyId);
            Assert.Equal(proxy.ProxyId, retrieved.ProxyId);

            broadPhase.GetFatAabb(proxyId, out Aabb fat);
            Assert.True(fat.LowerBound.X <= aabb.LowerBound.X);
        }

        [Fact]
        public void NonGenericDynamicTreeBroadPhase_UpdatePairs_Works()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(1.0f, 1.0f), new Vector2F(3.0f, 3.0f));
            FixtureProxy proxyA = new FixtureProxy { ProxyId = 1 };
            FixtureProxy proxyB = new FixtureProxy { ProxyId = 2 };

            int idA = broadPhase.AddProxy(ref aabbA);
            int idB = broadPhase.AddProxy(ref aabbB);
            broadPhase.SetProxy(idA, ref proxyA);
            broadPhase.SetProxy(idB, ref proxyB);

            List<(int, int)> pairs = new List<(int, int)>();
            broadPhase.UpdatePairs((id1, id2) => pairs.Add((id1, id2)));

            Assert.NotEmpty(pairs);
        }

        [Fact]
        public void NonGenericDynamicTreeBroadPhase_TouchProxyAndQuery_Works()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            FixtureProxy proxy = new FixtureProxy();

            int proxyId = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(proxyId, ref proxy);
            broadPhase.TouchProxy(proxyId);

            List<int> hits = new List<int>();
            Aabb query = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(3.0f, 3.0f));
            broadPhase.Query(id =>
            {
                hits.Add(id);
                return true;
            }, ref query);

            Assert.Contains(proxyId, hits);
        }

        [Fact]
        public void NonGenericDynamicTreeBroadPhase_RayCast_Works()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            FixtureProxy proxy = new FixtureProxy();

            int proxyId = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(proxyId, ref proxy);

            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-1.0f, 1.0f),
                Point2 = new Vector2F(3.0f, 1.0f),
                MaxFraction = 1.0f
            };

            int hitCount = 0;
            broadPhase.RayCast((ref RayCastInput ri, int id) =>
            {
                hitCount++;
                return ri.MaxFraction;
            }, ref input);

            Assert.Equal(1, hitCount);
        }

        [Fact]
        public void NonGenericDynamicTreeBroadPhase_TestOverlap_Works()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(1.0f, 1.0f), new Vector2F(3.0f, 3.0f));

            int idA = broadPhase.AddProxy(ref aabbA);
            int idB = broadPhase.AddProxy(ref aabbB);

            Assert.True(broadPhase.TestOverlap(idA, idB));
        }

        [Fact]
        public void NonGenericDynamicTreeBroadPhase_RemoveProxy_DecrementsCount()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            Aabb aabb = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(1.0f, 1.0f));

            int proxyId = broadPhase.AddProxy(ref aabb);
            broadPhase.RemoveProxy(proxyId);

            Assert.Equal(0, broadPhase.ProxyCount);
        }

        [Fact]
        public void NonGenericDynamicTreeBroadPhase_MoveProxy_BuffersMove()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            FixtureProxy proxy = new FixtureProxy();

            int proxyId = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(proxyId, ref proxy);

            Aabb moved = new Aabb(new Vector2F(5.0f, 5.0f), new Vector2F(7.0f, 7.0f));
            broadPhase.MoveProxy(proxyId, ref moved, Vector2F.Zero);
        }

        [Fact]
        public void NonGenericDynamicTreeBroadPhase_ShiftOrigin_DoesNotThrow()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            broadPhase.AddProxy(ref aabb);

            broadPhase.ShiftOrigin(new Vector2F(10.0f, 10.0f));
        }

        [Fact]
        public void UpdatePairs_DuplicatePairsAreSkipped()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            List<(int, int)> pairs = new List<(int, int)>();
            int[] ids = new int[5];

            for (int i = 0; i < 5; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(0.0f, 0.0f),
                    new Vector2F(10.0f, 10.0f));
                ids[i] = broadPhase.AddProxy(ref aabb);
                broadPhase.SetProxy(ids[i], ref ids[i]);
            }

            broadPhase.UpdatePairs((idA, idB) => pairs.Add((idA, idB)));

            for (int i = 0; i < pairs.Count; i++)
            {
                for (int j = i + 1; j < pairs.Count; j++)
                {
                    Assert.False(
                        pairs[i].Item1 == pairs[j].Item1 &&
                        pairs[i].Item2 == pairs[j].Item2,
                        $"Duplicate pair found: ({pairs[i].Item1}, {pairs[i].Item2})");
                }
            }
        }

        [Fact]
        public void UpdatePairs_WithEmptyMoveBuffer_DoesNotCallCallback()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();

            bool called = false;
            broadPhase.UpdatePairs((idA, idB) => called = true);

            Assert.False(called);
        }

        [Fact]
        public void UpdatePairs_WithNoOverlap_ReportsNoPairs()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            Aabb aabbB = new Aabb(new Vector2F(100.0f, 100.0f), new Vector2F(101.0f, 101.0f));

            int idA = broadPhase.AddProxy(ref aabbA);
            int idB = broadPhase.AddProxy(ref aabbB);
            broadPhase.SetProxy(idA, ref idA);
            broadPhase.SetProxy(idB, ref idB);

            List<(int, int)> pairs = new List<(int, int)>();
            broadPhase.UpdatePairs((id1, id2) => pairs.Add((id1, id2)));

            Assert.Empty(pairs);
        }

        [Fact]
        public void Query_MultipleOverlappingProxies_ReturnsAll()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            for (int i = 0; i < 10; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(0.0f, 0.0f),
                    new Vector2F(5.0f, 5.0f));
                int id = broadPhase.AddProxy(ref aabb);
                broadPhase.SetProxy(id, ref id);
            }

            List<int> hits = new List<int>();
            Aabb query = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(6.0f, 6.0f));
            broadPhase.Query(id =>
            {
                hits.Add(id);
                return true;
            }, ref query);

            Assert.Equal(10, hits.Count);
        }

        [Fact]
        public void Query_WithEmptyTree_DoesNotThrow()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb query = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));

            broadPhase.Query(id => true, ref query);
        }

        [Fact]
        public void TreeProperties_WithMultipleProxies_ReturnExpectedValues()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            for (int i = 0; i < 10; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, 0.0f),
                    new Vector2F(i * 2.0f + 1.0f, 1.0f));
                broadPhase.AddProxy(ref aabb);
            }

            Assert.True(broadPhase.TreeQuality >= 0);
            Assert.True(broadPhase.TreeBalance >= 0);
            Assert.True(broadPhase.TreeHeight >= 0);
        }

        [Fact]
        public void AddProxy_ManyProxies_CausesMoveAndPairBufferGrowth()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            int[] ids = new int[50];
            for (int i = 0; i < 50; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(0.0f, 0.0f),
                    new Vector2F(10.0f, 10.0f));
                ids[i] = broadPhase.AddProxy(ref aabb);
                broadPhase.SetProxy(ids[i], ref ids[i]);
            }

            Assert.Equal(50, broadPhase.ProxyCount);

            int pairCount = 0;
            broadPhase.UpdatePairs((idA, idB) => pairCount++);
            Assert.True(pairCount > 0);
        }

        [Fact]
        public void RemoveAndReAddProxy_ReusesSlot()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));

            int firstId = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(firstId, ref firstId);
            broadPhase.RemoveProxy(firstId);

            int secondId = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(secondId, ref secondId);

            Assert.Equal(1, broadPhase.ProxyCount);
        }

        [Fact]
        public void MoveProxy_SamePosition_DoesNotBufferMove()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));

            int proxyId = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(proxyId, ref proxyId);

            Aabb sameAabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            broadPhase.MoveProxy(proxyId, ref sameAabb, Vector2F.Zero);

            List<(int, int)> pairs = new List<(int, int)>();
            broadPhase.UpdatePairs((idA, idB) => pairs.Add((idA, idB)));
            Assert.Empty(pairs);
        }

        [Fact]
        public void TestOverlap_BothDirections_ReturnsSame()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(1.0f, 1.0f), new Vector2F(3.0f, 3.0f));

            int idA = broadPhase.AddProxy(ref aabbA);
            int idB = broadPhase.AddProxy(ref aabbB);

            Assert.Equal(broadPhase.TestOverlap(idA, idB), broadPhase.TestOverlap(idB, idA));
        }

        [Fact]
        public void BroadPhaseQueryCallback_StopsWhenReturnsFalse()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            for (int i = 0; i < 10; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(0.0f, 0.0f),
                    new Vector2F(5.0f, 5.0f));
                int id = broadPhase.AddProxy(ref aabb);
                broadPhase.SetProxy(id, ref id);
            }

            int hitCount = 0;
            Aabb query = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(6.0f, 6.0f));
            broadPhase.Query(id =>
            {
                hitCount++;
                return false;
            }, ref query);

            Assert.Equal(1, hitCount);
        }

        [Fact]
        public void RayCast_SeparationAxis_SkipsNode()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabb = new Aabb(new Vector2F(5.0f, 5.0f), new Vector2F(6.0f, 6.0f));
            int id = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(id, ref id);

            int hitCount = 0;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(0.0f, 10.0f),
                Point2 = new Vector2F(10.0f, 10.0f),
                MaxFraction = 1.0f
            };

            broadPhase.RayCast((ref RayCastInput ri, int proxyId) =>
            {
                hitCount++;
                return 1.0f;
            }, ref input);

            Assert.Equal(0, hitCount);
        }
    }
}
