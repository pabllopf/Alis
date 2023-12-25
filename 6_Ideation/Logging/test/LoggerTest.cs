// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: LoggerTest.cs
// 
//  Author: Pablo Perdomo Falcón
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

using System;
using System.IO;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     The logger test class
    /// </summary>
    public class LoggerTest
    {
        /// <summary>
        ///     Tests that trace should print trace message
        /// </summary>
        [Fact]
        public void Trace_ShouldPrintTraceMessage()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Trace;
            Logger.Trace("Test Trace Message");

            string output = consoleOutput.ToString();
            Assert.Contains("Trace: Test Trace Message", output);
        }

        /// <summary>
        ///     Tests that set log level should change log level
        /// </summary>
        [Fact]
        public void SetLogLevel_ShouldChangeLogLevel()
        {
            Logger.LogLevel = LogLevel.Info;
            Assert.Equal(LogLevel.Info, Logger.LogLevel);

            Logger.LogLevel = LogLevel.Warning;
            Assert.Equal(LogLevel.Warning, Logger.LogLevel);
        }

        /// <summary>
        ///     Tests that set detail level should change detail level
        /// </summary>
        [Fact]
        public void SetDetailLevel_ShouldChangeDetailLevel()
        {
            Logger.DetailLevel = DetailLevel.Full;
            Assert.Equal(DetailLevel.Full, Logger.DetailLevel);

            Logger.DetailLevel = DetailLevel.Minimal;
            Assert.Equal(DetailLevel.Minimal, Logger.DetailLevel);
        }

        /// <summary>
        ///     Tests that set log level should print log message when log level is set to log
        /// </summary>
        [Fact]
        public void SetLogLevel_ShouldPrintLogMessage_WhenLogLevelIsSetToLog()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Log;
            Logger.Log("Test Log Message");

            string output = consoleOutput.ToString();
            Assert.Contains("Log: Test Log Message", output);
        }

        /// <summary>
        ///     Tests that exception should print exception message when log level is critical
        /// </summary>
        [Fact]
        public void Exception_ShouldPrintExceptionMessage_WhenLogLevelIsCritical()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Critical;
            Exception exception = new Exception("Test Exception Message");
            Logger.Exception(exception);

            string output = consoleOutput.ToString();
            Assert.Contains($"Exception: {exception.Message}", output);
        }


        /// <summary>
        ///     Tests that trace with log level trace should print trace message
        /// </summary>
        [Fact]
        public void Trace_WithLogLevelTrace_ShouldPrintTraceMessage()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Trace;
            Logger.Trace("Test Trace Message");

            string output = consoleOutput.ToString();
            Assert.Contains("Trace: Test Trace Message", output);
        }

        /// <summary>
        ///     Tests that trace with log level info should not print trace message
        /// </summary>
        [Fact]
        public void Trace_WithLogLevelInfo_ShouldNotPrintTraceMessage()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Info;
            Logger.Trace("Test Trace Message");

            string output = consoleOutput.ToString();
            Assert.DoesNotContain("Trace: Test Trace Message", output);
        }

        /// <summary>
        ///     Tests that info with log level info should print info message
        /// </summary>
        [Fact]
        public void Info_WithLogLevelInfo_ShouldPrintInfoMessage()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Info;
            Logger.Info("Test Info Message");

            string output = consoleOutput.ToString();
            Assert.Contains("Info: Test Info Message", output);
        }

        /// <summary>
        ///     Tests that info with log level event should not print info message
        /// </summary>
        [Fact]
        public void Info_WithLogLevelEvent_ShouldNotPrintInfoMessage()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Event;
            Logger.Info("Test Info Message");

            string output = consoleOutput.ToString();
            Assert.DoesNotContain("Info: Test Info Message", output);
        }

        /// <summary>
        ///     Tests that warning should print warning message
        /// </summary>
        [Fact]
        public void Warning_ShouldPrintWarningMessage()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.Warning("Test Warning Message");

            string output = consoleOutput.ToString();
            Assert.Contains("Warning: Test Warning Message", output);
        }

        /// <summary>
        ///     Tests that error should print error message
        /// </summary>
        [Fact]
        public void Error_ShouldPrintErrorMessage()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.Error("Test Error Message");

            string output = consoleOutput.ToString();
            Assert.Contains("Error: Test Error Message", output);
        }

        /// <summary>
        ///     Tests that exception with exception should print exception message
        /// </summary>
        [Fact]
        public void Exception_WithException_ShouldPrintExceptionMessage()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.Exception(new Exception("Test Exception Message"));

            string output = consoleOutput.ToString();
            Assert.Contains("Exception: Test Exception Message", output);
        }

        /// <summary>
        ///     Tests that set detail level should change detail level when calling different methods
        /// </summary>
        [Fact]
        public void SetDetailLevel_ShouldChangeDetailLevel_WhenCallingDifferentMethods()
        {
            Logger.SetDetailLevel(DetailLevel.Minimal);
            Assert.Equal(DetailLevel.Minimal, Logger.DetailLevel);

            Logger.SetDetailLevel(DetailLevel.Full);
            Assert.Equal(DetailLevel.Full, Logger.DetailLevel);
        }

        /// <summary>
        ///     Tests that exception should not print exception message when log level is info
        /// </summary>
        [Fact]
        public void Exception_ShouldNotPrintExceptionMessage_WhenLogLevelIsInfo()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Info;
            Logger.Exception("Test Exception Message Exception_ShouldNotPrintExceptionMessage_WhenLogLevelIsInfo");

            string output = consoleOutput.ToString();
            Assert.Contains("Exception: Test Exception Message Exception_ShouldNotPrintExceptionMessage_WhenLogLevelIsInfo", output);
        }

        /// <summary>
        ///     Tests that exception should not print exception message when log level is trace
        /// </summary>
        [Fact]
        public void Exception_ShouldNotPrintExceptionMessage_WhenLogLevelIsTrace()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Trace;
            Logger.Exception("Test Exception Message Exception_ShouldNotPrintExceptionMessage_WhenLogLevelIsTrace");

            string output = consoleOutput.ToString();
            Assert.Contains("Exception: Test Exception Message Exception_ShouldNotPrintExceptionMessage_WhenLogLevelIsTrace", output);
        }

        /// <summary>
        ///     Tests that trace should print trace message when log level is trace
        /// </summary>
        [Fact]
        public void Trace_ShouldPrintTraceMessage_WhenLogLevelIsTrace()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Trace;
            Logger.Trace();

            string output = consoleOutput.ToString();
            Assert.Contains("Trace:", output);
        }

        /// <summary>
        ///     Tests that trace should not print trace message when log level is info
        /// </summary>
        [Fact]
        public void Trace_ShouldNotPrintTraceMessage_WhenLogLevelIsInfo()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Info;
            Logger.Trace();

            string output = consoleOutput.ToString();
            Assert.DoesNotContain("Trace:", output);
        }

        /// <summary>
        ///     Tests that trace should not print trace message when log level is event
        /// </summary>
        [Fact]
        public void Trace_ShouldNotPrintTraceMessage_WhenLogLevelIsEvent()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Event;
            Logger.Trace();

            string output = consoleOutput.ToString();
            Assert.DoesNotContain("Trace:", output);
        }

        /// <summary>
        ///     Tests that info should print info message when log level is info
        /// </summary>
        [Fact]
        public void Info_ShouldPrintInfoMessage_WhenLogLevelIsInfo()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Info;
            Logger.Info();

            string output = consoleOutput.ToString();
            Assert.Contains("Info: Info method called with no message.", output);
        }

        /// <summary>
        ///     Tests that info should not print info message when log level is event
        /// </summary>
        [Fact]
        public void Info_ShouldNotPrintInfoMessage_WhenLogLevelIsEvent()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Event;
            Logger.Info();

            string output = consoleOutput.ToString();
            Assert.DoesNotContain("Info: Info method called with no message of Info_ShouldNotPrintInfoMessage_WhenLogLevelIsEvent", output);
        }

        /// <summary>
        ///     Tests that info should not print info message when log level is trace
        /// </summary>
        [Fact]
        public void Info_ShouldNotPrintInfoMessage_WhenLogLevelIsTrace()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Trace;
            Logger.Info();

            string output = consoleOutput.ToString();
            Assert.DoesNotContain("Info: Info method called with no message of Info_ShouldNotPrintInfoMessage_WhenLogLevelIsTrace", output);
        }

        /// <summary>
        ///     Tests that event should print event message when log level is event
        /// </summary>
        [Fact]
        public void Event_ShouldPrintEventMessage_WhenLogLevelIsEvent()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Event;
            Logger.Event("Test Event Message");

            string output = consoleOutput.ToString();
            Assert.Contains("Event: Test Event Message", output);
        }

        /// <summary>
        ///     Tests that event should not print event message when log level is info
        /// </summary>
        [Fact]
        public void Event_ShouldNotPrintEventMessage_WhenLogLevelIsInfo()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Info;
            Logger.Event("Test Event Message");

            string output = consoleOutput.ToString();
            Assert.Contains("Event: Test Event Message", output);
        }

        /// <summary>
        ///     Tests that event should not print event message when log level is trace
        /// </summary>
        [Fact]
        public void Event_ShouldNotPrintEventMessage_WhenLogLevelIsTrace()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Trace;
            Logger.Event("Test Event Message");

            string output = consoleOutput.ToString();
            Assert.Contains("Event: Test Event Message", output);
        }


        /// <summary>
        ///     Tests that event no message should print event message when log level is event
        /// </summary>
        [Fact]
        public void Event_NoMessage_ShouldPrintEventMessage_WhenLogLevelIsEvent()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Event;
            Logger.Event();

            string output = consoleOutput.ToString();
            Assert.Contains("Event: Event method called with no message.", output);
        }

        /// <summary>
        ///     Tests that event no message should not print event message when log level is info
        /// </summary>
        [Fact]
        public void Event_NoMessage_ShouldNotPrintEventMessage_WhenLogLevelIsInfo()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Info;
            Logger.Event();

            string output = consoleOutput.ToString();
            Assert.Contains("Event: Event method called with no message.", output);
        }

        /// <summary>
        ///     Tests that event no message should not print event message when log level is trace
        /// </summary>
        [Fact]
        public void Event_NoMessage_ShouldNotPrintEventMessage_WhenLogLevelIsTrace()
        {
            using StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            Logger.LogLevel = LogLevel.Trace;
            Logger.Event();

            string output = consoleOutput.ToString();
            Assert.Contains("Event: Event method called with no message.", output);
        }
    }
}