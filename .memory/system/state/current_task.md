
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 145 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/TextureTools/MarchingSquares.cs

    ### Language
    cs

    ### Coverage
    81.7% (Line: 82.9%, Branch: 78.3%)

    ### Uncovered Lines
    85

    ### Uncovered Branches
    39

    ### Method
    MarchingSquares

    ### Complexity / LOC
    137 / 603 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:MarchingSquares.cs
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

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;

namespace Alis.Core.Physic.Common.TextureTools
{
    /// <summary>
    ///     The marching squares class
    /// </summary>
    public static class MarchingSquares
    {
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 


        /// <summary>
        ///     The look march
        /// </summary>
        internal static readonly int[] LookMarch =
        {
            0x00, 0xE0, 0x38, 0xD8, 0x0E, 0xEE, 0x36, 0xD6, 0x83, 0x63, 0xBB, 0x5B, 0x8D,
            0x6D, 0xB5, 0x55
        };

        /// <summary>
        ///     Marching squares over the given domain using the mesh defined via the dimensions
        ///     (wid,hei) to build a set of polygons such that f(x,y) less than 0, using the given number
        ///     'bin' for recursive linear inteprolation along cell boundaries.
        ///     if 'comb' is true, then the polygons will also be composited into larger possible concave
        ///     polygons.
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/TextureTools/MarchingSquaresTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/TextureTools/MarchingSquares.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage MarchingSquares.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
