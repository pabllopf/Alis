﻿using Alis.Core.Ecs.Updating.Runners;

namespace Alis.Core.Ecs
{
    /// <summary>
    /// Config information for a <see cref="World"/>.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// Whether or not to multithread.
        /// </summary>
        public bool MultiThreadedUpdate { get; init; }

        /// <summary>
        /// When <see langword="true"/>, entities created during <see cref="World.Update()"/>, <see cref="Update{TComp}"/>, and <see cref="World.Update{T}()"/> will also be updated during the same update.
        /// </summary>
        public bool UpdateDeferredCreationEntities { get; set; } = false;

        /// <summary>
        /// The default multithreaded config.
        /// </summary>
        public static Config Multithreaded { get; } = new Config() { MultiThreadedUpdate = true };
        /// <summary>
        /// The default singlethreaded config.
        /// </summary>
        public static Config Singlethreaded { get; } = new Config() { MultiThreadedUpdate = false };
    }
}
