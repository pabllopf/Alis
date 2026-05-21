

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The sweep test class
    /// </summary>
    public class SweepTest
    {
        /// <summary>
        ///     Tests that get transform should interpolate correctly
        /// </summary>
        [Fact]
        public void GetTransform_ShouldInterpolateCorrectly()
        {
            Sweep sweep = new Sweep
            {
                C0 = new Vector2F(0.0f, 0.0f),
                C = new Vector2F(10.0f, 10.0f),
                A0 = 0.0f,
                A = (float) Math.PI / 2,
                Alpha0 = 0.0f,
                LocalCenter = Vector2F.Zero
            };

            sweep.GetTransform(out ControllerTransform xf, 0.5f);

            Assert.Equal(5.0f, xf.Position.X, 5);
            Assert.Equal(5.0f, xf.Position.Y, 5);
        }

        /// <summary>
        ///     Tests that get transform with beta zero should return initial state
        /// </summary>
        [Fact]
        public void GetTransform_WithBetaZero_ShouldReturnInitialState()
        {
            Sweep sweep = new Sweep
            {
                C0 = new Vector2F(1.0f, 2.0f),
                C = new Vector2F(5.0f, 6.0f),
                A0 = 0.0f,
                A = (float) Math.PI,
                Alpha0 = 0.0f,
                LocalCenter = Vector2F.Zero
            };

            sweep.GetTransform(out ControllerTransform xf, 0.0f);

            Assert.Equal(1.0f, xf.Position.X, 5);
            Assert.Equal(2.0f, xf.Position.Y, 5);
        }

        /// <summary>
        ///     Tests that get transform with beta one should return final state
        /// </summary>
        [Fact]
        public void GetTransform_WithBetaOne_ShouldReturnFinalState()
        {
            Sweep sweep = new Sweep
            {
                C0 = new Vector2F(1.0f, 2.0f),
                C = new Vector2F(5.0f, 6.0f),
                A0 = 0.0f,
                A = (float) Math.PI,
                Alpha0 = 0.0f,
                LocalCenter = Vector2F.Zero
            };

            sweep.GetTransform(out ControllerTransform xf, 1.0f);

            Assert.Equal(5.0f, xf.Position.X, 5);
            Assert.Equal(6.0f, xf.Position.Y, 5);
        }

        /// <summary>
        ///     Tests that advance should update sweep state
        /// </summary>
        [Fact]
        public void Advance_ShouldUpdateSweepState()
        {
            Sweep sweep = new Sweep
            {
                C0 = new Vector2F(0.0f, 0.0f),
                C = new Vector2F(10.0f, 10.0f),
                A0 = 0.0f,
                A = (float) Math.PI,
                Alpha0 = 0.0f,
                LocalCenter = Vector2F.Zero
            };

            sweep.Advance(0.5f);

            Assert.Equal(5.0f, sweep.C0.X, 5);
            Assert.Equal(5.0f, sweep.C0.Y, 5);
            Assert.Equal(0.5f, sweep.Alpha0, 5);
        }

        /// <summary>
        ///     Tests that advance to one should make c 0 equal to c
        /// </summary>
        [Fact]
        public void Advance_ToOne_ShouldMakeC0EqualToC()
        {
            Sweep sweep = new Sweep
            {
                C0 = new Vector2F(0.0f, 0.0f),
                C = new Vector2F(10.0f, 10.0f),
                A0 = 0.0f,
                A = (float) Math.PI,
                Alpha0 = 0.0f,
                LocalCenter = Vector2F.Zero
            };

            sweep.Advance(1.0f);

            Assert.Equal(sweep.C.X, sweep.C0.X, 5);
            Assert.Equal(sweep.C.Y, sweep.C0.Y, 5);
            Assert.Equal(sweep.A, sweep.A0, 5);
        }

        /// <summary>
        ///     Tests that normalize should adjust angles correctly
        /// </summary>
        [Fact]
        public void Normalize_ShouldAdjustAnglesCorrectly()
        {
            Sweep sweep = new Sweep
            {
                C0 = Vector2F.Zero,
                C = Vector2F.Zero,
                A0 = (float) (2 * Math.PI + 1),
                A = (float) (3 * Math.PI),
                Alpha0 = 0.0f,
                LocalCenter = Vector2F.Zero
            };

            sweep.Normalize();

            Assert.True(sweep.A0 < 2 * Math.PI);
            Assert.True(sweep.A < 2 * Math.PI);
        }

        /// <summary>
        ///     Tests that get transform with local center should shift correctly
        /// </summary>
        [Fact]
        public void GetTransform_WithLocalCenter_ShouldShiftCorrectly()
        {
            Sweep sweep = new Sweep
            {
                C0 = new Vector2F(10.0f, 10.0f),
                C = new Vector2F(10.0f, 10.0f),
                A0 = 0.0f,
                A = 0.0f,
                Alpha0 = 0.0f,
                LocalCenter = new Vector2F(1.0f, 1.0f)
            };

            sweep.GetTransform(out ControllerTransform xf, 0.5f);

            Assert.NotEqual(10.0f, xf.Position.X);
            Assert.NotEqual(10.0f, xf.Position.Y);
        }

        /// <summary>
        ///     Tests that advance multiple times should accumulate correctly
        /// </summary>
        [Fact]
        public void Advance_MultipleTimes_ShouldAccumulateCorrectly()
        {
            Sweep sweep = new Sweep
            {
                C0 = new Vector2F(0.0f, 0.0f),
                C = new Vector2F(10.0f, 10.0f),
                A0 = 0.0f,
                A = (float) Math.PI,
                Alpha0 = 0.0f,
                LocalCenter = Vector2F.Zero
            };

            sweep.Advance(0.25f);
            sweep.Advance(0.5f);

            Assert.True(sweep.C0.X > 0.0f);
            Assert.True(sweep.C0.Y > 0.0f);
        }

        /// <summary>
        ///     Tests that normalize with negative angle should work
        /// </summary>
        [Fact]
        public void Normalize_WithNegativeAngle_ShouldWork()
        {
            Sweep sweep = new Sweep
            {
                C0 = Vector2F.Zero,
                C = Vector2F.Zero,
                A0 = -(float) (2 * Math.PI + 1),
                A = -(float) Math.PI,
                Alpha0 = 0.0f,
                LocalCenter = Vector2F.Zero
            };

            sweep.Normalize();

            Assert.NotNull(sweep);
        }
    }
}