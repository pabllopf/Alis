// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPayloadTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im gui payload tests class
    /// </summary>
    public class ImGuiPayloadTests
    {
        /// <summary>
        /// Datas the set and get returns value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Data_SetAndGet_ReturnsValue()
        {
            ImGuiPayload payload = new ImGuiPayload();
            IntPtr expected = new IntPtr(42);
            payload.Data = expected;
            Assert.Equal(expected, payload.Data);
        }

        /// <summary>
        /// Datas the default is zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void Data_Default_IsZero()
        {
            ImGuiPayload payload = new ImGuiPayload();
            Assert.Equal(IntPtr.Zero, payload.Data);
        }

        /// <summary>
        /// Datas the size set and get returns value
        /// </summary>
        [RequireCImguiSystemFact]
        public void DataSize_SetAndGet_ReturnsValue()
        {
            ImGuiPayload payload = new ImGuiPayload();
            payload.DataSize = 256;
            Assert.Equal(256, payload.DataSize);
        }

        /// <summary>
        /// Datas the size default is zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void DataSize_Default_IsZero()
        {
            ImGuiPayload payload = new ImGuiPayload();
            Assert.Equal(0, payload.DataSize);
        }

        /// <summary>
        /// Sources the id set and get returns value
        /// </summary>
        [RequireCImguiSystemFact]
        public void SourceId_SetAndGet_ReturnsValue()
        {
            ImGuiPayload payload = new ImGuiPayload();
            payload.SourceId = 123u;
            Assert.Equal(123u, payload.SourceId);
        }

        /// <summary>
        /// Sources the id default is zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void SourceId_Default_IsZero()
        {
            ImGuiPayload payload = new ImGuiPayload();
            Assert.Equal(0u, payload.SourceId);
        }

        /// <summary>
        /// Sources the parent id set and get returns value
        /// </summary>
        [RequireCImguiSystemFact]
        public void SourceParentId_SetAndGet_ReturnsValue()
        {
            ImGuiPayload payload = new ImGuiPayload();
            payload.SourceParentId = 456u;
            Assert.Equal(456u, payload.SourceParentId);
        }

        /// <summary>
        /// Sources the parent id default is zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void SourceParentId_Default_IsZero()
        {
            ImGuiPayload payload = new ImGuiPayload();
            Assert.Equal(0u, payload.SourceParentId);
        }

        /// <summary>
        /// Datas the frame count set and get returns value
        /// </summary>
        [RequireCImguiSystemFact]
        public void DataFrameCount_SetAndGet_ReturnsValue()
        {
            ImGuiPayload payload = new ImGuiPayload();
            payload.DataFrameCount = 789;
            Assert.Equal(789, payload.DataFrameCount);
        }

        /// <summary>
        /// Datas the frame count default is zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void DataFrameCount_Default_IsZero()
        {
            ImGuiPayload payload = new ImGuiPayload();
            Assert.Equal(0, payload.DataFrameCount);
        }

        /// <summary>
        /// Datas the type set and get returns value
        /// </summary>
        [RequireCImguiSystemFact]
        public void DataType_SetAndGet_ReturnsValue()
        {
            ImGuiPayload payload = new ImGuiPayload();
            byte[] expected = new byte[33];
            for (int i = 0; i < 33; i++)
            {
                expected[i] = (byte)i;
            }
            payload.DataType = expected;
            Assert.Equal(expected, payload.DataType);
        }

        /// <summary>
        /// Datas the type default is null
        /// </summary>
        [RequireCImguiSystemFact]
        public void DataType_Default_IsNull()
        {
            ImGuiPayload payload = new ImGuiPayload();
            Assert.Null(payload.DataType);
        }

        /// <summary>
        /// Previews the set and get returns value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Preview_SetAndGet_ReturnsValue()
        {
            ImGuiPayload payload = new ImGuiPayload();
            payload.Preview = 1;
            Assert.Equal(1, payload.Preview);
        }

        /// <summary>
        /// Previews the default is zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void Preview_Default_IsZero()
        {
            ImGuiPayload payload = new ImGuiPayload();
            Assert.Equal(0, payload.Preview);
        }

        /// <summary>
        /// Deliveries the set and get returns value
        /// </summary>
        [RequireCImguiSystemFact]
        public void Delivery_SetAndGet_ReturnsValue()
        {
            ImGuiPayload payload = new ImGuiPayload();
            payload.Delivery = 1;
            Assert.Equal(1, payload.Delivery);
        }

        /// <summary>
        /// Deliveries the default is zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void Delivery_Default_IsZero()
        {
            ImGuiPayload payload = new ImGuiPayload();
            Assert.Equal(0, payload.Delivery);
        }

        /// <summary>
        /// Clears the resets data to zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void Clear_ResetsDataToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { Data = new IntPtr(123) };
            payload.Clear();
            Assert.Equal(IntPtr.Zero, payload.Data);
        }

        /// <summary>
        /// Clears the resets data size to zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void Clear_ResetsDataSizeToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { DataSize = 100 };
            payload.Clear();
            Assert.Equal(0, payload.DataSize);
        }

        /// <summary>
        /// Clears the resets source id to zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void Clear_ResetsSourceIdToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { SourceId = 123u };
            payload.Clear();
            Assert.Equal(0u, payload.SourceId);
        }

        /// <summary>
        /// Clears the resets source parent id to zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void Clear_ResetsSourceParentIdToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { SourceParentId = 456u };
            payload.Clear();
            Assert.Equal(0u, payload.SourceParentId);
        }

        /// <summary>
        /// Clears the resets data frame count to negative one
        /// </summary>
        [RequireCImguiSystemFact]
        public void Clear_ResetsDataFrameCountToNegativeOne()
        {
            ImGuiPayload payload = new ImGuiPayload { DataFrameCount = 789 };
            payload.Clear();
            Assert.Equal(-1, payload.DataFrameCount);
        }

        /// <summary>
        /// Clears the resets preview to zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void Clear_ResetsPreviewToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { Preview = 1 };
            payload.Clear();
            Assert.Equal((byte)0, payload.Preview);
        }

        /// <summary>
        /// Clears the resets delivery to zero
        /// </summary>
        [RequireCImguiSystemFact]
        public void Clear_ResetsDeliveryToZero()
        {
            ImGuiPayload payload = new ImGuiPayload { Delivery = 1 };
            payload.Clear();
            Assert.Equal((byte)0, payload.Delivery);
        }

        /// <summary>
        /// Ises the data type matching type returns true
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsDataType_MatchingType_ReturnsTrue()
        {
            byte[] typeBytes = Encoding.UTF8.GetBytes("test\0");
            Array.Resize(ref typeBytes, 33);
            ImGuiPayload payload = new ImGuiPayload { DataType = typeBytes };
            Assert.True(payload.IsDataType("test"));
        }

        /// <summary>
        /// Ises the data type non matching type returns false
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsDataType_NonMatchingType_ReturnsFalse()
        {
            byte[] typeBytes = Encoding.UTF8.GetBytes("other\0");
            Array.Resize(ref typeBytes, 33);
            ImGuiPayload payload = new ImGuiPayload { DataType = typeBytes };
            Assert.False(payload.IsDataType("test"));
        }

        /// <summary>
        /// Ises the data type empty type returns false
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsDataType_EmptyType_ReturnsFalse()
        {
            ImGuiPayload payload = new ImGuiPayload { DataType = new byte[33] };
            Assert.False(payload.IsDataType("anything"));
        }

        /// <summary>
        /// Ises the delivery when set returns true
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsDelivery_WhenSet_ReturnsTrue()
        {
            ImGuiPayload payload = new ImGuiPayload { Delivery = 1 };
            Assert.True(payload.IsDelivery());
        }

        /// <summary>
        /// Ises the delivery when not set returns false
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsDelivery_WhenNotSet_ReturnsFalse()
        {
            ImGuiPayload payload = new ImGuiPayload { Delivery = 0 };
            Assert.False(payload.IsDelivery());
        }

        /// <summary>
        /// Ises the preview when set returns true
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsPreview_WhenSet_ReturnsTrue()
        {
            ImGuiPayload payload = new ImGuiPayload { Preview = 1 };
            Assert.True(payload.IsPreview());
        }

        /// <summary>
        /// Ises the preview when not set returns false
        /// </summary>
        [RequireCImguiSystemFact]
        public void IsPreview_WhenNotSet_ReturnsFalse()
        {
            ImGuiPayload payload = new ImGuiPayload { Preview = 0 };
            Assert.False(payload.IsPreview());
        }
    }
}
