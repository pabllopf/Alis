
[INFO] Found 1 coverage targets. (limited to 1 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs

    ### Language
    cs

    ### Coverage
    39.3% (Line: 43.2%, Branch: 16.7%)

    ### Uncovered Lines
    158

    ### Uncovered Branches
    40

    ### Method
    BoxCollider

    ### Complexity / LOC
    72 / 314 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:BoxCollider.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     The box collider class
    /// </summary>
    /// <seealso cref="IBoxCollider" />
    /// <seealso cref="IOnInit" />
    /// <seealso cref="IOnUpdate" />
    public class BoxCollider : IBoxCollider
    {
        /// <summary>
        ///     The vertices
        /// </summary>
        private static readonly float[] Vertices =
        {
            -0.5f, -0.5f,
            0.5f, -0.5f,
            0.0f, 0.5f
        };

    ```
    
    ### Test File Hint
    pabllopf-official_alis:2_Application/Alis/test/Core/Ecs/Components/Collider/BoxColliderTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage BoxCollider.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
