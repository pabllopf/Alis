// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PairManager.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

// The pair manager is used by the broad-phase to quickly add/remove/find pairs
// of overlapping proxies. It is based closely on code provided by Pierre Terdiman.
// http://www.codercorner.com/IncrementalSAP.txt

#define DEBUG

using System;
using Alis.Core.Physic.Common;
using Math = Alis.Core.Physic.Common.Math;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The pair manager class
    /// </summary>
    public class PairManager
    {
        /// <summary>
        ///     The ushrt max
        /// </summary>
        public static readonly ushort NullPair = Math.UshrtMax;

        /// <summary>
        ///     The ushrt max
        /// </summary>
        public static readonly ushort NullProxy = Math.UshrtMax;

        /// <summary>
        ///     The max pairs
        /// </summary>
        public static readonly int TableCapacity = Settings.MaxPairs; // must be a power of two

        /// <summary>
        ///     The table capacity
        /// </summary>
        public static readonly int TableMask = TableCapacity - 1;

        /// <summary>
        ///     The table capacity
        /// </summary>
        public readonly ushort[] HashTable = new ushort[TableCapacity];

        /// <summary>
        ///     The max pairs
        /// </summary>
        public readonly BufferedPair[] PairBuffer = new BufferedPair[Settings.MaxPairs];

        /// <summary>
        ///     The max pairs
        /// </summary>
        public readonly Pair[] Pairs = new Pair[Settings.MaxPairs];

        /// <summary>
        ///     The broad phase
        /// </summary>
        public BroadPhase BroadPhase;

        /// <summary>
        ///     The callback
        /// </summary>
        public PairCallback Callback;

        /// <summary>
        ///     The free pair
        /// </summary>
        public ushort FreePair;

        /// <summary>
        ///     The pair buffer count
        /// </summary>
        public int PairBufferCount;

        /// <summary>
        ///     The pair count
        /// </summary>
        public int PairCount;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PairManager" /> class
        /// </summary>
        public PairManager()
        {
            Box2DxDebug.Assert(Math.IsPowerOfTwo((uint) TableCapacity));
            Box2DxDebug.Assert(TableCapacity >= Settings.MaxPairs);
            for (int i = 0; i < TableCapacity; ++i)
            {
                HashTable[i] = NullPair;
            }

            FreePair = 0;
            for (int i = 0; i < Settings.MaxPairs; ++i)
            {
                Pairs[i] = new Pair(); //todo: need some pool here
                Pairs[i].ProxyId1 = NullProxy;
                Pairs[i].ProxyId2 = NullProxy;
                Pairs[i].UserData = null;
                Pairs[i].Status = 0;
                Pairs[i].Next = (ushort) (i + 1U);
            }

            Pairs[Settings.MaxPairs - 1].Next = NullPair;
            PairCount = 0;
            PairBufferCount = 0;
        }

        /// <summary>
        ///     Initializes the broad phase
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        /// <param name="callback">The callback</param>
        public void Initialize(BroadPhase broadPhase, PairCallback callback)
        {
            BroadPhase = broadPhase;
            Callback = callback;
        }

        /*
        As proxies are created and moved, many pairs are created and destroyed. Even worse, the same
        pair may be added and removed multiple times in a single time step of the physics engine. To reduce
        traffic in the pair manager, we try to avoid destroying pairs in the pair manager until the
        end of the physics step. This is done by buffering all the RemovePair requests. AddPair
        requests are processed immediately because we need the hash table entry for quick lookup.

        All user user callbacks are delayed until the buffered pairs are confirmed in Commit.
        This is very important because the user callbacks may be very expensive and client logic
        may be harmed if pairs are added and removed within the same time step.

        Buffer a pair for addition.
        We may add a pair that is not in the pair manager or pair buffer.
        We may add a pair that is already in the pair manager and pair buffer.
        If the added pair is not a new pair, then it must be in the pair buffer (because RemovePair was called).
        */
        /// <summary>
        ///     Adds the buffered pair using the specified id 1
        /// </summary>
        /// <param name="id1">The id</param>
        /// <param name="id2">The id</param>
        public void AddBufferedPair(int id1, int id2)
        {
            Box2DxDebug.Assert(id1 != NullProxy && id2 != NullProxy);
            Box2DxDebug.Assert(PairBufferCount < Settings.MaxPairs);

            Pair pair = AddPair(id1, id2);

            // If this pair is not in the pair buffer ...
            if (pair.IsBuffered() == false)
            {
                // This must be a newly added pair.
                Box2DxDebug.Assert(pair.IsFinal() == false);

                // Add it to the pair buffer.
                pair.SetBuffered();
                PairBuffer[PairBufferCount].ProxyId1 = pair.ProxyId1;
                PairBuffer[PairBufferCount].ProxyId2 = pair.ProxyId2;
                ++PairBufferCount;

                Box2DxDebug.Assert(PairBufferCount <= PairCount);
            }

            // Confirm this pair for the subsequent call to Commit.
            pair.ClearRemoved();

            if (BroadPhase.IsValidate)
            {
                ValidateBuffer();
            }
        }

        // Buffer a pair for removal.
        /// <summary>
        ///     Removes the buffered pair using the specified id 1
        /// </summary>
        /// <param name="id1">The id</param>
        /// <param name="id2">The id</param>
        public void RemoveBufferedPair(int id1, int id2)
        {
            Box2DxDebug.Assert(id1 != NullProxy && id2 != NullProxy);
            Box2DxDebug.Assert(PairBufferCount < Settings.MaxPairs);

            Pair pair = Find(id1, id2);

            if (pair == null)
            {
                // The pair never existed. This is legal (due to collision filtering).
                return;
            }

            // If this pair is not in the pair buffer ...
            if (pair.IsBuffered() == false)
            {
                // This must be an old pair.
                Box2DxDebug.Assert(pair.IsFinal());

                pair.SetBuffered();
                PairBuffer[PairBufferCount].ProxyId1 = pair.ProxyId1;
                PairBuffer[PairBufferCount].ProxyId2 = pair.ProxyId2;
                ++PairBufferCount;

                Box2DxDebug.Assert(PairBufferCount <= PairCount);
            }

            pair.SetRemoved();

            if (BroadPhase.IsValidate)
            {
                ValidateBuffer();
            }
        }

        /// <summary>
        ///     Commits this instance
        /// </summary>
        public void Commit()
        {
            int removeCount = 0;

            Proxy[] proxies = BroadPhase.ProxyPool;

            for (int i = 0; i < PairBufferCount; ++i)
            {
                Pair pair = Find(PairBuffer[i].ProxyId1, PairBuffer[i].ProxyId2);
                Box2DxDebug.Assert(pair.IsBuffered());
                pair.ClearBuffered();

                Box2DxDebug.Assert(pair.ProxyId1 < Settings.MaxProxies && pair.ProxyId2 < Settings.MaxProxies);

                Proxy proxy1 = proxies[pair.ProxyId1];
                Proxy proxy2 = proxies[pair.ProxyId2];

                Box2DxDebug.Assert(proxy1.IsValid);
                Box2DxDebug.Assert(proxy2.IsValid);

                if (pair.IsRemoved())
                {
                    // It is possible a pair was added then removed before a commit. Therefore,
                    // we should be careful not to tell the user the pair was removed when the
                    // the user didn't receive a matching add.
                    if (pair.IsFinal())
                    {
                        Callback.PairRemoved(proxy1.UserData, proxy2.UserData, pair.UserData);
                    }

                    // Store the ids so we can actually remove the pair below.
                    PairBuffer[removeCount].ProxyId1 = pair.ProxyId1;
                    PairBuffer[removeCount].ProxyId2 = pair.ProxyId2;
                    ++removeCount;
                }
                else
                {
                    Box2DxDebug.Assert(BroadPhase.TestOverlap(proxy1, proxy2));

                    if (pair.IsFinal() == false)
                    {
                        pair.UserData = Callback.PairAdded(proxy1.UserData, proxy2.UserData);
                        pair.SetFinal();
                    }
                }
            }

            for (int i = 0; i < removeCount; ++i)
            {
                RemovePair(PairBuffer[i].ProxyId1, PairBuffer[i].ProxyId2);
            }

            PairBufferCount = 0;

            if (BroadPhase.IsValidate)
            {
                ValidateTable();
            }
        }

        /// <summary>
        ///     Finds the proxy id 1
        /// </summary>
        /// <param name="proxyId1">The proxy id</param>
        /// <param name="proxyId2">The proxy id</param>
        /// <returns>The pair</returns>
        private Pair Find(int proxyId1, int proxyId2)
        {
            if (proxyId1 > proxyId2)
            {
                Math.Swap(ref proxyId1, ref proxyId2);
            }

            uint hash = (uint) (Hash((uint) proxyId1, (uint) proxyId2) & TableMask);

            return Find(proxyId1, proxyId2, hash);
        }

        /// <summary>
        ///     Finds the proxy id 1
        /// </summary>
        /// <param name="proxyId1">The proxy id</param>
        /// <param name="proxyId2">The proxy id</param>
        /// <param name="hash">The hash</param>
        /// <returns>The pair</returns>
        private Pair Find(int proxyId1, int proxyId2, uint hash)
        {
            int index = HashTable[hash];

            while (index != NullPair && Equals(Pairs[index], proxyId1, proxyId2) == false)
            {
                index = Pairs[index].Next;
            }

            if (index == NullPair)
            {
                return null;
            }

            Box2DxDebug.Assert(index < Settings.MaxPairs);

            return Pairs[index];
        }

        // Returns existing pair or creates a new one.
        /// <summary>
        ///     Adds the pair using the specified proxy id 1
        /// </summary>
        /// <param name="proxyId1">The proxy id</param>
        /// <param name="proxyId2">The proxy id</param>
        /// <returns>The pair</returns>
        private Pair AddPair(int proxyId1, int proxyId2)
        {
            if (proxyId1 > proxyId2)
            {
                Math.Swap(ref proxyId1, ref proxyId2);
            }

            int hash = (int) (Hash((uint) proxyId1, (uint) proxyId2) & TableMask);

            Pair pair = Find(proxyId1, proxyId2, (uint) hash);
            if (pair != null)
            {
                return pair;
            }

            Box2DxDebug.Assert(PairCount < Settings.MaxPairs && FreePair != NullPair);

            ushort pairIndex = FreePair;
            pair = Pairs[pairIndex];
            FreePair = pair.Next;

            pair.ProxyId1 = (ushort) proxyId1;
            pair.ProxyId2 = (ushort) proxyId2;
            pair.Status = 0;
            pair.UserData = null;
            pair.Next = HashTable[hash];

            HashTable[hash] = pairIndex;

            ++PairCount;

            return pair;
        }

        // Removes a pair. The pair must exist.
        /// <summary>
        ///     Removes the pair using the specified proxy id 1
        /// </summary>
        /// <param name="proxyId1">The proxy id</param>
        /// <param name="proxyId2">The proxy id</param>
        /// <returns>The object</returns>
        private object RemovePair(int proxyId1, int proxyId2)
        {
            Box2DxDebug.Assert(PairCount > 0);

            if (proxyId1 > proxyId2)
            {
                Math.Swap(ref proxyId1, ref proxyId2);
            }

            int hash = (int) (Hash((uint) proxyId1, (uint) proxyId2) & TableMask);

            //uint16* node = &m_hashTable[hash];
            ushort node = HashTable[hash];
            bool ion = false;
            int ni = 0;
            while (node != NullPair)
            {
                if (Equals(Pairs[node], proxyId1, proxyId2))
                {
                    //uint16 index = *node;
                    //*node = m_pairs[*node].next;

                    ushort index = node;
                    node = Pairs[node].Next;
                    if (ion)
                    {
                        Pairs[ni].Next = node;
                    }
                    else
                    {
                        HashTable[hash] = node;
                    }

                    Pair pair = Pairs[index];
                    object userData = pair.UserData;

                    // Scrub
                    pair.Next = FreePair;
                    pair.ProxyId1 = NullProxy;
                    pair.ProxyId2 = NullProxy;
                    pair.UserData = null;
                    pair.Status = 0;

                    FreePair = index;
                    --PairCount;
                    return userData;
                }

                //node = &m_pairs[*node].next;
                ni = node;
                node = Pairs[ni].Next;
                ion = true;
            }

            Box2DxDebug.Assert(false);
            return null;
        }

        /// <summary>
        ///     Validates the buffer
        /// </summary>
        private void ValidateBuffer()
        {
#if DEBUG
            Box2DxDebug.Assert(PairBufferCount <= PairCount);

            //std::sort(m_pairBuffer, m_pairBuffer + m_pairBufferCount);
            BufferedPair[] tmp = new BufferedPair[PairBufferCount];
            Array.Copy(PairBuffer, 0, tmp, 0, PairBufferCount);
            Array.Sort(tmp, BufferedPairSortPredicate);
            Array.Copy(tmp, 0, PairBuffer, 0, PairBufferCount);

            for (int i = 0; i < PairBufferCount; ++i)
            {
                if (i > 0)
                {
                    Box2DxDebug.Assert(Equals(PairBuffer[i], PairBuffer[i - 1]) == false);
                }

                Pair pair = Find(PairBuffer[i].ProxyId1, PairBuffer[i].ProxyId2);
                Box2DxDebug.Assert(pair.IsBuffered());

                Box2DxDebug.Assert(pair.ProxyId1 != pair.ProxyId2);
                Box2DxDebug.Assert(pair.ProxyId1 < Settings.MaxProxies);
                Box2DxDebug.Assert(pair.ProxyId2 < Settings.MaxProxies);

                Proxy proxy1 = BroadPhase.ProxyPool[pair.ProxyId1];
                Proxy proxy2 = BroadPhase.ProxyPool[pair.ProxyId2];

                Box2DxDebug.Assert(proxy1.IsValid);
                Box2DxDebug.Assert(proxy2.IsValid);
            }
#endif
        }

        /// <summary>
        ///     Validates the table
        /// </summary>
        private void ValidateTable()
        {
#if DEBUG
            for (int i = 0; i < TableCapacity; ++i)
            {
                ushort index = HashTable[i];
                while (index != NullPair)
                {
                    Pair pair = Pairs[index];
                    Box2DxDebug.Assert(pair.IsBuffered() == false);
                    Box2DxDebug.Assert(pair.IsFinal());
                    Box2DxDebug.Assert(pair.IsRemoved() == false);

                    Box2DxDebug.Assert(pair.ProxyId1 != pair.ProxyId2);
                    Box2DxDebug.Assert(pair.ProxyId1 < Settings.MaxProxies);
                    Box2DxDebug.Assert(pair.ProxyId2 < Settings.MaxProxies);

                    Proxy proxy1 = BroadPhase.ProxyPool[pair.ProxyId1];
                    Proxy proxy2 = BroadPhase.ProxyPool[pair.ProxyId2];

                    Box2DxDebug.Assert(proxy1.IsValid);
                    Box2DxDebug.Assert(proxy2.IsValid);

                    Box2DxDebug.Assert(BroadPhase.TestOverlap(proxy1, proxy2));

                    index = pair.Next;
                }
            }
#endif
        }

        // Thomas Wang's hash, see: http://www.concentric.net/~Ttwang/tech/inthash.htm
        // This assumes proxyId1 and proxyId2 are 16-bit.
        /// <summary>
        ///     Hashes the proxy id 1
        /// </summary>
        /// <param name="proxyId1">The proxy id</param>
        /// <param name="proxyId2">The proxy id</param>
        /// <returns>The key</returns>
        private uint Hash(uint proxyId1, uint proxyId2)
        {
            uint key = (proxyId2 << 16) | proxyId1;
            key = ~key + (key << 15);
            key = key ^ (key >> 12);
            key = key + (key << 2);
            key = key ^ (key >> 4);
            key = key * 2057;
            key = key ^ (key >> 16);
            return key;
        }

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="pair">The pair</param>
        /// <param name="proxyId1">The proxy id</param>
        /// <param name="proxyId2">The proxy id</param>
        /// <returns>The bool</returns>
        private bool Equals(Pair pair, int proxyId1, int proxyId2)
        {
            return pair.ProxyId1 == proxyId1 && pair.ProxyId2 == proxyId2;
        }

        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="pair1">The pair</param>
        /// <param name="pair2">The pair</param>
        /// <returns>The bool</returns>
        private bool Equals(ref BufferedPair pair1, ref BufferedPair pair2)
        {
            return pair1.ProxyId1 == pair2.ProxyId1 && pair1.ProxyId2 == pair2.ProxyId2;
        }

        /// <summary>
        ///     Buffereds the pair sort predicate using the specified pair 1
        /// </summary>
        /// <param name="pair1">The pair</param>
        /// <param name="pair2">The pair</param>
        /// <returns>The int</returns>
        public static int BufferedPairSortPredicate(BufferedPair pair1, BufferedPair pair2)
        {
            if (pair1.ProxyId1 < pair2.ProxyId1)
            {
                return 1;
            }

            if (pair1.ProxyId1 > pair2.ProxyId1)
            {
                return -1;
            }

            if (pair1.ProxyId2 < pair2.ProxyId2)
            {
                return 1;
            }

            if (pair1.ProxyId2 > pair2.ProxyId2)
            {
                return -1;
            }

            return 0;
        }
    }
}