// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SparseSetCoverageTest.cs
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

using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    public class SparseSetCoverageTest
    {
        [Fact] public void Constructor_Default_DoesNotThrow()
        {
            SparseSet<int> set = new SparseSet<int>();
            Assert.NotNull(set);
        }

        [Fact] public void Indexer_NewId_StoresAndRetrievesInt()
        {
            SparseSet<int> set = new SparseSet<int>();
            set[0] = 42;
            Assert.Equal(42, set[0]);
        }

        [Fact] public void Indexer_MultipleNewIds_AllAccessible()
        {
            SparseSet<string> set = new SparseSet<string>();
            set[0] = "a";
            set[1] = "b";
            set[2] = "c";
            Assert.Equal("a", set[0]);
            Assert.Equal("b", set[1]);
            Assert.Equal("c", set[2]);
        }

        [Fact] public void Indexer_ExistingId_Overwrites()
        {
            SparseSet<int> set = new SparseSet<int>();
            set[3] = 10;
            set[3] = 20;
            Assert.Equal(20, set[3]);
        }

        [Fact] public void Indexer_LargeId_Resizes()
        {
            SparseSet<int> set = new SparseSet<int>();
            set[1000] = 999;
            Assert.Equal(999, set[1000]);
        }

        [Fact] public void Indexer_SparseIds_AllCorrect()
        {
            SparseSet<int> set = new SparseSet<int>();
            set[1] = 10;
            set[10] = 20;
            set[100] = 30;
            Assert.Equal(10, set[1]);
            Assert.Equal(20, set[10]);
            Assert.Equal(30, set[100]);
        }

        [Fact] public void Indexer_RefReturn_MutationPersists()
        {
            SparseSet<int> set = new SparseSet<int>();
            set[5] = 100;
            ref int val = ref set[5];
            val = 200;
            Assert.Equal(200, set[5]);
        }

        [Fact] public void Indexer_RefReturn_IncrementPersists()
        {
            SparseSet<int> set = new SparseSet<int>();
            set[0] = 10;
            ref int val = ref set[0];
            val += 5;
            Assert.Equal(15, set[0]);
        }

        [Fact] public void Indexer_StringType_StoresAndRetrieves()
        {
            SparseSet<string> set = new SparseSet<string>();
            set[2] = "hello";
            Assert.Equal("hello", set[2]);
        }
        
        [Fact] public void Indexer_SequentialUpToInitialCapacity_Works()
        {
            SparseSet<int> set = new SparseSet<int>();
            for (int i = 0; i < 4; i++)
            {
                set[i] = i * 10;
            }
            for (int i = 0; i < 4; i++)
            {
                Assert.Equal(i * 10, set[i]);
            }
        }

        [Fact] public void Indexer_SequentialBeyondCapacity_Works()
        {
            SparseSet<int> set = new SparseSet<int>();
            for (int i = 0; i < 20; i++)
            {
                set[i] = i;
            }
            for (int i = 0; i < 20; i++)
            {
                Assert.Equal(i, set[i]);
            }
        }

        [Fact] public void Indexer_AccessDefaultValue_ReturnsZero()
        {
            SparseSet<int> set = new SparseSet<int>();
            Assert.Equal(0, set[99]);
        }
    }
}
