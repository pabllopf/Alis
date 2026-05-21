// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILogFilterTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Abstractions
{
    /// <summary>
    ///     Comprehensive unit tests for the ILogFilter interface contract.
    ///     Validates that implementations properly support all interface methods.
    /// </summary>
    public class ILogFilterTest
    {
        /// <summary>
        ///     Tests that i log filter implementation can be created
        /// </summary>
        [Fact]
        public void ILogFilter_ImplementationCanBeCreated()
        {
            ILogFilter filter = new LogLevelFilter(LogLevel.Info);

            Assert.NotNull(filter);
        }

        /// <summary>
        ///     Tests that i log filter has name property
        /// </summary>
        [Fact]
        public void ILogFilter_HasNameProperty()
        {
            ILogFilter filter = new LogLevelFilter(LogLevel.Info);

            Assert.NotNull(filter.Name);
            Assert.NotEmpty(filter.Name);
        }

        /// <summary>
        ///     Tests that i log filter should log method can be called
        /// </summary>
        [Fact]
        public void ILogFilter_ShouldLogMethod_CanBeCalled()
        {
            ILogFilter filter = new LogLevelFilter(LogLevel.Info);
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            bool result = filter.ShouldLog(entry);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that i log filter multiple implementations should work
        /// </summary>
        [Fact]
        public void ILogFilter_MultipleImplementations_ShouldWork()
        {
            ILogFilter filter1 = new LogLevelFilter(LogLevel.Info);
            ILogFilter filter2 = new LoggerNameFilter(new[] {"Test"});

            Assert.NotNull(filter1);
            Assert.NotNull(filter2);
            Assert.NotEqual(filter1.Name, filter2.Name);
        }

        /// <summary>
        ///     Tests that i log filter can be combined
        /// </summary>
        [Fact]
        public void ILogFilter_CanBeCombined()
        {
            ILogFilter[] filters = new[]
            {
                new LogLevelFilter(LogLevel.Info),
                (ILogFilter) new LoggerNameFilter(new[] {"Test"})
            };

            foreach (ILogFilter filter in filters)
            {
                Assert.NotNull(filter);
            }
        }
    }
}