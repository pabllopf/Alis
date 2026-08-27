
    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImFontGlyph.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    12

    ### Uncovered Branches
    0

    ### Method
    ImFontGlyph

    ### Complexity / LOC
    24 / 18 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyph.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font glyph
    /// </summary>
    public struct ImFontGlyph
    {
        /// <summary>
        ///     The colored
        /// </summary>
        public uint Colored { get; set; }

        /// <summary>
        ///     The visible
        /// </summary>
        public uint Visible { get; set; }

        /// <summary>
        ///     The codepoint
        /// </summary>
        public uint Codepoint { get; set; }

        /// <summary>
        ///     The advance
        /// </summary>
        public float AdvanceX { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public float X0 { get; set; }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImFontGlyphTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImFontGlyph.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImFontGlyph.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
