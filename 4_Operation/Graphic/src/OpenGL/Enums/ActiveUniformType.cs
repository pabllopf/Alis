// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ActiveUniformType.cs
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

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The active uniform type enum
    /// </summary>
    public enum ActiveUniformType
    {
        /// <summary>
        ///     A signed 32-bit integer uniform (GL_INT)
        /// </summary>
        Int = 0x1404,

        /// <summary>
        ///     A single 32-bit floating-point uniform (GL_FLOAT)
        /// </summary>
        Float = 0x1406,

        /// <summary>
        ///     A two-component floating-point vector uniform (GL_FLOAT_VEC2)
        /// </summary>
        FloatVec2 = 0x8B50,

        /// <summary>
        ///     A three-component floating-point vector uniform (GL_FLOAT_VEC3)
        /// </summary>
        FloatVec3 = 0x8B51,

        /// <summary>
        ///     A four-component floating-point vector uniform (GL_FLOAT_VEC4)
        /// </summary>
        FloatVec4 = 0x8B52,

        /// <summary>
        ///     A two-component signed integer vector uniform (GL_INT_VEC2)
        /// </summary>
        IntVec2 = 0x8B53,

        /// <summary>
        ///     A three-component signed integer vector uniform (GL_INT_VEC3)
        /// </summary>
        IntVec3 = 0x8B54,

        /// <summary>
        ///     A four-component signed integer vector uniform (GL_INT_VEC4)
        /// </summary>
        IntVec4 = 0x8B55,

        /// <summary>
        ///     A boolean uniform (GL_BOOL)
        /// </summary>
        Bool = 0x8B56,

        /// <summary>
        ///     A two-component boolean vector uniform (GL_BOOL_VEC2)
        /// </summary>
        BoolVec2 = 0x8B57,

        /// <summary>
        ///     A three-component boolean vector uniform (GL_BOOL_VEC3)
        /// </summary>
        BoolVec3 = 0x8B58,

        /// <summary>
        ///     A four-component boolean vector uniform (GL_BOOL_VEC4)
        /// </summary>
        BoolVec4 = 0x8B59,

        /// <summary>
        ///     A 2x2 floating-point matrix uniform (GL_FLOAT_MAT2)
        /// </summary>
        FloatMat2 = 0x8B5A,

        /// <summary>
        ///     A 3x3 floating-point matrix uniform (GL_FLOAT_MAT3)
        /// </summary>
        FloatMat3 = 0x8B5B,

        /// <summary>
        ///     A 4x4 floating-point matrix uniform (GL_FLOAT_MAT4)
        /// </summary>
        FloatMat4 = 0x8B5C,

        /// <summary>
        ///     A 1D sampler uniform (GL_SAMPLER_1D)
        /// </summary>
        Sampler1D = 0x8B5D,

        /// <summary>
        ///     A 2D sampler uniform (GL_SAMPLER_2D)
        /// </summary>
        Sampler2D = 0x8B5E,

        /// <summary>
        ///     A 3D sampler uniform (GL_SAMPLER_3D)
        /// </summary>
        Sampler3D = 0x8B5F,

        /// <summary>
        ///     A cube map sampler uniform (GL_SAMPLER_CUBE)
        /// </summary>
        SamplerCube = 0x8B60,

        /// <summary>
        ///     A 1D shadow sampler uniform (GL_SAMPLER_1D_SHADOW)
        /// </summary>
        Sampler1DShadow = 0x8B61,

        /// <summary>
        ///     A 2D shadow sampler uniform (GL_SAMPLER_2D_SHADOW)
        /// </summary>
        Sampler2DShadow = 0x8B62,

        /// <summary>
        ///     A 2D rectangle sampler uniform (GL_SAMPLER_2D_RECT)
        /// </summary>
        Sampler2DRect = 0x8B63,

        /// <summary>
        ///     A 2D rectangle shadow sampler uniform (GL_SAMPLER_2D_RECT_SHADOW)
        /// </summary>
        Sampler2DRectShadow = 0x8B64,

        /// <summary>
        ///     A 2x3 floating-point matrix uniform (GL_FLOAT_MAT2x3)
        /// </summary>
        FloatMat2X3 = 0x8B65,

        /// <summary>
        ///     A 2x4 floating-point matrix uniform (GL_FLOAT_MAT2x4)
        /// </summary>
        FloatMat2X4 = 0x8B66,

        /// <summary>
        ///     A 3x2 floating-point matrix uniform (GL_FLOAT_MAT3x2)
        /// </summary>
        FloatMat3X2 = 0x8B67,

        /// <summary>
        ///     A 3x4 floating-point matrix uniform (GL_FLOAT_MAT3x4)
        /// </summary>
        FloatMat3X4 = 0x8B68,

        /// <summary>
        ///     A 4x2 floating-point matrix uniform (GL_FLOAT_MAT4x2)
        /// </summary>
        FloatMat4X2 = 0x8B69,

        /// <summary>
        ///     A 4x3 floating-point matrix uniform (GL_FLOAT_MAT4x3)
        /// </summary>
        FloatMat4X3 = 0x8B6A,

        /// <summary>
        ///     A 1D array sampler uniform (GL_SAMPLER_1D_ARRAY)
        /// </summary>
        Sampler1DArray = 0x8DC0,

        /// <summary>
        ///     A 2D array sampler uniform (GL_SAMPLER_2D_ARRAY)
        /// </summary>
        Sampler2DArray = 0x8DC1,

        /// <summary>
        ///     A buffer sampler uniform (GL_SAMPLER_BUFFER)
        /// </summary>
        SamplerBuffer = 0x8DC2,

        /// <summary>
        ///     A 1D array shadow sampler uniform (GL_SAMPLER_1D_ARRAY_SHADOW)
        /// </summary>
        Sampler1DArrayShadow = 0x8DC3,

        /// <summary>
        ///     A 2D array shadow sampler uniform (GL_SAMPLER_2D_ARRAY_SHADOW)
        /// </summary>
        Sampler2DArrayShadow = 0x8DC4,

        /// <summary>
        ///     A cube map shadow sampler uniform (GL_SAMPLER_CUBE_SHADOW)
        /// </summary>
        SamplerCubeShadow = 0x8DC5,

        /// <summary>
        ///     A two-component unsigned integer vector uniform (GL_UNSIGNED_INT_VEC2)
        /// </summary>
        UnsignedIntVec2 = 0x8DC6,

        /// <summary>
        ///     A three-component unsigned integer vector uniform (GL_UNSIGNED_INT_VEC3)
        /// </summary>
        UnsignedIntVec3 = 0x8DC7,

        /// <summary>
        ///     A four-component unsigned integer vector uniform (GL_UNSIGNED_INT_VEC4)
        /// </summary>
        UnsignedIntVec4 = 0x8DC8,

        /// <summary>
        ///     A signed integer 1D sampler uniform (GL_INT_SAMPLER_1D)
        /// </summary>
        IntSampler1D = 0x8DC9,

        /// <summary>
        ///     A signed integer 2D sampler uniform (GL_INT_SAMPLER_2D)
        /// </summary>
        IntSampler2D = 0x8DCA,

        /// <summary>
        ///     A signed integer 3D sampler uniform (GL_INT_SAMPLER_3D)
        /// </summary>
        IntSampler3D = 0x8DCB,

        /// <summary>
        ///     A signed integer cube map sampler uniform (GL_INT_SAMPLER_CUBE)
        /// </summary>
        IntSamplerCube = 0x8DCC,

        /// <summary>
        ///     A signed integer 2D rectangle sampler uniform (GL_INT_SAMPLER_2D_RECT)
        /// </summary>
        IntSampler2DRect = 0x8DCD,

        /// <summary>
        ///     A signed integer 1D array sampler uniform (GL_INT_SAMPLER_1D_ARRAY)
        /// </summary>
        IntSampler1DArray = 0x8DCE,

        /// <summary>
        ///     A signed integer 2D array sampler uniform (GL_INT_SAMPLER_2D_ARRAY)
        /// </summary>
        IntSampler2DArray = 0x8DCF,

        /// <summary>
        ///     A signed integer buffer sampler uniform (GL_INT_SAMPLER_BUFFER)
        /// </summary>
        IntSamplerBuffer = 0x8DD0,

        /// <summary>
        ///     An unsigned integer 1D sampler uniform (GL_UNSIGNED_INT_SAMPLER_1D)
        /// </summary>
        UnsignedIntSampler1D = 0x8DD1,

        /// <summary>
        ///     An unsigned integer 2D sampler uniform (GL_UNSIGNED_INT_SAMPLER_2D)
        /// </summary>
        UnsignedIntSampler2D = 0x8DD2,

        /// <summary>
        ///     An unsigned integer 3D sampler uniform (GL_UNSIGNED_INT_SAMPLER_3D)
        /// </summary>
        UnsignedIntSampler3D = 0x8DD3,

        /// <summary>
        ///     An unsigned integer cube map sampler uniform (GL_UNSIGNED_INT_SAMPLER_CUBE)
        /// </summary>
        UnsignedIntSamplerCube = 0x8DD4,

        /// <summary>
        ///     An unsigned integer 2D rectangle sampler uniform (GL_UNSIGNED_INT_SAMPLER_2D_RECT)
        /// </summary>
        UnsignedIntSampler2DRect = 0x8DD5,

        /// <summary>
        ///     An unsigned integer 1D array sampler uniform (GL_UNSIGNED_INT_SAMPLER_1D_ARRAY)
        /// </summary>
        UnsignedIntSampler1DArray = 0x8DD6,

        /// <summary>
        ///     An unsigned integer 2D array sampler uniform (GL_UNSIGNED_INT_SAMPLER_2D_ARRAY)
        /// </summary>
        UnsignedIntSampler2DArray = 0x8DD7,

        /// <summary>
        ///     An unsigned integer buffer sampler uniform (GL_UNSIGNED_INT_SAMPLER_BUFFER)
        /// </summary>
        UnsignedIntSamplerBuffer = 0x8DD8,

        /// <summary>
        ///     A 2D multisample sampler uniform (GL_SAMPLER_2D_MULTISAMPLE)
        /// </summary>
        Sampler2DMultisample = 0x9108,

        /// <summary>
        ///     A signed integer 2D multisample sampler uniform (GL_INT_SAMPLER_2D_MULTISAMPLE)
        /// </summary>
        IntSampler2DMultisample = 0x9109,

        /// <summary>
        ///     An unsigned integer 2D multisample sampler uniform (GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE)
        /// </summary>
        UnsignedIntSampler2DMultisample = 0x910A,

        /// <summary>
        ///     A 2D multisample array sampler uniform (GL_SAMPLER_2D_MULTISAMPLE_ARRAY)
        /// </summary>
        Sampler2DMultisampleArray = 0x910B,

        /// <summary>
        ///     A signed integer 2D multisample array sampler uniform (GL_INT_SAMPLER_2D_MULTISAMPLE_ARRAY)
        /// </summary>
        IntSampler2DMultisampleArray = 0x910C,

        /// <summary>
        ///     An unsigned integer 2D multisample array sampler uniform (GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY)
        /// </summary>
        UnsignedIntSampler2DMultisampleArray = 0x910D
    }
}