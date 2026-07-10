using System;
using System.Text;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    public class ImGuiPayloadRemainingCoverageTests
    {
        [Fact]
        public void Clear_ShouldResetDataToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { Data = new IntPtr(123), DataSize = 100 };
            payload.Clear();
            Assert.Equal(IntPtr.Zero, payload.Data);
        }

        [Fact]
        public void Clear_ShouldResetDataSizeToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { DataSize = 100, DataFrameCount = 5 };
            payload.Clear();
            Assert.Equal(0, payload.DataSize);
        }

        [Fact]
        public void Clear_ShouldResetSourceIdToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { SourceId = 123u };
            payload.Clear();
            Assert.Equal(0u, payload.SourceId);
        }

        [Fact]
        public void Clear_ShouldResetSourceParentIdToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { SourceParentId = 456u };
            payload.Clear();
            Assert.Equal(0u, payload.SourceParentId);
        }

        [Fact]
        public void Clear_ShouldResetDataFrameCountToNegativeOne()
        {
            ImGuiPayload payload = new ImGuiPayload { DataFrameCount = 789 };
            payload.Clear();
            Assert.Equal(-1, payload.DataFrameCount);
        }

        [Fact]
        public void Clear_ShouldResetPreviewToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { Preview = 1 };
            payload.Clear();
            Assert.Equal((byte)0, payload.Preview);
        }

        [Fact]
        public void Clear_ShouldResetDeliveryToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { Delivery = 1 };
            payload.Clear();
            Assert.Equal((byte)0, payload.Delivery);
        }

        [Fact]
        public void IsDataType_ShouldReturnTrueForMatchingType()
        {
            byte[] typeBytes = Encoding.UTF8.GetBytes("test\0");
            Array.Resize(ref typeBytes, 33);
            ImGuiPayload payload = new ImGuiPayload { DataType = typeBytes };
            Assert.True(payload.IsDataType("test"));
        }

        [Fact]
        public void IsDataType_ShouldReturnFalseForNonMatchingType()
        {
            byte[] typeBytes = Encoding.UTF8.GetBytes("other\0");
            Array.Resize(ref typeBytes, 33);
            ImGuiPayload payload = new ImGuiPayload { DataType = typeBytes };
            Assert.False(payload.IsDataType("test"));
        }

        [Fact]
        public void IsDataType_EmptyType_ShouldReturnFalse()
        {
            byte[] typeBytes = new byte[33];
            ImGuiPayload payload = new ImGuiPayload { DataType = typeBytes };
            Assert.False(payload.IsDataType("anything"));
        }

        [Fact]
        public void IsDelivery_ShouldReturnTrueWhenDeliveryIsSet()
        {
            ImGuiPayload payload = new ImGuiPayload { Delivery = 1 };
            Assert.True(payload.IsDelivery());
        }

        [Fact]
        public void IsDelivery_ShouldReturnFalseWhenDeliveryIsNotSet()
        {
            ImGuiPayload payload = new ImGuiPayload { Delivery = 0 };
            Assert.False(payload.IsDelivery());
        }

        [Fact]
        public void IsPreview_ShouldReturnTrueWhenPreviewIsSet()
        {
            ImGuiPayload payload = new ImGuiPayload { Preview = 1 };
            Assert.True(payload.IsPreview());
        }

        [Fact]
        public void IsPreview_ShouldReturnFalseWhenPreviewIsNotSet()
        {
            ImGuiPayload payload = new ImGuiPayload { Preview = 0 };
            Assert.False(payload.IsPreview());
        }

        [Fact]
        public void Data_WithNonZeroIntPtr_ShouldRoundtrip()
        {
            IntPtr expected = new IntPtr(12345);
            ImGuiPayload payload = new ImGuiPayload { Data = expected };
            Assert.Equal(expected, payload.Data);
        }

        [Fact]
        public void DataType_ArrayOfMaxSize_ShouldRoundtrip()
        {
            byte[] expected = new byte[33];
            for (int i = 0; i < expected.Length; i++)
            {
                expected[i] = (byte)i;
            }

            ImGuiPayload payload = new ImGuiPayload { DataType = expected };
            Assert.Equal(expected, payload.DataType);
        }

        [Fact]
        public void Preview_DefaultValue_ShouldBeZero()
        {
            ImGuiPayload payload = new ImGuiPayload();
            Assert.Equal(0, payload.Preview);
        }

        [Fact]
        public void Delivery_DefaultValue_ShouldBeZero()
        {
            ImGuiPayload payload = new ImGuiPayload();
            Assert.Equal(0, payload.Delivery);
        }

        [Fact]
        public void DataSize_NegativeValue_ShouldRoundtrip()
        {
            ImGuiPayload payload = new ImGuiPayload { DataSize = -1 };
            Assert.Equal(-1, payload.DataSize);
        }

        [Fact]
        public void DataFrameCount_NegativeValue_ShouldRoundtrip()
        {
            ImGuiPayload payload = new ImGuiPayload { DataFrameCount = -100 };
            Assert.Equal(-100, payload.DataFrameCount);
        }
    }
}
