// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPayloadTableSortRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui payload table sort remaining coverage tests class
    /// </summary>
    public class ImGuiPayloadTableSortRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that payload properties round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void Payload_Properties_RoundTrip()
        {
            ImGuiPayload payload = new ImGuiPayload
            {
                Data = new IntPtr(42),
                DataSize = 16,
                SourceId = 7,
                SourceParentId = 8,
                DataFrameCount = 3,
                Preview = 1,
                Delivery = 1
            };

            Assert.Equal(new IntPtr(42), payload.Data);
            Assert.Equal(16, payload.DataSize);
            Assert.Equal(7u, payload.SourceId);
            Assert.Equal(8u, payload.SourceParentId);
            Assert.Equal(3, payload.DataFrameCount);
            Assert.Equal(1, payload.Preview);
            Assert.Equal(1, payload.Delivery);
        }

        /// <summary>
        ///     Tests that payload defaults are zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Payload_Defaults_AreZero()
        {
            ImGuiPayload payload = new ImGuiPayload();

            Assert.Equal(IntPtr.Zero, payload.Data);
            Assert.Equal(0, payload.DataSize);
            Assert.Equal(0u, payload.SourceId);
            Assert.Equal(0u, payload.SourceParentId);
            Assert.Equal(0, payload.DataFrameCount);
            Assert.Equal(0, payload.Preview);
            Assert.Equal(0, payload.Delivery);
        }

        /// <summary>
        ///     Tests that table sort specs properties round trip
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableSortSpecs_Properties_RoundTrip()
        {
            ImGuiTableSortSpecs specs = new ImGuiTableSortSpecs
            {
                Specs = new IntPtr(99),
                SpecsCount = 5,
                SpecsDirty = 1
            };

            Assert.Equal(new IntPtr(99), specs.Specs);
            Assert.Equal(5, specs.SpecsCount);
            Assert.Equal(1, specs.SpecsDirty);
        }

        /// <summary>
        ///     Tests that table sort specs defaults are zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableSortSpecs_Defaults_AreZero()
        {
            ImGuiTableSortSpecs specs = new ImGuiTableSortSpecs();

            Assert.Equal(IntPtr.Zero, specs.Specs);
            Assert.Equal(0, specs.SpecsCount);
            Assert.Equal(0, specs.SpecsDirty);
        }
    }
}
