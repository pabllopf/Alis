using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    /// The ecs sample interface
    /// </summary>
    internal interface IEcsSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Runs this instance
        /// </summary>
        void Run();
    }
}

