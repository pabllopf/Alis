using System.Collections.Generic;
using Alis.Extension.Io.FileDialog.Native;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    /// The dialog result class
    /// </summary>
    public class DialogResult
    {
        /// <summary>
        /// The result
        /// </summary>
        private readonly NfdresultT result;

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
        public bool IsError => result == NfdresultT.NfdError;

        /// <summary>
        /// Gets the value of the error message
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Gets the value of the is cancelled
        /// </summary>
        public bool IsCancelled => result == NfdresultT.NfdCancel;

        /// <summary>
        /// Gets the value of the is ok
        /// </summary>
        public bool IsOk => result == NfdresultT.NfdOkay;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogResult"/> class
        /// </summary>
        /// <param name="result">The result</param>
        /// <param name="path">The path</param>
        /// <param name="paths">The paths</param>
        /// <param name="errorMessage">The error message</param>
        internal DialogResult(NfdresultT result, string path, IReadOnlyList<string> paths, string errorMessage)
        {
            this.result = result;
            Path = path;
            Paths = paths;
            ErrorMessage = errorMessage;
        }
    }
}