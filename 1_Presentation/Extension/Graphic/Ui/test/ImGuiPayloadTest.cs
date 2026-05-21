

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
            ImGuiPayload payload = new ImGuiPayload {Data = IntPtr.Zero};

            IntPtr result = payload.Data;

            Assert.Equal(IntPtr.Zero, result);
        }

        /// <summary>
        ///     Tests that data size should be initialized correctly
        /// </summary>
        [Fact]
        public void DataSize_ShouldBeInitializedCorrectly()
        {
            ImGuiPayload payload = new ImGuiPayload {DataSize = 100};

            int result = payload.DataSize;

            Assert.Equal(100, result);
        }

        /// <summary>
        ///     Tests that source id should be initialized correctly
        /// </summary>
        [Fact]
        public void SourceId_ShouldBeInitializedCorrectly()
        {
            ImGuiPayload payload = new ImGuiPayload {SourceId = 123};

            uint result = payload.SourceId;

            Assert.Equal(123u, result);
        }

        /// <summary>
        ///     Tests that source parent id should be initialized correctly
        /// </summary>
        [Fact]
        public void SourceParentId_ShouldBeInitializedCorrectly()
        {
            ImGuiPayload payload = new ImGuiPayload {SourceParentId = 456};

            uint result = payload.SourceParentId;

            Assert.Equal(456u, result);
        }

        /// <summary>
        ///     Tests that data frame count should be initialized correctly
        /// </summary>
        [Fact]
        public void DataFrameCount_ShouldBeInitializedCorrectly()
        {
            ImGuiPayload payload = new ImGuiPayload {DataFrameCount = 789};

            int result = payload.DataFrameCount;

            Assert.Equal(789, result);
        }

        /// <summary>
        ///     Tests that data type should be initialized correctly
        /// </summary>
        [Fact]
        public void DataType_ShouldBeInitializedCorrectly()
        {
            ImGuiPayload payload = new ImGuiPayload {DataType = new byte[33]};

            byte[] result = payload.DataType;

            Assert.Equal(new byte[33], result);
        }

        /// <summary>
        ///     Tests that preview should be initialized correctly
        /// </summary>
        [Fact]
        public void Preview_ShouldBeInitializedCorrectly()
        {
            ImGuiPayload payload = new ImGuiPayload {Preview = 1};

            byte result = payload.Preview;

            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that delivery should be initialized correctly
        /// </summary>
        [Fact]
        public void Delivery_ShouldBeInitializedCorrectly()
        {
            ImGuiPayload payload = new ImGuiPayload {Delivery = 1};

            byte result = payload.Delivery;

            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that clear should clear payload
        /// </summary>
        [Fact]
        public void Clear_ShouldClearPayload()
        {
            ImGuiPayload payload = new ImGuiPayload {Data = new IntPtr(123), DataSize = 100};

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
            ImGuiPayload payload = new ImGuiPayload {DataType = Encoding.UTF8.GetBytes("test\0")};

        }

        /// <summary>
        ///     Tests that is data type should return false for non matching type
        /// </summary>
        [Fact]
        public void IsDataType_ShouldReturnFalseForNonMatchingType()
        {
            ImGuiPayload payload = new ImGuiPayload {DataType = Encoding.UTF8.GetBytes("test\0")};


        }

        /// <summary>
        ///     Tests that is delivery should return true when delivery is set
        /// </summary>
        [Fact]
        public void IsDelivery_ShouldReturnTrueWhenDeliveryIsSet()
        {
            ImGuiPayload payload = new ImGuiPayload {Delivery = 1};

        }

        /// <summary>
        ///     Tests that is delivery should return false when delivery is not set
        /// </summary>
        [Fact]
        public void IsDelivery_ShouldReturnFalseWhenDeliveryIsNotSet()
        {
            ImGuiPayload payload = new ImGuiPayload {Delivery = 0};

        }

        /// <summary>
        ///     Tests that is preview should return true when preview is set
        /// </summary>
        [Fact]
        public void IsPreview_ShouldReturnTrueWhenPreviewIsSet()
        {
            ImGuiPayload payload = new ImGuiPayload {Preview = 1};

        }

        /// <summary>
        ///     Tests that is preview should return false when preview is not set
        /// </summary>
        [Fact]
        public void IsPreview_ShouldReturnFalseWhenPreviewIsNotSet()
        {
            ImGuiPayload payload = new ImGuiPayload {Preview = 0};

        }
    }
}