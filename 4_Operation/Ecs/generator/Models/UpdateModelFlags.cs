using System;

namespace Alis.Core.Ecs.Generator.Models
{
    /// <summary>
    /// The update model flags enum
    /// </summary>
    [Flags]
    public enum UpdateModelFlags
    {
        /// <summary>
        /// The none update model flags
        /// </summary>
        None = 0,
        /// <summary>
        /// The is update model flags
        /// </summary>
        IsClass = 1 << 0,
        /// <summary>
        /// The is struct update model flags
        /// </summary>
        IsStruct = 1 << 1,
        /// <summary>
        /// The is generic update model flags
        /// </summary>
        IsGeneric = 1 << 2,
        /// <summary>
        /// The initable update model flags
        /// </summary>
        Initable = 1 << 3,
        /// <summary>
        /// The destroyable update model flags
        /// </summary>
        Destroyable = 1 << 4,
        /// <summary>
        /// The is record update model flags
        /// </summary>
        IsRecord = 1 << 5,
        /// <summary>
        /// The is self init update model flags
        /// </summary>
        IsSelfInit = 1 << 6,
    }
}