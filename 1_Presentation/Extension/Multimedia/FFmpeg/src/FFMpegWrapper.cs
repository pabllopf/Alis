// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FFMpegWrapper.cs
// 
//  Author:Pablo Perdomo Falcón
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
using System.Text.RegularExpressions;

namespace Alis.Extension.Multimedia.FFmpeg
{
    /// <summary>
    ///     FFmpeg wrapper
    /// </summary>
    public static class FfMpegWrapper
    {
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
        ///     This may affect the progress tracker that depends on displayed stats. Default is 'info'.
        /// </summary>
        public static Verbosity LogLevel { get; set; } = Verbosity.Info;

        /// <summary>
        ///     FFmpeg banner setting. This sets the 'hide_banner' parameter on FFmpeg. Default is 'true' to hide the banner.
        /// </summary>
        public static bool HideFFmpegBanner { get; set; } = true;

        /// <summary>
        ///     Run given command (arguments) using the given executable name or path
        /// </summary>
        /// <param name="executable">Executable name or path</param>
        /// <param name="command">Command to run. This string will be passed as an argument to the executable</param>
        /// <param name="prettify">Add new lines to output/error.</param>
        public static (string output, string error) RunCommand(string executable, string command, bool prettify = true)
        {
            Process p = Process.Start(new ProcessStartInfo
            {
                FileName = executable,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments =
                    $"-loglevel {LogLevel.ToString().ToLowerInvariant()} " +
                    $"{(HideFFmpegBanner ? "-hide_banner" : "")} " +
                    $"{command}"
            });

            string output = "", error = "";
            p.OutputDataReceived += (a, d) => output += d.Data + (prettify ? "\n" : "");
            p.ErrorDataReceived += (a, d) => output += d.Data + (prettify ? "\n" : "");
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            p.WaitForExit();
            return (output, error);
        }

        /// <summary>
        ///     Run given command (arguments) using the given executable name or path. This does not wait for the process to exit
        ///     or return the output.
        /// </summary>
        /// <param name="executable">Executable name or path</param>
        /// <param name="command">Command to run. This string will be passed as an argument to the executable</param>
        /// <param name="showOutput">Show output to terminal. Error stream will not be redirected if this is set to true.</param>
        public static Process ExecuteCommand(string executable, string command, bool showOutput = false)
        {
            Process p = Process.Start(new ProcessStartInfo
            {
                FileName = executable,
                UseShellExecute = false,
                RedirectStandardError = !showOutput,
                CreateNoWindow = !showOutput,
                Arguments =
                    $"-loglevel {LogLevel.ToString().ToLowerInvariant()} " +
                    $"{(HideFFmpegBanner ? "-hide_banner" : "")} " +
                    $"{command}"
            });

            if (!showOutput)
            {
                p.BeginErrorReadLine();
            }

            return p;
        }

        /// <summary>
        ///     Run given command (arguments) using the given executable name or path. This redirects the output and error streams
        ///     and returns the output stream.
        /// </summary>
        /// <param name="executable">Executable name or path</param>
        /// <param name="command">Command to run. This string will be passed as an argument to the executable</param>
        /// <param name="process">FFmpeg process</param>
        /// <param name="showOutput">Show output to terminal. Error stream will not be redirected if this is set to true.</param>
        public static Stream OpenOutput(string executable, string command, out Process process, bool showOutput = false)
        {
            process = Process.Start(new ProcessStartInfo
            {
                FileName = executable,
                UseShellExecute = false,
                RedirectStandardError = !showOutput,
                RedirectStandardOutput = true,
                CreateNoWindow = !showOutput,
                Arguments =
                    $"-loglevel {LogLevel.ToString().ToLowerInvariant()} " +
                    $"{(HideFFmpegBanner ? "-hide_banner" : "")} " +
                    $"{command}"
            });

            if (!showOutput)
            {
                process.BeginErrorReadLine();
            }

            return process.StandardOutput.BaseStream;
        }

        /// <summary>
        ///     Run given command (arguments) using the given executable name or path. This redirects the output and error streams
        ///     and returns the output stream.
        ///     This does not return any FFmpeg process.
        /// </summary>
        /// <param name="executable">Executable name or path</param>
        /// <param name="command">Command to run. This string will be passed as an argument to the executable</param>
        /// <param name="showOutput">Show output to terminal. Error stream will not be redirected if this is set to true.</param>
        public static Stream OpenOutput(string executable, string command, bool showOutput = false) => OpenOutput(executable, command, out _, showOutput);

        /// <summary>
        ///     Run given command (arguments) using the given executable name or path. This redirects the input stream and returns
        ///     it.
        /// </summary>
        /// <param name="executable">Executable name or path</param>
        /// <param name="command">Command to run. This string will be passed as an argument to the executable</param>
        /// <param name="process">FFmpeg process</param>
        /// <param name="showOutput">Show output to terminal. Error stream will not be redirected if this is set to true.</param>
        public static Stream OpenInput(string executable, string command, out Process process, bool showOutput = false)
        {
            process = Process.Start(new ProcessStartInfo
            {
                FileName = executable,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardError = !showOutput,
                CreateNoWindow = !showOutput,
                Arguments =
                    $"-loglevel {LogLevel.ToString().ToLowerInvariant()} " +
                    $"{(HideFFmpegBanner ? "-hide_banner" : "")} " +
                    $"{command}"
            });

            if (!showOutput)
            {
                process.BeginErrorReadLine();
            }

            return process.StandardInput.BaseStream;
        }

        /// <summary>
        ///     Run given command (arguments) using the given executable name or path. This redirects the input stream and returns
        ///     it.
        ///     This does not return any FFmpeg process.
        /// </summary>
        /// <param name="executable">Executable name or path</param>
        /// <param name="command">Command to run. This string will be passed as an argument to the executable</param>
        /// <param name="showOutput">Show output to terminal. Error stream will not be redirected if this is set to true.</param>
        public static Stream OpenInput(string executable, string command, bool showOutput = false) => OpenInput(executable, command, out _, showOutput);

        /// <summary>
        ///     Run given command (arguments) using the given executable name or path. This redirects the input and output streams
        ///     and returns them.
        /// </summary>
        /// <param name="executable">Executable name or path</param>
        /// <param name="command">Command to run. This string will be passed as an argument to the executable</param>
        /// <param name="process">FFmpeg process</param>
        /// <param name="showOutput">Show output to terminal. Error stream will not be redirected if this is set to true.</param>
        public static (Stream input, Stream output) Open(string executable, string command, out Process process, bool showOutput = false)
        {
            process = Process.Start(new ProcessStartInfo
            {
                FileName = executable,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardError = !showOutput,
                RedirectStandardOutput = true,
                CreateNoWindow = !showOutput,
                Arguments =
                    $"-loglevel {LogLevel.ToString().ToLowerInvariant()} " +
                    $"{(HideFFmpegBanner ? "-hide_banner" : "")} " +
                    $"{command}"
            });

            if (!showOutput)
            {
                process.BeginErrorReadLine();
            }

            return (process.StandardInput.BaseStream, process.StandardOutput.BaseStream);
        }

        /// <summary>
        ///     Run given command (arguments) using the given executable name or path. This redirects the input and output streams
        ///     and returns them.
        ///     This does not return any FFmpeg process.
        /// </summary>
        /// <param name="executable">Executable name or path</param>
        /// <param name="command">Command to run. This string will be passed as an argument to the executable</param>
        /// <param name="showOutput">Show output to terminal. Error stream will not be redirected if this is set to true.</param>
        public static (Stream input, Stream output) Open(string executable, string command, bool showOutput = false)
            => Open(executable, command, out _, showOutput);

        /// <summary>
        ///     Gets the encoders using the specified ffmpeg executable
        /// </summary>
        /// <param name="ffmpegExecutable">The ffmpeg executable</param>
        /// <returns>The data</returns>
        public static Dictionary<string, (string Description, MediaType Type)> GetEncoders(string ffmpegExecutable = "ffmpeg")
        {
            Dictionary<string, (string Description, MediaType Type)> data = new Dictionary<string, (string Description, MediaType Type)>();
            (string output, _) = RunCommand(ffmpegExecutable, "-encoders -v quiet");
            MatchCollection mtc = CodecRegex.Matches(output);
            foreach (Match m in mtc)
            {
                char t = m.Groups["type"].Value[0];
                data.Add(m.Groups["codec"].Value, (m.Groups["description"].Value, t == 'A' ? MediaType.Audio : t == 'V' ? MediaType.Video : MediaType.Subtitle));
            }

            return data;
        }

        /// <summary>
        ///     Gets the decoders using the specified ffmpeg executable
        /// </summary>
        /// <param name="ffmpegExecutable">The ffmpeg executable</param>
        /// <returns>The data</returns>
        public static Dictionary<string, (string Description, MediaType Type)> GetDecoders(string ffmpegExecutable = "ffmpeg")
        {
            Dictionary<string, (string Description, MediaType Type)> data = new Dictionary<string, (string Description, MediaType Type)>();
            (string output, _) = RunCommand(ffmpegExecutable, "-decoders -v quiet");
            MatchCollection mtc = CodecRegex.Matches(output);
            foreach (Match m in mtc)
            {
                char t = m.Groups["type"].Value[0];
                data.Add(m.Groups["codec"].Value, (m.Groups["description"].Value, t == 'A' ? MediaType.Audio : t == 'V' ? MediaType.Video : MediaType.Subtitle));
            }

            return data;
        }

        /// <summary>
        ///     Gets the formats using the specified ffmpeg executable
        /// </summary>
        /// <param name="ffmpegExecutable">The ffmpeg executable</param>
        /// <returns>The data</returns>
        public static Dictionary<string, (string Description, MuxingSupport Support)> GetFormats(string ffmpegExecutable = "ffmpeg")
        {
            Dictionary<string, (string Description, MuxingSupport Support)> data = new Dictionary<string, (string Description, MuxingSupport Support)>();
            (string output, _) = RunCommand(ffmpegExecutable, "-formats -v quiet -loglevel silent");
            MatchCollection mtc = FormatRegex.Matches(output);
            foreach (Match m in mtc)
            {
                string t = m.Groups["type"].Value.Trim();
                data.Add(m.Groups["format"].Value, (m.Groups["description"].Value,
                    t == "DE" ? MuxingSupport.MuxDemux : t == "D" ? MuxingSupport.Demux : MuxingSupport.Mux));
            }

            return data;
        }

        /// <summary>
        ///     Take a running FFmpeg process with a redirected Error stream and try to parse progress. Requires the total media
        ///     duration in seconds.
        ///     May not work on certain loglevels.
        /// </summary>
        /// <param name="ffmpegProcess">Running FFmpeg process with redirected Error stream</param>
        /// <param name="duration">Media duration in seconds</param>
        public static Progress<double> RegisterProgressTracker(Process ffmpegProcess, double duration)
        {
            Progress<double> prg = new Progress<double>();
            IProgress<double> iprg = prg;

            Regex rgx = new Regex(@"^(frame=\s*?(?<frame>\d+)\s*?)?(fps=\s*?\d+\.?\d*?\s+?)?(q=\s*?[\-0-9\.]+\s*?)?\w+?=\s*?\d+[kMBGTb]+\s*?time=(?<h>\d+):(?<m>\d+):(?<s>[0-9\.]+?)\s",
                RegexOptions.Compiled,
                TimeSpan.FromSeconds(10));

            ffmpegProcess.ErrorDataReceived += (sender, d) =>
            {
                if (string.IsNullOrEmpty(d.Data))
                {
                    return;
                }

                Match match = rgx.Match(d.Data);
                if (match.Success)
                {
                    int hours = int.Parse(match.Groups["h"].Value);
                    int minutes = int.Parse(match.Groups["m"].Value);
                    double seconds = double.Parse(match.Groups["s"].Value);
                    seconds = seconds + 60 * minutes + 60 * 60 * hours;

                    double progress = seconds / duration * 100;
                    if (progress > 100)
                    {
                        progress = 100;
                    }

                    iprg.Report(progress);
                }
            };

            return prg;
        }
    }
}