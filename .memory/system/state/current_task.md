
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 148 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/Sweep/DTSweep.cs

    ### Language
    cs

    ### Coverage
    85.0% (Line: 86.6%, Branch: 79.6%)

    ### Uncovered Lines
    88

    ### Uncovered Branches
    42

    ### Method
    DTSweep

    ### Complexity / LOC
    141 / 766 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:DTSweep.cs
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
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep class
    /// </summary>
    internal static class DtSweep
    {
        /// <summary>
        ///     The pi
        /// </summary>
        private const double PiDiv2 = Math.PI / 2;

        /// <summary>
        ///     The pi
        /// </summary>
        private const double Pi3Div4 = 3 * Math.PI / 4;

        /// <summary>
        ///     Triangulate simple polygon with holes
        /// </summary>
        public static void Triangulate(DtSweepContext tcx)
        {
            tcx.CreateAdvancingFront();

            Sweep(tcx);

            if (tcx.TriangulationMode == TriangulationMode.Polygon)
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/Decomposition/CDT/Delaunay/Sweep/DTSweepTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/Sweep/DTSweep.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage DTSweep.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
