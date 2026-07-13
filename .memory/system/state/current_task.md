
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 75 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/EntityUpdate.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    45

    ### Uncovered Branches
    4

    ### Method
    EntityUpdate

    ### Complexity / LOC
    4 / 58 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:EntityUpdate.cs
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

using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Handles update logic for entities that have a specific component and up to five dependency arguments.
    /// </summary>
    /// <typeparam name="TComp">The component type that implements <see cref="IOnUpdate{TArg1,TArg2,TArg3,TArg4,TArg5}"/>.</typeparam>
    /// <typeparam name="TArg1">The type of the first update argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second update argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third update argument.</typeparam>
    /// <typeparam name="TArg4">The type of the fourth update argument.</typeparam>
    /// <typeparam name="TArg5">The type of the fifth update argument.</typeparam>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class EntityUpdate<TComp, TArg1, TArg2, TArg3, TArg4, TArg5>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IOnUpdate<TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        /// <summary>
        ///     Runs the update logic for all entities of this archetype.
        /// </summary>
        /// <param name="scene">The scene containing the entities to update.</param>
        /// <param name="b">The archetype representing the set of entities to update.</param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref GameObjectIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/EntityUpdateTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/EntityUpdate.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage EntityUpdate.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
