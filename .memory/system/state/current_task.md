
    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Vec3.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    11

    ### Uncovered Branches
    0

    ### Method
    Vec3

    ### Complexity / LOC
    2 / 25 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Vec3.cs
// 
//  Author:Pablo Perdomo FalcÃ³n
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

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     <see cref="Vec3" /> is a struct represent a glsl vec3 value
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3
    {
        /// <summary>
        ///     Implicit cast from <see cref="Alis.Core.Aspect.Math.Vector.Vector3F" /> to <see cref="Vec3" />
        /// </summary>
        public static implicit operator Vec3(Vector3F vec) => new Vec3(vec);


        /// <summary>
        ///     Construct the <see cref="Vec3" /> from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public Vec3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }


    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/Vec3Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Vec3.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Vec3.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
