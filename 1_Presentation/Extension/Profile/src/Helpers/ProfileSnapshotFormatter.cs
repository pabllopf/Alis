// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProfileSnapshotFormatter.cs
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
using System.Text;
using Alis.Extension.Profile.Models;

namespace Alis.Extension.Profile.Helpers
{
    /// <summary>
    ///     Provides formatting utilities for converting <see cref="ProfileSnapshot" /> data
    ///     into human-readable strings with various output formats. This class follows
    ///     the Single Responsibility Principle by handling only formatting concerns.
    /// </summary>
    public static class ProfileSnapshotFormatter
    {
        /// <summary>
        ///     Formats a profile snapshot as a detailed multi-line string with all metrics.
        /// </summary>
        /// <param name="snapshot">The snapshot to format.</param>
        /// <returns>
        ///     A formatted string containing all snapshot information.
        /// </returns>
        public static string FormatDetailed(ProfileSnapshot snapshot)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("=== Profile Snapshot ===");
            builder.AppendLine($"Session Period: {snapshot.StartTime:yyyy-MM-dd HH:mm:ss.fff} - {snapshot.EndTime:yyyy-MM-dd HH:mm:ss.fff}");
            builder.AppendLine($"Total Elapsed Time: {snapshot.ElapsedTime.TotalMilliseconds:F2} ms");
            builder.AppendLine();
            builder.AppendLine("--- Resource Deltas ---");
            builder.AppendLine($"CPU Usage Change: {snapshot.CpuUsageDelta:F2} ms");
            builder.AppendLine($"Memory Usage Change: {FormatBytes(snapshot.MemoryUsageDelta)}");
            builder.AppendLine($"Garbage Collections: {snapshot.GarbageCollectionsDuringProfiling}");
            builder.AppendLine();
            builder.AppendLine("--- Start Metrics ---");
            builder.AppendLine(FormatResourceMetrics(snapshot.StartMetrics));
            builder.AppendLine();
            builder.AppendLine("--- End Metrics ---");
            builder.AppendLine(FormatResourceMetrics(snapshot.EndMetrics));
            builder.AppendLine("========================");

            return builder.ToString();
        }

        /// <summary>
        ///     Formats a profile snapshot as a compact single-line summary.
        /// </summary>
        /// <param name="snapshot">The snapshot to format.</param>
        /// <returns>
        ///     A compact string summarizing the snapshot.
        /// </returns>
        public static string FormatCompact(ProfileSnapshot snapshot)
        {
            return $"[{snapshot.ElapsedTime.TotalMilliseconds:F2}ms | " +
                   $"CPU: {snapshot.CpuUsageDelta:F2}ms | " +
                   $"Mem: {FormatBytes(snapshot.MemoryUsageDelta)} | " +
                   $"GC: {snapshot.GarbageCollectionsDuringProfiling}]";
        }

        /// <summary>
        ///     Formats resource metrics into a readable string.
        /// </summary>
        /// <param name="metrics">The metrics to format.</param>
        /// <returns>
        ///     A formatted string containing the metrics information.
        /// </returns>
        private static string FormatResourceMetrics(ResourceMetrics metrics)
        {
            return $"CPU: {metrics.CpuUsageMilliseconds:F2} ms | " +
                   $"Memory: {FormatBytes(metrics.MemoryUsageBytes)} | " +
                   $"GC Count: {metrics.GarbageCollectionCount} | " +
                   $"Threads: {metrics.ThreadCount}";
        }

        /// <summary>
        ///     Formats a byte count into a human-readable string with appropriate units.
        /// </summary>
        /// <param name="bytes">The number of bytes to format.</param>
        /// <returns>
        ///     A formatted string with appropriate unit suffix (B, KB, MB, GB).
        /// </returns>
        public static string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = Math.Abs(bytes);
            int order = 0;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }

            string sign = bytes < 0 ? "-" : "";
            return $"{sign}{len:F2} {sizes[order]}";
        }
    }
}

