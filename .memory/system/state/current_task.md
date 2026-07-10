
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 193 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Contacts/ContactSolver.cs

    ### Language
    cs

    ### Coverage
    77.8% (Line: 80.4%, Branch: 64.8%)

    ### Uncovered Lines
    120

    ### Uncovered Branches
    43

    ### Method
    ContactSolver

    ### Complexity / LOC
    90 / 700 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ContactSolver.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver class
    /// </summary>
    public class ContactSolver : IDisposable
    {
        /// <summary>
        ///     Bundles contact constraint data for impulse application.
        /// </summary>
        private readonly struct ContactConstraintData
        {
            /// <summary>
            /// The cp
            /// </summary>
            public readonly VelocityConstraintPoint Cp1;
            /// <summary>
            /// The cp
            /// </summary>
            public readonly VelocityConstraintPoint Cp2;
            /// <summary>
            /// The normal
            /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/Contacts/ContactSolverTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Contacts/ContactSolver.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ContactSolver.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
