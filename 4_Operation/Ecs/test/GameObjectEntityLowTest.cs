// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectEntityLowTest.cs
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


using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Unit tests for the <see cref="GameObject.EntityLow" /> internal property.
    ///     <para>
    ///         <c>EntityLow</c> reinterprets the <see cref="GameObject" /> struct memory as an
    ///         <see cref="EntityHighLow" /> and reads its <c>EntityLow</c> field, which covers
    ///         bytes 4-7 of the struct layout (i.e. <c>EntityVersion</c> packed in the low 16 bits
    ///         and <c>WorldID</c> packed in the high 16 bits of the returned <c>int</c>).
    ///     </para>
    /// </summary>
    public class GameObjectEntityLowTest
    {
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     Computes the expected <c>EntityLow</c> value from its two component fields.
        ///     On little-endian architectures <c>EntityVersion</c> occupies the low 16 bits
        ///     and <c>WorldID</c> occupies the high 16 bits.
        /// </summary>
        private static int ExpectedEntityLow(ushort version, ushort worldId)
            => (int) (version | ((uint) worldId << 16));

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     A default-constructed <see cref="GameObject" /> has EntityVersion = 0 and
        ///     WorldID = 0, so <c>EntityLow</c> must return 0.
        /// </summary>
        [Fact]
        public void EntityLow_DefaultGameObject_ReturnsZero()
        {
            GameObject gameObject = new GameObject();

            int result = gameObject.EntityLow;

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     <c>default(GameObject)</c> must also yield <c>EntityLow</c> = 0.
        /// </summary>
        [Fact]
        public void EntityLow_DefaultKeyword_ReturnsZero()
        {
            GameObject gameObject = default(GameObject);

            int result = gameObject.EntityLow;

            Assert.Equal(0, result);
        }

        /// <summary>
        ///     <see cref="GameObject.Null" /> has all fields zeroed, so <c>EntityLow</c> = 0.
        /// </summary>
        [Fact]
        public void EntityLow_NullGameObject_ReturnsZero()
        {
            GameObject gameObject = GameObject.Null;

            int result = gameObject.EntityLow;

            Assert.Equal(0, result);
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     When only <c>EntityVersion = 1</c> and <c>WorldID = 0</c>, the result
        ///     must equal 1 (version occupies the low 16 bits).
        /// </summary>
        [Fact]
        public void EntityLow_VersionOne_WorldIdZero_ReturnsOne()
        {
            GameObject gameObject = new GameObject(0, 1, 0);

            int result = gameObject.EntityLow;

            Assert.Equal(ExpectedEntityLow(1, 0), result);
        }

        /// <summary>
        ///     When <c>EntityVersion = 42</c> and <c>WorldID = 0</c>, the result must equal 42.
        /// </summary>
        [Fact]
        public void EntityLow_VersionFortyTwo_WorldIdZero_ReturnsFortyTwo()
        {
            GameObject gameObject = new GameObject(0, 42, 0);

            int result = gameObject.EntityLow;

            Assert.Equal(ExpectedEntityLow(42, 0), result);
        }

        /// <summary>
        ///     Maximum version value (<c>ushort.MaxValue = 65535</c>) with <c>WorldID = 0</c>
        ///     must pack entirely into the low 16 bits.
        /// </summary>
        [Fact]
        public void EntityLow_MaxVersion_WorldIdZero_Returns65535()
        {
            GameObject gameObject = new GameObject(0, ushort.MaxValue, 0);

            int result = gameObject.EntityLow;

            Assert.Equal(ExpectedEntityLow(ushort.MaxValue, 0), result);
            Assert.Equal(65535, result);
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     When <c>EntityVersion = 0</c> and <c>WorldID = 1</c>, the result must equal
        ///     65536 (world id shifts into the high 16 bits).
        /// </summary>
        [Fact]
        public void EntityLow_VersionZero_WorldIdOne_Returns65536()
        {
            GameObject gameObject = new GameObject(1, 0, 0);

            int result = gameObject.EntityLow;

            Assert.Equal(ExpectedEntityLow(0, 1), result);
            Assert.Equal(65536, result);
        }

        /// <summary>
        ///     <c>WorldID = 10</c> with <c>EntityVersion = 0</c> must return <c>10 * 65536</c>.
        /// </summary>
        [Fact]
        public void EntityLow_VersionZero_WorldIdTen_Returns655360()
        {
            GameObject gameObject = new GameObject(10, 0, 0);

            int result = gameObject.EntityLow;

            Assert.Equal(ExpectedEntityLow(0, 10), result);
            Assert.Equal(10 * 65536, result);
        }

        /// <summary>
        ///     Maximum world id (<c>ushort.MaxValue = 65535</c>) with <c>EntityVersion = 0</c>
        ///     must set all high-16 bits to 1 producing a negative <c>int</c> (-65536).
        /// </summary>
        [Fact]
        public void EntityLow_VersionZero_MaxWorldId_ReturnsNegative65536()
        {
            GameObject gameObject = new GameObject(ushort.MaxValue, 0, 0);

            int result = gameObject.EntityLow;

            Assert.Equal(ExpectedEntityLow(0, ushort.MaxValue), result);
            Assert.Equal(-65536, result); // unchecked((int)0xFFFF0000)
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     With <c>EntityVersion = 5</c> and <c>WorldID = 3</c> the packed result is
        ///     <c>5 | (3 &lt;&lt; 16) = 196613</c>.
        /// </summary>
        [Fact]
        public void EntityLow_Version5_WorldId3_Returns196613()
        {
            GameObject gameObject = new GameObject(3, 5, 0);

            int result = gameObject.EntityLow;

            Assert.Equal(ExpectedEntityLow(5, 3), result);
            Assert.Equal(196613, result);
        }

        /// <summary>
        ///     With <c>EntityVersion = 0x1234</c> and <c>WorldID = 0x5678</c>
        ///     the packed result must be <c>0x56781234 = 1450762804</c>.
        /// </summary>
        [Fact]
        public void EntityLow_Version0x1234_WorldId0x5678_ReturnsCorrectPacked()
        {
            GameObject gameObject = new GameObject(0x5678, 0x1234, 0);

            int result = gameObject.EntityLow;

            Assert.Equal(ExpectedEntityLow(0x1234, 0x5678), result);
            Assert.Equal(unchecked(0x56781234), result);
        }

        /// <summary>
        ///     Both fields at maximum value (<c>ushort.MaxValue</c>) pack to all-ones = -1 as a
        ///     signed 32-bit integer.
        /// </summary>
        [Fact]
        public void EntityLow_MaxVersionMaxWorldId_ReturnsNegativeOne()
        {
            GameObject gameObject = new GameObject(ushort.MaxValue, ushort.MaxValue, 0);

            int result = gameObject.EntityLow;

            Assert.Equal(ExpectedEntityLow(ushort.MaxValue, ushort.MaxValue), result);
            Assert.Equal(-1, result); // unchecked((int)0xFFFFFFFF)
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     <c>EntityLow</c> must NOT be influenced by <c>EntityID</c>.
        ///     Two instances with the same version and world id but different entity ids must
        ///     return the same <c>EntityLow</c>.
        /// </summary>
        [Fact]
        public void EntityLow_DifferentEntityIDs_SameVersionAndWorldId_ReturnsSameValue()
        {
            GameObject go1 = new GameObject(2, 7, 0);
            GameObject go2 = new GameObject(2, 7, 999);
            GameObject go3 = new GameObject(2, 7, int.MaxValue);

            Assert.Equal(go1.EntityLow, go2.EntityLow);
            Assert.Equal(go1.EntityLow, go3.EntityLow);
        }

        /// <summary>
        ///     Changing only <c>EntityID</c> while keeping version and world id identical
        ///     must produce the same <c>EntityLow</c>.
        /// </summary>
        [Fact]
        public void EntityLow_IsIndependentOf_EntityID()
        {
            const ushort version = 100;
            const ushort worldId = 50;
            int expected = ExpectedEntityLow(version, worldId);

            foreach (int entityId in new[] {0, 1, 42, 1000, int.MaxValue})
            {
                GameObject go = new GameObject(worldId, version, entityId);
                Assert.Equal(expected, go.EntityLow);
            }
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     The value returned by <see cref="GameObject.EntityLow" /> must exactly match the
        ///     <c>EntityLow</c> field of an <see cref="EntityHighLow" /> struct that has
        ///     <c>EntityID</c> set to the same bytes (i.e. same underlying bit pattern).
        /// </summary>
        [Fact]
        public void EntityLow_MatchesEntityHighLowField_SameBitPattern()
        {
            ushort version = 0xABCD;
            ushort worldId = 0x1234;
            GameObject go = new GameObject(worldId, version, 77);

            EntityHighLow ehl = new EntityHighLow();
            ehl.EntityID = go.EntityID; // same first 4 bytes
            ehl.EntityLow = ExpectedEntityLow(version, worldId); // manually packed

            Assert.Equal(ehl.EntityLow, go.EntityLow);
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     Two instances with different <c>EntityVersion</c> values (and <c>WorldID = 0</c>)
        ///     must return different <c>EntityLow</c> values.
        /// </summary>
        [Fact]
        public void EntityLow_DifferentVersions_ProduceDifferentValues_WhenWorldIdIsZero()
        {
            GameObject go1 = new GameObject(0, 10, 0);
            GameObject go2 = new GameObject(0, 20, 0);

            Assert.NotEqual(go1.EntityLow, go2.EntityLow);
        }

        /// <summary>
        ///     Two instances with different <c>WorldID</c> values (and <c>EntityVersion = 0</c>)
        ///     must return different <c>EntityLow</c> values.
        /// </summary>
        [Fact]
        public void EntityLow_DifferentWorldIds_ProduceDifferentValues_WhenVersionIsZero()
        {
            GameObject go1 = new GameObject(1, 0, 0);
            GameObject go2 = new GameObject(2, 0, 0);

            Assert.NotEqual(go1.EntityLow, go2.EntityLow);
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     For several (version, worldId) pairs the property must return the expected packed
        ///     integer computed by <c>ExpectedEntityLow</c>.
        /// </summary>
        [Theory, InlineData(0, 0, 0), InlineData(1, 0, 1), InlineData(0, 1, 65536), InlineData(1, 1, 65537), InlineData(255, 0, 255), InlineData(0, 255, unchecked((int) (255u << 16))), InlineData(100, 200, unchecked((int) (100u | (200u << 16)))), InlineData(0xFFFF, 0, 65535), InlineData(0, 0xFFFF, unchecked((int) 0xFFFF0000)), InlineData(0xFFFF, 0xFFFF, -1)]
        public void EntityLow_Theory_VersionAndWorldId_ReturnExpected(
            int version, int worldId, int expected)
        {
            GameObject go = new GameObject(
                (ushort) worldId,
                (ushort) version,
                0);

            int result = go.EntityLow;

            Assert.Equal(expected, result);
        }
    }
}