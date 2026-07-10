
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 183 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiPayload.cs

    ### Language
    cs

    ### Coverage
    69.2% (Line: 69.2%, Branch: None%)

    ### Uncovered Lines
    4

    ### Uncovered Branches
    0

    ### Method
    ImGuiPayload

    ### Complexity / LOC
    20 / 27 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPayload.cs
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
using System.Text;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui payload
    /// </summary>
    public struct ImGuiPayload
    {
        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data { get; set; }

        /// <summary>
        ///     The data size
        /// </summary>
        public int DataSize { get; set; }

        /// <summary>
        ///     The source id
        /// </summary>
        public uint SourceId { get; set; }

        /// <summary>
        ///     The source parent id
        /// </summary>
        public uint SourceParentId { get; set; }

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiPayloadTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiPayload.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiPayload.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
