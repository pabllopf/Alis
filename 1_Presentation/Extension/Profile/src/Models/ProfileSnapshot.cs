// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfileSnapshot.cs
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
    ///     Represents an immutable snapshot of profiling data captured during a profiling session.
    ///     This struct contains both time-based metrics and resource consumption data,
    ///     providing a complete picture of performance at a specific moment.
    /// </summary>
    public readonly struct ProfileSnapshot : IEquatable<ProfileSnapshot>
    {
        /// <summary>
        ///     Gets the elapsed time duration measured during the profiling session.
        /// </summary>
        /// <value>
        ///     A <see cref="TimeSpan" /> representing the total elapsed time.
        /// </value>
        public TimeSpan ElapsedTime { get; }

        /// <summary>
        ///     Gets the resource metrics captured at the start of the profiling session.
        /// </summary>
        /// <value>
        ///     A <see cref="ResourceMetrics" /> struct containing initial resource data.
        /// </value>
        public ResourceMetrics StartMetrics { get; }

        /// <summary>
        ///     Gets the resource metrics captured at the end of the profiling session.
        /// </summary>
        /// <value>
        ///     A <see cref="ResourceMetrics" /> struct containing final resource data.
        /// </value>
        public ResourceMetrics EndMetrics { get; }

        /// <summary>
        ///     Gets the start time when profiling began.
        /// </summary>
        /// <value>
        ///     A <see cref="DateTime" /> representing the profiling start time.
        /// </value>
        public DateTime StartTime { get; }

        /// <summary>
        ///     Gets the end time when profiling was stopped.
        /// </summary>
        /// <value>
        ///     A <see cref="DateTime" /> representing the profiling end time.
        /// </value>
        public DateTime EndTime { get; }

        /// <summary>
        ///     Gets the delta (difference) in CPU usage between start and end metrics.
        /// </summary>
        /// <value>
        ///     A <see cref="double" /> representing the CPU usage change in milliseconds.
        /// </value>
        public double CpuUsageDelta => EndMetrics.CpuUsageMilliseconds - StartMetrics.CpuUsageMilliseconds;

        /// <summary>
        ///     Gets the delta (difference) in memory usage between start and end metrics.
        /// </summary>
        /// <value>
        ///     A <see cref="long" /> representing the memory usage change in bytes.
        /// </value>
        public long MemoryUsageDelta => EndMetrics.MemoryUsageBytes - StartMetrics.MemoryUsageBytes;

        /// <summary>
        ///     Gets the number of garbage collections that occurred during the profiling session.
        /// </summary>
        /// <value>
        ///     An <see cref="int" /> representing the GC count during profiling.
        /// </value>
        public int GarbageCollectionsDuringProfiling => 
            EndMetrics.GarbageCollectionCount - StartMetrics.GarbageCollectionCount;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProfileSnapshot" /> struct.
        /// </summary>
        /// <param name="elapsedTime">The elapsed time during profiling.</param>
        /// <param name="startMetrics">The resource metrics at the start of profiling.</param>
        /// <param name="endMetrics">The resource metrics at the end of profiling.</param>
        /// <param name="startTime">The start time of the profiling session.</param>
        /// <param name="endTime">The end time of the profiling session.</param>
        /// <exception cref="ArgumentException">
        ///     Thrown when elapsed time is negative or end time is before start time.
        /// </exception>
        public ProfileSnapshot(
            TimeSpan elapsedTime,
            ResourceMetrics startMetrics,
            ResourceMetrics endMetrics,
            DateTime startTime,
            DateTime endTime)
        {
            if (elapsedTime < TimeSpan.Zero)
            {
                throw new ArgumentException("Elapsed time cannot be negative.", nameof(elapsedTime));
            }

            if (endTime < startTime)
            {
                throw new ArgumentException("End time cannot be before start time.", nameof(endTime));
            }

            ElapsedTime = elapsedTime;
            StartMetrics = startMetrics;
            EndMetrics = endMetrics;
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        ///     Creates an empty <see cref="ProfileSnapshot" /> with default values.
        /// </summary>
        /// <returns>
        ///     A <see cref="ProfileSnapshot" /> with all values set to defaults.
        /// </returns>
        public static ProfileSnapshot Empty => new ProfileSnapshot(
            TimeSpan.Zero,
            ResourceMetrics.Empty,
            ResourceMetrics.Empty,
            DateTime.MinValue,
            DateTime.MinValue);

        /// <summary>
        ///     Determines whether the specified <see cref="ProfileSnapshot" /> is equal to the current instance.
        /// </summary>
        /// <param name="other">The other snapshot to compare.</param>
        /// <returns>
        ///     <c>true</c> if the specified snapshot is equal to the current instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ProfileSnapshot other)
        {
            return ElapsedTime.Equals(other.ElapsedTime) &&
                   StartMetrics.Equals(other.StartMetrics) &&
                   EndMetrics.Equals(other.EndMetrics) &&
                   StartTime.Equals(other.StartTime) &&
                   EndTime.Equals(other.EndTime);
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
            return obj is ProfileSnapshot other && Equals(other);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///     A hash code for the current <see cref="ProfileSnapshot" />.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + ElapsedTime.GetHashCode();
                hash = hash * 23 + StartMetrics.GetHashCode();
                hash = hash * 23 + EndMetrics.GetHashCode();
                hash = hash * 23 + StartTime.GetHashCode();
                hash = hash * 23 + EndTime.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        ///     Determines whether two <see cref="ProfileSnapshot" /> instances are equal.
        /// </summary>
        /// <param name="left">The first snapshot to compare.</param>
        /// <param name="right">The second snapshot to compare.</param>
        /// <returns>
        ///     <c>true</c> if the snapshots are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(ProfileSnapshot left, ProfileSnapshot right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Determines whether two <see cref="ProfileSnapshot" /> instances are not equal.
        /// </summary>
        /// <param name="left">The first snapshot to compare.</param>
        /// <param name="right">The second snapshot to compare.</param>
        /// <returns>
        ///     <c>true</c> if the snapshots are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ProfileSnapshot left, ProfileSnapshot right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Returns a string representation of the profile snapshot.
        /// </summary>
        /// <returns>
        ///     A formatted string containing all snapshot information.
        /// </returns>
        public override string ToString()
        {
            return $"ProfileSnapshot[Elapsed: {ElapsedTime.TotalMilliseconds:F2}ms, " +
                   $"CPU Delta: {CpuUsageDelta:F2}ms, " +
                   $"Memory Delta: {MemoryUsageDelta:N0} bytes, " +
                   $"GC During Session: {GarbageCollectionsDuringProfiling}, " +
                   $"Period: {StartTime:HH:mm:ss.fff} - {EndTime:HH:mm:ss.fff}]";
        }
    }
}

