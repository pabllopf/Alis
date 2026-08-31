
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 178 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Updating/Runners/UpdateRunnerFactory.cs

    ### Language
    cs

    ### Coverage
    33.3% (Line: 33.3%, Branch: None%)

    ### Uncovered Lines
    18

    ### Uncovered Branches
    0

    ### Method
    UpdateRunnerFactory

    ### Complexity / LOC
    27 / 78 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:UpdateRunnerFactory.cs
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

using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <summary>
    ///     The update runner factory class
    /// </summary>
    /// <seealso cref="IComponentStorageBaseFactory" />
    /// <seealso cref="IComponentStorageBaseFactory{TComp}" />
    public class UpdateRunnerFactory<TComp> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IOnUpdate
    {
        /// <summary>
        ///     Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new Update<TComp>(capacity);

        /// <summary>
        ///     Creates the stack
        /// </summary>
        /// <returns>The id table</returns>
        IdTable IComponentStorageBaseFactory.CreateStack() => new IdTable<TComp>();

        /// <summary>
        ///     Creates the strongly typed using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Updating/Runners/UpdateRunnerFactoryTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Updating/Runners/UpdateRunnerFactory.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage UpdateRunnerFactory.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
