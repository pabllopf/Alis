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

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    /// Comprehensive unit tests for Vector4F class
    /// </summary>
    public class Vector4FTest
    {
        /// <summary>
        /// Tests that constructor with four values initializes correctly
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
        /// Tests that constructor default initializes to zero
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
        /// Tests that properties can be set and retrieved
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
        /// Tests that equals with same vector returns true
        /// </summary>
        [Fact]
        public void Equals_WithSameVector_ReturnsTrue()
        {
            Vector4F v1 = new Vector4F(1f, 2f, 3f, 4f);
            Vector4F v2 = new Vector4F(1f, 2f, 3f, 4f);

            Assert.True(v1.Equals(v2));
        }

        /// <summary>
        /// Tests that equals with different vector returns false
        /// </summary>
        [Fact]
        public void Equals_WithDifferentVector_ReturnsFalse()
        {
            Vector4F v1 = new Vector4F(1f, 2f, 3f, 4f);
            Vector4F v2 = new Vector4F(5f, 6f, 7f, 8f);

            Assert.False(v1.Equals(v2));
        }

        /// <summary>
        /// Tests that equals with object override works correctly
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
        /// Tests that get hash code with same vector returns same hash
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
        /// Tests that to string returns formatted string
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
        /// Tests that get object data serializes vector
        /// </summary>
        [Fact]
        public void GetObjectData_SerializesVector()
        {
            Vector4F v = new Vector4F(1f, 2f, 3f, 4f);
            var serializationInfo = new System.Runtime.Serialization.SerializationInfo(typeof(Vector4F), new System.Runtime.Serialization.FormatterConverter());

            v.GetObjectData(serializationInfo, default);

            Assert.Equal(1f, serializationInfo.GetSingle("x"));
            Assert.Equal(2f, serializationInfo.GetSingle("y"));
            Assert.Equal(3f, serializationInfo.GetSingle("z"));
            Assert.Equal(4f, serializationInfo.GetSingle("w"));
        }

        /// <summary>
        /// Tests that get object data with different values serializes correctly
        /// </summary>
        [Fact]
        public void GetObjectData_WithDifferentValues_SerializesCorrectly()
        {
            Vector4F v = new Vector4F(10f, 20f, 30f, 40f);
            var serializationInfo = new System.Runtime.Serialization.SerializationInfo(typeof(Vector4F), new System.Runtime.Serialization.FormatterConverter());

            v.GetObjectData(serializationInfo, default);

            Assert.Equal(10f, serializationInfo.GetSingle("x"));
            Assert.Equal(20f, serializationInfo.GetSingle("y"));
            Assert.Equal(30f, serializationInfo.GetSingle("z"));
            Assert.Equal(40f, serializationInfo.GetSingle("w"));
        }
    }
}