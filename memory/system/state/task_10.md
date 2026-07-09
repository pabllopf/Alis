
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 10 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Audio/AudioSource.cs

    ### Language
    cs

    ### Coverage
    95.3% (Line: 93.8%, Branch: 100.0%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    0

    ### Method
    cs

    ### Complexity / LOC
    30 / 69 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AudioSource.cs
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

using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Audio;
using Alis.Core.Audio.Interfaces;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Audio
{
    /// <summary>
    ///     The audio clip
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AudioSource(Context context, string nameFile = "", float volume = 100, bool isMute = false, bool playOnAwake = false, bool loop = false) :
        IAudioSource
    {
        /// <summary>
        ///     The loop
        /// </summary>
        private readonly bool loop = loop;

        /// <summary>
        ///     The player
        /// </summary>
        private IPlayer player = new Player();

        /// <summary>
        ///     Sets the player for testing purposes
        /// </summary>
        internal IPlayer PlayerForTest { set { player = value; } }

    ```
    
    ### Test File Hint
    pabllopf-official_alis:2_Application/Alis/test/Core/Ecs/Components/Audio/AudioSourceTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Audio/AudioSource.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AudioSource.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
