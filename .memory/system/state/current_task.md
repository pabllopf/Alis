
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 102 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/SizeEventArgs.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    10

    ### Uncovered Branches
    0

    ### Method
    SizeEventArgs

    ### Complexity / LOC
    6 / 17 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SizeEventArgs.cs
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
    ///     Size event parameters
    /// </summary>
    public class SizeEventArgs : EventArgs
    {
        /// <summary>
        ///     Gets or sets the new height of the window
        /// </summary>
        public uint Height { get; set; }

        /// <summary>
        ///     Gets or sets the new width of the window
        /// </summary>
        public uint Width { get; set; }

        /// <summary>
        ///     Construct the size arguments from a size event
        /// </summary>
        /// <param name="e">Size event</param>
        public SizeEventArgs(SizeEvent e)
        {
            Width = e.Width;
            Height = e.Height;
        }


        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/SizeEventArgsTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/SizeEventArgs.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SizeEventArgs.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
