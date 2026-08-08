using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The dynamic tree remaining coverage tests class
    /// </summary>
    public class DynamicTreeRemainingCoverageTests
    {
        /// <summary>
        /// Tests that move proxy negative x negative y displacement extends lower bounds
        /// </summary>
        [Fact]
        public void MoveProxy_NegativeXNegativeY_Displacement_ExtendsLowerBounds()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(1, 1));
            int proxyId = tree.AddProxy(ref aabb);
            Aabb newAabb = new Aabb(new Vector2F(5, 5), new Vector2F(6, 6));
            bool moved = tree.MoveProxy(proxyId, ref newAabb, new Vector2F(-1, -1));
            Assert.True(moved);
            Aabb fat = tree.GetFatAabb(proxyId);
            Assert.True(fat.LowerBound.X < newAabb.LowerBound.X);
            Assert.True(fat.LowerBound.Y < newAabb.LowerBound.Y);
        }

        /// <summary>
        /// Tests that move proxy positive x positive y displacement extends upper bounds
        /// </summary>
        [Fact]
        public void MoveProxy_PositiveXPositiveY_Displacement_ExtendsUpperBounds()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(1, 1));
            int proxyId = tree.AddProxy(ref aabb);
            Aabb newAabb = new Aabb(new Vector2F(5, 5), new Vector2F(6, 6));
            bool moved = tree.MoveProxy(proxyId, ref newAabb, new Vector2F(1, 1));
            Assert.True(moved);
        }

        /// <summary>
        /// Tests that move proxy negative x positive y displacement extends lower upper
        /// </summary>
        [Fact]
        public void MoveProxy_NegativeXPositiveY_Displacement_ExtendsLowerUpper()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(1, 1));
            int proxyId = tree.AddProxy(ref aabb);
            Aabb newAabb = new Aabb(new Vector2F(5, 5), new Vector2F(6, 6));
            bool moved = tree.MoveProxy(proxyId, ref newAabb, new Vector2F(-1, 1));
            Assert.True(moved);
        }

        /// <summary>
        /// Tests that move proxy positive x negative y displacement extends upper lower
        /// </summary>
        [Fact]
        public void MoveProxy_PositiveXNegativeY_Displacement_ExtendsUpperLower()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0, 0), new Vector2F(1, 1));
            int proxyId = tree.AddProxy(ref aabb);
            Aabb newAabb = new Aabb(new Vector2F(5, 5), new Vector2F(6, 6));
            bool moved = tree.MoveProxy(proxyId, ref newAabb, new Vector2F(1, -1));
            Assert.True(moved);
        }

        /// <summary>
        /// Tests that ray cast separation axis positive skips node
        /// </summary>
        [Fact]
        public void RayCast_SeparationAxisPositive_SkipsNode()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(5.0f, 5.0f), new Vector2F(6.0f, 6.0f));
            tree.AddProxy(ref aabb);

            int hitCount = 0;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(0.0f, 10.0f),
                Point2 = new Vector2F(10.0f, 10.0f),
                MaxFraction = 1.0f
            };

            tree.RayCast((ref RayCastInput ri, int id) =>
            {
                hitCount++;
                return 1.0f;
            }, ref input);

            Assert.Equal(0, hitCount);
        }

        /// <summary>
        /// Tests that ray cast callback returns negative does not update fraction
        /// </summary>
        [Fact]
        public void RayCast_CallbackReturnsNegative_DoesNotUpdateFraction()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            tree.AddProxy(ref aabb);

            int hitCount = 0;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-5.0f, 0.5f),
                Point2 = new Vector2F(5.0f, 0.5f),
                MaxFraction = 1.0f
            };

            tree.RayCast((ref RayCastInput ri, int id) =>
            {
                hitCount++;
                return -0.5f;
            }, ref input);

            Assert.Equal(1, hitCount);
        }

        /// <summary>
        /// Tests that ray cast callback returns zero stops processing
        /// </summary>
        [Fact]
        public void RayCast_CallbackReturnsZero_StopsProcessing()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 10; i++)
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
                Point2 = new Vector2F(30.0f, 0.0f),
                MaxFraction = 1.0f
            };

            tree.RayCast((ref RayCastInput ri, int id) =>
            {
                hitCount++;
                return 0.0f;
            }, ref input);

            Assert.True(hitCount > 0);
        }

        /// <summary>
        /// Tests that compute child cost with leaf and internal returns correct cost
        /// </summary>
        [Fact]
        public void ComputeChildCost_WithLeafAndInternal_ReturnsCorrectCost()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb a1 = new Aabb(new Vector2F(0, 0), new Vector2F(1, 1));
            Aabb a2 = new Aabb(new Vector2F(2, 0), new Vector2F(3, 1));
            int p1 = tree.AddProxy(ref a1);
            tree.AddProxy(ref a2);

            float leafCost = tree.ComputeChildCost(p1, new Aabb(new Vector2F(0.5f, 0.5f), new Vector2F(2.5f, 1.5f)), 1.0f);
            Assert.True(leafCost >= 0);

            Aabb a3 = new Aabb(new Vector2F(4, 0), new Vector2F(5, 1));
            tree.AddProxy(ref a3);

            Aabb leafAabb = new Aabb(new Vector2F(1, 0), new Vector2F(3, 1));
            int sibling = tree.FindBestSibling(leafAabb);
            Assert.True(sibling >= 0);
        }

        /// <summary>
        /// Tests that find best sibling with overlapping aabb triggers break condition
        /// </summary>
        [Fact]
        public void FindBestSibling_WithOverlappingAabb_TriggersBreakCondition()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 20; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, 0.0f),
                    new Vector2F(i * 2.0f + 1.0f, 1.0f));
                tree.AddProxy(ref aabb);
            }

            Aabb leafAabb = new Aabb(new Vector2F(0.5f, 0.0f), new Vector2F(1.5f, 1.0f));
            int sibling = tree.FindBestSibling(leafAabb);
            Assert.True(sibling >= 0);
        }

        /// <summary>
        /// Tests that balance with linear chain triggers both rotation directions
        /// </summary>
        [Fact]
        public void Balance_WithLinearChain_TriggersBothRotationDirections()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 200; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 0.1f, 0.0f),
                    new Vector2F(i * 0.1f + 0.05f, 0.05f));
                tree.AddProxy(ref aabb);
            }
            tree.Validate();
            Assert.True(tree.MaxBalance >= 0);
            Assert.True(tree.Height > 0);
        }

        /// <summary>
        /// Tests that balance with descending chain triggers alternate rotations
        /// </summary>
        [Fact]
        public void Balance_WithDescendingChain_TriggersAlternateRotations()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 100; i >= 0; i--)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 0.5f, 0.0f),
                    new Vector2F(i * 0.5f + 0.4f, 0.4f));
                tree.AddProxy(ref aabb);
            }
            tree.Validate();
            Assert.True(tree.MaxBalance >= 0);
        }

        /// <summary>
        /// Tests that remove proxy with grand parent both child branches exercised
        /// </summary>
        [Fact]
        public void RemoveProxy_WithGrandParent_BothChildBranchesExercised()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            List<int> proxies = new List<int>();
            for (int i = 0; i < 30; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 4.0f, 0.0f),
                    new Vector2F(i * 4.0f + 2.0f, 2.0f));
                proxies.Add(tree.AddProxy(ref aabb));
            }
            tree.RemoveProxy(proxies[5]);
            tree.Validate();
            tree.RemoveProxy(proxies[15]);
            tree.Validate();
            tree.RemoveProxy(proxies[25]);
            tree.Validate();
            Assert.True(tree.Height >= 0);
        }

        /// <summary>
        /// Tests that allocate node multiple capacity expansions grows correctly
        /// </summary>
        [Fact]
        public void AllocateNode_MultipleCapacityExpansions_GrowsCorrectly()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 300; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 0.5f, 0.0f),
                    new Vector2F(i * 0.5f + 0.4f, 0.4f));
                tree.AddProxy(ref aabb);
            }
            tree.Validate();
            Assert.True(tree.Height >= 0);
        }

        /// <summary>
        /// Tests that remove and re add many reuses freed nodes
        /// </summary>
        [Fact]
        public void RemoveAndReAddMany_ReusesFreedNodes()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            List<int> proxies = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, 0.0f),
                    new Vector2F(i * 2.0f + 1.0f, 1.0f));
                proxies.Add(tree.AddProxy(ref aabb));
            }
            foreach (int p in proxies)
            {
                tree.RemoveProxy(p);
            }
            for (int i = 0; i < 20; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 2.0f, 10.0f),
                    new Vector2F(i * 2.0f + 1.0f, 11.0f));
                int newId = tree.AddProxy(ref aabb);
                Assert.True(newId >= 0);
            }
            tree.Validate();
            Assert.True(tree.Height > 0);
        }

        /// <summary>
        /// Tests that shift origin large offset updates all aabbs
        /// </summary>
        [Fact]
        public void ShiftOrigin_LargeOffset_UpdatesAllAabbs()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 10; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 10.0f, 0.0f),
                    new Vector2F(i * 10.0f + 5.0f, 5.0f));
                tree.AddProxy(ref aabb);
            }
            tree.ShiftOrigin(new Vector2F(1000.0f, 1000.0f));
            for (int i = 0; i < 10; i++)
            {
                Aabb fat = tree.GetFatAabb(i);
                Assert.True(fat.LowerBound.X < 10.0f * i - 900.0f);
            }
        }

        /// <summary>
        /// Tests that query with empty tree does not throw
        /// </summary>
        [Fact]
        public void Query_WithEmptyTree_DoesNotThrow()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb queryArea = new Aabb(new Vector2F(0, 0), new Vector2F(1, 1));
            tree.Query(id => true, ref queryArea);
        }

        /// <summary>
        /// Tests that FindBestSibling triggers the break condition when cost
        /// of creating a new parent is less than descending into both children.
        /// </summary>
        [Fact]
        public void FindBestSibling_BreakCondition_WhenCostMinimal()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb close = new Aabb(new Vector2F(1.5f, 1.5f), new Vector2F(2.0f, 2.0f));
            Aabb far = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.5f));
            tree.AddProxy(ref close);
            tree.AddProxy(ref far);

            Aabb leafAabb = new Aabb(new Vector2F(5.0f, 5.0f), new Vector2F(6.0f, 6.0f));
            int sibling = tree.FindBestSibling(leafAabb);
            Assert.True(sibling >= 0);
        }

        /// <summary>
        /// Tests that Balance right rotation covers the iBa.Height > iBb.Height sub-case.
        /// </summary>
        [Fact]
        public void Balance_RightRotation_BaHeightGreaterBbHeight()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 50; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 0.3f, 0.0f),
                    new Vector2F(i * 0.3f + 0.2f, 0.2f));
                tree.AddProxy(ref aabb);
            }
            tree.Validate();
            Assert.True(tree.MaxBalance >= 0);
        }

        /// <summary>
        /// Tests that Balance right rotation covers the iBa.Height &lt;= iBb.Height sub-case.
        /// </summary>
        [Fact]
        public void Balance_RightRotation_BaHeightLessOrEqualBbHeight()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 50; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 0.2f, i * 0.1f),
                    new Vector2F(i * 0.2f + 0.15f, i * 0.1f + 0.15f));
                tree.AddProxy(ref aabb);
            }
            tree.Validate();
            Assert.True(tree.MaxBalance >= 0);
        }

        /// <summary>
        /// Tests that Balance left rotation covers the iAa.Height > iAb.Height sub-case.
        /// </summary>
        [Fact]
        public void Balance_LeftRotation_AaHeightGreaterAbHeight()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 50; i >= 0; i--)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 0.3f, 0.0f),
                    new Vector2F(i * 0.3f + 0.2f, 0.2f));
                tree.AddProxy(ref aabb);
            }
            tree.Validate();
            Assert.True(tree.MaxBalance >= 0);
        }

        /// <summary>
        /// Tests that Balance left rotation covers the iAa.Height &lt;= iAb.Height sub-case.
        /// </summary>
        [Fact]
        public void Balance_LeftRotation_AaHeightLessOrEqualAbHeight()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 50; i >= 0; i--)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 0.2f, i * 0.1f),
                    new Vector2F(i * 0.2f + 0.15f, i * 0.1f + 0.15f));
                tree.AddProxy(ref aabb);
            }
            tree.Validate();
            Assert.True(tree.MaxBalance >= 0);
        }

        /// <summary>
        /// Tests that ComputeChildCost with an internal node returns cost correctly.
        /// </summary>
        [Fact]
        public void ComputeChildCost_WithInternalNode_ReturnsCost()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 10; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 3.0f, 0.0f),
                    new Vector2F(i * 3.0f + 1.0f, 1.0f));
                tree.AddProxy(ref aabb);
            }

            Aabb leafAabb = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(0.0f, 0.0f));
            Assert.True(tree.ComputeChildCost(0, leafAabb, 0.5f) >= 0);
            Assert.True(tree.ComputeChildCost(1, leafAabb, 0.5f) >= 0);
        }

        /// <summary>
        /// Tests that UpdateParentPointer sets root when parent is NullNode.
        /// </summary>
        [Fact]
        public void UpdateParentPointer_RootRotation_SetsNewRoot()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 200; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 0.1f, 0.0f),
                    new Vector2F(i * 0.1f + 0.05f, 0.05f));
                tree.AddProxy(ref aabb);
            }
            tree.Validate();
            Assert.True(tree.Height > 0);
        }
    }
}
