
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 200 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/WeldJoint.cs

    ### Language
    cs

    ### Coverage
    99.1% (Line: 100.0%, Branch: 90.9%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    2

    ### Method
    WeldJoint

    ### Complexity / LOC
    32 / 241 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WeldJoint.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A weld joint essentially glues two bodies together. A weld joint may
    ///     distort somewhat because the island constraint solver is approximate.
    ///     The joint is soft constraint based, which means the two bodies will move
    ///     relative to each other, when a force is applied. To combine two bodies
    ///     in a rigid fashion, combine the fixtures to a single body instead.
    /// </summary>
    /// <remarks>
    ///     Point-to-point constraint
    ///     C = p2 - p1
    ///     Cdot = v2 - v1
    ///     = v2 + cross(w2, r2) - v1 - cross(w1, r1)
    ///     J = [-I -r1_skew I r2_skew ]
    ///     Identity used:
    ///     w k % (rx i + ry j) = w * (-ry i + rx j)
    ///     Angle constraint
    ///     C = angle2 - angle1 - referenceAngle
    ///     Cdot = w2 - w1
    ///     J = [0 0 -1 0 0 1]
    ///     K = invI1 + invI2
    /// </remarks>
    public class WeldJoint : Joint
    {
        /// <summary>
        ///     The bias
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/Joints/WeldJointTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/WeldJoint.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WeldJoint.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
