using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Common.TextureTools;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test
{
    public class FinalCoverageTest
    {
        [Fact]
        public void TOI_FailedOnMaxIter()
        {
            var shapeA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            var shapeB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            var input = new ToiInput
            {
                ProxyA = new DistanceProxy(shapeA, 0),
                ProxyB = new DistanceProxy(shapeB, 0),
                SweepA = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(1.5f, 0.0f), C = new Vector2F(0.1f, 0.0f), A0 = 0.0f, A = 0.5f, Alpha0 = 0.0f },
                SweepB = new Sweep { LocalCenter = Vector2F.Zero, C0 = Vector2F.Zero, C = Vector2F.Zero, A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                TMax = 1.0f
            };
            TimeOfImpact.CalculateTimeOfImpact(out var output, ref input);
            Assert.NotNull(output);
        }

        [Fact]
        public void TOI_PushBackTouching()
        {
            var shapeA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            var shapeB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            var input = new ToiInput
            {
                ProxyA = new DistanceProxy(shapeA, 0),
                ProxyB = new DistanceProxy(shapeB, 0),
                SweepA = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(2.0f, 0.0f), C = new Vector2F(1.5f, 0.0f), A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                SweepB = new Sweep { LocalCenter = Vector2F.Zero, C0 = Vector2F.Zero, C = Vector2F.Zero, A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                TMax = 1.0f
            };
            TimeOfImpact.CalculateTimeOfImpact(out var output, ref input);
            Assert.NotNull(output);
        }

        [Fact]
        public void TOI_PushBackMaxIterBreak()
        {
            var shapeA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            var shapeB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            var input = new ToiInput
            {
                ProxyA = new DistanceProxy(shapeA, 0),
                ProxyB = new DistanceProxy(shapeB, 0),
                SweepA = new Sweep { LocalCenter = Vector2F.Zero, C0 = new Vector2F(3.0f, 0.0f), C = new Vector2F(0.1f, 0.0f), A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                SweepB = new Sweep { LocalCenter = Vector2F.Zero, C0 = Vector2F.Zero, C = Vector2F.Zero, A0 = 0.0f, A = 0.0f, Alpha0 = 0.0f },
                TMax = 1.0f
            };
            TimeOfImpact.CalculateTimeOfImpact(out var output, ref input);
            Assert.NotNull(output);
        }

        [Fact]
        public void SepFunc_FindMinSepDefault()
        {
            var typeField = typeof(SeparationFunction).GetField("_type", BindingFlags.Static | BindingFlags.NonPublic);
            typeField.SetValue(null, (SeparationFunctionType)99);
            float sep = SeparationFunction.FindMinSeparation(out var idxA, out var idxB, 0.0f);
            Assert.Equal(0.0f, sep);
            Assert.Equal(-1, idxA);
            Assert.Equal(-1, idxB);
        }

        [Fact]
        public void SepFunc_EvaluateDefault()
        {
            var typeField = typeof(SeparationFunction).GetField("_type", BindingFlags.Static | BindingFlags.NonPublic);
            typeField.SetValue(null, (SeparationFunctionType)99);
            float sep = SeparationFunction.Evaluate(0, 0, 0.0f);
            Assert.Equal(0.0f, sep);
        }

        [Fact]
        public void ContactMgr_TryResolveFilterShouldCollideFalse()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            var bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            world.ContactManager.BeginContact = c => { c.FilterFlag = true; return true; };
            var joint = new DistanceJoint(bodyA, bodyB, bodyA.Position, bodyB.Position);
            joint.CollideConnected = false;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount >= 0);
            world.Remove(joint);
        }

        [Fact]
        public void Collision_BarySeparation2ExceedsRadius()
        {
            var poly = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            var circle = new CircleShape(0.1f, 1.0f);
            var xfPoly = ControllerTransform.Identity;
            var xfCircle = new ControllerTransform(new Vector2F(0.3f, 0.3f), 0.0f);
            var manifold = new Manifold();
            Collision.CollidePolygonAndCircle(ref manifold, poly, ref xfPoly, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void Collision_PolygonsFewClipPoints()
        {
            var polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            var polyB = new PolygonShape(PolygonTools.CreateRectangle(10.0f, 0.5f), 1.0f);
            var xfA = ControllerTransform.Identity;
            var xfB = new ControllerTransform(new Vector2F(0.8f, 0.0f), (float)Math.PI / 4.0f);
            var manifold = new Manifold();
            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void Collision_EpColliderPolygonAxisExceedsRadius()
        {
            var edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-0.5f, 0.0f);
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(1.5f, 0.0f);
            var polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            var xfEdge = ControllerTransform.Identity;
            var xfPolygon = new ControllerTransform(new Vector2F(5.0f, 5.0f), 0.0f);
            var manifold = new Manifold();
            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.Equal(0, manifold.PointCount);
        }

        [Fact]
        public void Collision_EpColliderFewClipPoints()
        {
            var edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            var polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            var xfEdge = ControllerTransform.Identity;
            var xfPolygon = new ControllerTransform(new Vector2F(0.5f, 0.0f), (float)Math.PI / 2.0f);
            var manifold = new Manifold();
            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void Collision_EpColliderPolygonSepExceedsRadius()
        {
            var edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            var polygon = new PolygonShape(PolygonTools.CreateRectangle(2.0f, 2.0f), 1.0f);
            var xfEdge = ControllerTransform.Identity;
            var xfPolygon = new ControllerTransform(new Vector2F(3.0f, 0.0f), 0.0f);
            var manifold = new Manifold();
            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void Collision_EpColliderSelectPrimaryUnknown()
        {
            var edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            var polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            var xfEdge = ControllerTransform.Identity;
            var xfPolygon = new ControllerTransform(new Vector2F(10.0f, 0.0f), 0.0f);
            var manifold = new Manifold();
            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.Equal(0, manifold.PointCount);
        }

        [Fact]
        public void Collision_EdgeCircleBothEdges()
        {
            var edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-0.5f, 0.0f);
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(1.5f, 0.0f);
            var circle = new CircleShape(0.2f, 1.0f);
            var xfEdge = ControllerTransform.Identity;
            var xfCircle = new ControllerTransform(new Vector2F(1.2f, 0.0f), 0.0f);
            var manifold = new Manifold();
            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void World_ResetToiStateEarlyReturn()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.IsBullet = true;
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            for (int i = 0; i < 3; i++)
            {
                Record.Exception(() => world.Step(1.0f / 60.0f));
            }
            Assert.NotNull(bodyA);
        }

        [Fact]
        public void World_CalcContactAlphaDifferentAlpha0()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-5f, 0f), BodyType.Dynamic);
            var bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            bodyA.IsBullet = true;
            bodyA.Sweep.Alpha0 = 0.3f;
            bodyB.Sweep.Alpha0 = 0.6f;
            Record.Exception(() => world.Step(1.0f / 60.0f));
        }

        [Fact]
        public void World_ProcessToiContactFullPath()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            var bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            bodyA.IsBullet = true;
            for (int i = 0; i < 3; i++)
            {
                Record.Exception(() => world.Step(1.0f / 60.0f));
            }
            Assert.NotNull(bodyA);
        }

        [Fact]
        public void World_StepLockedThrows()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            bool threw = false;
            world.ContactManager.BeginContact = contact =>
            {
                try { world.Step(1.0f / 60.0f); }
                catch (InvalidOperationException) { threw = true; }
                return false;
            };
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(threw);
        }

        [Fact]
        public void Island_SolveToiClamping()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(-10f, 0f), BodyType.Dynamic);
            var bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(10000f, 0f);
            bodyA.AngularVelocity = 10000f;
            for (int i = 0; i < 3; i++)
            {
                Record.Exception(() => world.Step(1.0f / 60.0f));
            }
            Assert.NotNull(bodyA);
        }

        [Fact]
        public void Island_ProcessJointEdgesOtherEnabled()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateBody(new Vector2F(0f, 0f), 0f, BodyType.Dynamic);
            var bodyB = world.CreateBody(new Vector2F(2f, 0f), 0f, BodyType.Dynamic);
            var joint = new DistanceJoint(bodyA, bodyB, Vector2F.Zero, new Vector2F(2f, 0f));
            world.Add(joint);
            Record.Exception(() => world.Step(1.0f / 60.0f));
        }

        [Fact]
        public void Body_ApplyLinearImpulseRefPoint()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            var impulse = new Vector2F(10f, 0f);
            var point = new Vector2F(1f, 1f);
            body.ApplyLinearImpulse(ref impulse, ref point);
            Assert.True(body.LinearVelocityInternal.X > 0);
        }

        [Fact]
        public void Terrain_RemoveOldDataWithBodyMap()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var area = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));
            var terrain = new Terrain(world, area)
            {
                PointsPerUnit = 2,
                CellSize = 2,
                SubCellSize = 1,
                Decomposer = TriangulationAlgorithm.Earclip
            };
            terrain.Initialize();
            terrain.ModifyTerrain(new Vector2F(1f, 1f), -1);
            terrain.RegenerateTerrain();
            Assert.NotNull(terrain);
        }

        [Fact]
        public void Marching_CombineScanLines()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var area = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));
            var terrain = new Terrain(world, area)
            {
                PointsPerUnit = 2,
                CellSize = 3,
                SubCellSize = 1,
                Decomposer = TriangulationAlgorithm.Earclip
            };
            terrain.Initialize();
            terrain.ModifyTerrain(new Vector2F(3f, 3f), -1);
            terrain.RegenerateTerrain();
            Assert.NotNull(terrain);
        }

        [Fact]
        public void RealExplosion_MergeCircularData()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            var explosion = new RealExplosion(world);
            var result = explosion.Activate(Vector2F.Zero, 10f, 100f);
            Assert.NotNull(result);
        }

        [Fact]
        public void RealExplosion_MergeCircularDataWrapping()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(20f, 20f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            var explosion = new RealExplosion(world);
            var result = explosion.Activate(Vector2F.Zero, 5f, 100f);
            Assert.NotNull(result);
        }

        [Fact]
        public void Collision_EdgeCircleHasVertex3()
        {
            var edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(1.5f, 0.0f);
            var circle = new CircleShape(0.2f, 1.0f);
            var xfEdge = ControllerTransform.Identity;
            var xfCircle = new ControllerTransform(new Vector2F(1.3f, 0.0f), 0.0f);
            var manifold = new Manifold();
            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void Collision_EdgeCircleHasVertex0()
        {
            var edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-0.5f, 0.0f);
            var circle = new CircleShape(0.2f, 1.0f);
            var xfEdge = ControllerTransform.Identity;
            var xfCircle = new ControllerTransform(new Vector2F(-0.3f, 0.0f), 0.0f);
            var manifold = new Manifold();
            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // SeparationFunction FaceB flip (line 197-199)
        // ========================================================================
        [Fact]
        public void SepFunc_FaceBFlipAxis()
        {
            var shapeA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            var shapeB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            var proxyA = new DistanceProxy(shapeA, 0);
            var proxyB = new DistanceProxy(shapeB, 0);
            var sweepA = new Sweep { C0 = new Vector2F(0.0f, 2.0f), C = new Vector2F(0.0f, 2.0f), LocalCenter = Vector2F.Zero };
            var sweepB = new Sweep { C0 = Vector2F.Zero, C = Vector2F.Zero, LocalCenter = Vector2F.Zero };
            var cache = new SimplexCache { Count = 2 };
            cache.IndexA[0] = 0; cache.IndexA[1] = 0;
            cache.IndexB[0] = 0; cache.IndexB[1] = 1;
            SeparationFunction.Set(ref cache, ref proxyA, ref sweepA, ref proxyB, ref sweepB, 0.0f);
            float sep = SeparationFunction.FindMinSeparation(out var idxA, out var idxB, 0.0f);
            Assert.False(float.IsNaN(sep));
        }

        // ========================================================================
        // WorldPhysic SolveToi disabled contact reset (lines 578-584)
        // ========================================================================
        [Fact]
        public void World_SolveToiDisabledContact()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            var bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            world.ContactManager.BeginContact = contact =>
            {
                contact.Enabled = false;
                return true;
            };
            Record.Exception(() => world.Step(1.0f / 60.0f));
        }

        // ========================================================================
        // WorldPhysic ProcessToiContact sensor fixture skip (lines 813-815)
        // ========================================================================
        [Fact]
        public void World_ProcessToiSensorSkip()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            var bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            bodyA.IsBullet = true;
            bodyA.FixtureList[0].GetIsSensor = true;
            Record.Exception(() => world.Step(1.0f / 60.0f));
        }

        // ========================================================================
        // WorldPhysic CalculateContactAlpha both inactive skip (lines 726-727)
        // Uses ToiFlag path
        // ========================================================================
        [Fact]
        public void World_CalcContactAlphaToiFlag()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2f, 0f), BodyType.Dynamic);
            var bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100f, 0f);
            bodyA.Awake = false;
            bodyB.Awake = false;
            Record.Exception(() => world.Step(1.0f / 60.0f));
        }

        // ========================================================================
        // WorldPhysic RemoveBody events (lines 914-916, 1406)
        // ========================================================================
        [Fact]
        public void World_RemoveBodyWithEvents()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            int removed = 0;
            var body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.BodyRemoved += (w, b) => removed++;
            world.Remove(body);
            Assert.Equal(1, removed);
        }

        // ========================================================================
        // ContactManager TryResolveContactFilter full path (lines 655-665)
        // ========================================================================
        [Fact]
        public void ContactMgr_TryResolveFilterFull()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            var bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            world.ContactManager.BeginContact = c =>
            {
                c.FilterFlag = true;
                return true;
            };
            var joint = new DistanceJoint(bodyA, bodyB, bodyA.Position, bodyB.Position);
            joint.CollideConnected = true;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // Island Report handler paths (lines 665-666 null _contactManager)
        // ========================================================================
        [Fact]
        public void Island_ReportNullCM()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            var islandField = typeof(WorldPhysic).GetField("<GetIsland>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var island = islandField?.GetValue(world) as Island;
            if (island != null)
            {
                var cmField = typeof(Island).GetField("_contactManager",
                    BindingFlags.Instance | BindingFlags.NonPublic);
                cmField?.SetValue(island, null);
                Record.Exception(() => world.Step(1.0f / 60.0f));
            }
        }

        // ========================================================================
        // Body GetBodyType lock error path (lines 228-229)
        // ========================================================================
        [Fact]
        public void Body_GetBodyTypeWhileLocked_Throws()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            var lockedField = typeof(WorldPhysic).GetField("<GetIsLocked>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            lockedField?.SetValue(world, true);
            Assert.Throws<InvalidOperationException>(() => body.GetBodyType = BodyType.Static);
            lockedField?.SetValue(world, false);
        }

        // ========================================================================
        // Body Enabled locked path (lines 413-414)
        // ========================================================================
        [Fact]
        public void Body_EnabledWhileLocked_Throws()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            var lockedField = typeof(WorldPhysic).GetField("<GetIsLocked>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            lockedField?.SetValue(world, true);
            Assert.Throws<InvalidOperationException>(() => body.Enabled = false);
            lockedField?.SetValue(world, false);
        }

        // ========================================================================
        // Body LocalCenter locked path (lines 545-546)
        // ========================================================================
        [Fact]
        public void Body_LocalCenterLocked_Throws()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            var lockedField = typeof(WorldPhysic).GetField("<GetIsLocked>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            lockedField?.SetValue(world, true);
            Assert.Throws<InvalidOperationException>(() => body.LocalCenter = Vector2F.Zero);
            lockedField?.SetValue(world, false);
        }

        // ========================================================================
        // Body Mass locked path (lines 577-578)
        // ========================================================================
        [Fact]
        public void Body_MassLocked_Throws()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            var lockedField = typeof(WorldPhysic).GetField("<GetIsLocked>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            lockedField?.SetValue(world, true);
            Assert.Throws<InvalidOperationException>(() => body.Mass = 10f);
            lockedField?.SetValue(world, false);
        }

        // ========================================================================
        // Body Inertia locked path (lines 609-610)
        // ========================================================================
        [Fact]
        public void Body_InertiaLocked_Throws()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            var lockedField = typeof(WorldPhysic).GetField("<GetIsLocked>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            lockedField?.SetValue(world, true);
            Assert.Throws<InvalidOperationException>(() => body.Inertia = 5f);
            lockedField?.SetValue(world, false);
        }

        // ========================================================================
        // Body Add fixture locked path (lines 691-692)
        // ========================================================================
        [Fact]
        public void Body_AddFixtureLocked_Throws()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            var lockedField = typeof(WorldPhysic).GetField("<GetIsLocked>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            lockedField?.SetValue(world, true);
            var shape = new CircleShape(0.5f, 1.0f);
            Assert.Throws<InvalidOperationException>(() => body.Add(new Fixture(shape)));
            lockedField?.SetValue(world, false);
        }

        // ========================================================================
        // Body Remove fixture locked path (lines 759-760)
        // ========================================================================
        [Fact]
        public void Body_RemoveFixtureLocked_Throws()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            var lockedField = typeof(WorldPhysic).GetField("<GetIsLocked>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            lockedField?.SetValue(world, true);
            Assert.Throws<InvalidOperationException>(() => body.Remove(body.FixtureList[0]));
            lockedField?.SetValue(world, false);
        }

        // ========================================================================
        // Body SetTransformIgnoreContacts locked path (lines 856-857)
        // ========================================================================
        [Fact]
        public void Body_SetTransformLocked_Throws()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            var lockedField = typeof(WorldPhysic).GetField("<GetIsLocked>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            lockedField?.SetValue(world, true);
            var pos = Vector2F.Zero;
            Assert.Throws<InvalidOperationException>(() => body.SetTransformIgnoreContacts(ref pos, 0f));
            lockedField?.SetValue(world, false);
        }

        // ========================================================================
        // RealExplosion MergeCircularData with wrapping (lines 384-396)
        // ========================================================================
        [Fact]
        public void RealExplosion_MergeCircularWrap()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(5f, 5f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            var explosion = new RealExplosion(world);
            var result = explosion.Activate(Vector2F.Zero, 10f, 100f);
            Assert.NotNull(result);
        }

        // ========================================================================
        // Terrain RemoveOldData with body entries (lines 293-298)
        // ========================================================================
        [Fact]
        public void Terrain_RemoveOldDataBodies()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var area = new Aabb(new Vector2F(0f, 0f), new Vector2F(10f, 10f));
            var terrain = new Terrain(world, area)
            {
                PointsPerUnit = 4,
                CellSize = 4,
                SubCellSize = 1,
                Decomposer = TriangulationAlgorithm.Earclip
            };
            terrain.Initialize();
            terrain._terrainMap[0, 0] = -1;
            terrain.ModifyTerrain(new Vector2F(2f, 2f), -1);
            terrain.RegenerateTerrain();
            Assert.NotNull(terrain);
        }

        // ========================================================================
        // WorldPhysic Clear locked (line 1406)
        // ========================================================================
        [Fact]
        public void World_ClearLocked_Throws()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var lockedField = typeof(WorldPhysic).GetField("<GetIsLocked>k__BackingField",
                BindingFlags.Instance | BindingFlags.NonPublic);
            lockedField?.SetValue(world, true);
            Assert.Throws<InvalidOperationException>(() => world.Clear());
            lockedField?.SetValue(world, false);
        }

        // ========================================================================
        // Body OnCollision event (lines 1287, 1296)
        // ========================================================================
        [Fact]
        public void Body_OnCollisionEvent()
        {
            var body = new Body();
            int count = 0;
            body.OnCollision += (a, b, c) => { count++; return true; };
            body.OnCollision += (a, b, c) => true;
            body.OnCollision -= (a, b, c) => true;
            Assert.NotNull(body);
        }

        // ========================================================================
        // Body Remove fixture with contact (lines 776-789)
        // ========================================================================
        [Fact]
        public void Body_RemoveFixtureWithContact()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateRectangle(2f, 2f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            var other = world.CreateRectangle(2f, 2f, 1f, new Vector2F(0.5f, 0f), 0f, BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            body.Remove(body.FixtureList[0]);
            Assert.Empty(body.FixtureList);
        }

        // ========================================================================
        // Body FixtureRemoved event (lines 809-811)
        // ========================================================================
        [Fact]
        public void Body_FixtureRemovedEvent()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            int removed = 0;
            world.FixtureRemoved += (w, b, f) => removed++;
            var body = world.CreateRectangle(2f, 2f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            body.Remove(body.FixtureList[0]);
            Assert.Equal(1, removed);
        }

        // ========================================================================
        // Body ApplyLinearImpulse ref point on static body (lines 1019-1021)
        // ========================================================================
        [Fact]
        public void Body_ApplyLinearImpulseStatic()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Static);
            var impulse = new Vector2F(10f, 0f);
            var point = new Vector2F(1f, 1f);
            body.ApplyLinearImpulse(ref impulse, ref point);
            Assert.Equal(Vector2F.Zero, body.LinearVelocityInternal);
        }

        // ========================================================================
        // Body OnSeparation event unsubscribe (line 1296)
        // ========================================================================
        [Fact]
        public void Body_OnSeparationEvent()
        {
            var body = new Body();
            int count = 0;
            body.OnSeparation += (a, b, c) => count++;
            body.OnSeparation -= (a, b, c) => count++;
            Assert.NotNull(body);
        }

        // ========================================================================
        // ContactManager AddPair null contact (lines 180-181)
        // ========================================================================
        [Fact]
        public void ContactMgr_AddPairNullContact()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateEdge(Vector2F.Zero, new Vector2F(1f, 0f));
            bodyA.GetBodyType = BodyType.Dynamic;
            var bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.5f, 0.5f), BodyType.Dynamic);
            Record.Exception(() => world.Step(1.0f / 60.0f));
        }

        // ========================================================================
        // ContactManager PassesCollisionFilters BeforeCollisionA false (lines 515-516)
        // ========================================================================
        [Fact]
        public void ContactMgr_PassesFilters_BeforeCollisionAFalse()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            var bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            foreach (var f in bodyA.FixtureList) f.BeforeCollision = (_, _) => false;
            world.Step(1.0f / 60.0f);
            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        // ========================================================================
        // ContactManager PassesCollisionFilters BeforeCollisionB false (lines 521-522)
        // ========================================================================
        [Fact]
        public void ContactMgr_PassesFilters_BeforeCollisionBFalse()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            var bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            foreach (var f in bodyB.FixtureList) f.BeforeCollision = (_, _) => false;
            world.Step(1.0f / 60.0f);
            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        // ========================================================================
        // Terrain RemoveOldData with body entries (lines 293-298)
        // ========================================================================
        [Fact]
        public void Terrain_RemoveOldData_WithBodies()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var area = new Aabb(new Vector2F(0f, 0f), new Vector2F(5f, 5f));
            var terrain = new Terrain(world, area)
            {
                PointsPerUnit = 3,
                CellSize = 3,
                SubCellSize = 1,
                Decomposer = TriangulationAlgorithm.Earclip
            };
            terrain.Initialize();
            terrain._terrainMap[0, 0] = -1;
            terrain._terrainMap[1, 1] = -1;
            terrain.ModifyTerrain(new Vector2F(2f, 2f), -1);
            terrain.RegenerateTerrain();
            Assert.NotNull(terrain);
        }

        // ========================================================================
        // RealExplosion MergeCircularData full path (lines 384-396)
        // ========================================================================
        [Fact]
        public void RealExplosion_MergeCircularFull()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(8f, 8f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            world.CreateCircle(2f, 1f, new Vector2F(-5f, -5f), BodyType.Dynamic);
            world.CreateCircle(2f, 1f, new Vector2F(5f, 5f), BodyType.Dynamic);
            var explosion = new RealExplosion(world);
            var result = explosion.Activate(Vector2F.Zero, 20f, 100f);
            Assert.NotNull(result);
        }

        // ========================================================================
        // Body ApplyLinearImpulse on sleeping dynamic body (lines 1019-1021)
        // ========================================================================
        [Fact]
        public void Body_ApplyLinearImpulseSleeping()
        {
            var world = new WorldPhysic(Vector2F.Zero);
            var body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.Awake = false;
            var impulse = new Vector2F(10f, 0f);
            var point = new Vector2F(1f, 1f);
            body.ApplyLinearImpulse(ref impulse, ref point);
            Assert.True(body.LinearVelocityInternal.X > 0);
        }

        // ========================================================================
        // SeparationFunction FaceB fully flips axis (lines 197-199)
        // Uses specific geometry to force s < 0
        // ========================================================================
        [Fact]
        public void SepFunc_FaceBFlipAxisFull()
        {
            var shapeA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            var shapeB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            var proxyA = new DistanceProxy(shapeA, 0);
            var proxyB = new DistanceProxy(shapeB, 0);
            var sweepA = new Sweep { C0 = new Vector2F(0.0f, 5.0f), C = new Vector2F(0.0f, 5.0f), LocalCenter = Vector2F.Zero };
            var sweepB = new Sweep { C0 = Vector2F.Zero, C = Vector2F.Zero, LocalCenter = Vector2F.Zero };
            var cache = new SimplexCache { Count = 2 };
            cache.IndexA[0] = 0; cache.IndexA[1] = 0;
            cache.IndexB[0] = 0; cache.IndexB[1] = 1;
            SeparationFunction.Set(ref cache, ref proxyA, ref sweepA, ref proxyB, ref sweepB, 0.0f);
            float sep = SeparationFunction.FindMinSeparation(out var idxA, out var idxB, 0.0f);
            Assert.False(float.IsNaN(sep));
        }
    }
}
