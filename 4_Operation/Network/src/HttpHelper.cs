// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HttpHelper.cs
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

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Network.Exceptions;

namespace Alis.Core.Network
{
    /// <summary>
    ///     The http helper class
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        ///     The http get header regex
        /// </summary>
        private const string HttpGetHeaderRegex = @"^GET(.*)HTTP\/1\.1";
        
        /// <summary>
        ///     Calculates a random WebSocket key that can be used to initiate a WebSocket handshake
        /// </summary>
        /// <returns>A random websocket key</returns>
        public static string CalculateWebSocketKey()
        {
            // this is not used for cryptography so doing something simple like he code below is op
            RandomNumberGenerator ran = RandomNumberGenerator.Create();
            byte[] keyAsBytes = new byte[16];
            ran.GetBytes(keyAsBytes);
            return Convert.ToBase64String(keyAsBytes);
        }
        
        /// <summary>
        ///     Computes a WebSocket accept string from a given key
        /// </summary>
        /// <param name="secWebSocketKey">The web socket key to base the accept string on</param>
        /// <returns>A web socket accept string</returns>
        [Obsolete("Obsolete")]
        public static string ComputeSocketAcceptString(string secWebSocketKey)
        {
            // this is a guid as per the web socket spec
            const string webSocketGuid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
            string concatenated = secWebSocketKey + webSocketGuid;
            byte[] concatenatedAsBytes = Encoding.UTF8.GetBytes(concatenated);
            
            // note an instance of SHA1 is not threadsafe so we have to create a new one every time here
            HashAlgorithm hashProvider3 = new SHA512Managed();
            byte[] sha1Hash = hashProvider3.ComputeHash(concatenatedAsBytes);
            string secWebSocketAccept = Convert.ToBase64String(sha1Hash);
            return secWebSocketAccept;
        }
        
        /// <summary>
        ///     Reads an http header as per the HTTP spec
        /// </summary>
        /// <param name="stream">The stream to read UTF8 text from</param>
        /// <param name="token">The cancellation token</param>
        /// <returns>The HTTP header</returns>
        [ExcludeFromCodeCoverage]
        public static async Task<string> ReadHttpHeaderAsync(Stream stream, CancellationToken token)
        {
            int length = 1024 * 16; // 16KB buffer more than enough for http header
            byte[] buffer = new byte[length];
            int offset = 0;
            int bytesRead = 0;
            
            do
            {
                if (offset >= length)
                {
                    throw new EntityTooLargeException("Http header message too large to fit in buffer (16KB)");
                }
                
                bytesRead = await stream.ReadAsync(buffer, offset, length - offset, token);
                offset += bytesRead;
                string header = Encoding.UTF8.GetString(buffer, 0, offset);
                
                // as per http specification, all headers should end this this
                if (header.Contains("\r\n\r\n"))
                {
                    return header;
                }
            } while (bytesRead > 0);
            
            return string.Empty;
        }
        
        /// <summary>
        ///     Decodes the header to detect is this is a web socket upgrade response
        /// </summary>
        /// <param name="header">The HTTP header</param>
        /// <returns>True if this is an http WebSocket upgrade response</returns>
        [ExcludeFromCodeCoverage]
        public static bool IsWebSocketUpgradeRequest(string header)
        {
            Regex getRegex = new Regex(HttpGetHeaderRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            Match getRegexMatch = getRegex.Match(header);
            
            if (getRegexMatch.Success)
            {
                // check if this is a web socket upgrade request
                Regex webSocketUpgradeRegex = new Regex("Upgrade: websocket", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
                Match webSocketUpgradeRegexMatch = webSocketUpgradeRegex.Match(header);
                return webSocketUpgradeRegexMatch.Success;
            }
            
            return false;
        }
        
        /// <summary>
        ///     Gets the path from the HTTP header
        /// </summary>
        /// <param name="httpHeader">The HTTP header to read</param>
        /// <returns>The path</returns>
        [ExcludeFromCodeCoverage]
        public static string GetPathFromHeader(string httpHeader)
        {
            Regex getRegex = new Regex(HttpGetHeaderRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            Match getRegexMatch = getRegex.Match(httpHeader);
            
            return getRegexMatch.Success ?
                // extract the path attribute from the first line of the header
                getRegexMatch.Groups[1].Value.Trim() : null;
        }
        
        /// <summary>
        ///     Gets the sub protocols using the specified http header
        /// </summary>
        /// <param name="httpHeader">The http header</param>
        /// <exception cref="EntityTooLargeException">Sec-WebSocket-Protocol exceeded the maximum of length of {MAX_LEN}</exception>
        /// <returns>A list of string</returns>
        public static IList<string> GetSubProtocols(string httpHeader)
        {
            Regex regex = new Regex(@"Sec-WebSocket-Protocol:(?<protocols>.+)", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            Match match = regex.Match(httpHeader);
            
            if (match.Success)
            {
                const int maxLen = 2048;
                if (match.Length > maxLen)
                {
                    throw new EntityTooLargeException(
                        $"Sec-WebSocket-Protocol exceeded the maximum of length of {maxLen}");
                }
                
                // extract a csv list of sub protocols (in order of highest preference first)
                string csv = match.Groups["protocols"].Value.Trim();
                return csv.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();
            }
            
            return new List<string>();
        }
        
        /// <summary>
        ///     Reads the HTTP response code from the http response string
        /// </summary>
        /// <param name="response">The response string</param>
        /// <returns>the response code</returns>
        public static string ReadHttpResponseCode(string response)
        {
            Regex getRegex = new Regex(@"HTTP\/1\.1 (.*)", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(100));
            Match getRegexMatch = getRegex.Match(response);
            
            if (getRegexMatch.Success)
            {
                // extract the path attribute from the first line of the header
                return getRegexMatch.Groups[1].Value.Trim();
            }
            
            return null;
        }
        
        /// <summary>
        ///     Writes an HTTP response string to the stream
        /// </summary>
        /// <param name="response">The response (without the new line characters)</param>
        /// <param name="stream">The stream to write to</param>
        /// <param name="token">The cancellation token</param>
        public static async Task WriteHttpHeaderAsync(string response, Stream stream, CancellationToken token)
        {
            response = response.Trim() + "\r\n\r\n";
            byte[] bytes = Encoding.UTF8.GetBytes(response);
            await stream.WriteAsync(bytes, 0, bytes.Length, token);
        }
    }
}