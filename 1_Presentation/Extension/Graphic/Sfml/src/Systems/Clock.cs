using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Alis.Extension.Graphic.Sfml.Systems
{
    
    /// <summary>
    /// Utility class that measures the elapsed time
    /// </summary>
    
    public class Clock : ObjectBase
    {
        
        /// <summary>
        /// Default Constructor
        /// </summary>
        
        public Clock() : base(sfClock_create()) { }

        
        /// <summary>
        /// Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        
        public override void Destroy(bool disposing)
        {
            sfClock_destroy(CPointer);
        }

        
        /// <summary>
        /// Gets the time elapsed since the last call to Restart
        /// </summary>
        
        public Time ElapsedTime => sfClock_getElapsedTime(CPointer);

        
        /// <summary>
        /// This function puts the time counter back to zero.
        /// </summary>
        /// <returns>Time elapsed since the clock was started.</returns>
        
        public Time Restart() => sfClock_restart(CPointer);

        #region Imports
        /// <summary>
        /// Sfs the clock create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfClock_create();

        /// <summary>
        /// Sfs the clock destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfClock_destroy(IntPtr cPointer);

        /// <summary>
        /// Sfs the clock get elapsed time using the specified clock
        /// </summary>
        /// <param name="clock">The clock</param>
        /// <returns>The time</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Time sfClock_getElapsedTime(IntPtr clock);

        /// <summary>
        /// Sfs the clock restart using the specified clock
        /// </summary>
        /// <param name="clock">The clock</param>
        /// <returns>The time</returns>
        [DllImport(Csfml.System, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Time sfClock_restart(IntPtr clock);
        #endregion
    }
}
