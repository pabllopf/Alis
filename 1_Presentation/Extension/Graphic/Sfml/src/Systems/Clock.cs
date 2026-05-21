

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace Alis.Extension.Graphic.Sfml.Systems
{
    /// <summary>
    ///     Utility class that measures the elapsed time
    /// </summary>
    public class Clock : ObjectBase
    {
        /// <summary>
        ///     Default Constructor
        /// </summary>
        public Clock() : base(sfClock_create())
        {
        }


        /// <summary>
        ///     Gets the time elapsed since the last call to Restart
        /// </summary>

        public SfmlTime ElapsedSfmlTime => sfClock_getElapsedTime(CPointer);


        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        public override void Destroy(bool disposing)
        {
            sfClock_destroy(CPointer);
        }


        /// <summary>
        ///     This function puts the time counter back to zero.
        /// </summary>
        /// <returns>Time elapsed since the clock was started.</returns>
        public SfmlTime Restart() => sfClock_restart(CPointer);


        /// <summary>
        ///     Sfs the clock create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity, ExcludeFromCodeCoverage]
        private static extern IntPtr sfClock_create();

        /// <summary>
        ///     Sfs the clock destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity, ExcludeFromCodeCoverage]
        private static extern void sfClock_destroy(IntPtr cPointer);

        /// <summary>
        ///     Sfs the clock get elapsed time using the specified clock
        /// </summary>
        /// <param name="clock">The clock</param>
        /// <returns>The time</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity, ExcludeFromCodeCoverage]
        private static extern SfmlTime sfClock_getElapsedTime(IntPtr clock);

        /// <summary>
        ///     Sfs the clock restart using the specified clock
        /// </summary>
        /// <param name="clock">The clock</param>
        /// <returns>The time</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity, ExcludeFromCodeCoverage]
        private static extern SfmlTime sfClock_restart(IntPtr clock);
    }
}