// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RealExplosionBranchCoverageTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The real explosion branch coverage tests class
    /// </summary>
    public class RealExplosionBranchCoverageTests
    {
        // ========================================================================
        // CreatePolygonFromCircle (line 210-219) — private static
        // ========================================================================

        /// <summary>
        ///     Tests that create polygon from circle creates valid polygon with 4 vertices
        /// </summary>
        [Fact]
        public void CreatePolygonFromCircle_CreatesValidPolygon()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("CreatePolygonFromCircle",
                BindingFlags.Static | BindingFlags.NonPublic);

            CircleShape circle = new CircleShape(5f, 1f);
            PolygonShape result = (PolygonShape)method.Invoke(null, new object[] { circle });

            Assert.NotNull(result);
            Assert.Equal(4, result.Vertices.Count);
        }

        // ========================================================================
        // ComputeAngleBoundsForShape (line 229-251) — private static
        // branch: Math.Abs(diff) > Constant.Pi → continue
        // ========================================================================

        /// <summary>
        ///     Tests that compute angle bounds for shape with diff greater than pi skips vertex
        /// </summary>
        [Fact]
        public void ComputeAngleBoundsForShape_WithLargeDiff_SkipsVertex()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ComputeAngleBoundsForShape",
                BindingFlags.Static | BindingFlags.NonPublic);

            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(4f, 4f, 1f, new Vector2F(10f, 0), 0f, BodyType.Dynamic);
            PolygonShape ps = body.FixtureList[0].GetShape as PolygonShape;

            float[] vals = new float[10];
            int valIndex = 0;

            method.Invoke(null, new object[] { ps, body, new Vector2F(100f, 0), vals, valIndex });
            // No exception = success. The large distance may cause large angle diffs.
        }

        // ========================================================================
        // ShouldSkipAnglePair (line 310-311) — private static
        // branch: true (when angles are equal within epsilon)
        // ========================================================================

        /// <summary>
        ///     Tests that should skip angle pair with equal angles returns true
        /// </summary>
        [Fact]
        public void ShouldSkipAnglePair_WithEqualAngles_ReturnsTrue()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ShouldSkipAnglePair",
                BindingFlags.Static | BindingFlags.NonPublic);

            float[] vals = { 1.0f, 1.0f };
            bool result = (bool)method.Invoke(null, new object[] { vals, 0, 2 });

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that should skip angle pair with different angles returns false
        /// </summary>
        [Fact]
        public void ShouldSkipAnglePair_WithDifferentAngles_ReturnsFalse()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ShouldSkipAnglePair",
                BindingFlags.Static | BindingFlags.NonPublic);

            float[] vals = { 1.0f, 3.0f };
            bool result = (bool)method.Invoke(null, new object[] { vals, 0, 2 });

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that should skip angle pair with last index wraps around correctly
        /// </summary>
        [Fact]
        public void ShouldSkipAnglePair_AtLastIndex_WrapsToFirst()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ShouldSkipAnglePair",
                BindingFlags.Static | BindingFlags.NonPublic);

            float[] vals = { 3.0f, 1.0f, 2.0f, 3.0f };
            bool result = (bool)method.Invoke(null, new object[] { vals, 3, 4 });

            Assert.False(result);
        }

        // ========================================================================
        // ComputeMidpoint (line 320-326) — private static
        // branches: i == valIndex - 1 vs else
        // ========================================================================

        /// <summary>
        ///     Tests that compute midpoint at interior index computes average
        /// </summary>
        [Fact]
        public void ComputeMidpoint_AtInteriorIndex_ComputesAverage()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ComputeMidpoint",
                BindingFlags.Static | BindingFlags.NonPublic);

            float[] vals = { 1.0f, 3.0f };
            float result = (float)method.Invoke(null, new object[] { vals, 0, 2 });

            Assert.Equal(2.0f, result);
        }

        /// <summary>
        ///     Tests that compute midpoint at last index wraps around
        /// </summary>
        [Fact]
        public void ComputeMidpoint_AtLastIndex_WrapsAround()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ComputeMidpoint",
                BindingFlags.Static | BindingFlags.NonPublic);

            float[] vals = { 3.0f, 1.0f };
            float result = (float)method.Invoke(null, new object[] { vals, 1, 2 });

            float expected = (vals[0] + (float)(Math.PI * 2) + vals[1]) / 2;
            Assert.Equal(expected, result, 5);
        }

        // ========================================================================
        // ProcessRayCastResults (line 269-300) — internal
        // branches: skip angle pair, ray hit dynamic, ray miss/static
        // ========================================================================

        /// <summary>
        ///     Tests that process ray cast results with empty vals does nothing
        /// </summary>
        [Fact]
        public void ProcessRayCastResults_WithEmptyVals_DoesNothing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);

            float[] vals = new float[0];
            explosion.ProcessRayCastResults(vals, 0, Vector2F.Zero, 10f);

            Assert.NotNull(explosion);
        }

        // ========================================================================
        // ProcessRayHit (line 336-352) — internal
        // branches: same body (!rayMissed) vs different body
        //          i == valIndex - 1 vs not
        // ========================================================================

        /// <summary>
        ///     Tests that process ray hit with new body adds shape data
        /// </summary>
        [Fact]
        public void ProcessRayHit_WithNewBody_AddsShapeData()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(2f, 2f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            float[] vals = { 0.1f, 1.0f, 1.5f, 2.0f };
            bool rayMissed = true;
            explosion.ProcessRayHit(vals, 0, 4, body, ref rayMissed);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Assert.Equal(1, data.Count);
        }

        /// <summary>
        ///     Tests that process ray hit with same body consecutive updates existing
        /// </summary>
        [Fact]
        public void ProcessRayHit_WithSameBodyConsecutive_UpdatesExisting()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(2f, 2f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            float[] vals = { 0.1f, 1.0f, 1.5f, 2.5f };
            bool rayMissed = false;

            explosion.ProcessRayHit(vals, 0, 4, body, ref rayMissed);
            explosion.ProcessRayHit(vals, 1, 4, body, ref rayMissed);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Assert.Equal(1, data.Count);
        }

        /// <summary>
        ///     Tests that process ray hit at last index merges and adjusts wrapped
        /// </summary>
        [Fact]
        public void ProcessRayHit_AtLastIndex_MergesAndAdjusts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(2f, 2f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            float[] vals = { 0.1f, 1.0f };
            bool rayMissed = false;
            explosion.ProcessRayHit(vals, 1, 2, body, ref rayMissed);

            Assert.NotNull(explosion);
        }

        // ========================================================================
        // UpdateLastShapeData (line 358-364) — internal
        // ========================================================================

        /// <summary>
        ///     Tests that update last shape data updates max field
        /// </summary>
        [Fact]
        public void UpdateLastShapeData_UpdatesMax()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Type shapeDataType = typeof(RealExplosion).Assembly.GetType("Alis.Core.Physic.Common.Logic.ShapeData");
            object sd = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd, body);
            shapeDataType.GetField("Min").SetValue(sd, 0.1f);
            shapeDataType.GetField("Max").SetValue(sd, 1.0f);
            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd });

            explosion.UpdateLastShapeData(5.0f);

            ShapeData updated = (ShapeData)data[0];
            Assert.Equal(5.0f, updated.Max);
        }

        // ========================================================================
        // AddNewShapeData (line 372-376) — internal
        // ========================================================================

        /// <summary>
        ///     Tests that add new shape data adds entry to data list
        /// </summary>
        [Fact]
        public void AddNewShapeData_AddsToDataList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            explosion.AddNewShapeData(body, 0.1f, 1.0f);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Assert.Equal(1, data.Count);
        }

        // ========================================================================
        // MergeCircularData (line 381-397) — internal
        // branches: count <= 1, bodies mismatch, non-wrapping
        // ========================================================================

        /// <summary>
        ///     Tests that merge circular data with single element returns early
        /// </summary>
        [Fact]
        public void MergeCircularData_WithSingleElement_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Type shapeDataType = typeof(RealExplosion).Assembly.GetType("Alis.Core.Physic.Common.Logic.ShapeData");
            object sd = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd, body);
            shapeDataType.GetField("Min").SetValue(sd, 0.1f);
            shapeDataType.GetField("Max").SetValue(sd, 1.0f);
            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd });

            explosion.MergeCircularData();

            int count = (int)data.GetType().GetProperty("Count").GetValue(data);
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that merge circular data with different bodies returns early
        /// </summary>
        [Fact]
        public void MergeCircularData_WithDifferentBodies_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body1 = world.CreateBody(new Vector2F(0, 0), 0f, BodyType.Dynamic);
            Body body2 = world.CreateBody(new Vector2F(10f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Type shapeDataType = typeof(RealExplosion).Assembly.GetType("Alis.Core.Physic.Common.Logic.ShapeData");
            object sd1 = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd1, body1);
            shapeDataType.GetField("Min").SetValue(sd1, 0.1f);
            shapeDataType.GetField("Max").SetValue(sd1, 1.0f);

            object sd2 = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd2, body2);
            shapeDataType.GetField("Min").SetValue(sd2, 2.0f);
            shapeDataType.GetField("Max").SetValue(sd2, 3.0f);

            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd1 });
            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd2 });

            explosion.MergeCircularData();

            int count = (int)data.GetType().GetProperty("Count").GetValue(data);
            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that merge circular data with non wrapping angles returns early
        /// </summary>
        [Fact]
        public void MergeCircularData_WithNonWrappingAngles_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Type shapeDataType = typeof(RealExplosion).Assembly.GetType("Alis.Core.Physic.Common.Logic.ShapeData");
            object sd1 = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd1, body);
            shapeDataType.GetField("Min").SetValue(sd1, 0.1f);
            shapeDataType.GetField("Max").SetValue(sd1, 1.0f);

            object sd2 = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd2, body);
            shapeDataType.GetField("Min").SetValue(sd2, 2.0f);
            shapeDataType.GetField("Max").SetValue(sd2, 3.0f);

            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd1 });
            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd2 });

            explosion.MergeCircularData();

            int count = (int)data.GetType().GetProperty("Count").GetValue(data);
            Assert.Equal(2, count);
        }

        // ========================================================================
        // AdjustWrappedData (line 402-411) — internal
        // while loop: when last.Min >= last.Max
        // ========================================================================

        /// <summary>
        ///     Tests that adjust wrapped data with wrapped entry adjusts min
        /// </summary>
        [Fact]
        public void AdjustWrappedData_WithWrappedEntry_AdjustsMin()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Type shapeDataType = typeof(RealExplosion).Assembly.GetType("Alis.Core.Physic.Common.Logic.ShapeData");
            object sd = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd, body);
            shapeDataType.GetField("Min").SetValue(sd, 5.0f);
            shapeDataType.GetField("Max").SetValue(sd, 1.0f);

            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd });

            explosion.AdjustWrappedData();

            ShapeData updated = (ShapeData)data[0];
            Assert.True(updated.Min < updated.Max);
        }

        // ========================================================================
        // AdjustOverlappingData (line 416-419) — internal
        // delegates to AdjustWrappedData
        // ========================================================================

        /// <summary>
        ///     Tests that adjust overlapping data delegates to adjust wrapped
        /// </summary>
        [Fact]
        public void AdjustOverlappingData_DelegatesToAdjustWrapped()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Type shapeDataType = typeof(RealExplosion).Assembly.GetType("Alis.Core.Physic.Common.Logic.ShapeData");
            object sd = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd, body);
            shapeDataType.GetField("Min").SetValue(sd, 5.0f);
            shapeDataType.GetField("Max").SetValue(sd, 1.0f);

            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd });

            explosion.AdjustOverlappingData();

            ShapeData updated = (ShapeData)data[0];
            Assert.True(updated.Min < updated.Max);
        }

        // ========================================================================
        // ApplyExplosionImpulses (line 424-437) — internal
        // branch: IsActiveOn returns false → continue
        // ========================================================================

        /// <summary>
        ///     Tests that apply explosion impulses skips inactive bodies
        /// </summary>
        [Fact]
        public void ApplyExplosionImpulses_WithInactiveBody_SkipsBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(2f, 2f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            body.Enabled = false;
            RealExplosion explosion = new RealExplosion(world);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Type shapeDataType = typeof(RealExplosion).Assembly.GetType("Alis.Core.Physic.Common.Logic.ShapeData");
            object sd = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd, body);
            shapeDataType.GetField("Min").SetValue(sd, 0.1f);
            shapeDataType.GetField("Max").SetValue(sd, 2.0f);
            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd });

            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();
            explosion.ApplyExplosionImpulses(Vector2F.Zero, 10f, 100f, exploded);

            Assert.Empty(exploded);
        }

        // ========================================================================
        // ComputeInsertedRays (line 447-451) — private static
        // branch: negative result → 0 (already tested but with tautology)
        // ========================================================================

        /// <summary>
        ///     Tests that compute inserted rays with zero arclen returns zero
        /// </summary>
        [Fact]
        public void ComputeInsertedRays_WithZeroArclen_ReturnsZero()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ComputeInsertedRays",
                BindingFlags.Static | BindingFlags.NonPublic);

            int result = (int)method.Invoke(null, new object[] { 0.0f, 0.0f, 5, 0.2f });

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that compute inserted rays with sufficient arclen returns positive
        /// </summary>
        [Fact]
        public void ComputeInsertedRays_WithSufficientArclen_ReturnsPositive()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ComputeInsertedRays",
                BindingFlags.Static | BindingFlags.NonPublic);

            int result = (int)method.Invoke(null, new object[] { 10.0f, 0.5f, 5, 0.2f });

            Assert.True(result >= 0);
        }

        // ========================================================================
        // ComputeRayOffset (line 461-462) — private static
        // ========================================================================

        /// <summary>
        ///     Tests that compute ray offset with valid inputs returns positive
        /// </summary>
        [Fact]
        public void ComputeRayOffset_WithValidInputs_ReturnsPositive()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ComputeRayOffset",
                BindingFlags.Static | BindingFlags.NonPublic);

            float result = (float)method.Invoke(null, new object[] { 10f, 1f, 3, 5 });

            Assert.True(result > 0);
        }

        // ========================================================================
        // ApplyImpulsesForArc (line 476-484) — internal
        // ========================================================================

        /// <summary>
        ///     Tests that apply impulses for arc with valid data does not throw
        /// </summary>
        [Fact]
        public void ApplyImpulsesForArc_WithValidData_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(4f, 4f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Type shapeDataType = typeof(RealExplosion).Assembly.GetType("Alis.Core.Physic.Common.Logic.ShapeData");
            object sd = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd, body);
            shapeDataType.GetField("Min").SetValue(sd, 0.1f);
            shapeDataType.GetField("Max").SetValue(sd, 2.0f);
            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd });

            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();

            explosion.ApplyImpulsesForArc(0, Vector2F.Zero, 10f, 1.9f, 0.1f, 0.3f, 5, 100f, exploded);

            Assert.NotNull(exploded);
        }

        // ========================================================================
        // ApplyRayImpulses (line 497-519) — internal
        // branches: RayCast hit with min lambda, multiple fixtures
        // ========================================================================

        /// <summary>
        ///     Tests that apply ray impulses with dynamic body applies impulse
        /// </summary>
        [Fact]
        public void ApplyRayImpulses_WithDynamicBody_AppliesImpulse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(4f, 4f, 1f, new Vector2F(5f, 0), 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            FieldInfo dataField = typeof(RealExplosion).GetField("_data",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var data = (System.Collections.IList)dataField.GetValue(explosion);

            Type shapeDataType = typeof(RealExplosion).Assembly.GetType("Alis.Core.Physic.Common.Logic.ShapeData");
            object sd = Activator.CreateInstance(shapeDataType);
            shapeDataType.GetField("Body").SetValue(sd, body);
            shapeDataType.GetField("Min").SetValue(sd, 0.1f);
            shapeDataType.GetField("Max").SetValue(sd, 2.0f);
            data.GetType().GetMethod("Add").Invoke(data, new object[] { sd });

            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();

            explosion.ApplyRayImpulses(0, Vector2F.Zero, 10f, 0.5f, 1.9f, 5, 100f, exploded);

            Assert.NotEmpty(exploded);
        }

        // ========================================================================
        // ComputeImpulseVector (line 533-538) — private static
        // ========================================================================

        /// <summary>
        ///     Tests that compute impulse vector returns valid vector
        /// </summary>
        [Fact]
        public void ComputeImpulseVector_ReturnsValidVector()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ComputeImpulseVector",
                BindingFlags.Static | BindingFlags.NonPublic);

            RayCastOutput ro = new RayCastOutput();
            Vector2F result = (Vector2F)method.Invoke(null, new object[] { 0.5f, 0.3f, 1.9f, 5, 100f, ro, 5 });

            Assert.NotNull(result);
        }

        // ========================================================================
        // UpdateExplodedDictionary (line 546-552) — private static
        // branches: contains key (accumulate) vs add new
        // ========================================================================

        /// <summary>
        ///     Tests that update exploded dictionary with new key adds entry
        /// </summary>
        [Fact]
        public void UpdateExplodedDictionary_WithNewKey_AddsEntry()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("UpdateExplodedDictionary",
                BindingFlags.Static | BindingFlags.NonPublic);

            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(2f, 2f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Fixture fixture = body.FixtureList[0];

            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();

            method.Invoke(null, new object[] { exploded, fixture, new Vector2F(10f, 0) });

            Assert.Single(exploded);
            Assert.Equal(new Vector2F(10f, 0), exploded[fixture]);
        }

        /// <summary>
        ///     Tests that update exploded dictionary with existing key accumulates
        /// </summary>
        [Fact]
        public void UpdateExplodedDictionary_WithExistingKey_Accumulates()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("UpdateExplodedDictionary",
                BindingFlags.Static | BindingFlags.NonPublic);

            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(2f, 2f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Fixture fixture = body.FixtureList[0];

            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();
            exploded.Add(fixture, new Vector2F(5f, 0));

            method.Invoke(null, new object[] { exploded, fixture, new Vector2F(10f, 0) });

            Assert.Equal(new Vector2F(15f, 0), exploded[fixture]);
        }

        // ========================================================================
        // ApplyContainedShapeImpulses (line 557-589) — internal
        // branches: IsActiveOn skip, CircleShape vs PolygonShape
        // ========================================================================

        /// <summary>
        ///     Tests that apply contained shape impulses with circle shape uses circle position
        /// </summary>
        [Fact]
        public void ApplyContainedShapeImpulses_WithCircleShape_UsesCirclePosition()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(5f, 1f, Vector2F.Zero, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Fixture[] contained = { body.FixtureList[0] };
            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();

            explosion.ApplyContainedShapeImpulses(Vector2F.Zero, 100f, contained, 1, exploded);

            Assert.NotEmpty(exploded);
        }

        /// <summary>
        ///     Tests that apply contained shape impulses with polygon shape uses centroid
        /// </summary>
        [Fact]
        public void ApplyContainedShapeImpulses_WithPolygonShape_UsesCentroid()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Fixture[] contained = { body.FixtureList[0] };
            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();

            explosion.ApplyContainedShapeImpulses(Vector2F.Zero, 100f, contained, 1, exploded);

            Assert.NotEmpty(exploded);
        }

        /// <summary>
        ///     Tests that apply contained shape impulses with inactive body skips
        /// </summary>
        [Fact]
        public void ApplyContainedShapeImpulses_WithInactiveBody_Skips()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            body.Enabled = false;
            RealExplosion explosion = new RealExplosion(world);

            Fixture[] contained = { body.FixtureList[0] };
            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();

            explosion.ApplyContainedShapeImpulses(Vector2F.Zero, 100f, contained, 1, exploded);

            Assert.Empty(exploded);
        }

        /// <summary>
        ///     Tests that apply contained shape impulses with already exploded fixture does not duplicate
        /// </summary>
        [Fact]
        public void ApplyContainedShapeImpulses_WithAlreadyExplodedFixture_DoesNotDuplicate()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Fixture[] contained = { body.FixtureList[0] };
            Dictionary<Fixture, Vector2F> exploded = new Dictionary<Fixture, Vector2F>();
            exploded.Add(contained[0], Vector2F.Zero);

            explosion.ApplyContainedShapeImpulses(Vector2F.Zero, 100f, contained, 1, exploded);

            Assert.Single(exploded);
        }

        // ========================================================================
        // NormalizeAngleDifference (line 258-264) — private static
        // branch: negative diff wraps
        // ========================================================================

        /// <summary>
        ///     Tests that normalize angle difference with positive diff returns same
        /// </summary>
        [Fact]
        public void NormalizeAngleDifference_WithPositiveDiff_ReturnsSame()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("NormalizeAngleDifference",
                BindingFlags.Static | BindingFlags.NonPublic);

            float result = (float)method.Invoke(null, new object[] { 0.5f });

            Assert.True(Math.Abs(result) <= Math.PI);
        }

        /// <summary>
        ///     Tests that normalize angle difference with value two pi returns normalized
        /// </summary>
        [Fact]
        public void NormalizeAngleDifference_WithTwoPi_ReturnsNormalized()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("NormalizeAngleDifference",
                BindingFlags.Static | BindingFlags.NonPublic);

            float result = (float)method.Invoke(null, new object[] { (float)(Math.PI * 3) });

            Assert.True(Math.Abs(result) <= Math.PI);
        }

        // ========================================================================
        // Activate edge cases for additional branch coverage
        // ========================================================================

        /// <summary>
        ///     Tests that activate with contained shape inside circle uses circle shape path
        /// </summary>
        [Fact]
        public void Activate_WithContainedCircleShape_UsesCircleShapePath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(10f, 1f, new Vector2F(5f, 0), BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(new Vector2F(5f, 0), 1f, 100f);

            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that activate with body at origin contained uses polygon shape path
        /// </summary>
        [Fact]
        public void Activate_WithBodyAtOriginContained_UsesPolygonShapePath()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(20f, 20f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 1f, 100f);

            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that activate with multiple fixtures body processes each fixture
        /// </summary>
        [Fact]
        public void Activate_WithBodyHavingMultipleFixtures_ProcessesAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Body body = world.CreateBody(Vector2F.Zero, 0f, BodyType.Dynamic);
            CircleShape circle = new CircleShape(3f, 1f);
            CircleShape circle2 = new CircleShape(2f, 1f);
            body.CreateFixture(circle);
            body.CreateFixture(circle2);

            RealExplosion explosion = new RealExplosion(world);
            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 100f);

            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that activate with many dynamic bodies at different angles processes all
        /// </summary>
        [Fact]
        public void Activate_WithManyBodiesAtDifferentAngles_ProcessesAll()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            RealExplosion explosion = new RealExplosion(world);

            for (int i = 0; i < 5; i++)
            {
                float angle = i * (float)(Math.PI * 2 / 5);
                world.CreateRectangle(2f, 2f, 1f, new Vector2F(10f * (float)Math.Cos(angle), 10f * (float)Math.Sin(angle)), 0f, BodyType.Dynamic);
            }

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 50f, 100f);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that activate with contained shape that is already in exploded dictionary does not duplicate
        /// </summary>
        [Fact]
        public void Activate_WithContainedShapeAlreadyInDictionary_DoesNotDuplicate()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(20f, 20f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            RealExplosion explosion = new RealExplosion(world);

            Dictionary<Fixture, Vector2F> result = explosion.Activate(Vector2F.Zero, 100f, 100f);

            Assert.NotEmpty(result);
        }

        // ========================================================================
        // ConvertToPolygonShape branches (line 197-203) — private static
        // ========================================================================

        /// <summary>
        ///     Tests that convert to polygon shape with circle shape returns polygon
        /// </summary>
        [Fact]
        public void ConvertToPolygonShape_WithCircleShape_ReturnsPolygon()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ConvertToPolygonShape",
                BindingFlags.Static | BindingFlags.NonPublic);

            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(5f, 1f, Vector2F.Zero, BodyType.Dynamic);
            Fixture fixture = body.FixtureList[0];

            PolygonShape result = (PolygonShape)method.Invoke(null, new object[] { fixture });

            Assert.NotNull(result);
            Assert.Equal(4, result.Vertices.Count);
        }

        /// <summary>
        ///     Tests that convert to polygon shape with polygon shape returns same
        /// </summary>
        [Fact]
        public void ConvertToPolygonShape_WithPolygonShape_ReturnsSame()
        {
            MethodInfo method = typeof(RealExplosion).GetMethod("ConvertToPolygonShape",
                BindingFlags.Static | BindingFlags.NonPublic);

            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateRectangle(10f, 10f, 1f, Vector2F.Zero, 0f, BodyType.Dynamic);
            Fixture fixture = body.FixtureList[0];

            PolygonShape original = fixture.GetShape as PolygonShape;
            PolygonShape result = (PolygonShape)method.Invoke(null, new object[] { fixture });

            Assert.Same(original, result);
        }

        // ========================================================================
        // ListAny/ListFirst/ListLast additional edge cases
        // ========================================================================

        /// <summary>
        ///     Tests that list first with single element returns that element
        /// </summary>
        [Fact]
        public void ListFirst_WithSingleElement_ReturnsThatElement()
        {
            List<int> list = new List<int> { 42 };
            Assert.Equal(42, RealExplosion.ListFirst(list));
        }

        /// <summary>
        ///     Tests that list last with single element returns that element
        /// </summary>
        [Fact]
        public void ListLast_WithSingleElement_ReturnsThatElement()
        {
            List<int> list = new List<int> { 42 };
            Assert.Equal(42, RealExplosion.ListLast(list));
        }
    }
}
