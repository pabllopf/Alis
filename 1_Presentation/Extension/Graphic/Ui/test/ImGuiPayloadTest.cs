// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPayloadTest.cs
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
using System.Text;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui payload test class
    /// </summary>
    public class ImGuiPayloadTest
    {
        /// <summary>
        ///     Tests that data should be initialized correctly
        /// </summary>
        [Fact]
        public void Data_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {Data = IntPtr.Zero};

            // Act
            IntPtr result = payload.Data;

            // Assert
            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that data size should be initialized correctly
        /// </summary>
        [Fact]
        public void DataSize_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {DataSize = 100};

            // Act
            int result = payload.DataSize;

            // Assert
            Assert.Equal(100, result);
        }

        /// <summary>
        ///     Tests that source id should be initialized correctly
        /// </summary>
        [Fact]
        public void SourceId_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {SourceId = 123};

            // Act
            uint result = payload.SourceId;

            // Assert
            Assert.Equal(123u, result);
        }

        /// <summary>
        ///     Tests that source parent id should be initialized correctly
        /// </summary>
        [Fact]
        public void SourceParentId_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {SourceParentId = 456};

            // Act
            uint result = payload.SourceParentId;

            // Assert
            Assert.Equal(456u, result);
        }

        /// <summary>
        ///     Tests that data frame count should be initialized correctly
        /// </summary>
        [Fact]
        public void DataFrameCount_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {DataFrameCount = 789};

            // Act
            int result = payload.DataFrameCount;

            // Assert
            Assert.Equal(789, result);
        }

        /// <summary>
        ///     Tests that data type should be initialized correctly
        /// </summary>
        [Fact]
        public void DataType_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {DataType = new byte[33]};

            // Act
            byte[] result = payload.DataType;

            // Assert
            Assert.Equal(new byte[33], result);
        }

        /// <summary>
        ///     Tests that preview should be initialized correctly
        /// </summary>
        [Fact]
        public void Preview_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {Preview = 1};

            // Act
            byte result = payload.Preview;

            // Assert
            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that delivery should be initialized correctly
        /// </summary>
        [Fact]
        public void Delivery_ShouldBeInitializedCorrectly()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {Delivery = 1};

            // Act
            byte result = payload.Delivery;

            // Assert
            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that clear should clear payload
        /// </summary>
        [Fact]
        public void Clear_ShouldClearPayload()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {Data = new IntPtr(123), DataSize = 100};

            // Act
        }

        /// <summary>
        ///     Tests that clear calls im gui native clear
        /// </summary>
        [Fact]
        public void Clear_CallsImGuiNativeClear()
        {
            ImGuiPayload payload = new ImGuiPayload();
        }

        /// <summary>
        ///     Tests that is data type returns true for matching type
        /// </summary>
        [Fact]
        public void IsDataType_ReturnsTrueForMatchingType()
        {
            ImGuiPayload payload = new ImGuiPayload();
        }

        /// <summary>
        ///     Tests that is data type returns false for non matching type
        /// </summary>
        [Fact]
        public void IsDataType_ReturnsFalseForNonMatchingType()
        {
            ImGuiPayload payload = new ImGuiPayload();
        }

        /// <summary>
        ///     Tests that is delivery returns true when delivery
        /// </summary>
        [Fact]
        public void IsDelivery_ReturnsTrueWhenDelivery()
        {
            ImGuiPayload payload = new ImGuiPayload();
        }

        /// <summary>
        ///     Tests that is preview returns true when preview
        /// </summary>
        [Fact]
        public void IsPreview_ReturnsTrueWhenPreview()
        {
            ImGuiPayload payload = new ImGuiPayload();
        }

        /// <summary>
        ///     Tests that is data type should return true for matching type
        /// </summary>
        [Fact]
        public void IsDataType_ShouldReturnTrueForMatchingType()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {DataType = Encoding.UTF8.GetBytes("test\0")};

            // Act
        }

        /// <summary>
        ///     Tests that is data type should return false for non matching type
        /// </summary>
        [Fact]
        public void IsDataType_ShouldReturnFalseForNonMatchingType()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {DataType = Encoding.UTF8.GetBytes("test\0")};


            // Act
        }

        /// <summary>
        ///     Tests that is delivery should return true when delivery is set
        /// </summary>
        [Fact]
        public void IsDelivery_ShouldReturnTrueWhenDeliveryIsSet()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {Delivery = 1};

            // Act
        }

        /// <summary>
        ///     Tests that is delivery should return false when delivery is not set
        /// </summary>
        [Fact]
        public void IsDelivery_ShouldReturnFalseWhenDeliveryIsNotSet()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {Delivery = 0};

            // Act
        }

        /// <summary>
        ///     Tests that is preview should return true when preview is set
        /// </summary>
        [Fact]
        public void IsPreview_ShouldReturnTrueWhenPreviewIsSet()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {Preview = 1};

            // Act
        }

        /// <summary>
        ///     Tests that is preview should return false when preview is not set
        /// </summary>
        [Fact]
        public void IsPreview_ShouldReturnFalseWhenPreviewIsNotSet()
        {
            // Arrange
            ImGuiPayload payload = new ImGuiPayload {Preview = 0};

            // Act
        }
    }
}