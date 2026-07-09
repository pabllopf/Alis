
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 11 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Language/Dialogue/src/Core/CallbackDialogAction.cs

    ### Language
    cs

    ### Coverage
    96.0% (Line: 100.0%, Branch: 83.3%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    cs

    ### Complexity / LOC
    8 / 31 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:CallbackDialogAction.cs
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

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     A dialog action that executes a callback function
    /// </summary>
    public class CallbackDialogAction : ICallbackDialogAction
    {
        /// <summary>
        ///     The action callback
        /// </summary>
        private Action _callback;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallbackDialogAction" /> class
        /// </summary>
        /// <param name="id">The action identifier</param>
        /// <param name="callback">The callback to execute (optional)</param>
        /// <exception cref="ArgumentNullException">Thrown when id is null or empty</exception>
        public CallbackDialogAction(string id, Action callback = null)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
            _callback = callback;
        }

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Language/Dialogue/test/Core/CallbackDialogActionTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Language/Dialogue/src/Core/CallbackDialogAction.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage CallbackDialogAction.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
