
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 160 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyConfiguration.cs

    ### Language
    cs

    ### Coverage
    55.1% (Line: 56.4%, Branch: 46.4%)

    ### Uncovered Lines
    78

    ### Uncovered Branches
    15

    ### Method
    WebAssemblyConfiguration

    ### Complexity / LOC
    75 / 216 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyConfiguration.cs
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

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Configuration builder for WebAssembly platform
    ///     Provides a fluent interface to configure platform settings
    /// </summary>
    
    public class WebAssemblyConfigurationBuilder
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly WebAssemblyConfiguration _configuration;

        /// <summary>
        ///     Initializes a new instance of the WebAssemblyConfigurationBuilder
        /// </summary>
        public WebAssemblyConfigurationBuilder() => _configuration = new WebAssemblyConfiguration();

        /// <summary>
        ///     Sets the window width and height
        /// </summary>
        public WebAssemblyConfigurationBuilder WithSize(int width, int height)
        {
            _configuration.WindowWidth = width;
            _configuration.WindowHeight = height;
            return this;
        }

    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/WebAssemblyConfigurationTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyConfiguration.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebAssemblyConfiguration.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
