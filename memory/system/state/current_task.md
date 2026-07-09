
[INFO] Found 1 coverage targets. (limited to 1 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioWriter.cs

    ### Language
    cs

    ### Coverage
    63.4% (Line: 60.7%, Branch: 68.5%)

    ### Uncovered Lines
    42

    ### Uncovered Branches
    17

    ### Method
    AudioWriter

    ### Complexity / LOC
    41 / 138 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AudioWriter.cs
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
using System.Threading;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;

namespace Alis.Extension.Media.FFmpeg.Audio
{
    /// <summary>
    ///     The audio writer class
    /// </summary>
    /// <seealso cref="MediaWriter{Frame}" />
    /// <seealso cref="IDisposable" />
    public class AudioWriter : MediaWriter<AudioFrame>, IDisposable
    {
        /// <summary>
        ///     The ffmpeg
        /// </summary>
        private readonly string ffmpeg;

        /// <summary>
        ///     The csc
        /// </summary>
        private CancellationTokenSource csc;

        /// <summary>
        ///     The ffmpegp
        /// </summary>
        internal Process Ffmpegp;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Audio/AudioWriterTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioWriter.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AudioWriter.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
