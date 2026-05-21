

using System;

namespace Alis.Extension.Thread.Core
{
    /// <summary>
    ///     Represents a unit of work that can be executed in parallel
    /// </summary>
    internal sealed class WorkItem
    {
        /// <summary>
        ///     Gets or sets the action to execute
        /// </summary>
        public Action<int, int> Action { get; set; }

        /// <summary>
        ///     Gets or sets the start index for this work item
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        ///     Gets or sets the length of elements to process
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        ///     Resets the work item for reuse
        /// </summary>
        public void Reset()
        {
            Action = null;
            StartIndex = 0;
            Length = 0;
        }
    }
}