
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 212 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/FFMpegWrapper.cs

    ### Language
    cs

    ### Coverage
    89.5% (Line: 87.9%, Branch: 97.2%)

    ### Uncovered Lines
    21

    ### Uncovered Branches
    1

    ### Method
    FFMpegWrapper

    ### Complexity / LOC
    38 / 195 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:FFMpegWrapper.cs
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Alis.Extension.Media.FFmpeg
{
    /// <summary>
    ///     FFmpeg wrapper
    /// </summary>
    public static class FfMpegWrapper
    {
        /// <summary>
        /// The hide banner arg
        /// </summary>
        private const string HideBannerArg = "-hide_banner";

        /// <summary>
        ///     The regex
        /// </summary>
        private static readonly Regex CodecRegex = new Regex(@"(?<type>[VAS\.])[F\.][S\.][X\.][B\.][D\.] (?<codec>[a-zA-Z0-9_-]+)\W+(?<description>.*)\n?", RegexOptions.Compiled, TimeSpan.FromSeconds(10));

        /// <summary>
        ///     The regex
        /// </summary>
        private static readonly Regex FormatRegex = new Regex(@"(?<type>[DE]{1,2})\s+?(?<format>[a-zA-Z0-9_\-,]+)\W+(?<description>.*)\n?", RegexOptions.Compiled, TimeSpan.FromSeconds(10));

        /// <summary>
        ///     FFmpeg verbosity. This sets the 'loglevel' parameter on FFmpeg. Useful when showing output and debugging issues.
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/FFMpegWrapperTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/FFMpegWrapper.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage FFMpegWrapper.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
