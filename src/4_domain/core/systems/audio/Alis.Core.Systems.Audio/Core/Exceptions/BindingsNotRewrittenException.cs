// 

using System;

namespace Alis.Core.Systems.Audio.Core.Exceptions
{
    /// <summary>
    ///     Represents exceptions thrown when a binding method is called and the bindings have not been rewritten by
    ///     Rewrite.exe.
    /// </summary>
    public class BindingsNotRewrittenException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BindingsNotRewrittenException" /> class.
        /// </summary>
        public BindingsNotRewrittenException()
            : base("Rewrite.exe has not been run.")
        {
        }
    }
}