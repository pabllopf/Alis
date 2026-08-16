
[INFO] Found 1 coverage targets. (limited to 1 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Audio/src/Players/UnixPlayerBase.cs

    ### Language
    cs

    ### Coverage
    88.3% (Line: 91.3%, Branch: 78.3%)

    ### Uncovered Lines
    13

    ### Uncovered Branches
    10

    ### Method
    UnixPlayerBase

    ### Complexity / LOC
    36 / 188 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBase.cs
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     The unix player base class
    /// </summary>
    /// <seealso cref="IPlayer" />
    public abstract class UnixPlayerBase : IPlayer
    {
        /// <summary>
        ///     The pause process command
        /// </summary>
        internal const string PauseProcessCommand = "kill -STOP {0}";

        /// <summary>
        ///     The resume process command
        /// </summary>
        internal const string ResumeProcessCommand = "kill -CONT {0}";

        /// <summary>
        ///     The last extracted file
        /// </summary>
        internal string _lastExtractedFile;

    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Audio/test/Players/UnixPlayerBaseTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Audio/src/Players/UnixPlayerBase.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage UnixPlayerBase.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
