
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 209 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/PolygonManipulation/CuttingTools.cs

    ### Language
    cs

    ### Coverage
    88.5% (Line: 88.0%, Branch: 90.0%)

    ### Uncovered Lines
    20

    ### Uncovered Branches
    5

    ### Method
    CuttingTools

    ### Complexity / LOC
    35 / 194 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:CuttingTools.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.PolygonManipulation
{
    /// <summary>
    ///     The cutting tools class
    /// </summary>
    public static class CuttingTools
    {
        /// <summary>
        ///     Split a fixture into 2 vertice collections using the given entry and exit-point.
        /// </summary>
        /// <param name="fixture">The Fixture to split</param>
        /// <param name="entryPoint">The entry point - The start point</param>
        /// <param name="exitPoint">The exit point - The end point</param>
        /// <param name="first">The first collection of vertexes</param>
        /// <param name="second">The second collection of vertexes</param>
        public static void SplitShape(Fixture fixture, Vector2F entryPoint, Vector2F exitPoint, out Vertices first, out Vertices second)
        {
            Vector2F localEntryPoint = fixture.GetBody.GetLocalPoint(ref entryPoint);
            Vector2F localExitPoint = fixture.GetBody.GetLocalPoint(ref exitPoint);

            if (!(fixture.GetShape is PolygonShape shape))
            {
                first = new Vertices();
                second = new Vertices();
                return;
            }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/PolygonManipulation/CuttingToolsTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/PolygonManipulation/CuttingTools.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage CuttingTools.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
