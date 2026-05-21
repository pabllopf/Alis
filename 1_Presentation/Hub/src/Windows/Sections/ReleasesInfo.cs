

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Json;

namespace Alis.App.Hub.Windows.Sections
{
    /// <summary>
    ///     The releases info
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct ReleasesInfo(
        List<ReleaseElement> releases
    )
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ReleasesInfo" /> class
        /// </summary>
        public ReleasesInfo() : this(
            new List<ReleaseElement>()
        )
        {
        }

        /// <summary>
        ///     Gets or sets the value of the releases
        /// </summary>
        [JsonNativePropertyName("_Releases_")]
        public List<ReleaseElement> Releases { get; set; } = releases;
    }
}