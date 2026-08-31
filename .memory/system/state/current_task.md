
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 179 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Structs/AudioSpec.cs

    ### Language
    cs

    ### Coverage
    33.3% (Line: 33.3%, Branch: None%)

    ### Uncovered Lines
    4

    ### Uncovered Branches
    0

    ### Method
    AudioSpec

    ### Complexity / LOC
    12 / 18 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AudioSpec.cs
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
using Alis.Extension.Graphic.Sdl2.Delegates;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl audio spec
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AudioSpec
    {
        /// <summary>
        ///     The freq
        /// </summary>
        public int Freq { get; set; }

        /// <summary>
        ///     The SDL_AudioFormat
        /// </summary>
        public ushort Format { get; set; }

        /// <summary>
        ///     The channels
        /// </summary>
        public byte Channels { get; set; }

        /// <summary>
        ///     The silence
        /// </summary>
        public readonly byte silence;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/test/Structs/AudioSpecTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Structs/AudioSpec.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AudioSpec.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
