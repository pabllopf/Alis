
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 41 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioPlayer.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    99

    ### Uncovered Branches
    48

    ### Method
    AudioPlayer

    ### Complexity / LOC
    32 / 133 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayer.cs
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
using Alis.Extension.Media.FFmpeg.BaseClasses;

namespace Alis.Extension.Media.FFmpeg.Audio
{
    /// <summary>
    ///     The audio player class
    /// </summary>
    /// <seealso cref="MediaWriter{Frame}" />
    /// <seealso cref="IDisposable" />
    public class AudioPlayer : MediaWriter<AudioFrame>, IDisposable
    {
        /// <summary>
        ///     The ffplay
        /// </summary>
        internal readonly string ffplay;

        /// <summary>
        ///     The ffplayp
        /// </summary>
        private Process ffplayp;

        /// <summary>
        ///     Used for playing audio data
        /// </summary>
        /// <param name="input">Input audio to play (can be left empty if planning on playing samples directly)</param>
        /// <param name="ffplayExecutable">Name or path to the ffplay executable</param>
        public AudioPlayer(string input = null, string ffplayExecutable = "ffplay")
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Audio/AudioPlayerTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioPlayer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AudioPlayer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
