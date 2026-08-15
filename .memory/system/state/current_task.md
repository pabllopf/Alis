
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 148 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/Structs/Window.cs

    ### Language
    cs

    ### Coverage
    90.0% (Line: 87.5%, Branch: 100.0%)

    ### Uncovered Lines
    2

    ### Uncovered Branches
    0

    ### Method
    Window

    ### Complexity / LOC
    10 / 32 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Window.cs
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

namespace Alis.Extension.Graphic.Glfw.Structs
{
    /// <summary>
    ///     Wrapper around a GLFW window pointer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Window : IEquatable<Window>
    {
        /// <summary>
        ///     Describes a default/null instance.
        /// </summary>
        public static readonly Window None;

        /// <summary>
        ///     Internal pointer.
        /// </summary>
        internal readonly IntPtr handle;

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Window" /> to <see cref="IntPtr" />.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator IntPtr(Window window) => window.handle;

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/test/Structs/WindowTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/Structs/Window.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Window.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
