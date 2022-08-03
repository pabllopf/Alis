// Licensed under the Apache License, Version 2.0 (the "License").
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HIDDevices.Sample
{
    /// <summary>
    ///     The sample interface
    /// </summary>
    public interface ISample
    {
        /// <summary>
        ///     Gets the value of the full name
        /// </summary>
        string FullName { get; }

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        string Description { get; }

        /// <summary>
        ///     Gets the value of the short names
        /// </summary>
        IReadOnlyCollection<string> ShortNames { get; }

        /// <summary>
        ///     Executes the token
        /// </summary>
        /// <param name="token">The token</param>
        Task ExecuteAsync(CancellationToken token = default);
    }
}