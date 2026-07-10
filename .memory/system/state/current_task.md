
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 243 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Models/CorridorData.cs

    ### Language
    cs

    ### Coverage
    96.8% (Line: 100.0%, Branch: 90.0%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    CorridorData

    ### Complexity / LOC
    16 / 37 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:CorridorData.cs
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
using Alis.Core.Aspect.Data.Json;
using HashCode = Alis.Core.Aspect.Math.HashCode;

namespace Alis.Extension.Math.ProceduralDungeon.Models
{
    /// <summary>
    ///     Represents the data structure for a corridor in the dungeon.
    ///     This is an immutable data structure that holds corridor information.
    /// </summary>
    [Serializable]
    public readonly partial struct CorridorData : IEquatable<CorridorData>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CorridorData" /> struct.
        /// </summary>
        /// <param name="xPos">The x position of the corridor on the board.</param>
        /// <param name="yPos">The y position of the corridor on the board.</param>
        /// <param name="width">The width of the corridor.</param>
        /// <param name="height">The height of the corridor.</param>
        /// <param name="direction">The direction the corridor is facing.</param>
        public CorridorData(int xPos, int yPos, int width, int height, Direction direction)
        {
            XPos = xPos;
            YPos = yPos;
            Width = width;
            Height = height;
            Direction = direction;
        }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/test/Models/CorridorDataTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Models/CorridorData.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage CorridorData.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
