
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 39 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgram.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    126

    ### Uncovered Branches
    95

    ### Method
    GLShaderProgram

    ### Complexity / LOC
    90 / 188 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GLShaderProgram.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL.Enums;
using Type = System.Type;

namespace Alis.Core.Graphic.OpenGL.Constructs
{
    /// <summary>
    ///     The gl shader program class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public sealed class GlShaderProgram : IDisposable
    {
        /// <summary>
        ///     Specifies whether this program will dispose of the child
        ///     vertex/fragment programs when the IDisposable method is called.
        /// </summary>
        public readonly bool DisposeChildren;

        /// <summary>
        ///     Specifies the fragment shader used in this program.
        /// </summary>
        public readonly GlShader FragmentShader;

        /// <summary>
        ///     Specifies the vertex shader used in this program.
        /// </summary>
        public readonly GlShader VertexShader;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/OpenGL/Constructs/GLShaderProgramTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgram.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GLShaderProgram.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
