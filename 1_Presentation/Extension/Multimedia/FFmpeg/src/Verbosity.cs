namespace Alis.Extension.Multimedia.FFmpeg
{
    /// <summary>
    ///     The verbosity enum
    /// </summary>
    public enum Verbosity
    {
        /// <summary>
        ///     Show nothing at all; be silent.
        /// </summary>
        Quiet = 0,

        /// <summary>
        ///     Show informative messages during processing. This is in addition to warnings and errors. This is the default value.
        /// </summary>
        Info = 1,

        /// <summary>
        ///     Same as info, except more verbose.
        /// </summary>
        Verbose = 2,

        /// <summary>
        ///     Show everything, including debugging information.
        /// </summary>
        Debug = 3,

        /// <summary>
        ///     Show all warnings and errors. Any message related to possibly incorrect or unexpected events will be shown.
        /// </summary>
        Warning = 4,

        /// <summary>
        ///     Show all errors, including ones which can be recovered from.
        /// </summary>
        Error = 5,

        /// <summary>
        ///     Only show fatal errors. These are errors after which the process absolutely cannot continue.
        /// </summary>
        Fatal = 6
    }
}