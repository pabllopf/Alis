// Licensed under the Apache License, Version 2.0 (the "License").
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HIDDevices.Sample
{
    /// <summary>
    ///     The sample class
    /// </summary>
    /// <seealso cref="ISample" />
    public abstract class Sample : ISample
    {
        /// <summary>
        ///     The logger
        /// </summary>
        private readonly SimpleConsoleLogger<Sample> _logger;

        /// <summary>
        ///     The short names
        /// </summary>
        private readonly HashSet<string> _shortNames;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Sample" /> class
        /// </summary>
        /// <param name="fullName">The full name</param>
        /// <param name="shortNames">The short names</param>
        protected Sample(string fullName = null, params string[] shortNames)
        {
            FullName = fullName ?? GetFullName(GetType().Name);

            _shortNames = shortNames.Length > 0 ? new HashSet<string>(shortNames) : GetShortNames(FullName);
            _logger = new SimpleConsoleLogger<Sample>(LogLevel.Information, GetType().Name);
        }

        /// <summary>
        ///     Gets the value of the logger
        /// </summary>
        protected ILogger Logger => _logger;

        /// <summary>
        ///     Gets or sets the value of the log level
        /// </summary>
        public LogLevel LogLevel
        {
            get => _logger.LogLevel;
            set => _logger.LogLevel = value;
        }

        /// <inheritdoc />
        public string FullName { get; }

        /// <inheritdoc />
        public IReadOnlyCollection<string> ShortNames => _shortNames;

        /// <inheritdoc />
        public virtual Task ExecuteAsync(CancellationToken token = default)
        {
            return Task.Run(Execute, token);
        }

        /// <inheritdoc />
        public abstract string Description { get; }

        /// <summary>
        ///     Execute the example synchronously.
        /// </summary>
        protected virtual void Execute()
        {
        }

        /// <summary>
        ///     Creates the logger using the specified log level
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="logLevel">The log level</param>
        /// <returns>A logger of t</returns>
        public static ILogger<T> CreateLogger<T>(LogLevel logLevel = LogLevel.Information)
        {
            return new SimpleConsoleLogger<T>(logLevel);
        }

        /// <summary>
        ///     Gets a friendly full name
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        protected static string GetFullName(string typeName)
        {
            var builder = new StringBuilder(typeName.Length + 5);
            var first = true;
            foreach (var c in typeName)
            {
                if (first)
                {
                    first = false;
                }
                else if (char.IsUpper(c))
                {
                    builder.Append(' ');
                }

                builder.Append(c);
            }

            var fullName = builder.ToString();
            if (fullName.EndsWith("Sample", StringComparison.InvariantCultureIgnoreCase))
            {
                fullName = fullName[..^6].TrimEnd();
            }

            return fullName;
        }

        /// <summary>
        ///     Gets some short names based on the first word and initials.
        /// </summary>
        /// <param name="fullName">The full name of the sample.</param>
        /// <returns>An array of short names.</returns>
        protected static HashSet<string> GetShortNames(string fullName)
        {
            var shortNames = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
            var initials = new StringBuilder();
            var word = new StringBuilder();
            var titleCase = new StringBuilder();
            var afterSpace = true;
            var firstWord = true;
            foreach (var c in fullName)
            {
                if (char.GetUnicodeCategory(c) == UnicodeCategory.SpaceSeparator)
                {
                    afterSpace = true;
                    firstWord = false;
                    continue;
                }

                if (afterSpace)
                {
                    afterSpace = false;
                    var ch = char.ToUpperInvariant(c);
                    initials.Append(ch);
                    titleCase.Append(ch);
                }
                else
                {
                    titleCase.Append(c);
                }

                if (firstWord)
                {
                    word.Append(c);
                }
            }

            shortNames.Add(initials.ToString(0, 1));
            if (initials.Length > 1)
            {
                shortNames.Add(initials.ToString());
            }

            shortNames.Add(word.ToString());

            if (titleCase.Length < 10)
            {
                shortNames.Add(titleCase.ToString());
            }

            return shortNames;
        }
    }
}