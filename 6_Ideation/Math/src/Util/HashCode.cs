// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HashCode.cs
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
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Alis.Core.Aspect.Math.Util
{
    /// <summary>
    ///     The hash code
    /// </summary>
    public struct HashCode
    {
        /// <summary>
        ///     The generate global seed
        /// </summary>
        private static readonly uint SSeed = GenerateGlobalSeed();

        /// <summary>
        ///     The prime
        /// </summary>
        private const uint Prime1 = 2654435761U;

        /// <summary>
        ///     The prime
        /// </summary>
        private const uint Prime2 = 2246822519U;

        /// <summary>
        ///     The prime
        /// </summary>
        private const uint Prime3 = 3266489917U;

        /// <summary>
        ///     The prime
        /// </summary>
        private const uint Prime4 = 668265263U;

        /// <summary>
        ///     The prime
        /// </summary>
        private const uint Prime5 = 374761393U;

        /// <summary>
        ///     The
        /// </summary>
        private uint _v1, _v2, _v3, _v4;

        /// <summary>
        ///     The queue
        /// </summary>
        private uint _queue1, _queue2, _queue3;

        /// <summary>
        ///     The length
        /// </summary>
        private uint _length;

        /// <summary>
        ///     Generates the global seed
        /// </summary>
        /// <returns>The uint</returns>
        private static uint GenerateGlobalSeed()
        {
            byte[] randomBytes = new byte[sizeof(uint)];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return BitConverter.ToUInt32(randomBytes, 0);
        }

        /// <summary>
        ///     Combines the value 1
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <param name="value1">The value</param>
        /// <returns>The int</returns>
        public static int Combine<T1>(T1 value1)
        {
            // Provide a way of diffusing bits from something with a limited
            // input hash space. For example, many enums only have a few
            // possible hashes, only using the bottom few bits of the code. Some
            // collections are built on the assumption that hashes are spread
            // over a larger space, so diffusing the bits may help the
            // collection work more efficiently.

            uint hc1 = (uint) (value1?.GetHashCode() ?? 0);

            uint hash = MixEmptyState();
            hash += 4;

            hash = QueueRound(hash, hc1);

            hash = MixFinal(hash);
            return (int) hash;
        }

        /// <summary>
        ///     Combines the value 1
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <returns>The int</returns>
        public static int Combine<T1, T2>(T1 value1, T2 value2)
        {
            uint hc1 = (uint) (value1?.GetHashCode() ?? 0);
            uint hc2 = (uint) (value2?.GetHashCode() ?? 0);

            uint hash = MixEmptyState();
            hash += 8;

            hash = QueueRound(hash, hc1);
            hash = QueueRound(hash, hc2);

            hash = MixFinal(hash);
            return (int) hash;
        }

        /// <summary>
        ///     Combines the value 1
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <returns>The int</returns>
        public static int Combine<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
        {
            uint hc1 = (uint) (value1?.GetHashCode() ?? 0);
            uint hc2 = (uint) (value2?.GetHashCode() ?? 0);
            uint hc3 = (uint) (value3?.GetHashCode() ?? 0);

            uint hash = MixEmptyState();
            hash += 12;

            hash = QueueRound(hash, hc1);
            hash = QueueRound(hash, hc2);
            hash = QueueRound(hash, hc3);

            hash = MixFinal(hash);
            return (int) hash;
        }

        /// <summary>
        ///     Combines the value 1
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <returns>The int</returns>
        public static int Combine<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            uint hc1 = (uint) (value1?.GetHashCode() ?? 0);
            uint hc2 = (uint) (value2?.GetHashCode() ?? 0);
            uint hc3 = (uint) (value3?.GetHashCode() ?? 0);
            uint hc4 = (uint) (value4?.GetHashCode() ?? 0);

            Initialize(out uint v1, out uint v2, out uint v3, out uint v4);

            v1 = Round(v1, hc1);
            v2 = Round(v2, hc2);
            v3 = Round(v3, hc3);
            v4 = Round(v4, hc4);

            uint hash = MixState(v1, v2, v3, v4);
            hash += 16;

            hash = MixFinal(hash);
            return (int) hash;
        }

        /// <summary>
        ///     Combines the value 1
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="value5">The value</param>
        /// <returns>The int</returns>
        public static int Combine<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            uint hc1 = (uint) (value1?.GetHashCode() ?? 0);
            uint hc2 = (uint) (value2?.GetHashCode() ?? 0);
            uint hc3 = (uint) (value3?.GetHashCode() ?? 0);
            uint hc4 = (uint) (value4?.GetHashCode() ?? 0);
            uint hc5 = (uint) (value5?.GetHashCode() ?? 0);

            Initialize(out uint v1, out uint v2, out uint v3, out uint v4);

            v1 = Round(v1, hc1);
            v2 = Round(v2, hc2);
            v3 = Round(v3, hc3);
            v4 = Round(v4, hc4);

            uint hash = MixState(v1, v2, v3, v4);
            hash += 20;

            hash = QueueRound(hash, hc5);

            hash = MixFinal(hash);
            return (int) hash;
        }

        /// <summary>
        ///     Combines the value 1
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="value5">The value</param>
        /// <param name="value6">The value</param>
        /// <returns>The int</returns>
        public static int Combine<T1, T2, T3, T4, T5, T6>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
        {
            uint hc1 = (uint) (value1?.GetHashCode() ?? 0);
            uint hc2 = (uint) (value2?.GetHashCode() ?? 0);
            uint hc3 = (uint) (value3?.GetHashCode() ?? 0);
            uint hc4 = (uint) (value4?.GetHashCode() ?? 0);
            uint hc5 = (uint) (value5?.GetHashCode() ?? 0);
            uint hc6 = (uint) (value6?.GetHashCode() ?? 0);

            Initialize(out uint v1, out uint v2, out uint v3, out uint v4);

            v1 = Round(v1, hc1);
            v2 = Round(v2, hc2);
            v3 = Round(v3, hc3);
            v4 = Round(v4, hc4);

            uint hash = MixState(v1, v2, v3, v4);
            hash += 24;

            hash = QueueRound(hash, hc5);
            hash = QueueRound(hash, hc6);

            hash = MixFinal(hash);
            return (int) hash;
        }

        /// <summary>
        ///     Combines the value 1
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="value5">The value</param>
        /// <param name="value6">The value</param>
        /// <param name="value7">The value</param>
        /// <returns>The int</returns>
        public static int Combine<T1, T2, T3, T4, T5, T6, T7>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
        {
            uint hc1 = (uint) (value1?.GetHashCode() ?? 0);
            uint hc2 = (uint) (value2?.GetHashCode() ?? 0);
            uint hc3 = (uint) (value3?.GetHashCode() ?? 0);
            uint hc4 = (uint) (value4?.GetHashCode() ?? 0);
            uint hc5 = (uint) (value5?.GetHashCode() ?? 0);
            uint hc6 = (uint) (value6?.GetHashCode() ?? 0);
            uint hc7 = (uint) (value7?.GetHashCode() ?? 0);

            Initialize(out uint v1, out uint v2, out uint v3, out uint v4);

            v1 = Round(v1, hc1);
            v2 = Round(v2, hc2);
            v3 = Round(v3, hc3);
            v4 = Round(v4, hc4);

            uint hash = MixState(v1, v2, v3, v4);
            hash += 28;

            hash = QueueRound(hash, hc5);
            hash = QueueRound(hash, hc6);
            hash = QueueRound(hash, hc7);

            hash = MixFinal(hash);
            return (int) hash;
        }

        /// <summary>
        ///     Combines the value 1
        /// </summary>
        /// <typeparam name="T1">The </typeparam>
        /// <typeparam name="T2">The </typeparam>
        /// <typeparam name="T3">The </typeparam>
        /// <typeparam name="T4">The </typeparam>
        /// <typeparam name="T5">The </typeparam>
        /// <typeparam name="T6">The </typeparam>
        /// <typeparam name="T7">The </typeparam>
        /// <typeparam name="T8">The </typeparam>
        /// <param name="value1">The value</param>
        /// <param name="value2">The value</param>
        /// <param name="value3">The value</param>
        /// <param name="value4">The value</param>
        /// <param name="value5">The value</param>
        /// <param name="value6">The value</param>
        /// <param name="value7">The value</param>
        /// <param name="value8">The value</param>
        /// <returns>The int</returns>
        public static int Combine<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8)
        {
            uint hc1 = (uint) (value1?.GetHashCode() ?? 0);
            uint hc2 = (uint) (value2?.GetHashCode() ?? 0);
            uint hc3 = (uint) (value3?.GetHashCode() ?? 0);
            uint hc4 = (uint) (value4?.GetHashCode() ?? 0);
            uint hc5 = (uint) (value5?.GetHashCode() ?? 0);
            uint hc6 = (uint) (value6?.GetHashCode() ?? 0);
            uint hc7 = (uint) (value7?.GetHashCode() ?? 0);
            uint hc8 = (uint) (value8?.GetHashCode() ?? 0);

            Initialize(out uint v1, out uint v2, out uint v3, out uint v4);

            v1 = Round(v1, hc1);
            v2 = Round(v2, hc2);
            v3 = Round(v3, hc3);
            v4 = Round(v4, hc4);

            v1 = Round(v1, hc5);
            v2 = Round(v2, hc6);
            v3 = Round(v3, hc7);
            v4 = Round(v4, hc8);

            uint hash = MixState(v1, v2, v3, v4);
            hash += 32;

            hash = MixFinal(hash);
            return (int) hash;
        }

        /// <summary>
        ///     Initializes the v 1
        /// </summary>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="v3">The </param>
        /// <param name="v4">The </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Initialize(out uint v1, out uint v2, out uint v3, out uint v4)
        {
            v1 = SSeed + Prime1 + Prime2;
            v2 = SSeed + Prime2;
            v3 = SSeed;
            v4 = SSeed - Prime1;
        }

        /// <summary>
        ///     Rounds the hash
        /// </summary>
        /// <param name="hash">The hash</param>
        /// <param name="input">The input</param>
        /// <returns>The uint</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint Round(uint hash, uint input) => RotateLeft(hash + input * Prime2, 13) * Prime1;

        /// <summary>
        ///     Queues the round using the specified hash
        /// </summary>
        /// <param name="hash">The hash</param>
        /// <param name="queuedValue">The queued value</param>
        /// <returns>The uint</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint QueueRound(uint hash, uint queuedValue) => RotateLeft(hash + queuedValue * Prime3, 17) * Prime4;

        /// <summary>
        ///     Mixes the state using the specified v 1
        /// </summary>
        /// <param name="v1">The </param>
        /// <param name="v2">The </param>
        /// <param name="v3">The </param>
        /// <param name="v4">The </param>
        /// <returns>The uint</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint MixState(uint v1, uint v2, uint v3, uint v4) => RotateLeft(v1, 1) + RotateLeft(v2, 7) + RotateLeft(v3, 12) + RotateLeft(v4, 18);

        /// <summary>
        ///     Rotates the left using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="offset">The offset</param>
        /// <returns>The uint</returns>
        public static uint RotateLeft(uint value, int offset)
            => (value << offset) | (value >> (32 - offset));

        /// <summary>
        ///     Mixes the empty state
        /// </summary>
        /// <returns>The uint</returns>
        private static uint MixEmptyState() => SSeed + Prime5;

        /// <summary>
        ///     Mixes the final using the specified hash
        /// </summary>
        /// <param name="hash">The hash</param>
        /// <returns>The hash</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static uint MixFinal(uint hash)
        {
            hash ^= hash >> 15;
            hash *= Prime2;
            hash ^= hash >> 13;
            hash *= Prime3;
            hash ^= hash >> 16;
            return hash;
        }

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        public void Add<T>(T value)
        {
            Add(value?.GetHashCode() ?? 0);
        }

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="value">The value</param>
        /// <param name="comparer">The comparer</param>
        public void Add<T>(T value, IEqualityComparer<T> comparer)
        {
            Add(value is null ? 0 : comparer?.GetHashCode(value) ?? value.GetHashCode());
        }

        /// <summary>
        ///     Adds the value
        /// </summary>
        /// <param name="value">The value</param>
        private void Add(int value)
        {
            // The original xxHash works as follows:
            // 0. Initialize immediately. We can't do this in a struct (no
            //    default ctor).
            // 1. Accumulate blocks of length 16 (4 uints) into 4 accumulators.
            // 2. Accumulate remaining blocks of length 4 (1 uint) into the
            //    hash.
            // 3. Accumulate remaining blocks of length 1 into the hash.

            // There is no need for #3 as this type only accepts ints. _queue1,
            // _queue2 and _queue3 are basically a buffer so that when
            // ToHashCode is called we can execute #2 correctly.

            // We need to initialize the xxHash32 state (_v1 to _v4) lazily (see
            // #0) nd the last place that can be done if you look at the
            // original code is just before the first block of 16 bytes is mixed
            // in. The xxHash32 state is never used for streams containing fewer
            // than 16 bytes.

            // To see what's really going on here, have a look at the Combine
            // methods.

            uint val = (uint) value;

            // Storing the value of _length locally shaves of quite a few bytes
            // in the resulting machine code.
            uint previousLength = _length++;
            uint position = previousLength % 4;

            // Switch can't be inlined.

            if (position == 0)
            {
                _queue1 = val;
            }
            else if (position == 1)
            {
                _queue2 = val;
            }
            else if (position == 2)
            {
                _queue3 = val;
            }
            else // position == 3
            {
                if (previousLength == 3)
                {
                    Initialize(out _v1, out _v2, out _v3, out _v4);
                }

                _v1 = Round(_v1, _queue1);
                _v2 = Round(_v2, _queue2);
                _v3 = Round(_v3, _queue3);
                _v4 = Round(_v4, val);
            }
        }

        /// <summary>
        ///     Returns the hash code
        /// </summary>
        /// <returns>The int</returns>
        public int ToHashCode()
        {
            // Storing the value of _length locally shaves of quite a few bytes
            // in the resulting machine code.
            uint length = _length;

            // position refers to the *next* queue position in this method, so
            // position == 1 means that _queue1 is populated; _queue2 would have
            // been populated on the next call to Add.
            uint position = length % 4;

            // If the length is less than 4, _v1 to _v4 don't contain anything
            // yet. xxHash32 treats this differently.

            uint hash = length < 4 ? MixEmptyState() : MixState(_v1, _v2, _v3, _v4);

            // _length is incremented once per Add(Int32) and is therefore 4
            // times too small (xxHash length is in bytes, not ints).

            hash += length * 4;

            // Mix what remains in the queue

            // Switch can't be inlined right now, so use as few branches as
            // possible by manually excluding impossible scenarios (position > 1
            // is always false if position is not > 0).
            if (position > 0)
            {
                hash = QueueRound(hash, _queue1);
                if (position > 1)
                {
                    hash = QueueRound(hash, _queue2);
                    if (position > 2)
                    {
                        hash = QueueRound(hash, _queue3);
                    }
                }
            }

            hash = MixFinal(hash);
            return (int) hash;
        }
    }
}