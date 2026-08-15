
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 150 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs

    ### Language
    cs

    ### Coverage
    90.2% (Line: 91.3%, Branch: 84.2%)

    ### Uncovered Lines
    56

    ### Uncovered Branches
    18

    ### Method
    Archetype

    ### Complexity / LOC
    104 / 786 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Archetype.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;
using HashCode = Alis.Core.Aspect.Math.HashCode;

// S3963: Static constructor required for ECS null archetype initialization
[assembly: SuppressMessage("SonarAnalyzer.CSharp", "S3963", Justification = "Static constructor required for ECS null archetype lazy initialization")]

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype class
    /// </summary>
    public class Archetype(GameObjectType archetypeId, ComponentStorageBase[] components, bool isTempCreateArchetype)
    {
        /// <summary>
        ///     The null
        /// </summary>
        internal static readonly GameObjectType Null;

        /// <summary>
        ///     The create
        /// </summary>
        // S2223: Required for ECS archetype table access from GameObjectType
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Kernel/Archetypes/ArchetypeTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Archetype.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
