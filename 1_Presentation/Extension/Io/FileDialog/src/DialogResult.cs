using System.Collections.Generic;
using NativeFileDialogSharp.Native;

namespace NativeFileDialogSharp
{
    /// <summary>
    /// The dialog result class
    /// </summary>
    public class DialogResult
    {
        /// <summary>
        /// The result
        /// </summary>
        private readonly nfdresult_t result;

        /// <summary>
        /// Gets the value of the path
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the value of the paths
        /// </summary>
        public IReadOnlyList<string> Paths { get; }

        /// <summary>
        /// Gets the value of the is error
        /// </summary>
        public bool IsError => result == nfdresult_t.NFD_ERROR;

        /// <summary>
        /// Gets the value of the error message
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Gets the value of the is cancelled
        /// </summary>
        public bool IsCancelled => result == nfdresult_t.NFD_CANCEL;

        /// <summary>
        /// Gets the value of the is ok
        /// </summary>
        public bool IsOk => result == nfdresult_t.NFD_OKAY;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogResult"/> class
        /// </summary>
        /// <param name="result">The result</param>
        /// <param name="path">The path</param>
        /// <param name="paths">The paths</param>
        /// <param name="errorMessage">The error message</param>
        internal DialogResult(nfdresult_t result, string path, IReadOnlyList<string> paths, string errorMessage)
        {
            this.result = result;
            Path = path;
            Paths = paths;
            ErrorMessage = errorMessage;
        }
    }
}