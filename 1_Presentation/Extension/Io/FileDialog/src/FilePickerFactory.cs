

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Factory class for creating the appropriate file picker implementation based on the operating system.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class FilePickerFactory
    {
        /// <summary>
        ///     Creates the appropriate file picker implementation for the current operating system.
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the current platform is not supported</exception>
        /// <returns>The file picker instance</returns>
        public static IFilePicker CreateFilePicker()
        {
            Logger.Trace("Creating FilePicker for the current operating system...");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Logger.Info("Creating WindowsFilePicker.");
                return new WindowsFilePicker();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Logger.Info("Creating MacFilePicker.");
                return new MacFilePicker();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Logger.Info("Creating LinuxFilePicker.");
                return new LinuxFilePicker();
            }

            Logger.Error("Operating system is not supported.");
            throw new NotSupportedException($"File dialog is not supported on this platform: {RuntimeInformation.OSDescription}");
        }

        /// <summary>
        ///     Creates a file picker with custom options.
        /// </summary>
        /// <param name="options">The picker options</param>
        /// <returns>The configured file picker instance</returns>
        /// <exception cref="ArgumentNullException">Thrown when options is null</exception>
        /// <exception cref="NotSupportedException">Thrown when the current platform is not supported</exception>
        public static IFilePicker CreateFilePickerWithOptions(FilePickerOptions options)
        {
            Logger.Trace("Creating FilePicker with custom options...");

            if (options == null)
            {
                Logger.Warning("FilePickerOptions is null.");
                throw new ArgumentNullException(nameof(options), "Options cannot be null.");
            }

            FilePickerValidator.ValidateOptions(options);

            return CreateFilePicker();
        }

        /// <summary>
        ///     Gets the current operating system platform name.
        /// </summary>
        /// <returns>The platform name ("Windows", "macOS", "Linux", or "Unknown")</returns>
        public static string GetPlatformName()
        {
            Logger.Trace("Getting current platform name...");

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "Windows";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return "macOS";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "Linux";
            }

            return "Unknown";
        }

        /// <summary>
        ///     Checks if the current platform is supported.
        /// </summary>
        /// <returns>True if the platform is supported, false otherwise</returns>
        public static bool IsPlatformSupported()
        {
            Logger.Trace("Checking if current platform is supported...");

            bool isSupported = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                               || RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                               || RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

            Logger.Info($"Platform {GetPlatformName()} is {(isSupported ? "supported" : "not supported")}.");
            return isSupported;
        }
    }
}