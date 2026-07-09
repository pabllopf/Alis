
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 5 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs

    ### Language
    cs

    ### Coverage
    81.4% (Line: 82.4%, Branch: 79.2%)

    ### Uncovered Lines
    21

    ### Uncovered Branches
    10

    ### Method
    cs

    ### Complexity / LOC
    40 / 154 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AudioReader.cs
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Media.FFmpeg.Audio.Models;
using Alis.Extension.Media.FFmpeg.BaseClasses;

namespace Alis.Extension.Media.FFmpeg.Audio
{
    /// <summary>
    ///     The audio reader class
    /// </summary>
    /// <seealso cref="MediaReader{Frame,Writer}" />
    /// <seealso cref="IDisposable" />
    public class AudioReader : MediaReader<AudioFrame, AudioWriter>, IDisposable
    {
        /// <summary>
        ///     The ffprobe
        /// </summary>
        private readonly string ffmpeg;

        /// <summary>
        ///     The ffprobe
        /// </summary>
        private readonly string ffprobe;

        /// <summary>
        ///     The loaded bit depth
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Audio/AudioReaderTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AudioReader.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
