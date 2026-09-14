
[INFO] Found 1 coverage targets. (limited to 1 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyGameExamples.cs

    ### Language
    cs

    ### Coverage
    17.5% (Line: 17.4%, Branch: 17.6%)

    ### Uncovered Lines
    346

    ### Uncovered Branches
    84

    ### Method
    WebAssemblyGameExamples

    ### Complexity / LOC
    76 / 411 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameExamples.cs
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
using System.Threading;

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Examples and utilities for developing games with WebAssembly
    ///     This class provides practical examples and helper methods for common game development tasks
    /// </summary>
    
    public static class WebAssemblyGameExamples
    {
        /// <summary>
        ///     Example 1: Basic game loop setup
        ///     Shows how to create a simple game context and run a basic game loop
        /// </summary>
        public static void BasicGameLoopExample()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(1280, 720, "My Game"))
            {
                gameContext.RegisterAction("Move_Up", ConsoleKey.W, ConsoleKey.UpArrow);
                gameContext.RegisterAction("Move_Down", ConsoleKey.S, ConsoleKey.DownArrow);
                gameContext.RegisterAction("Move_Left", ConsoleKey.A, ConsoleKey.LeftArrow);
                gameContext.RegisterAction("Move_Right", ConsoleKey.D, ConsoleKey.RightArrow);
                gameContext.RegisterAction("Jump", ConsoleKey.Spacebar);
                gameContext.RegisterAction("MenuToggle", ConsoleKey.Escape);

                gameContext.OnUpdate += (sender, e) =>
                {
                    if (gameContext.IsActionActive("Move_Up"))
                    {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/WebAssemblyGameExamplesTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyGameExamples.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebAssemblyGameExamples.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
