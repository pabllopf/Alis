
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 1 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiIO.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    741

    ### Uncovered Branches
    0

    ### Method
    ImGuiIO

    ### Complexity / LOC
    1481 / 781 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIO.cs
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
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui io
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ImGuiIo
    {
        /// <summary>
        ///     The config flags
        /// </summary>
        public ImGuiConfigFlags ConfigFlags { get; set; }

        /// <summary>
        ///     The backend flags
        /// </summary>
        public ImGuiBackendFlags BackendFlags { get; set; }

        /// <summary>
        ///     The display size
        /// </summary>
        public Vector2F DisplaySize { get; set; }

        /// <summary>
        ///     The delta time
        /// </summary>
        public float DeltaTime { get; set; }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiIOTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiIO.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiIO.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
