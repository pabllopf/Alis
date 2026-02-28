// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NsPointTest.cs
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
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Xunit;
using Alis.Core.Graphic.Platforms.Osx.Native;

namespace Alis.Core.Graphic.Test.Platforms.Osx.Native
{
    /// <summary>
    /// Tests for the NsPoint struct validating OSX native coordinate representation.
    /// </summary>
    public class NsPointTest
    {
        /// <summary>
        /// Tests that NsPoint is a struct type.
        /// </summary>
        [Fact]
        public void NsPoint_IsStruct_TypeIsCorrect()
        {
            // Arrange & Act
            Type pointType = typeof(NsPoint);

            // Assert
            Assert.True(pointType.IsValueType);
        }

        /// <summary>
        /// Tests that NsPoint is public.
        /// </summary>
        [Fact]
        public void NsPoint_IsPublic_CanBeAccessed()
        {
            // Arrange & Act
            Type pointType = typeof(NsPoint);

            // Assert
            Assert.True(pointType.IsPublic);
        }


        /// <summary>
        /// Tests that NsPoint has X field.
        /// </summary>
        [Fact]
        public void NsPoint_X_FieldExists()
        {
            // Arrange & Act
            FieldInfo xField = typeof(NsPoint).GetField("X");

            // Assert
            Assert.NotNull(xField);
            Assert.Equal(typeof(double), xField.FieldType);
        }

        /// <summary>
        /// Tests that NsPoint has Y field.
        /// </summary>
        [Fact]
        public void NsPoint_Y_FieldExists()
        {
            // Arrange & Act
            FieldInfo yField = typeof(NsPoint).GetField("Y");

            // Assert
            Assert.NotNull(yField);
            Assert.Equal(typeof(double), yField.FieldType);
        }

        /// <summary>
        /// Tests that NsPoint X and Y fields are public.
        /// </summary>
        [Fact]
        public void NsPoint_Fields_ArePublic()
        {
            // Arrange & Act
            FieldInfo xField = typeof(NsPoint).GetField("X");
            FieldInfo yField = typeof(NsPoint).GetField("Y");

            // Assert
            Assert.True(xField.IsPublic);
            Assert.True(yField.IsPublic);
        }

        /// <summary>
        /// Tests that NsPoint can be instantiated.
        /// </summary>
        [Fact]
        public void NsPoint_CanBeInstantiated_StructCreationIsValid()
        {
            // Arrange & Act
            NsPoint point = new NsPoint { X = 10.5, Y = 20.5 };

            // Assert
            Assert.Equal(10.5, point.X);
            Assert.Equal(20.5, point.Y);
        }

        /// <summary>
        /// Tests that NsPoint X and Y can be modified after creation.
        /// </summary>
        [Fact]
        public void NsPoint_CanModifyFields_ValuesCanBeChanged()
        {
            // Arrange
            NsPoint point = new NsPoint { X = 0, Y = 0 };

            // Act
            point.X = 5.0;
            point.Y = 10.0;

            // Assert
            Assert.Equal(5.0, point.X);
            Assert.Equal(10.0, point.Y);
        }

        /// <summary>
        /// Tests that NsPoint fields are double precision.
        /// </summary>
        [Fact]
        public void NsPoint_Fields_AreDoublePrecision()
        {
            // Arrange
            NsPoint point = new NsPoint { X = 3.14159265358979, Y = 2.71828182845905 };

            // Act & Assert
            Assert.Equal(3.14159265358979, point.X);
            Assert.Equal(2.71828182845905, point.Y);
        }

        /// <summary>
        /// Tests that NsPoint supports default value initialization.
        /// </summary>
        [Fact]
        public void NsPoint_DefaultInitialization_CreatesZeroCoordinates()
        {
            // Arrange & Act
            NsPoint point = new NsPoint();

            // Assert
            Assert.Equal(0.0, point.X);
            Assert.Equal(0.0, point.Y);
        }

        /// <summary>
        /// Tests that NsPoint struct can be used in collections.
        /// </summary>
        [Fact]
        public void NsPoint_CanBeStoredInCollections_ListSupport()
        {
            // Arrange
            List<NsPoint> points = new System.Collections.Generic.List<NsPoint>
            {
                new NsPoint { X = 0, Y = 0 },
                new NsPoint { X = 10, Y = 10 },
                new NsPoint { X = 20, Y = 20 }
            };

            // Act & Assert
            Assert.Equal(3, points.Count);
            Assert.Equal(10, points[1].X);
        }

        /// <summary>
        /// Tests that NsPoint can be used in native P/Invoke calls.
        /// </summary>
        [Fact]
        public void NsPoint_IsMarshallable_InteropIsSupported()
        {
            // Arrange
            Type pointType = typeof(NsPoint);

            // Act
            int marshalSize = Marshal.SizeOf(pointType);

            // Assert
            Assert.Equal(16, marshalSize); // 2 doubles = 16 bytes
        }
    }
}

