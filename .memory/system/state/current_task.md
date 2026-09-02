
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 18 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Shader.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    189

    ### Uncovered Branches
    24

    ### Method
    Shader

    ### Complexity / LOC
    54 / 394 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Shader.cs
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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;
using LoadingFailedException = Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Wrapper for pixel shaders
    /// </summary>
    public class Shader : ObjectBase
    {
        /// <summary>
        ///     Special value that can be passed to SetParameter,
        ///     and that represents the texture of the object being drawn
        /// </summary>
        public static readonly CurrentTextureType CurrentTexture = null;

        /// <summary>
        ///     The texture
        /// </summary>
        internal readonly Dictionary<string, Texture> myTextures = new Dictionary<string, Texture>();


    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/ShaderTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Shader.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Shader.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
