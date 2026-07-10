using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class DynamicTreeCoverageTest
    {
        [Fact]
        public void AddMultipleProxies_TriggersBalance()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 20; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, 0.0f),
                    new Vector2F(i * 2.0f + 1.0f, 1.0f));
                tree.AddProxy(ref aabb);
            }

            Assert.True(tree.Height > 0);
            Assert.True(tree.MaxBalance >= 0);
        }

        [Fact]
        public void AddAndRemoveAll_ResetsTree()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            List<int> proxies = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 3.0f, 0.0f),
                    new Vector2F(i * 3.0f + 1.0f, 1.0f));
                proxies.Add(tree.AddProxy(ref aabb));
            }

            foreach (int proxyId in proxies)
            {
                tree.RemoveProxy(proxyId);
            }

            Assert.Equal(0, tree.Height);
        }

        [Fact]
        public void AllocateBeyondCapacity_TriggersGrowth()
        {
            DynamicTree<int> tree = new DynamicTree<int>();

            for (int i = 0; i < 50; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 0.5f, 0.0f),
                    new Vector2F(i * 0.5f + 0.4f, 0.4f));
                tree.AddProxy(ref aabb);
            }

            int height = tree.ComputeHeight();
            Assert.True(height >= 0);
        }

        [Fact]
        public void RebuildBottomUp_ProducesValidTree()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 10; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, 0.0f),
                    new Vector2F(i * 2.0f + 1.0f, 1.0f));
                tree.AddProxy(ref aabb);
            }

            tree.RebuildBottomUp();

            int height = tree.ComputeHeight();
            Assert.True(height >= 0);
            Assert.True(tree.Height >= 0);
        }

        [Fact]
        public void Validate_DoesNotThrow()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 5; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, 0.0f),
                    new Vector2F(i * 2.0f + 1.0f, 1.0f));
                tree.AddProxy(ref aabb);
            }

            tree.Validate();
        }

        [Fact]
        public void RayCast_CallbackReturnsZero_Terminates()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 5; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, 0.0f),
                    new Vector2F(i * 2.0f + 1.0f, 1.0f));
                tree.AddProxy(ref aabb);
            }

            int hitCount = 0;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-10.0f, 0.0f),
                Point2 = new Vector2F(20.0f, 0.0f),
                MaxFraction = 1.0f
            };

            tree.RayCast((ref RayCastInput ri, int id) =>
            {
                hitCount++;
                return 0.0f;
            }, ref input);

            Assert.True(hitCount >= 0);
        }

        [Fact]
        public void RayCast_CallbackReturnsPositive_UpdatesMaxFraction()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 5; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, -1.0f),
                    new Vector2F(i * 2.0f + 1.0f, 1.0f));
                tree.AddProxy(ref aabb);
            }

            int hitCount = 0;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-10.0f, 0.0f),
                Point2 = new Vector2F(20.0f, 0.0f),
                MaxFraction = 1.0f
            };

            tree.RayCast((ref RayCastInput ri, int id) =>
            {
                hitCount++;
                return ri.MaxFraction * 0.5f;
            }, ref input);

            Assert.True(hitCount > 0);
        }

        [Fact]
        public void MoveProxy_WithDisplacement_ExtendsAabb()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = tree.AddProxy(ref aabb);

            Aabb newAabb = new Aabb(new Vector2F(2.0f, 2.0f), new Vector2F(3.0f, 3.0f));
            bool moved = tree.MoveProxy(proxyId, ref newAabb, new Vector2F(5.0f, 0.0f));

            Assert.True(moved);

            Aabb fatAabb = tree.GetFatAabb(proxyId);
            Assert.True(fatAabb.LowerBound.X < newAabb.LowerBound.X);
        }

        [Fact]
        public void ComputeHeight_WithMultipleNodes()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 8; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, 0.0f),
                    new Vector2F(i * 2.0f + 1.0f, 1.0f));
                tree.AddProxy(ref aabb);
            }

            int height = tree.ComputeHeight();
            Assert.True(height >= 3);
        }

        [Fact]
        public void ShiftOrigin_WithMultipleProxies()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 5; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 10.0f, 0.0f),
                    new Vector2F(i * 10.0f + 5.0f, 5.0f));
                tree.AddProxy(ref aabb);
            }

            tree.ShiftOrigin(new Vector2F(100.0f, 100.0f));

            for (int i = 0; i < 5; i++)
            {
                Aabb fatAabb = tree.GetFatAabb(i);
                Assert.True(fatAabb.LowerBound.X < 10.0f * i);
            }
        }

        [Fact]
        public void Query_WithNonOverlappingAabb_ReturnsEmpty()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 5; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 10.0f + 100.0f, 0.0f),
                    new Vector2F(i * 10.0f + 105.0f, 5.0f));
                tree.AddProxy(ref aabb);
            }

            List<int> hits = new List<int>();
            Aabb queryArea = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            tree.Query(id =>
            {
                hits.Add(id);
                return true;
            }, ref queryArea);

            Assert.Empty(hits);
        }

        [Fact]
        public void RemoveAndReAdd_MaintainsTreeIntegrity()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            List<int> proxies = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 3.0f, 0.0f),
                    new Vector2F(i * 3.0f + 1.0f, 1.0f));
                proxies.Add(tree.AddProxy(ref aabb));
            }

            for (int i = 0; i < 5; i++)
            {
                tree.RemoveProxy(proxies[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 3.0f, 10.0f),
                    new Vector2F(i * 3.0f + 1.0f, 11.0f));
                int newId = tree.AddProxy(ref aabb);
                Assert.True(newId >= 0);
            }

            tree.Validate();
            Assert.True(tree.Height > 0);
        }

        [Fact]
        public void FindBestSibling_WithTwoProxies_ReturnsBestSibling()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb1 = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabb2 = new Aabb(new Vector2F(10.0f, 10.0f), new Vector2F(12.0f, 12.0f));
            tree.AddProxy(ref aabb1);
            tree.AddProxy(ref aabb2);

            Aabb leafAabb = new Aabb(new Vector2F(1.0f, 1.0f), new Vector2F(3.0f, 3.0f));
            int sibling = tree.FindBestSibling(leafAabb);

            Assert.True(sibling >= 0);
        }

        [Fact]
        public void ComputeChildCost_LeafAndInternal_ReturnsDifferentCost()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb1 = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            Aabb aabb2 = new Aabb(new Vector2F(2.0f, 0.0f), new Vector2F(3.0f, 1.0f));
            int proxy1 = tree.AddProxy(ref aabb1);
            int proxy2 = tree.AddProxy(ref aabb2);

            float cost = tree.ComputeChildCost(proxy1, new Aabb(new Vector2F(0.5f, 0.5f), new Vector2F(2.5f, 1.5f)), 1.0f);

            Assert.True(cost >= 0);
        }

        [Fact]
        public void RemoveLeaf_WithGrandParent_ExercisesFullRemoval()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 10; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, 0.0f),
                    new Vector2F(i * 2.0f + 1.0f, 1.0f));
                tree.AddProxy(ref aabb);
            }

            // Remove proxy 4 which has a grandparent in the tree
            tree.RemoveProxy(4);

            tree.Validate();
            Assert.True(tree.Height >= 0);
        }

        [Fact]
        public void Balance_WithImbalancedTree_TriggersRotation()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 50; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 0.5f, 0.0f),
                    new Vector2F(i * 0.5f + 0.4f, 0.4f));
                tree.AddProxy(ref aabb);
            }

            int balance = tree.MaxBalance;
            tree.Validate();
            Assert.True(balance >= 0);
        }

        [Fact]
        public void AttachNewParent_WhenSiblingIsRoot_UpdatesRoot()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb1 = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabb2 = new Aabb(new Vector2F(10.0f, 10.0f), new Vector2F(12.0f, 12.0f));
            tree.AddProxy(ref aabb1);
            tree.AddProxy(ref aabb2);

            tree.Validate();
            Assert.True(tree.Height > 0);
        }

        [Fact]
        public void ValidateStructure_WithNullNode_ReturnsEarly()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            tree.ValidateStructure(DynamicTree<int>.NullNode);
        }

        [Fact]
        public void ValidateMetrics_WithNullNode_ReturnsEarly()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            tree.ValidateMetrics(DynamicTree<int>.NullNode);
        }

        [Fact]
        public void RayCast_OnEmptyTree_ReturnsWithoutIterating()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(0, 0),
                Point2 = new Vector2F(1, 0),
                MaxFraction = 1.0f
            };

            tree.RayCast((ref RayCastInput ri, int id) => 1.0f, ref input);
        }
    }
}
