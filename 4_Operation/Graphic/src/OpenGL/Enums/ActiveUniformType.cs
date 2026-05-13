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
    /// Defines all possible data types for active uniforms in an OpenGL shader program.
    /// Used with glGetActiveUniform to determine the GLSL type of each active uniform variable.
    /// Covers scalar, vector, matrix, and sampler types across all recent OpenGL versions.
    /// </summary>
    public enum ActiveUniformType
    {
        /// <summary>Signed integer scalar (GL_INT = 0x1404).</summary>
        Int = 0x1404,

        /// <summary>Single-precision float scalar (GL_FLOAT = 0x1406).</summary>
        Float = 0x1406,

        /// <summary>Two-component float vector (GL_FLOAT_VEC2 = 0x8B50).</summary>
        FloatVec2 = 0x8B50,

        /// <summary>Three-component float vector (GL_FLOAT_VEC3 = 0x8B51).</summary>
        FloatVec3 = 0x8B51,

        /// <summary>Four-component float vector (GL_FLOAT_VEC4 = 0x8B52).</summary>
        FloatVec4 = 0x8B52,

        /// <summary>Two-component integer vector (GL_INT_VEC2 = 0x8B53).</summary>
        IntVec2 = 0x8B53,

        /// <summary>Three-component integer vector (GL_INT_VEC3 = 0x8B54).</summary>
        IntVec3 = 0x8B54,

        /// <summary>Four-component integer vector (GL_INT_VEC4 = 0x8B55).</summary>
        IntVec4 = 0x8B55,

        /// <summary>Boolean scalar (GL_BOOL = 0x8B56).</summary>
        Bool = 0x8B56,

        /// <summary>Two-component boolean vector (GL_BOOL_VEC2 = 0x8B57).</summary>
        BoolVec2 = 0x8B57,

        /// <summary>Three-component boolean vector (GL_BOOL_VEC3 = 0x8B58).</summary>
        BoolVec3 = 0x8B58,

        /// <summary>Four-component boolean vector (GL_BOOL_VEC4 = 0x8B59).</summary>
        BoolVec4 = 0x8B59,

        /// <summary>2x2 float matrix (GL_FLOAT_MAT2 = 0x8B5A).</summary>
        FloatMat2 = 0x8B5A,

        /// <summary>3x3 float matrix (GL_FLOAT_MAT3 = 0x8B5B).</summary>
        FloatMat3 = 0x8B5B,

        /// <summary>4x4 float matrix (GL_FLOAT_MAT4 = 0x8B5C).</summary>
        FloatMat4 = 0x8B5C,

        /// <summary>1D sampler uniform (GL_SAMPLER_1D = 0x8B5D).</summary>
        Sampler1D = 0x8B5D,

        /// <summary>2D sampler uniform (GL_SAMPLER_2D = 0x8B5E).</summary>
        Sampler2D = 0x8B5E,

        /// <summary>3D sampler uniform (GL_SAMPLER_3D = 0x8B5F).</summary>
        Sampler3D = 0x8B5F,

        /// <summary>Cube map sampler uniform (GL_SAMPLER_CUBE = 0x8B60).</summary>
        SamplerCube = 0x8B60,

        /// <summary>1D shadow sampler uniform (GL_SAMPLER_1D_SHADOW = 0x8B61).</summary>
        Sampler1DShadow = 0x8B61,

        /// <summary>2D shadow sampler uniform (GL_SAMPLER_2D_SHADOW = 0x8B62).</summary>
        Sampler2DShadow = 0x8B62,

        /// <summary>2D rectangle sampler uniform (GL_SAMPLER_2D_RECT = 0x8B63).</summary>
        Sampler2DRect = 0x8B63,

        /// <summary>2D rectangle shadow sampler uniform (GL_SAMPLER_2D_RECT_SHADOW = 0x8B64).</summary>
        Sampler2DRectShadow = 0x8B64,

        /// <summary>2x3 float matrix (GL_FLOAT_MAT2x3 = 0x8B65).</summary>
        FloatMat2X3 = 0x8B65,

        /// <summary>2x4 float matrix (GL_FLOAT_MAT2x4 = 0x8B66).</summary>
        FloatMat2X4 = 0x8B66,

        /// <summary>3x2 float matrix (GL_FLOAT_MAT3x2 = 0x8B67).</summary>
        FloatMat3X2 = 0x8B67,

        /// <summary>3x4 float matrix (GL_FLOAT_MAT3x4 = 0x8B68).</summary>
        FloatMat3X4 = 0x8B68,

        /// <summary>4x2 float matrix (GL_FLOAT_MAT4x2 = 0x8B69).</summary>
        FloatMat4X2 = 0x8B69,

        /// <summary>4x3 float matrix (GL_FLOAT_MAT4x3 = 0x8B6A).</summary>
        FloatMat4X3 = 0x8B6A,

        /// <summary>1D array sampler uniform (GL_SAMPLER_1D_ARRAY = 0x8DC0).</summary>
        Sampler1DArray = 0x8DC0,

        /// <summary>2D array sampler uniform (GL_SAMPLER_2D_ARRAY = 0x8DC1).</summary>
        Sampler2DArray = 0x8DC1,

        /// <summary>Buffer sampler uniform (GL_SAMPLER_BUFFER = 0x8DC2).</summary>
        SamplerBuffer = 0x8DC2,

        /// <summary>1D array shadow sampler uniform (GL_SAMPLER_1D_ARRAY_SHADOW = 0x8DC3).</summary>
        Sampler1DArrayShadow = 0x8DC3,

        /// <summary>2D array shadow sampler uniform (GL_SAMPLER_2D_ARRAY_SHADOW = 0x8DC4).</summary>
        Sampler2DArrayShadow = 0x8DC4,

        /// <summary>Cube map shadow sampler uniform (GL_SAMPLER_CUBE_SHADOW = 0x8DC5).</summary>
        SamplerCubeShadow = 0x8DC5,

        /// <summary>Two-component unsigned integer vector (GL_UNSIGNED_INT_VEC2 = 0x8DC6).</summary>
        UnsignedIntVec2 = 0x8DC6,

        /// <summary>Three-component unsigned integer vector (GL_UNSIGNED_INT_VEC3 = 0x8DC7).</summary>
        UnsignedIntVec3 = 0x8DC7,

        /// <summary>Four-component unsigned integer vector (GL_UNSIGNED_INT_VEC4 = 0x8DC8).</summary>
        UnsignedIntVec4 = 0x8DC8,

        /// <summary>1D integer sampler uniform (GL_INT_SAMPLER_1D = 0x8DC9).</summary>
        IntSampler1D = 0x8DC9,

        /// <summary>2D integer sampler uniform (GL_INT_SAMPLER_2D = 0x8DCA).</summary>
        IntSampler2D = 0x8DCA,

        /// <summary>3D integer sampler uniform (GL_INT_SAMPLER_3D = 0x8DCB).</summary>
        IntSampler3D = 0x8DCB,

        /// <summary>Cube map integer sampler uniform (GL_INT_SAMPLER_CUBE = 0x8DCC).</summary>
        IntSamplerCube = 0x8DCC,

        /// <summary>2D rectangle integer sampler uniform (GL_INT_SAMPLER_2D_RECT = 0x8DCD).</summary>
        IntSampler2DRect = 0x8DCD,

        /// <summary>1D array integer sampler uniform (GL_INT_SAMPLER_1D_ARRAY = 0x8DCE).</summary>
        IntSampler1DArray = 0x8DCE,

        /// <summary>2D array integer sampler uniform (GL_INT_SAMPLER_2D_ARRAY = 0x8DCF).</summary>
        IntSampler2DArray = 0x8DCF,

        /// <summary>Buffer integer sampler uniform (GL_INT_SAMPLER_BUFFER = 0x8DD0).</summary>
        IntSamplerBuffer = 0x8DD0,

        /// <summary>1D unsigned integer sampler uniform (GL_UNSIGNED_INT_SAMPLER_1D = 0x8DD1).</summary>
        UnsignedIntSampler1D = 0x8DD1,

        /// <summary>2D unsigned integer sampler uniform (GL_UNSIGNED_INT_SAMPLER_2D = 0x8DD2).</summary>
        UnsignedIntSampler2D = 0x8DD2,

        /// <summary>3D unsigned integer sampler uniform (GL_UNSIGNED_INT_SAMPLER_3D = 0x8DD3).</summary>
        UnsignedIntSampler3D = 0x8DD3,

        /// <summary>Cube map unsigned integer sampler uniform (GL_UNSIGNED_INT_SAMPLER_CUBE = 0x8DD4).</summary>
        UnsignedIntSamplerCube = 0x8DD4,

        /// <summary>2D rectangle unsigned integer sampler uniform (GL_UNSIGNED_INT_SAMPLER_2D_RECT = 0x8DD5).</summary>
        UnsignedIntSampler2DRect = 0x8DD5,

        /// <summary>1D array unsigned integer sampler uniform (GL_UNSIGNED_INT_SAMPLER_1D_ARRAY = 0x8DD6).</summary>
        UnsignedIntSampler1DArray = 0x8DD6,

        /// <summary>2D array unsigned integer sampler uniform (GL_UNSIGNED_INT_SAMPLER_2D_ARRAY = 0x8DD7).</summary>
        UnsignedIntSampler2DArray = 0x8DD7,

        /// <summary>Buffer unsigned integer sampler uniform (GL_UNSIGNED_INT_SAMPLER_BUFFER = 0x8DD8).</summary>
        UnsignedIntSamplerBuffer = 0x8DD8,

        /// <summary>2D multisample sampler uniform (GL_SAMPLER_2D_MULTISAMPLE = 0x9108).</summary>
        Sampler2DMultisample = 0x9108,

        /// <summary>2D multisample integer sampler uniform (GL_INT_SAMPLER_2D_MULTISAMPLE = 0x9109).</summary>
        IntSampler2DMultisample = 0x9109,

        /// <summary>2D multisample unsigned integer sampler uniform (GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE = 0x910A).</summary>
        UnsignedIntSampler2DMultisample = 0x910A,

        /// <summary>2D multisample array sampler uniform (GL_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910B).</summary>
        Sampler2DMultisampleArray = 0x910B,

        /// <summary>2D multisample array integer sampler uniform (GL_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910C).</summary>
        IntSampler2DMultisampleArray = 0x910C,

        /// <summary>2D multisample array unsigned integer sampler uniform (GL_UNSIGNED_INT_SAMPLER_2D_MULTISAMPLE_ARRAY = 0x910D).</summary>
        UnsignedIntSampler2DMultisampleArray = 0x910D
    }
}
