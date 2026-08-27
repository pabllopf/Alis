
[INFO] Found 1 coverage targets. (limited to 1 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseWheelScrollEventArgs.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    16

    ### Uncovered Branches
    0

    ### Method
    MouseWheelScrollEventArgs

    ### Complexity / LOC
    10 / 23 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:MouseWheelScrollEventArgs.cs
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

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Mouse wheel scroll event parameters
    /// </summary>
    public class MouseWheelScrollEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the scroll amount
        /// </summary>
        public float Delta { get; set; }

        /// <summary>
        ///     Gets or sets the mouse wheel which triggered the event
        /// </summary>
        public Mouse.Wheel Wheel { get; set; }

        /// <summary>
        ///     Gets or sets the X coordinate of the mouse cursor
        /// </summary>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate of the mouse cursor
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        ///     Construct the mouse wheel scroll arguments from a mouse wheel scroll event
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/MouseWheelScrollEventArgsTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseWheelScrollEventArgs.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage MouseWheelScrollEventArgs.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
