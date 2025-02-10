using Alis.Core.Graphic.GlfwLib.Enums;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    /// Base exception class for GLFW related errors.
    /// </summary>
    public class Exception : System.Exception
    {
        #region Methods

        /// <summary>
        ///     Generic error messages if only an error code is supplied as an argument to the constructor.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <returns>Error message.</returns>
        public static string GetErrorMessage(ErrorCode code)
        {
            switch (code)
            {
                case ErrorCode.NotInitialized:     return "GLFW has not been initialized.";
                case ErrorCode.NoCurrentContext:   return "No context is current for this thread.";
                case ErrorCode.InvalidEnum:        return "One of the arguments to the function was an invalid enum value.";
                case ErrorCode.InvalidValue:       return "One of the arguments to the function was an invalid value.";
                case ErrorCode.OutOfMemory:        return "A memory allocation failed.";
                case ErrorCode.ApiUnavailable:     return "GLFW could not find support for the requested API on the system.";
                case ErrorCode.VersionUnavailable: return "The requested OpenGL or OpenGL ES version is not available.";
                case ErrorCode.PlatformError:      return "A platform-specific error occurred that does not match any of the more specific categories.";
                case ErrorCode.FormatUnavailable:  return "The requested format is not supported or available.";
                case ErrorCode.NoWindowContext:    return "The specified window does not have an OpenGL or OpenGL ES context.";
                default:                           return "Unknown error code.";
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Exception" /> class.
        /// </summary>
        /// <param name="error">The error code to create a generic message from.</param>
        public Exception(ErrorCode error) : base(GetErrorMessage(error)) { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Exception" /> class.
        /// </summary>
        /// <param name="message">The error message.</param>
        public Exception(string message) : base(message) { }

        #endregion
    }
}