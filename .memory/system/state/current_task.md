
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 115 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/NativeWindow.cs

    ### Language
    cs

    ### Coverage
    3.5% (Line: 3.6%, Branch: 3.4%)

    ### Uncovered Lines
    351

    ### Uncovered Branches
    85

    ### Method
    NativeWindow

    ### Complexity / LOC
    134 / 618 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:NativeWindow.cs
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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Microsoft.Win32.SafeHandles;
using Image = Alis.Core.Graphic.Image;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     Provides a simplified interface for creating and using a GLFW window with properties, events, etc.
    /// </summary>
    /// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid" />
    // S3897: Static fields are inherited from SafeHandle base class; ISerializable is not applicable for native handles
    // S4035: No unsafe methods in this class; base SafeHandle inherits from unsafe contexts
    [SuppressMessage("SonarAnalyzer.CSharp", "S3897", Justification = "Inherited static fields from SafeHandle base class")]
    [SuppressMessage("SonarAnalyzer.CSharp", "S4035", Justification = "No unsafe methods in this class")]
    public class NativeWindow : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        ///     The window instance this object wraps.
        /// </summary>
        protected readonly Window Window;

        /// <summary>
        ///     Roots GLFW callback delegates to prevent GC collection while they are registered with unmanaged code.
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/test/NativeWindowTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/NativeWindow.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage NativeWindow.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
