
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 13 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Render/Animator.cs

    ### Language
    cs

    ### Coverage
    97.8% (Line: 98.6%, Branch: 95.0%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    1

    ### Method
    cs

    ### Complexity / LOC
    29 / 98 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Animator.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Time;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The animator
    /// </summary>
    public struct Animator : IAnimator
    {
        /// <summary>
        ///     Gets or sets the value of the animations
        /// </summary>
        public List<Animation> Animations { get; set; }

        /// <summary>
        ///     Gets or sets the value of the current animation index
        /// </summary>
        public int CurrentAnimationIndex { get; set; }

        /// <summary>
        ///     Gets or sets the value of the current frame index
        /// </summary>
        public int CurrentFrameIndex { get; set; }

        /// <summary>
        ///     The clock
        /// </summary>
        private readonly Clock _clock;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:2_Application/Alis/test/Core/Ecs/Components/Render/AnimatorTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Render/Animator.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Animator.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
