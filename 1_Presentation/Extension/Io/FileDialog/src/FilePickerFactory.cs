using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Dll;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    /// Factory class for creating the right file picker implementation.
    /// </summary>
    public static class FilePickerFactory
    {
        /// <summary>
        /// Creates the file picker
        /// </summary>
        /// <exception cref="NotSupportedException">This platform is not supported.</exception>
        /// <returns>The file picker</returns>
        public static IFilePicker CreateFilePicker()
        {
            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.OSX)
            {
                return new MacFilePicker();
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Windows)
            {
                return new WindowsFilePicker();
            }

            if (EmbeddedDllClass.GetCurrentPlatform() == OSPlatform.Linux)
            {
                return new LinuxFilePicker();
            }

            throw new NotSupportedException("This platform is not supported.");
        }
    }
}