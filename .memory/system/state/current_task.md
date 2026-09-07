
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 146 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Updating/Runners/Update.cs

    ### Language
    cs

    ### Coverage
    84.1% (Line: 83.1%, Branch: 92.9%)

    ### Uncovered Lines
    43

    ### Uncovered Branches
    2

    ### Method
    Update

    ### Complexity / LOC
    35 / 394 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Update.cs
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
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <summary>
    ///     The update loop class
    /// </summary>
    internal static class UpdateLoop
    {
        /// <summary>
        ///     Runs the entity ids
        /// </summary>
        /// <typeparam name="TComp">The comp</typeparam>
        /// <param name="entityIds">The entity ids</param>
        /// <param name="comp">The comp</param>
        /// <param name="length">The length</param>
        /// <param name="gameObject">The game object</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Run<TComp>(ref GameObjectIdOnly entityIds, ref TComp comp, int length, GameObject gameObject)
            where TComp : IOnUpdate
        {
            if (length <= 0)
            {
                return;
            }

            do
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Updating/Runners/UpdateTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Updating/Runners/Update.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Update.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
