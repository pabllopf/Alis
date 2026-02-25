// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ResourceMetrics.cs
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

namespace Alis.Extension.Profile.Models
{
    /// <summary>
    ///     Represents an immutable snapshot of system resource metrics at a specific point in time.
    ///     This struct captures CPU usage, memory consumption, garbage collection statistics,
    ///     and thread count information for performance analysis.
    /// </summary>
    public readonly struct ResourceMetrics : IEquatable<ResourceMetrics>
    {
        /// <summary>
        ///     Gets the CPU usage in milliseconds of processor time consumed by the process.
        /// </summary>
        /// <value>
        ///     A <see cref="double" /> representing the CPU time in milliseconds.
        /// </value>
        public double CpuUsageMilliseconds { get; }

        /// <summary>
        ///     Gets the memory usage in bytes currently allocated by the process.
        /// </summary>
        /// <value>
        ///     A <see cref="long" /> representing the memory usage in bytes.
        /// </value>
        public long MemoryUsageBytes { get; }

        /// <summary>
        ///     Gets the total number of garbage collections that have occurred
        ///     across all generations since the process started.
        /// </summary>
        /// <value>
        ///     An <see cref="int" /> representing the total GC count.
        /// </value>
        public int GarbageCollectionCount { get; }

        /// <summary>
        ///     Gets the number of threads currently active in the process.
        /// </summary>
        /// <value>
        ///     An <see cref="int" /> representing the thread count.
        /// </value>
        public int ThreadCount { get; }

        /// <summary>
        ///     Gets the timestamp when these metrics were captured.
        /// </summary>
        /// <value>
        ///     A <see cref="DateTime" /> representing the capture time.
        /// </value>
        public DateTime Timestamp { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResourceMetrics" /> struct.
        /// </summary>
        /// <param name="cpuUsageMilliseconds">The CPU usage in milliseconds.</param>
        /// <param name="memoryUsageBytes">The memory usage in bytes.</param>
        /// <param name="garbageCollectionCount">The total garbage collection count.</param>
        /// <param name="threadCount">The active thread count.</param>
        /// <param name="timestamp">The timestamp when metrics were captured.</param>
        /// <exception cref="ArgumentException">
        ///     Thrown when cpuUsageMilliseconds or memoryUsageBytes is negative.
        /// </exception>
        public ResourceMetrics(
            double cpuUsageMilliseconds,
            long memoryUsageBytes,
            int garbageCollectionCount,
            int threadCount,
            DateTime timestamp)
        {
            if (cpuUsageMilliseconds < 0)
            {
                throw new ArgumentException("CPU usage cannot be negative.", nameof(cpuUsageMilliseconds));
            }

            if (memoryUsageBytes < 0)
            {
                throw new ArgumentException("Memory usage cannot be negative.", nameof(memoryUsageBytes));
            }

            CpuUsageMilliseconds = cpuUsageMilliseconds;
            MemoryUsageBytes = memoryUsageBytes;
            GarbageCollectionCount = garbageCollectionCount;
            ThreadCount = threadCount;
            Timestamp = timestamp;
        }

        /// <summary>
        ///     Creates a new <see cref="ResourceMetrics" /> instance representing zero or empty metrics.
        /// </summary>
        /// <returns>
        ///     A <see cref="ResourceMetrics" /> with all values set to zero or minimum.
        /// </returns>
        public static ResourceMetrics Empty => new ResourceMetrics(0, 0, 0, 0, DateTime.MinValue);

        /// <summary>
        ///     Determines whether the specified <see cref="ResourceMetrics" /> is equal to the current instance.
        /// </summary>
        /// <param name="other">The other resource metrics to compare.</param>
        /// <returns>
        ///     <c>true</c> if the specified metrics are equal to the current instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ResourceMetrics other)
        {
            return CpuUsageMilliseconds.Equals(other.CpuUsageMilliseconds) &&
                   MemoryUsageBytes == other.MemoryUsageBytes &&
                   GarbageCollectionCount == other.GarbageCollectionCount &&
                   ThreadCount == other.ThreadCount &&
                   Timestamp.Equals(other.Timestamp);
        }

        /// <summary>
        ///     Determines whether the specified object is equal to the current instance.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>
        ///     <c>true</c> if the specified object is equal to the current instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return obj is ResourceMetrics other && Equals(other);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for the current <see cref="ResourceMetrics" />.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + CpuUsageMilliseconds.GetHashCode();
                hash = hash * 23 + MemoryUsageBytes.GetHashCode();
                hash = hash * 23 + GarbageCollectionCount.GetHashCode();
                hash = hash * 23 + ThreadCount.GetHashCode();
                hash = hash * 23 + Timestamp.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        ///     Determines whether two <see cref="ResourceMetrics" /> instances are equal.
        /// </summary>
        /// <param name="left">The first metrics to compare.</param>
        /// <param name="right">The second metrics to compare.</param>
        /// <returns>
        ///     <c>true</c> if the metrics are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(ResourceMetrics left, ResourceMetrics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether two <see cref="ResourceMetrics" /> instances are not equal.
        /// </summary>
        /// <param name="left">The first metrics to compare.</param>
        /// <param name="right">The second metrics to compare.</param>
        /// <returns>
        ///     <c>true</c> if the metrics are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ResourceMetrics left, ResourceMetrics right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Returns a string representation of the resource metrics.
        /// </summary>
        /// <returns>
        ///     A formatted string containing all metric values.
        /// </returns>
        public override string ToString()
        {
            return $"CPU: {CpuUsageMilliseconds:F2}ms, Memory: {MemoryUsageBytes:N0} bytes, " +
                   $"GC: {GarbageCollectionCount}, Threads: {ThreadCount}, Timestamp: {Timestamp:yyyy-MM-dd HH:mm:ss.fff}";
        }
    }
}

