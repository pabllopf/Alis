

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Platforms.Osx.Native;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx.Native
{
    /// <summary>
    ///     Tests for the NsPoint struct validating OSX native coordinate representation.
    /// </summary>
    public class NsPointTest
    {
        /// <summary>
        ///     Tests that NsPoint is a struct type.
        /// </summary>
        [Fact]
        public void NsPoint_IsStruct_TypeIsCorrect()
        {
            Type pointType = typeof(NsPoint);

            Assert.True(pointType.IsValueType);
        }

        /// <summary>
        ///     Tests that NsPoint is public.
        /// </summary>
        [Fact]
        public void NsPoint_IsPublic_CanBeAccessed()
        {
            Type pointType = typeof(NsPoint);

            Assert.True(pointType.IsPublic);
        }


        /// <summary>
        ///     Tests that NsPoint has X field.
        /// </summary>
        [Fact]
        public void NsPoint_X_FieldExists()
        {
            FieldInfo xField = typeof(NsPoint).GetField("X");

            Assert.NotNull(xField);
            Assert.Equal(typeof(double), xField.FieldType);
        }

        /// <summary>
        ///     Tests that NsPoint has Y field.
        /// </summary>
        [Fact]
        public void NsPoint_Y_FieldExists()
        {
            FieldInfo yField = typeof(NsPoint).GetField("Y");

            Assert.NotNull(yField);
            Assert.Equal(typeof(double), yField.FieldType);
        }

        /// <summary>
        ///     Tests that NsPoint X and Y fields are public.
        /// </summary>
        [Fact]
        public void NsPoint_Fields_ArePublic()
        {
            FieldInfo xField = typeof(NsPoint).GetField("X");
            FieldInfo yField = typeof(NsPoint).GetField("Y");

            Assert.True(xField.IsPublic);
            Assert.True(yField.IsPublic);
        }

        /// <summary>
        ///     Tests that NsPoint can be instantiated.
        /// </summary>
        [Fact]
        public void NsPoint_CanBeInstantiated_StructCreationIsValid()
        {
            NsPoint point = new NsPoint {X = 10.5, Y = 20.5};

            Assert.Equal(10.5, point.X);
            Assert.Equal(20.5, point.Y);
        }

        /// <summary>
        ///     Tests that NsPoint X and Y can be modified after creation.
        /// </summary>
        [Fact]
        public void NsPoint_CanModifyFields_ValuesCanBeChanged()
        {
            NsPoint point = new NsPoint {X = 0, Y = 0};

            point.X = 5.0;
            point.Y = 10.0;

            Assert.Equal(5.0, point.X);
            Assert.Equal(10.0, point.Y);
        }

        /// <summary>
        ///     Tests that NsPoint fields are double precision.
        /// </summary>
        [Fact]
        public void NsPoint_Fields_AreDoublePrecision()
        {
            NsPoint point = new NsPoint {X = 3.14159265358979, Y = 2.71828182845905};

            Assert.Equal(3.14159265358979, point.X);
            Assert.Equal(2.71828182845905, point.Y);
        }

        /// <summary>
        ///     Tests that NsPoint supports default value initialization.
        /// </summary>
        [Fact]
        public void NsPoint_DefaultInitialization_CreatesZeroCoordinates()
        {
            NsPoint point = new NsPoint();

            Assert.Equal(0.0, point.X);
            Assert.Equal(0.0, point.Y);
        }

        /// <summary>
        ///     Tests that NsPoint struct can be used in collections.
        /// </summary>
        [Fact]
        public void NsPoint_CanBeStoredInCollections_ListSupport()
        {
            List<NsPoint> points = new List<NsPoint>
            {
                new NsPoint {X = 0, Y = 0},
                new NsPoint {X = 10, Y = 10},
                new NsPoint {X = 20, Y = 20}
            };

            Assert.Equal(3, points.Count);
            Assert.Equal(10, points[1].X);
        }

        /// <summary>
        ///     Tests that NsPoint can be used in native P/Invoke calls.
        /// </summary>
        [Fact]
        public void NsPoint_IsMarshallable_InteropIsSupported()
        {
            Type pointType = typeof(NsPoint);

            int marshalSize = Marshal.SizeOf(pointType);

            Assert.Equal(16, marshalSize); // 2 doubles = 16 bytes
        }
    }
}