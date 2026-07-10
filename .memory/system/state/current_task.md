
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 255 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/GearJoint.cs

    ### Language
    cs

    ### Coverage
    98.3% (Line: 98.9%, Branch: 88.9%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    2

    ### Method
    GearJoint

    ### Complexity / LOC
    23 / 335 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GearJoint.cs
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

namespace Alis.Core.Physic.Dynamics.Joints
{
    // K = J * invM * JT = invMass + invI * cross(r, ug)^2

    /// <summary>
    ///     A gear joint is used to connect two joints together.
    ///     Either joint can be a revolute or prismatic joint.
    ///     You specify a gear ratio to bind the motions together:
    ///     <![CDATA[coordinate1 + ratio * coordinate2 = ant]]>
    ///     The ratio can be negative or positive. If one joint is a revolute joint
    ///     and the other joint is a prismatic joint, then the ratio will have units
    ///     of length or units of 1/length.
    ///     Warning: You have to manually destroy the gear joint if jointA or jointB is destroyed.
    /// </summary>
    public class GearJoint : Joint
    {
        /// <summary>
        ///     The body
        /// </summary>
        private readonly Body _bodyA;

        /// <summary>
        ///     The body
        /// </summary>
        private readonly Body _bodyB;

        /// <summary>
        ///     The body
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/Joints/GearJointTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/GearJoint.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GearJoint.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
