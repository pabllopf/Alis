// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CodeBuilder.cs
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
using System.Text;
using System.Threading;

namespace Alis.Core.Ecs.Generator
{
    /// <summary>
    ///     The code builder class
    /// </summary>
    internal class CodeBuilder
    {
        /// <summary>
        ///     The tabs per indent
        /// </summary>
        public const int TabsPerIndent = 4;

        /// <summary>
        ///     The shared
        /// </summary>
        [ThreadStatic] private static CodeBuilder _shared;

        /// <summary>
        ///     The sb
        /// </summary>
        private readonly StringBuilder _sb = new();

        /// <summary>
        ///     Gets the value of the thread shared
        /// </summary>
        public static CodeBuilder ThreadShared
        {
            get
            {
                _shared ??= new();
                _shared.Indents = 0;
                _shared.Clear();
                return _shared;
            }
        }

        /// <summary>
        ///     Gets or sets the value of the indents
        /// </summary>
        public int Indents { get; private set; }

        /// <summary>
        ///     Appends the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The code builder</returns>
        public CodeBuilder Append<T>(T value)
        {
            _sb.Append(value);
            return this;
        }

        /// <summary>
        ///     Appends the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The code builder</returns>
        public CodeBuilder Append(ReadOnlySpan<char> value)
        {
            _sb.EnsureCapacity(value.Length + value.Length);
            foreach (char c in value)
            {
                _sb.Append(c);
            }

            return this;
        }

        /// <summary>
        ///     Appends the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="start">The start</param>
        /// <param name="count">The count</param>
        /// <returns>The code builder</returns>
        public CodeBuilder Append(string value, int start, int count)
        {
            _sb.Append(value, start, count);
            return this;
        }

        /// <summary>
        ///     Appends the line using the specified value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <returns>The code builder</returns>
        public CodeBuilder AppendLine<T>(T value)
        {
            _sb.Append(value);
            _sb.AppendLine();
            _sb.Append(' ', TabsPerIndent * Indents);
            return this;
        }

        /// <summary>
        ///     Foreaches the items
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="items">The items</param>
        /// <param name="ct">The ct</param>
        /// <param name="onEach">The on each</param>
        /// <returns>The code builder</returns>
        public CodeBuilder Foreach<T>(ReadOnlySpan<T> items, CancellationToken ct, CodeBuilderDelegate<T> onEach)
        {
            foreach (ref readonly T i in items)
            {
                onEach(in i, this, ct);
            }

            return this;
        }

        /// <summary>
        ///     Ifs the condition
        /// </summary>
        /// <param name="condition">The condition</param>
        /// <param name="action">The action</param>
        /// <returns>The code builder</returns>
        public CodeBuilder If(bool condition, Action<CodeBuilder> action)
        {
            if (condition)
            {
                action(this);
            }

            return this;
        }

        /// <summary>
        ///     Ifs the condition
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="condition">The condition</param>
        /// <param name="uniform">The uniform</param>
        /// <param name="action">The action</param>
        /// <returns>The code builder</returns>
        public CodeBuilder If<T>(bool condition, T uniform, Action<T, CodeBuilder> action)
        {
            if (condition)
            {
                action(uniform, this);
            }

            return this;
        }

        /// <summary>
        ///     Executes the uniform
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="uniform">The uniform</param>
        /// <param name="ct">The ct</param>
        /// <param name="action">The action</param>
        /// <returns>The code builder</returns>
        public CodeBuilder Execute<T>(in T uniform, CancellationToken ct, CodeBuilderDelegate<T> action)
        {
            action(in uniform, this, ct);
            return this;
        }

        /// <summary>
        ///     Appends the line
        /// </summary>
        /// <returns>The code builder</returns>
        public CodeBuilder AppendLine()
        {
            _sb.AppendLine();
            _sb.Append(' ', TabsPerIndent * Indents);
            return this;
        }

        /// <summary>
        ///     Indents this instance
        /// </summary>
        /// <returns>The code builder</returns>
        public CodeBuilder Indent()
        {
            Indents++;
            return this;
        }

        /// <summary>
        ///     Scopes this instance
        /// </summary>
        /// <returns>The code builder</returns>
        public CodeBuilder Scope() => Indent().AppendLine("{");

        /// <summary>
        ///     Unscopes this instance
        /// </summary>
        /// <returns>The code builder</returns>
        public CodeBuilder Unscope() => Outdent().AppendLine("}");


        /// <summary>
        ///     Outdents this instance
        /// </summary>
        /// <exception cref="InvalidOperationException">Indentation level must be positive!</exception>
        /// <returns>The code builder</returns>
        public CodeBuilder Outdent()
        {
            Indents--;
            if (Indents < 0)
            {
                throw new InvalidOperationException("Indentation level must be positive!");
            }

            if ((_sb[_sb.Length - 1] == ' ')
                && (_sb[_sb.Length - 2] == ' ')
                && (_sb[_sb.Length - 3] == ' ')
                && (_sb[_sb.Length - 4] == ' '))
            {
                _sb.Remove(_sb.Length - 4, 4);
            }

            return this;
        }

        /// <summary>
        ///     Appends the with dot using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The code builder</returns>
        public CodeBuilder AppendWithDot(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return this;
            }

            _sb.Append(str);
            _sb.Append('.');
            return this;
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        /// <returns>The code builder</returns>
        public CodeBuilder Clear()
        {
            _sb.Clear();
            return this;
        }

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => _sb.ToString();

        /// <summary>
        ///     The code builder delegate
        /// </summary>
        internal delegate void CodeBuilderDelegate<T>(in T model, CodeBuilder codeBuilder, CancellationToken ct);
    }
}