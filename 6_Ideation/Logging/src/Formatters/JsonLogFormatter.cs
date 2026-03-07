// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JsonLogFormatter.cs
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

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Formatters
{
    /// <summary>
    ///     Formats log entries as JSON objects for structured logging and analysis.
    ///     Suitable for cloud logging systems and centralized log aggregation.
    ///     AOT-compatible: Uses StringBuilder, no reflection-based JSON serialization.
    /// </summary>
    public sealed class JsonLogFormatter : ILogFormatter
    {
        
        /// <summary>
        /// Gets the value of the name
        /// </summary>
        public string Name => "JsonFormatter";

        
        /// <summary>
        /// Formats the entry
        /// </summary>
        /// <param name="entry">The entry</param>
        /// <returns>The string</returns>
        public string Format(ILogEntry entry)
        {
            StringBuilder sb = new StringBuilder(512);

            sb.Append("{\"timestamp\":\"");
            sb.Append(entry.Timestamp);
            sb.Append("\",\"level\":\"");
            sb.Append(entry.Level);
            sb.Append("\",\"logger\":\"");
            EscapeJsonString(sb, entry.LoggerName);
            sb.Append("\",\"message\":\"");
            EscapeJsonString(sb, entry.Message);
            sb.Append("\",\"threadId\":");
            sb.Append(entry.ThreadId);

            if (!string.IsNullOrEmpty(entry.CorrelationId))
            {
                sb.Append(",\"correlationId\":\"");
                EscapeJsonString(sb, entry.CorrelationId);
                sb.Append('\"');
            }

            if (entry.Scopes.Count > 0)
            {
                sb.Append(",\"scopes\":[");
                for (int i = 0; i < entry.Scopes.Count; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(',');
                    }

                    sb.Append('"');
                    EscapeJsonString(sb, entry.Scopes[i].ToString());
                    sb.Append('"');
                }

                sb.Append(']');
            }

            if (entry.Properties.Count > 0)
            {
                sb.Append(",\"properties\":{");
                int propIndex = 0;
                foreach (KeyValuePair<string, object> prop in entry.Properties)
                {
                    if (propIndex > 0)
                    {
                        sb.Append(',');
                    }

                    sb.Append('"');
                    EscapeJsonString(sb, prop.Key);
                    sb.Append("\":\"");
                    EscapeJsonString(sb, prop.Value?.ToString() ?? "null");
                    sb.Append('"');
                    propIndex++;
                }

                sb.Append('}');
            }

            if (entry.Exception != null)
            {
                sb.Append(",\"exception\":{\"type\":\"");
                EscapeJsonString(sb, entry.Exception.GetType().Name);
                sb.Append("\",\"message\":\"");
                EscapeJsonString(sb, entry.Exception.Message);
                sb.Append("\",\"stackTrace\":\"");
                EscapeJsonString(sb, entry.Exception.StackTrace);
                sb.Append("\"}");
            }

            sb.Append('}');

            return sb.ToString();
        }

        /// <summary>
        ///     Escapes special characters for JSON string values.
        /// </summary>
        [ExcludeFromCodeCoverage]
        private static void EscapeJsonString(StringBuilder sb, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            foreach (char c in value)
            {
                switch (c)
                {
                    case '"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        if (c < 32)
                        {
                            sb.Append("\\u");
                            sb.Append(((int) c).ToString("X4"));
                        }
                        else
                        {
                            sb.Append(c);
                        }

                        break;
                }
            }
        }
    }
}