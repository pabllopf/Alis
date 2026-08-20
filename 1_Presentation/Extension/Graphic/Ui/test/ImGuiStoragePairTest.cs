// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStoragePairTest.cs
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

using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The im gui storage pair test class
    /// </summary>
    public class ImGuiStoragePairTest
    {
        /// <summary>
        /// Tests that key default should be zero
        /// </summary>
         [RequireCImguiSystemFact]
        public void Key_Default_ShouldBeZero()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            Assert.Equal(0u, storagePair.Key);
        }

        /// <summary>
        /// Tests that key should set and get correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void Key_Should_SetAndGetCorrectly()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            storagePair.Key = 123u;
            Assert.Equal(123u, storagePair.Key);
        }

        /// <summary>
        /// Tests that key should handle max value
        /// </summary>
         [RequireCImguiSystemFact]
        public void Key_Should_HandleMaxValue()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            storagePair.Key = uint.MaxValue;
            Assert.Equal(uint.MaxValue, storagePair.Key);
        }

        /// <summary>
        /// Tests that key should handle min value
        /// </summary>
         [RequireCImguiSystemFact]
        public void Key_Should_HandleMinValue()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            storagePair.Key = uint.MinValue;
            Assert.Equal(uint.MinValue, storagePair.Key);
        }

        /// <summary>
        /// Tests that key should handle one
        /// </summary>
         [RequireCImguiSystemFact]
        public void Key_Should_HandleOne()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            storagePair.Key = 1u;
            Assert.Equal(1u, storagePair.Key);
        }

        /// <summary>
        /// Tests that value default should be default union value
        /// </summary>
         [RequireCImguiSystemFact]
        public void Value_Default_ShouldBeDefaultUnionValue()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            Assert.Equal(default(UnionValue), storagePair.Value);
        }

        /// <summary>
        /// Tests that value should set and get with value i 32
        /// </summary>
         [RequireCImguiSystemFact]
        public void Value_Should_SetAndGetWithValueI32()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            UnionValue value = new UnionValue {ValueI32 = 123};
            storagePair.Value = value;
            Assert.Equal(123, storagePair.Value.ValueI32);
        }

        /// <summary>
        /// Tests that value should set and get with value f 32
        /// </summary>
         [RequireCImguiSystemFact]
        public void Value_Should_SetAndGetWithValueF32()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            UnionValue value = new UnionValue {ValueF32 = 456.78f};
            storagePair.Value = value;
            Assert.Equal(456.78f, storagePair.Value.ValueF32, 5);
        }

        /// <summary>
        /// Tests that value should set and get with value ptr
        /// </summary>
         [RequireCImguiSystemFact]
        public void Value_Should_SetAndGetWithValuePtr()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            UnionValue value = new UnionValue {ValuePtr = new System.IntPtr(42)};
            storagePair.Value = value;
            Assert.Equal(new System.IntPtr(42), storagePair.Value.ValuePtr);
        }

        /// <summary>
        /// Tests that value should overwrite correctly
        /// </summary>
         [RequireCImguiSystemFact]
        public void Value_Should_OverwriteCorrectly()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            storagePair.Value = new UnionValue {ValueI32 = 100};
            storagePair.Value = new UnionValue {ValueF32 = 200.0f};
            Assert.Equal(200.0f, storagePair.Value.ValueF32, 5);
        }

        /// <summary>
        /// Tests that key and value should be independent
        /// </summary>
         [RequireCImguiSystemFact]
        public void Key_And_Value_Should_BeIndependent()
        {
            ImGuiStoragePair storagePair = new ImGuiStoragePair();
            storagePair.Key = 42u;
            storagePair.Value = new UnionValue {ValueI32 = 99};
            Assert.Equal(42u, storagePair.Key);
            Assert.Equal(99, storagePair.Value.ValueI32);
        }

        /// <summary>
        /// Tests that struct should be zeroed by default
        /// </summary>
         [RequireCImguiSystemFact]
        public void Struct_Should_BeZeroedByDefault()
        {
            ImGuiStoragePair storagePair = default;
            Assert.Equal(0u, storagePair.Key);
            Assert.Equal(0, storagePair.Value.ValueI32);
            Assert.Equal(0.0f, storagePair.Value.ValueF32, 5);
            Assert.Equal(System.IntPtr.Zero, storagePair.Value.ValuePtr);
        }
    }
}