// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SamplingLogFilter.cs
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
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Filters
{
    /// <summary>
    ///     Samples log entries to reduce volume while maintaining representative coverage.
    ///     Useful for high-frequency logging scenarios like render loops.
    ///     AOT-compatible: Uses atomic counters for sampling.
    /// </summary>
    public sealed class SamplingLogFilter : ILogFilter
    {
        /// <summary>
        ///     Determines the sampling frequency: 1 out of every N entries will pass through.
        /// </summary>
        private readonly int _sampleRate;

        /// <summary>
        ///     Internal counter used to track which entries pass through based on the sample rate.
        /// </summary>
        private long _counter;

        /// <summary>
        ///     Initializes a new instance of the SamplingLogFilter class.
        /// </summary>
        /// <param name="sampleRate">1 out of every N entries will pass. Must be >= 1.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="sampleRate"/> is less than 1.</exception>
        public SamplingLogFilter(int sampleRate = 10)
        {
            if (sampleRate < 1)
            {
                throw new ArgumentException("Sample rate must be >= 1", nameof(sampleRate));
            }

            _sampleRate = sampleRate;
            _counter = 0;
        }


        /// <summary>
        ///     Gets a human-readable name showing the sampling ratio (1:N).
        /// </summary>
        public string Name => $"SamplingFilter[1:{_sampleRate}]";


        /// <summary>
        ///     Determines whether a log entry should be processed based on the configured sample rate.
        ///     Every Nth entry (where N = sampleRate) passes through; others are discarded.
        ///     Returns false for null entries.
        /// </summary>
        /// <param name="entry">The log entry to evaluate. May be null.</param>
        /// <returns>True if the entry passes the sample; false if it should be skipped.</returns>
        public bool ShouldLog(ILogEntry entry)
        {
            if (entry == null)
            {
                return false;
            }

            unchecked
            {
                _counter++;
            }

            return _counter % _sampleRate == 0;
        }
    }
}