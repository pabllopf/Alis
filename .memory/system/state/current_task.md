
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 257 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Systems/Manager/Physic/PhysicManager.cs

    ### Language
    cs

    ### Coverage
    98.7% (Line: 98.4%, Branch: 100.0%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    PhysicManager

    ### Complexity / LOC
    18 / 79 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:PhysicManager.cs
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

using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Physic;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Ecs.Systems.Manager.Physic
{
    /// <summary>
    ///     The physic manager base class
    /// </summary>
    /// <seealso cref="AManager" />
    public class PhysicManager : AManager
    {
        /// <summary>
        ///     The iterations
        /// </summary>
        private SolverIterations iterations;

        /// <summary>
        ///     The time step physics
        /// </summary>
        internal float timeStepPhysics;

        /// <summary>
        ///     Gets or sets the world physic
        /// </summary>
        public WorldPhysic WorldPhysic { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:2_Application/Alis/test/Core/Ecs/Systems/Manager/Physic/PhysicManagerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Systems/Manager/Physic/PhysicManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage PhysicManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
