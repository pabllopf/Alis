
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 14 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Services/BoardBuilder.cs

    ### Language
    cs

    ### Coverage
    99.5% (Line: 100.0%, Branch: 98.7%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    cs

    ### Complexity / LOC
    46 / 162 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:BoardBuilder.cs
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
using Alis.Extension.Math.ProceduralDungeon.Interfaces;
using Alis.Extension.Math.ProceduralDungeon.Models;

namespace Alis.Extension.Math.ProceduralDungeon.Services
{
    /// <summary>
    ///     Builder class for constructing dungeon boards.
    ///     Implements the Builder pattern to create complex board structures.
    /// </summary>
    public class BoardBuilder : IBoardBuilder
    {
        /// <summary>
        ///     Creates an empty board with specified dimensions.
        /// </summary>
        /// <param name="width">The width of the board.</param>
        /// <param name="height">The height of the board.</param>
        /// <returns>A 2D array of board squares initialized with Empty type.</returns>
        /// <exception cref="ArgumentException">Thrown when dimensions are invalid.</exception>
        public BoardSquare[,] CreateEmptyBoard(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException("Width must be greater than 0.", nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height must be greater than 0.", nameof(height));
            }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/test/Services/BoardBuilderTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Services/BoardBuilder.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage BoardBuilder.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
