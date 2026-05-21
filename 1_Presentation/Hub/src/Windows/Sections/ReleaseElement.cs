

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Json;

namespace Alis.App.Hub.Windows.Sections
{
    /// <summary>
    ///     The release element
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct ReleaseElement(
        Dictionary<object, object> element
    )
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ReleaseElement" /> class
        /// </summary>
        public ReleaseElement() : this(
            new Dictionary<object, object>()
        )
        {
        }

        /// <summary>
        ///     Gets or sets the value of the element
        /// </summary>
        [JsonNativePropertyName("_Element_")]
        public Dictionary<object, object> Element { get; set; } = element;
    }
}