
    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/LoadingFailedException.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    15

    ### Uncovered Branches
    0

    ### Method
    LoadingFailedException

    ### Complexity / LOC
    5 / 28 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:LoadingFailedException.cs
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
    ///     Exception thrown by SFML whenever loading a resource fails
    /// </summary>
    public class LoadingFailedException : Exception
    {
        /// <summary>
        /// The failed prefix
        /// </summary>
        private const string FailedPrefix = "Failed to load ";

        /// <summary>
        ///     Default constructor (unknown error)
        /// </summary>
        public LoadingFailedException() :
            base("Failed to load a resource")
        {
        }


        /// <summary>
        ///     Failure to load a resource from memory
        /// </summary>
        /// <param name="resourceName">Name of the resource</param>
        public LoadingFailedException(string resourceName) :
            base(FailedPrefix + resourceName + " from memory")
        {
        }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/LoadingFailedExceptionTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/LoadingFailedException.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage LoadingFailedException.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
