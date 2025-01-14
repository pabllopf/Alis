// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:XMLFragmentParser.cs
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
using System.IO;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     The xml fragment parser class
    /// </summary>
    internal class XmlFragmentParser
    {
        /// <summary>
        ///     The list
        /// </summary>
        private static readonly List<char> Punctuation = new List<char> {'/', '<', '>', '='};

        /// <summary>
        ///     The buffer
        /// </summary>
        private FileBuffer _buffer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="XmlFragmentParser" /> class
        /// </summary>
        /// <param name="stream">The stream</param>
        public XmlFragmentParser(Stream stream)
        {
            Load(stream);
        }

        /// <summary>
        ///     Gets or sets the value of the root node
        /// </summary>
        public XmlFragmentElement RootNode { get; private set; }

        /// <summary>
        ///     Loads the stream
        /// </summary>
        /// <param name="stream">The stream</param>
        public void Load(Stream stream)
        {
            _buffer = new FileBuffer(stream);
        }

        /// <summary>
        ///     Loads the from stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The xml fragment element</returns>
        public static XmlFragmentElement LoadFromStream(Stream stream)
        {
            XmlFragmentParser x = new XmlFragmentParser(stream);
            x.Parse();
            return x.RootNode;
        }

        /// <summary>
        ///     Nexts the token
        /// </summary>
        /// <returns>The str</returns>
        private string NextToken()
        {
            string str = "";
            bool done = false;

            while (true)
            {
                char c = _buffer.Next;

                if (Punctuation.Contains(c))
                {
                    if (str != "")
                    {
                        _buffer.Position--;
                        break;
                    }

                    done = true;
                }
                else if (char.IsWhiteSpace(c))
                {
                    if (str != "")
                    {
                        break;
                    }

                    continue;
                }

                str += c;

                if (done)
                {
                    break;
                }
            }

            str = TrimControl(str);

            // Trim quotes from start and end
            if (str[0] == '\"')
            {
                str = str.Remove(0, 1);
            }

            if (str[str.Length - 1] == '\"')
            {
                str = str.Remove(str.Length - 1, 1);
            }

            return str;
        }

        /// <summary>
        ///     Peeks the token
        /// </summary>
        /// <returns>The str</returns>
        private string PeekToken()
        {
            int oldPos = _buffer.Position;
            string str = NextToken();
            _buffer.Position = oldPos;
            return str;
        }

        /// <summary>
        ///     Reads the until using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The str</returns>
        private string ReadUntil(char c)
        {
            string str = "";

            while (true)
            {
                char ch = _buffer.Next;

                if (ch == c)
                {
                    _buffer.Position--;
                    break;
                }

                str += ch;
            }

            // Trim quotes from start and end
            if (str[0] == '\"')
            {
                str = str.Remove(0, 1);
            }

            if (str[str.Length - 1] == '\"')
            {
                str = str.Remove(str.Length - 1, 1);
            }

            return str;
        }

        /// <summary>
        ///     Trims the control using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The new str</returns>
        private string TrimControl(string str)
        {
            string newStr = str;

            // Trim control characters
            int i = 0;
            while (true)
            {
                if (i == newStr.Length)
                {
                    break;
                }

                if (char.IsControl(newStr[i]))
                {
                    newStr = newStr.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }

            return newStr;
        }

        /// <summary>
        ///     Trims the tags using the specified outer
        /// </summary>
        /// <param name="outer">The outer</param>
        /// <returns>The string</returns>
        private string TrimTags(string outer)
        {
            int start = outer.IndexOf('>') + 1;
            int end = outer.LastIndexOf('<');

            return TrimControl(outer.Substring(start, end - start));
        }

        /// <summary>
        ///     Tries the parse node
        /// </summary>
        /// <exception cref="XmlFragmentException"></exception>
        /// <exception cref="XmlFragmentException"></exception>
        /// <exception cref="XmlFragmentException"></exception>
        /// <returns>The element</returns>
        public XmlFragmentElement TryParseNode()
        {
            if (_buffer.EndOfBuffer)
            {
                return null;
            }

            int startOuterXml = _buffer.Position;
            string token = NextToken();

            if (token != "<")
            {
                throw new XmlFragmentException("Expected \"<\", got " + token);
            }

            XmlFragmentElement element = new XmlFragmentElement();
            element.Name = NextToken();

            while (true)
            {
                token = NextToken();

                if (token == ">")
                {
                    break;
                }

                if (token == "/") // quick-exit case
                {
                    NextToken();

                    element.OuterXml =
                        TrimControl(_buffer.Buffer.Substring(startOuterXml, _buffer.Position - startOuterXml)).Trim();
                    element.InnerXml = "";

                    return element;
                }

                XmlFragmentAttribute attribute = new XmlFragmentAttribute();
                attribute.Name = token;
                if ((token = NextToken()) != "=")
                {
                    throw new XmlFragmentException("Expected \"=\", got " + token);
                }

                attribute.Value = NextToken();

                element.Attributes.Add(attribute);
            }

            while (true)
            {
                int oldPos = _buffer.Position; // for restoration below
                token = NextToken();

                if (token == "<")
                {
                    token = PeekToken();

                    if (token == "/") // finish element
                    {
                        NextToken(); // skip the / again
                        token = NextToken();
                        NextToken(); // skip >

                        element.OuterXml = TrimControl(_buffer.Buffer.Substring(startOuterXml, _buffer.Position - startOuterXml)).Trim();
                        element.InnerXml = TrimTags(element.OuterXml);

                        if (token != element.Name)
                        {
                            throw new XmlFragmentException("Mismatched element pairs: \"" + element.Name + "\" vs \"" +
                                                           token + "\"");
                        }

                        break;
                    }

                    _buffer.Position = oldPos;
                    element.Elements.Add(TryParseNode());
                }
                else
                {
                    // value, probably
                    _buffer.Position = oldPos;
                    element.Value = ReadUntil('<');
                }
            }

            return element;
        }

        /// <summary>
        ///     Parses this instance
        /// </summary>
        /// <exception cref="XmlFragmentException">Unable to load root node</exception>
        private void Parse()
        {
            RootNode = TryParseNode();

            if (RootNode == null)
            {
                throw new XmlFragmentException("Unable to load root node");
            }
        }
    }
}