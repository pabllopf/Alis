// 

using System;
using System.Diagnostics.CodeAnalysis;

namespace Alis.Core.Systems.Audio.Core.Native
{
    /// <summary>
    ///     Defines the slot index for a wrapper function.
    ///     This type supports OpenTK and should not be
    ///     used in user code.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class SlotAttribute : Attribute
    {
        /// <summary>
        ///     Defines the slot index for a wrapper function.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private",
            Justification =
                "This field is used in legacy internal rewriting logic. We don't want to change visibility just yet.")]
        internal int Slot;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SlotAttribute" /> class.
        /// </summary>
        /// <param name="index">The slot index for a wrapper function.</param>
        public SlotAttribute(int index) => Slot = index;
    }
}