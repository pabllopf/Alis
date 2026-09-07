
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 153 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Collisions/TimeOfImpact.cs

    ### Language
    cs

    ### Coverage
    89.7% (Line: 90.5%, Branch: 85.7%)

    ### Uncovered Lines
    14

    ### Uncovered Branches
    4

    ### Method
    TimeOfImpact

    ### Complexity / LOC
    30 / 183 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:TimeOfImpact.cs
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Computes the Time of Impact (TOI) between two moving convex shapes using continuous collision detection (CCD).
    /// </summary>
    /// <remarks>
    ///     This class implements the local separating axis method for CCD. It seeks progression
    ///     by computing the largest time at which separation is maintained between two shapes.
    ///     
    ///     The algorithm uses a swept separating axis and may miss some intermediate, non-tunneling collisions.
    ///     For contact point and normal information at the time of impact, use <see cref="Distance"/> after calling this method.
    ///     
    ///     Diagnostics can be enabled via <see cref="SettingEnv.EnableDiagnostics"/> to track TOI computation statistics.
    /// </remarks>
    public static class TimeOfImpact
    {
        // by computing the largest time at which separation is maintained.

        /// <summary>
        ///     Gets or sets the total number of TOI computation calls made (diagnostics only).
        /// </summary>
        /// <remarks>
        ///     Only updated when <see cref="SettingEnv.EnableDiagnostics"/> is true.
        /// </remarks>
        [ThreadStatic] public static int ToiCalls;

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Collisions/TimeOfImpactTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Collisions/TimeOfImpact.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage TimeOfImpact.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
