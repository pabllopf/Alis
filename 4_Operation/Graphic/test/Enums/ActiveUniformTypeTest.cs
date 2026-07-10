// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ActiveUniformTypeTest.cs
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
using Alis.Core.Graphic.OpenGL.Enums;
using Xunit;

namespace Alis.Core.Graphic.Test.Enums
{
    /// <summary>
    ///     Tests for the ActiveUniformType enum validating all active uniform types.
    /// </summary>
    public class ActiveUniformTypeTest
    {
        [Fact]
        public void Int_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1404, (int)ActiveUniformType.Int); }

        [Fact]
        public void Float_HasCorrectValue_EqualsExpected() { Assert.Equal(0x1406, (int)ActiveUniformType.Float); }

        [Fact]
        public void FloatVec2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B50, (int)ActiveUniformType.FloatVec2); }

        [Fact]
        public void FloatVec3_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B51, (int)ActiveUniformType.FloatVec3); }

        [Fact]
        public void FloatVec4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B52, (int)ActiveUniformType.FloatVec4); }

        [Fact]
        public void IntVec2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B53, (int)ActiveUniformType.IntVec2); }

        [Fact]
        public void IntVec3_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B54, (int)ActiveUniformType.IntVec3); }

        [Fact]
        public void IntVec4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B55, (int)ActiveUniformType.IntVec4); }

        [Fact]
        public void Bool_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B56, (int)ActiveUniformType.Bool); }

        [Fact]
        public void BoolVec2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B57, (int)ActiveUniformType.BoolVec2); }

        [Fact]
        public void BoolVec3_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B58, (int)ActiveUniformType.BoolVec3); }

        [Fact]
        public void BoolVec4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B59, (int)ActiveUniformType.BoolVec4); }

        [Fact]
        public void FloatMat2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B5A, (int)ActiveUniformType.FloatMat2); }

        [Fact]
        public void FloatMat3_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B5B, (int)ActiveUniformType.FloatMat3); }

        [Fact]
        public void FloatMat4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B5C, (int)ActiveUniformType.FloatMat4); }

        [Fact]
        public void Sampler1D_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B5D, (int)ActiveUniformType.Sampler1D); }

        [Fact]
        public void Sampler2D_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B5E, (int)ActiveUniformType.Sampler2D); }

        [Fact]
        public void Sampler3D_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B5F, (int)ActiveUniformType.Sampler3D); }

        [Fact]
        public void SamplerCube_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B60, (int)ActiveUniformType.SamplerCube); }

        [Fact]
        public void Sampler1DShadow_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B61, (int)ActiveUniformType.Sampler1DShadow); }

        [Fact]
        public void Sampler2DShadow_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B62, (int)ActiveUniformType.Sampler2DShadow); }

        [Fact]
        public void Sampler2DRect_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B63, (int)ActiveUniformType.Sampler2DRect); }

        [Fact]
        public void Sampler2DRectShadow_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B64, (int)ActiveUniformType.Sampler2DRectShadow); }

        [Fact]
        public void FloatMat2X3_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B65, (int)ActiveUniformType.FloatMat2X3); }

        [Fact]
        public void FloatMat2X4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B66, (int)ActiveUniformType.FloatMat2X4); }

        [Fact]
        public void FloatMat3X2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B67, (int)ActiveUniformType.FloatMat3X2); }

        [Fact]
        public void FloatMat3X4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B68, (int)ActiveUniformType.FloatMat3X4); }

        [Fact]
        public void FloatMat4X2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B69, (int)ActiveUniformType.FloatMat4X2); }

        [Fact]
        public void FloatMat4X3_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8B6A, (int)ActiveUniformType.FloatMat4X3); }

        [Fact]
        public void Sampler1DArray_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DC0, (int)ActiveUniformType.Sampler1DArray); }

        [Fact]
        public void Sampler2DArray_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DC1, (int)ActiveUniformType.Sampler2DArray); }

        [Fact]
        public void SamplerBuffer_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DC2, (int)ActiveUniformType.SamplerBuffer); }

        [Fact]
        public void Sampler1DArrayShadow_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DC3, (int)ActiveUniformType.Sampler1DArrayShadow); }

        [Fact]
        public void Sampler2DArrayShadow_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DC4, (int)ActiveUniformType.Sampler2DArrayShadow); }

        [Fact]
        public void SamplerCubeShadow_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DC5, (int)ActiveUniformType.SamplerCubeShadow); }

        [Fact]
        public void UnsignedIntVec2_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DC6, (int)ActiveUniformType.UnsignedIntVec2); }

        [Fact]
        public void UnsignedIntVec3_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DC7, (int)ActiveUniformType.UnsignedIntVec3); }

        [Fact]
        public void UnsignedIntVec4_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DC8, (int)ActiveUniformType.UnsignedIntVec4); }

        [Fact]
        public void IntSampler1D_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DC9, (int)ActiveUniformType.IntSampler1D); }

        [Fact]
        public void IntSampler2D_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DCA, (int)ActiveUniformType.IntSampler2D); }

        [Fact]
        public void IntSampler3D_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DCB, (int)ActiveUniformType.IntSampler3D); }

        [Fact]
        public void IntSamplerCube_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DCC, (int)ActiveUniformType.IntSamplerCube); }

        [Fact]
        public void IntSampler2DRect_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DCD, (int)ActiveUniformType.IntSampler2DRect); }

        [Fact]
        public void IntSampler1DArray_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DCE, (int)ActiveUniformType.IntSampler1DArray); }

        [Fact]
        public void IntSampler2DArray_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DCF, (int)ActiveUniformType.IntSampler2DArray); }

        [Fact]
        public void IntSamplerBuffer_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DD0, (int)ActiveUniformType.IntSamplerBuffer); }

        [Fact]
        public void UnsignedIntSampler1D_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DD1, (int)ActiveUniformType.UnsignedIntSampler1D); }

        [Fact]
        public void UnsignedIntSampler2D_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DD2, (int)ActiveUniformType.UnsignedIntSampler2D); }

        [Fact]
        public void UnsignedIntSampler3D_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DD3, (int)ActiveUniformType.UnsignedIntSampler3D); }

        [Fact]
        public void UnsignedIntSamplerCube_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DD4, (int)ActiveUniformType.UnsignedIntSamplerCube); }

        [Fact]
        public void UnsignedIntSampler2DRect_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DD5, (int)ActiveUniformType.UnsignedIntSampler2DRect); }

        [Fact]
        public void UnsignedIntSampler1DArray_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DD6, (int)ActiveUniformType.UnsignedIntSampler1DArray); }

        [Fact]
        public void UnsignedIntSampler2DArray_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DD7, (int)ActiveUniformType.UnsignedIntSampler2DArray); }

        [Fact]
        public void UnsignedIntSamplerBuffer_HasCorrectValue_EqualsExpected() { Assert.Equal(0x8DD8, (int)ActiveUniformType.UnsignedIntSamplerBuffer); }

        [Fact]
        public void Sampler2DMultisample_HasCorrectValue_EqualsExpected() { Assert.Equal(0x9108, (int)ActiveUniformType.Sampler2DMultisample); }

        [Fact]
        public void IntSampler2DMultisample_HasCorrectValue_EqualsExpected() { Assert.Equal(0x9109, (int)ActiveUniformType.IntSampler2DMultisample); }

        [Fact]
        public void UnsignedIntSampler2DMultisample_HasCorrectValue_EqualsExpected() { Assert.Equal(0x910A, (int)ActiveUniformType.UnsignedIntSampler2DMultisample); }

        [Fact]
        public void Sampler2DMultisampleArray_HasCorrectValue_EqualsExpected() { Assert.Equal(0x910B, (int)ActiveUniformType.Sampler2DMultisampleArray); }

        [Fact]
        public void IntSampler2DMultisampleArray_HasCorrectValue_EqualsExpected() { Assert.Equal(0x910C, (int)ActiveUniformType.IntSampler2DMultisampleArray); }

        [Fact]
        public void UnsignedIntSampler2DMultisampleArray_HasCorrectValue_EqualsExpected() { Assert.Equal(0x910D, (int)ActiveUniformType.UnsignedIntSampler2DMultisampleArray); }

        [Fact]
        public void ActiveUniformType_IsEnum_TypeIsCorrect() { Assert.True(typeof(ActiveUniformType).IsEnum); }

        [Fact]
        public void ActiveUniformType_IsPublic_CanBeAccessed() { Assert.True(typeof(ActiveUniformType).IsPublic); }

        [Fact]
        public void ActiveUniformType_HasMultipleValues_CountIsNotZero()
        {
            Array enumValues = Enum.GetValues(typeof(ActiveUniformType));
            Assert.NotEmpty(enumValues);
        }

        [Fact]
        public void ActiveUniformType_CanCastToInt_ConversionIsValid()
        {
            int value = (int)ActiveUniformType.Float;
            Assert.IsType<int>(value);
        }

        [Fact]
        public void ActiveUniformType_CanCompareValues_EqualityWorks()
        {
            ActiveUniformType type1 = ActiveUniformType.Float;
            ActiveUniformType type2 = ActiveUniformType.Float;
            Assert.Equal(type1, type2);
        }

        [Fact]
        public void ActiveUniformType_DifferentValues_AreNotEqual()
        {
            Assert.NotEqual(ActiveUniformType.Float, ActiveUniformType.Int);
        }
    }
}
