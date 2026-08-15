
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 161 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImDrawCmd.cs

    ### Language
    cs

    ### Coverage
    93.8% (Line: 93.8%, Branch: None%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    ImDrawCmd

    ### Complexity / LOC
    23 / 24 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImDrawCmd.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw cmd
    /// </summary>
    public struct ImDrawCmd
    {
        /// <summary>
        ///     The clip rect
        /// </summary>
        public Vector4F ClipRect { get; set; }

        /// <summary>
        ///     The texture id
        /// </summary>
        public IntPtr TextureId { get; set; }

        /// <summary>
        ///     The vtx offset
        /// </summary>
        public uint VtxOffset { get; set; }

        /// <summary>
        ///     The idx offset
        /// </summary>
        public uint IdxOffset { get; set; }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImDrawCmdTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImDrawCmd.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImDrawCmd.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
