
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 1 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs

    ### Language
    cs

    ### Coverage
    56.3% (Line: 57.4%, Branch: 53.9%)

    ### Uncovered Lines
    75

    ### Uncovered Branches
    35

    ### Method
    cs

    ### Complexity / LOC
    66 / 218 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriter.cs
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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Encoding;

namespace Alis.Extension.Media.FFmpeg.Video
{
    /// <summary>
    ///     The audio video writer class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class AudioVideoWriter : IDisposable
    {
        /// <summary>
        ///     The ffmpeg
        /// </summary>
        private readonly string ffmpeg;

        /// <summary>
        ///     The connected socket
        /// </summary>
        private Socket connectedSocket;

        /// <summary>
        ///     The csc
        /// </summary>
        private CancellationTokenSource csc;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Video/AudioVideoWriterTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AudioVideoWriter.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
