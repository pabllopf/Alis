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

namespace Alis.Extension.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The active uniform type enum
    /// </summary>
    public enum ActiveUniformType
    {
        /// <summary>
        ///     The int active uniform type
        /// </summary>
        Int = 0x1404,
        
        /// <summary>
        ///     The float active uniform type
        /// </summary>
        Float = 0x1406,
        
        /// <summary>
        ///     The float vec active uniform type
        /// </summary>
        FloatVec2 = 0x8B50,
        
        /// <summary>
        ///     The float vec active uniform type
        /// </summary>
        FloatVec3 = 0x8B51,
        
        /// <summary>
        ///     The float vec active uniform type
        /// </summary>
        FloatVec4 = 0x8B52,
        
        /// <summary>
        ///     The int vec active uniform type
        /// </summary>
        IntVec2 = 0x8B53,
        
        /// <summary>
        ///     The int vec active uniform type
        /// </summary>
        IntVec3 = 0x8B54,
        
        /// <summary>
        ///     The int vec active uniform type
        /// </summary>
        IntVec4 = 0x8B55,
        
        /// <summary>
        ///     The bool active uniform type
        /// </summary>
        Bool = 0x8B56,
        
        /// <summary>
        ///     The bool vec active uniform type
        /// </summary>
        BoolVec2 = 0x8B57,
        
        /// <summary>
        ///     The bool vec active uniform type
        /// </summary>
        BoolVec3 = 0x8B58,
        
        /// <summary>
        ///     The bool vec active uniform type
        /// </summary>
        BoolVec4 = 0x8B59,
        
        /// <summary>
        ///     The float mat active uniform type
        /// </summary>
        FloatMat2 = 0x8B5A,
        
        /// <summary>
        ///     The float mat active uniform type
        /// </summary>
        FloatMat3 = 0x8B5B,
        
        /// <summary>
        ///     The float mat active uniform type
        /// </summary>
        FloatMat4 = 0x8B5C,
        
        /// <summary>
        ///     The sampler active uniform type
        /// </summary>
        Sampler1D = 0x8B5D,
        
        /// <summary>
        ///     The sampler active uniform type
        /// </summary>
        Sampler2D = 0x8B5E,
        
        /// <summary>
        ///     The sampler active uniform type
        /// </summary>
        Sampler3D = 0x8B5F,
        
        /// <summary>
        ///     The sampler cube active uniform type
        /// </summary>
        SamplerCube = 0x8B60,
        
        /// <summary>
        ///     The sampler shadow active uniform type
        /// </summary>
        Sampler1DShadow = 0x8B61,
        
        /// <summary>
        ///     The sampler shadow active uniform type
        /// </summary>
        Sampler2DShadow = 0x8B62,
        
        /// <summary>
        ///     The sampler rect active uniform type
        /// </summary>
        Sampler2DRect = 0x8B63,
        
        /// <summary>
        ///     The sampler rect shadow active uniform type
        /// </summary>
        Sampler2DRectShadow = 0x8B64,
        
        /// <summary>
        ///     The float mat 2x active uniform type
        /// </summary>
        FloatMat2X3 = 0x8B65,
        
        /// <summary>
        ///     The float mat 2x active uniform type
        /// </summary>
        FloatMat2X4 = 0x8B66,
        
        /// <summary>
        ///     The float mat 3x active uniform type
        /// </summary>
        FloatMat3X2 = 0x8B67,
        
        /// <summary>
        ///     The float mat 3x active uniform type
        /// </summary>
        FloatMat3X4 = 0x8B68,
        
        /// <summary>
        ///     The float mat 4x active uniform type
        /// </summary>
        FloatMat4X2 = 0x8B69,
        
        /// <summary>
        ///     The float mat 4x active uniform type
        /// </summary>
        FloatMat4X3 = 0x8B6A,
        
        /// <summary>
        ///     The sampler array active uniform type
        /// </summary>
        Sampler1DArray = 0x8DC0,
        
        /// <summary>
        ///     The sampler array active uniform type
        /// </summary>
        Sampler2DArray = 0x8DC1,
        
        /// <summary>
        ///     The sampler buffer active uniform type
        /// </summary>
        SamplerBuffer = 0x8DC2,
        
        /// <summary>
        ///     The sampler array shadow active uniform type
        /// </summary>
        Sampler1DArrayShadow = 0x8DC3,
        
        /// <summary>
        ///     The sampler array shadow active uniform type
        /// </summary>
        Sampler2DArrayShadow = 0x8DC4,
        
        /// <summary>
        ///     The sampler cube shadow active uniform type
        /// </summary>
        SamplerCubeShadow = 0x8DC5,
        
        /// <summary>
        ///     The unsigned int vec active uniform type
        /// </summary>
        UnsignedIntVec2 = 0x8DC6,
        
        /// <summary>
        ///     The unsigned int vec active uniform type
        /// </summary>
        UnsignedIntVec3 = 0x8DC7,
        
        /// <summary>
        ///     The unsigned int vec active uniform type
        /// </summary>
        UnsignedIntVec4 = 0x8DC8,
        
        /// <summary>
        ///     The int sampler active uniform type
        /// </summary>
        IntSampler1D = 0x8DC9,
        
        /// <summary>
        ///     The int sampler active uniform type
        /// </summary>
        IntSampler2D = 0x8DCA,
        
        /// <summary>
        ///     The int sampler active uniform type
        /// </summary>
        IntSampler3D = 0x8DCB,
        
        /// <summary>
        ///     The int sampler cube active uniform type
        /// </summary>
        IntSamplerCube = 0x8DCC,
        
        /// <summary>
        ///     The int sampler rect active uniform type
        /// </summary>
        IntSampler2DRect = 0x8DCD,
        
        /// <summary>
        ///     The int sampler array active uniform type
        /// </summary>
        IntSampler1DArray = 0x8DCE,
        
        /// <summary>
        ///     The int sampler array active uniform type
        /// </summary>
        IntSampler2DArray = 0x8DCF,
        
        /// <summary>
        ///     The int sampler buffer active uniform type
        /// </summary>
        IntSamplerBuffer = 0x8DD0,
        
        /// <summary>
        ///     The unsigned int sampler active uniform type
        /// </summary>
        UnsignedIntSampler1D = 0x8DD1,
        
        /// <summary>
        ///     The unsigned int sampler active uniform type
        /// </summary>
        UnsignedIntSampler2D = 0x8DD2,
        
        /// <summary>
        ///     The unsigned int sampler active uniform type
        /// </summary>
        UnsignedIntSampler3D = 0x8DD3,
        
        /// <summary>
        ///     The unsigned int sampler cube active uniform type
        /// </summary>
        UnsignedIntSamplerCube = 0x8DD4,
        
        /// <summary>
        ///     The unsigned int sampler rect active uniform type
        /// </summary>
        UnsignedIntSampler2DRect = 0x8DD5,
        
        /// <summary>
        ///     The unsigned int sampler array active uniform type
        /// </summary>
        UnsignedIntSampler1DArray = 0x8DD6,
        
        /// <summary>
        ///     The unsigned int sampler array active uniform type
        /// </summary>
        UnsignedIntSampler2DArray = 0x8DD7,
        
        /// <summary>
        ///     The unsigned int sampler buffer active uniform type
        /// </summary>
        UnsignedIntSamplerBuffer = 0x8DD8,
        
        /// <summary>
        ///     The sampler multisample active uniform type
        /// </summary>
        Sampler2DMultisample = 0x9108,
        
        /// <summary>
        ///     The int sampler multisample active uniform type
        /// </summary>
        IntSampler2DMultisample = 0x9109,
        
        /// <summary>
        ///     The unsigned int sampler multisample active uniform type
        /// </summary>
        UnsignedIntSampler2DMultisample = 0x910A,
        
        /// <summary>
        ///     The sampler multisample array active uniform type
        /// </summary>
        Sampler2DMultisampleArray = 0x910B,
        
        /// <summary>
        ///     The int sampler multisample array active uniform type
        /// </summary>
        IntSampler2DMultisampleArray = 0x910C,
        
        /// <summary>
        ///     The unsigned int sampler multisample array active uniform type
        /// </summary>
        UnsignedIntSampler2DMultisampleArray = 0x910D
    }
}