// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector4FTest.cs
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

using System.Runtime.Serialization;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    ///     Comprehensive unit tests for Vector4F class
    /// </summary>
    public class Vector4FTest
    {
        /// <summary>
        ///     Tests that constructor with four values initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_WithFourValues_InitializesCorrectly()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            Assert.Equal(1f, v.X);
            Assert.Equal(2f, v.Y);
            Assert.Equal(3f, v.Z);
            Assert.Equal(4f, v.W);
        }

        /// <summary>
        ///     Tests that constructor default initializes to zero
        /// </summary>
        [Fact]
        public void Constructor_Default_InitializesToZero()
        {
            Vector4F v = new Vector4F();

            Assert.Equal(0f, v.X);
            Assert.Equal(0f, v.Y);
            Assert.Equal(0f, v.Z);
            Assert.Equal(0f, v.W);
        }

        /// <summary>
        ///     Tests that properties can be set and retrieved
        /// </summary>
        [Fact]
        public void Properties_CanBeSetAndRetrieved()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            v.X = 5f;
            v.Y = 6f;
            v.Z = 7f;
            v.W = 8f;

            Assert.Equal(5f, v.X);
            Assert.Equal(6f, v.Y);
            Assert.Equal(7f, v.Z);
            Assert.Equal(8f, v.W);
        }

        /// <summary>
        ///     Tests that equals with same vector returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameVector_ReturnsTrue()
        {
            Vector4F v1 = new Vector4F(1f, 2f, 3f, 4f);
            Vector4F v2 = new Vector4F(1f, 2f, 3f, 4f);

            Assert.True(v1.Equals(v2));
        }

        /// <summary>
        ///     Tests that equals with different vector returns false
        /// </summary>
        [Fact]
        public void Equals_WithDifferentVector_ReturnsFalse()
        {
            Vector4F v1 = new Vector4F(1f, 2f, 3f, 4f);
            Vector4F v2 = new Vector4F(5f, 6f, 7f, 8f);

            Assert.False(v1.Equals(v2));
        }

        /// <summary>
        ///     Tests that equals with object override works correctly
        /// </summary>
        [Fact]
        public void Equals_WithObjectOverride_WorksCorrectly()
        {
            Vector4F v1 = new Vector4F(1f, 2f, 3f, 4f);
            object v2 = new Vector4F(1f, 2f, 3f, 4f);
            object v3 = "not a vector";

            Assert.True(v1.Equals(v2));
            Assert.False(v1.Equals(v3));
        }

        /// <summary>
        ///     Tests that get hash code with same vector returns same hash
        /// </summary>
        [Fact]
        public void GetHashCode_WithSameVector_ReturnsSameHash()
        {
            Vector4F v1 = new Vector4F(1f, 2f, 3f, 4f);
            Vector4F v2 = new Vector4F(1f, 2f, 3f, 4f);
            Vector4F v3 = new Vector4F(5f, 6f, 7f, 8f);

            Assert.Equal(v1.GetHashCode(), v2.GetHashCode());
            Assert.NotEqual(v1.GetHashCode(), v3.GetHashCode());
        }

        /// <summary>
        ///     Tests that to string returns formatted string
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            string str = v.ToString();

            Assert.NotNull(str);
            Assert.NotEmpty(str);
        }

        /// <summary>
        ///     Tests that get object data serializes vector
        /// </summary>
        [Fact]
        public void GetObjectData_SerializesVector()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            SerializationInfo serializationInfo = new SerializationInfo(typeof(Vector4F), new FormatterConverter());

            v.GetObjectData(serializationInfo, default(StreamingContext));

            Assert.Equal(1f, serializationInfo.GetSingle("x"));
            Assert.Equal(2f, serializationInfo.GetSingle("y"));
            Assert.Equal(3f, serializationInfo.GetSingle("z"));
            Assert.Equal(4f, serializationInfo.GetSingle("w"));
        }

        /// <summary>
        ///     Tests that get object data with different values serializes correctly
        /// </summary>
        [Fact]
        public void GetObjectData_WithDifferentValues_SerializesCorrectly()
        {
            Vector4F v = new Vector4F(10f, 20f, 30f, 40f);
            SerializationInfo serializationInfo = new SerializationInfo(typeof(Vector4F), new FormatterConverter());

            v.GetObjectData(serializationInfo, default(StreamingContext));

            Assert.Equal(10f, serializationInfo.GetSingle("x"));
            Assert.Equal(20f, serializationInfo.GetSingle("y"));
            Assert.Equal(30f, serializationInfo.GetSingle("z"));
            Assert.Equal(40f, serializationInfo.GetSingle("w"));
        }


        /// <summary>
        ///     Tests that get with index 0 returns x component
        /// </summary>
        [Fact]
        public void Get_WithIndex0_ReturnsXComponent()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            float result = Vector4F.Get(v, 0);

            Assert.Equal(1f, result);
        }

        /// <summary>
        ///     Tests that get with index 1 returns y component
        /// </summary>
        [Fact]
        public void Get_WithIndex1_ReturnsYComponent()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            float result = Vector4F.Get(v, 1);

            Assert.Equal(2f, result);
        }

        /// <summary>
        ///     Tests that get with index 2 returns z component
        /// </summary>
        [Fact]
        public void Get_WithIndex2_ReturnsZComponent()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            float result = Vector4F.Get(v, 2);

            Assert.Equal(3f, result);
        }

        /// <summary>
        ///     Tests that get with index 3 returns w component
        /// </summary>
        [Fact]
        public void Get_WithIndex3_ReturnsWComponent()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            float result = Vector4F.Get(v, 3);

            Assert.Equal(4f, result);
        }

        /// <summary>
        ///     Tests that get with negative index returns zero
        /// </summary>
        [Fact]
        public void Get_WithNegativeIndex_ReturnsZero()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            float result = Vector4F.Get(v, -1);

            Assert.Equal(0f, result);
        }

        /// <summary>
        ///     Tests that get with index out of range returns zero
        /// </summary>
        [Fact]
        public void Get_WithIndexOutOfRange_ReturnsZero()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            float result = Vector4F.Get(v, 4);

            Assert.Equal(0f, result);
        }

        /// <summary>
        ///     Tests that get with large index out of range returns zero
        /// </summary>
        [Fact]
        public void Get_WithLargeIndexOutOfRange_ReturnsZero()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            float result = Vector4F.Get(v, 100);

            Assert.Equal(0f, result);
        }

        /// <summary>
        ///     Tests that get with very large negative index returns zero
        /// </summary>
        [Fact]
        public void Get_WithVeryLargeNegativeIndex_ReturnsZero()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            float result = Vector4F.Get(v, int.MinValue);

            Assert.Equal(0f, result);
        }

        /// <summary>
        ///     Tests that get with all zero vector returns zero for all indices
        /// </summary>
        [Fact]
        public void Get_WithAllZeroVector_ReturnsZeroForAllIndices()
        {
            Vector4F v = new Vector4F(0f, 0f, 0f, 0f);

            Assert.Equal(0f, Vector4F.Get(v, 0));
            Assert.Equal(0f, Vector4F.Get(v, 1));
            Assert.Equal(0f, Vector4F.Get(v, 2));
            Assert.Equal(0f, Vector4F.Get(v, 3));
        }

        /// <summary>
        ///     Tests that get with negative components returns correct values
        /// </summary>
        [Fact]
        public void Get_WithNegativeComponents_ReturnsCorrectValues()
        {
            Vector4F v = new Vector4F(-1f, -2f, -3f, -4f);

            Assert.Equal(-1f, Vector4F.Get(v, 0));
            Assert.Equal(-2f, Vector4F.Get(v, 1));
            Assert.Equal(-3f, Vector4F.Get(v, 2));
            Assert.Equal(-4f, Vector4F.Get(v, 3));
        }

        /// <summary>
        ///     Tests that get with max value components returns correct values
        /// </summary>
        [Fact]
        public void Get_WithMaxValueComponents_ReturnsCorrectValues()
        {
            Vector4F v = new Vector4F(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);

            Assert.Equal(float.MaxValue, Vector4F.Get(v, 0));
            Assert.Equal(float.MaxValue, Vector4F.Get(v, 1));
            Assert.Equal(float.MaxValue, Vector4F.Get(v, 2));
            Assert.Equal(float.MaxValue, Vector4F.Get(v, 3));
        }

        /// <summary>
        ///     Tests that get with min value components returns correct values
        /// </summary>
        [Fact]
        public void Get_WithMinValueComponents_ReturnsCorrectValues()
        {
            Vector4F v = new Vector4F(float.MinValue, float.MinValue, float.MinValue, float.MinValue);

            Assert.Equal(float.MinValue, Vector4F.Get(v, 0));
            Assert.Equal(float.MinValue, Vector4F.Get(v, 1));
            Assert.Equal(float.MinValue, Vector4F.Get(v, 2));
            Assert.Equal(float.MinValue, Vector4F.Get(v, 3));
        }

        /// <summary>
        ///     Tests that get with positive infinity components returns correct values
        /// </summary>
        [Fact]
        public void Get_WithPositiveInfinityComponents_ReturnsCorrectValues()
        {
            Vector4F v = new Vector4F(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

            Assert.True(float.IsPositiveInfinity(Vector4F.Get(v, 0)));
            Assert.True(float.IsPositiveInfinity(Vector4F.Get(v, 1)));
            Assert.True(float.IsPositiveInfinity(Vector4F.Get(v, 2)));
            Assert.True(float.IsPositiveInfinity(Vector4F.Get(v, 3)));
        }

        /// <summary>
        ///     Tests that get with negative infinity components returns correct values
        /// </summary>
        [Fact]
        public void Get_WithNegativeInfinityComponents_ReturnsCorrectValues()
        {
            Vector4F v = new Vector4F(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

            Assert.True(float.IsNegativeInfinity(Vector4F.Get(v, 0)));
            Assert.True(float.IsNegativeInfinity(Vector4F.Get(v, 1)));
            Assert.True(float.IsNegativeInfinity(Vector4F.Get(v, 2)));
            Assert.True(float.IsNegativeInfinity(Vector4F.Get(v, 3)));
        }

        /// <summary>
        ///     Tests that get with na n components returns correct values
        /// </summary>
        [Fact]
        public void Get_WithNaNComponents_ReturnsCorrectValues()
        {
            Vector4F v = new Vector4F(float.NaN, float.NaN, float.NaN, float.NaN);

            Assert.True(float.IsNaN(Vector4F.Get(v, 0)));
            Assert.True(float.IsNaN(Vector4F.Get(v, 1)));
            Assert.True(float.IsNaN(Vector4F.Get(v, 2)));
            Assert.True(float.IsNaN(Vector4F.Get(v, 3)));
        }

        /// <summary>
        ///     Tests that get with mixed components returns correct values
        /// </summary>
        [Fact]
        public void Get_WithMixedComponents_ReturnsCorrectValues()
        {
            Vector4F v = new Vector4F(1.5f, -2.5f, 3.7f, -4.1f);

            Assert.Equal(1.5f, Vector4F.Get(v, 0));
            Assert.Equal(-2.5f, Vector4F.Get(v, 1));
            Assert.Equal(3.7f, Vector4F.Get(v, 2));
            Assert.Equal(-4.1f, Vector4F.Get(v, 3));
        }

        /// <summary>
        ///     Tests that get with very small components returns correct values
        /// </summary>
        [Fact]
        public void Get_WithVerySmallComponents_ReturnsCorrectValues()
        {
            Vector4F v = new Vector4F(0.0001f, 0.0002f, 0.0003f, 0.0004f);

            Assert.Equal(0.0001f, Vector4F.Get(v, 0));
            Assert.Equal(0.0002f, Vector4F.Get(v, 1));
            Assert.Equal(0.0003f, Vector4F.Get(v, 2));
            Assert.Equal(0.0004f, Vector4F.Get(v, 3));
        }

        /// <summary>
        ///     Tests that get with very large components returns correct values
        /// </summary>
        [Fact]
        public void Get_WithVeryLargeComponents_ReturnsCorrectValues()
        {
            Vector4F v = new Vector4F(1e30f, 1e31f, 1e32f, 1e33f);

            Assert.Equal(1e30f, Vector4F.Get(v, 0));
            Assert.Equal(1e31f, Vector4F.Get(v, 1));
            Assert.Equal(1e32f, Vector4F.Get(v, 2));
            Assert.Equal(1e33f, Vector4F.Get(v, 3));
        }

        /// <summary>
        ///     Tests that get with valid indices returns correct component
        /// </summary>
        /// <param name="index">The index</param>
        [Theory, InlineData(0), InlineData(1), InlineData(2), InlineData(3)]
        public void Get_WithValidIndices_ReturnsCorrectComponent(int index)
        {
            Vector4F v = new Vector4F(10f, 20f, 30f, 40f);
            float expected = (index + 1) * 10f;

            float result = Vector4F.Get(v, index);

            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that get with invalid indices returns zero
        /// </summary>
        /// <param name="index">The index</param>
        [Theory, InlineData(-1), InlineData(-10), InlineData(4), InlineData(5), InlineData(10), InlineData(100)]
        public void Get_WithInvalidIndices_ReturnsZero(int index)
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            float result = Vector4F.Get(v, index);

            Assert.Equal(0f, result);
        }


        /// <summary>
        ///     Tests that constructor with four values initializes all components
        /// </summary>
        [Fact]
        public void Constructor_WithFourValues_InitializesAllComponents()
        {
            Vector4F v = new Vector4F(1.5f, 2.5f, 3.5f, 4.5f);

            Assert.Equal(1.5f, v.X);
            Assert.Equal(2.5f, v.Y);
            Assert.Equal(3.5f, v.Z);
            Assert.Equal(4.5f, v.W);
        }

        /// <summary>
        ///     Tests that constructor with zero values initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_WithZeroValues_InitializesCorrectly()
        {
            Vector4F v = new Vector4F(0f, 0f, 0f, 0f);

            Assert.Equal(0f, v.X);
            Assert.Equal(0f, v.Y);
            Assert.Equal(0f, v.Z);
            Assert.Equal(0f, v.W);
        }

        /// <summary>
        ///     Tests that constructor with negative values initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeValues_InitializesCorrectly()
        {
            Vector4F v = new Vector4F(-1f, -2f, -3f, -4f);

            Assert.Equal(-1f, v.X);
            Assert.Equal(-2f, v.Y);
            Assert.Equal(-3f, v.Z);
            Assert.Equal(-4f, v.W);
        }


        /// <summary>
        ///     Tests that x property can be set and retrieved
        /// </summary>
        [Fact]
        public void XProperty_CanBeSetAndRetrieved()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            v.X = 10f;

            Assert.Equal(10f, v.X);
        }

        /// <summary>
        ///     Tests that y property can be set and retrieved
        /// </summary>
        [Fact]
        public void YProperty_CanBeSetAndRetrieved()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            v.Y = 20f;

            Assert.Equal(20f, v.Y);
        }

        /// <summary>
        ///     Tests that z property can be set and retrieved
        /// </summary>
        [Fact]
        public void ZProperty_CanBeSetAndRetrieved()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            v.Z = 30f;

            Assert.Equal(30f, v.Z);
        }

        /// <summary>
        ///     Tests that w property can be set and retrieved
        /// </summary>
        [Fact]
        public void WProperty_CanBeSetAndRetrieved()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            v.W = 40f;

            Assert.Equal(40f, v.W);
        }

        /// <summary>
        ///     Tests that all properties can be set independently
        /// </summary>
        [Fact]
        public void AllProperties_CanBeSetIndependently()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);

            v.X = 10f;
            v.Y = 20f;
            v.Z = 30f;
            v.W = 40f;

            Assert.Equal(10f, v.X);
            Assert.Equal(20f, v.Y);
            Assert.Equal(30f, v.Z);
            Assert.Equal(40f, v.W);
        }


        /// <summary>
        ///     Tests that vector 4 f is value type
        /// </summary>
        [Fact]
        public void Vector4F_IsValueType()
        {
            Assert.True(typeof(Vector4F).IsValueType);
        }

        /// <summary>
        ///     Tests that assignment creates independent copy
        /// </summary>
        [Fact]
        public void Assignment_CreatesIndependentCopy()
        {
            Vector4F first = new Vector4F(1f, 2f, 3f, 4f);
            Vector4F second = first;

            second.X = 10f;

            Assert.Equal(1f, first.X);
            Assert.Equal(10f, second.X);
        }

        /// <summary>
        ///     Tests that struct layout is sequential
        /// </summary>
        [Fact]
        public void StructLayout_IsSequential()
        {
            Assert.True(typeof(Vector4F).IsLayoutSequential);
        }


        /// <summary>
        ///     Tests that equality with same values returns true
        /// </summary>
        [Fact]
        public void Equality_WithSameValues_ReturnsTrue()
        {
            Vector4F v1 = new Vector4F(1f, 2f, 3f, 4f);
            Vector4F v2 = new Vector4F(1f, 2f, 3f, 4f);

            Assert.Equal(v1, v2);
        }

        /// <summary>
        ///     Tests that equality with different values returns false
        /// </summary>
        [Fact]
        public void Equality_WithDifferentValues_ReturnsFalse()
        {
            Vector4F v1 = new Vector4F(1f, 2f, 3f, 4f);
            Vector4F v2 = new Vector4F(1f, 2f, 3f, 5f);

            Assert.NotEqual(v1, v2);
        }

        /// <summary>
        ///     Tests that get hash code with same values returns same hash
        /// </summary>
        [Fact]
        public void GetHashCode_WithSameValues_ReturnsSameHash()
        {
            Vector4F v1 = new Vector4F(1f, 2f, 3f, 4f);
            Vector4F v2 = new Vector4F(1f, 2f, 3f, 4f);

            Assert.Equal(v1.GetHashCode(), v2.GetHashCode());
        }


        /// <summary>
        ///     Tests that get object data serializes all components
        /// </summary>
        [Fact]
        public void GetObjectData_SerializesAllComponents()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            SerializationInfo info = new SerializationInfo(typeof(Vector4F), new FormatterConverter());

            v.GetObjectData(info, default(StreamingContext));

            Assert.Equal(1f, info.GetSingle("x"));
            Assert.Equal(2f, info.GetSingle("y"));
            Assert.Equal(3f, info.GetSingle("z"));
            Assert.Equal(4f, info.GetSingle("w"));
        }

        /// <summary>
        ///     Tests that get object data with different values serializes correctly v 2
        /// </summary>
        [Fact]
        public void GetObjectData_WithDifferentValues_SerializesCorrectly_V2()
        {
            Vector4F v = new Vector4F(5.5f, 6.5f, 7.5f, 8.5f);
            SerializationInfo info = new SerializationInfo(typeof(Vector4F), new FormatterConverter());

            v.GetObjectData(info, default(StreamingContext));

            Assert.Equal(5.5f, info.GetSingle("x"));
            Assert.Equal(6.5f, info.GetSingle("y"));
            Assert.Equal(7.5f, info.GetSingle("z"));
            Assert.Equal(8.5f, info.GetSingle("w"));
        }
    }
}