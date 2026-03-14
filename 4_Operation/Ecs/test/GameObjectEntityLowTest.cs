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
        // Helpers
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     Computes the expected <c>EntityLow</c> value from its two component fields.
        ///     On little-endian architectures <c>EntityVersion</c> occupies the low 16 bits
        ///     and <c>WorldID</c> occupies the high 16 bits.
        /// </summary>
        private static int ExpectedEntityLow(ushort version, ushort worldId)
            => (int)((uint)version | ((uint)worldId << 16));

        // ─────────────────────────────────────────────────────────────────────
        // Default / zero state
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     A default-constructed <see cref="GameObject" /> has EntityVersion = 0 and
        ///     WorldID = 0, so <c>EntityLow</c> must return 0.
        /// </summary>
        [Fact]
        public void EntityLow_DefaultGameObject_ReturnsZero()
        {
            // Arrange
            GameObject gameObject = new GameObject();

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     <c>default(GameObject)</c> must also yield <c>EntityLow</c> = 0.
        /// </summary>
        [Fact]
        public void EntityLow_DefaultKeyword_ReturnsZero()
        {
            // Arrange
            GameObject gameObject = default(GameObject);

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     <see cref="GameObject.Null" /> has all fields zeroed, so <c>EntityLow</c> = 0.
        /// </summary>
        [Fact]
        public void EntityLow_NullGameObject_ReturnsZero()
        {
            // Arrange
            GameObject gameObject = GameObject.Null;

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(0, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // Only EntityVersion set
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     When only <c>EntityVersion = 1</c> and <c>WorldID = 0</c>, the result
        ///     must equal 1 (version occupies the low 16 bits).
        /// </summary>
        [Fact]
        public void EntityLow_VersionOne_WorldIdZero_ReturnsOne()
        {
            // Arrange – worldId=0, version=1, entityId=0
            GameObject gameObject = new GameObject(worldId: 0, version: 1, entityId: 0);

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(ExpectedEntityLow(version: 1, worldId: 0), result);
        }

        /// <summary>
        ///     When <c>EntityVersion = 42</c> and <c>WorldID = 0</c>, the result must equal 42.
        /// </summary>
        [Fact]
        public void EntityLow_VersionFortyTwo_WorldIdZero_ReturnsFortyTwo()
        {
            // Arrange
            GameObject gameObject = new GameObject(worldId: 0, version: 42, entityId: 0);

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(ExpectedEntityLow(version: 42, worldId: 0), result);
        }

        /// <summary>
        ///     Maximum version value (<c>ushort.MaxValue = 65535</c>) with <c>WorldID = 0</c>
        ///     must pack entirely into the low 16 bits.
        /// </summary>
        [Fact]
        public void EntityLow_MaxVersion_WorldIdZero_Returns65535()
        {
            // Arrange
            GameObject gameObject = new GameObject(worldId: 0, version: ushort.MaxValue, entityId: 0);

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(ExpectedEntityLow(version: ushort.MaxValue, worldId: 0), result);
            Assert.Equal(65535, result);
        }

        // ─────────────────────────────────────────────────────────────────────
        // Only WorldID set
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     When <c>EntityVersion = 0</c> and <c>WorldID = 1</c>, the result must equal
        ///     65536 (world id shifts into the high 16 bits).
        /// </summary>
        [Fact]
        public void EntityLow_VersionZero_WorldIdOne_Returns65536()
        {
            // Arrange
            GameObject gameObject = new GameObject(worldId: 1, version: 0, entityId: 0);

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(ExpectedEntityLow(version: 0, worldId: 1), result);
            Assert.Equal(65536, result);
        }

        /// <summary>
        ///     <c>WorldID = 10</c> with <c>EntityVersion = 0</c> must return <c>10 * 65536</c>.
        /// </summary>
        [Fact]
        public void EntityLow_VersionZero_WorldIdTen_Returns655360()
        {
            // Arrange
            GameObject gameObject = new GameObject(worldId: 10, version: 0, entityId: 0);

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(ExpectedEntityLow(version: 0, worldId: 10), result);
            Assert.Equal(10 * 65536, result);
        }

        /// <summary>
        ///     Maximum world id (<c>ushort.MaxValue = 65535</c>) with <c>EntityVersion = 0</c>
        ///     must set all high-16 bits to 1 producing a negative <c>int</c> (-65536).
        /// </summary>
        [Fact]
        public void EntityLow_VersionZero_MaxWorldId_ReturnsNegative65536()
        {
            // Arrange
            GameObject gameObject = new GameObject(worldId: ushort.MaxValue, version: 0, entityId: 0);

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(ExpectedEntityLow(version: 0, worldId: ushort.MaxValue), result);
            Assert.Equal(-65536, result); // unchecked((int)0xFFFF0000)
        }

        // ─────────────────────────────────────────────────────────────────────
        // Both fields set
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     With <c>EntityVersion = 5</c> and <c>WorldID = 3</c> the packed result is
        ///     <c>5 | (3 &lt;&lt; 16) = 196613</c>.
        /// </summary>
        [Fact]
        public void EntityLow_Version5_WorldId3_Returns196613()
        {
            // Arrange
            GameObject gameObject = new GameObject(worldId: 3, version: 5, entityId: 0);

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(ExpectedEntityLow(version: 5, worldId: 3), result);
            Assert.Equal(196613, result);
        }

        /// <summary>
        ///     With <c>EntityVersion = 0x1234</c> and <c>WorldID = 0x5678</c>
        ///     the packed result must be <c>0x56781234 = 1450762804</c>.
        /// </summary>
        [Fact]
        public void EntityLow_Version0x1234_WorldId0x5678_ReturnsCorrectPacked()
        {
            // Arrange
            GameObject gameObject = new GameObject(worldId: 0x5678, version: 0x1234, entityId: 0);

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(ExpectedEntityLow(version: 0x1234, worldId: 0x5678), result);
            Assert.Equal(unchecked((int)0x56781234), result);
        }

        /// <summary>
        ///     Both fields at maximum value (<c>ushort.MaxValue</c>) pack to all-ones = -1 as a
        ///     signed 32-bit integer.
        /// </summary>
        [Fact]
        public void EntityLow_MaxVersionMaxWorldId_ReturnsNegativeOne()
        {
            // Arrange
            GameObject gameObject = new GameObject(worldId: ushort.MaxValue, version: ushort.MaxValue, entityId: 0);

            // Act
            int result = gameObject.EntityLow;

            // Assert
            Assert.Equal(ExpectedEntityLow(version: ushort.MaxValue, worldId: ushort.MaxValue), result);
            Assert.Equal(-1, result); // unchecked((int)0xFFFFFFFF)
        }

        // ─────────────────────────────────────────────────────────────────────
        // EntityID independence
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     <c>EntityLow</c> must NOT be influenced by <c>EntityID</c>.
        ///     Two instances with the same version and world id but different entity ids must
        ///     return the same <c>EntityLow</c>.
        /// </summary>
        [Fact]
        public void EntityLow_DifferentEntityIDs_SameVersionAndWorldId_ReturnsSameValue()
        {
            // Arrange
            GameObject go1 = new GameObject(worldId: 2, version: 7, entityId: 0);
            GameObject go2 = new GameObject(worldId: 2, version: 7, entityId: 999);
            GameObject go3 = new GameObject(worldId: 2, version: 7, entityId: int.MaxValue);

            // Act & Assert
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
            // Arrange
            const ushort version = 100;
            const ushort worldId = 50;
            int expected = ExpectedEntityLow(version, worldId);

            // Act & Assert – EntityID varies while version and worldId stay constant
            foreach (int entityId in new[] { 0, 1, 42, 1000, int.MaxValue })
            {
                GameObject go = new GameObject(worldId: worldId, version: version, entityId: entityId);
                Assert.Equal(expected, go.EntityLow);
            }
        }

        // ─────────────────────────────────────────────────────────────────────
        // Consistency with EntityHighLow
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     The value returned by <see cref="GameObject.EntityLow" /> must exactly match the
        ///     <c>EntityLow</c> field of an <see cref="EntityHighLow" /> struct that has
        ///     <c>EntityID</c> set to the same bytes (i.e. same underlying bit pattern).
        /// </summary>
        [Fact]
        public void EntityLow_MatchesEntityHighLowField_SameBitPattern()
        {
            // Arrange
            ushort version = 0xABCD;
            ushort worldId = 0x1234;
            GameObject go = new GameObject(worldId: worldId, version: version, entityId: 77);

            EntityHighLow ehl = new EntityHighLow();
            ehl.EntityID = go.EntityID;                         // same first 4 bytes
            ehl.EntityLow = ExpectedEntityLow(version, worldId); // manually packed

            // Act & Assert
            Assert.Equal(ehl.EntityLow, go.EntityLow);
        }

        // ─────────────────────────────────────────────────────────────────────
        // Distinct versions produce distinct EntityLow values (when WorldID = 0)
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     Two instances with different <c>EntityVersion</c> values (and <c>WorldID = 0</c>)
        ///     must return different <c>EntityLow</c> values.
        /// </summary>
        [Fact]
        public void EntityLow_DifferentVersions_ProduceDifferentValues_WhenWorldIdIsZero()
        {
            // Arrange
            GameObject go1 = new GameObject(worldId: 0, version: 10, entityId: 0);
            GameObject go2 = new GameObject(worldId: 0, version: 20, entityId: 0);

            // Act & Assert
            Assert.NotEqual(go1.EntityLow, go2.EntityLow);
        }

        /// <summary>
        ///     Two instances with different <c>WorldID</c> values (and <c>EntityVersion = 0</c>)
        ///     must return different <c>EntityLow</c> values.
        /// </summary>
        [Fact]
        public void EntityLow_DifferentWorldIds_ProduceDifferentValues_WhenVersionIsZero()
        {
            // Arrange
            GameObject go1 = new GameObject(worldId: 1, version: 0, entityId: 0);
            GameObject go2 = new GameObject(worldId: 2, version: 0, entityId: 0);

            // Act & Assert
            Assert.NotEqual(go1.EntityLow, go2.EntityLow);
        }

        // ─────────────────────────────────────────────────────────────────────
        // Parameterised round-trip
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     For several (version, worldId) pairs the property must return the expected packed
        ///     integer computed by <c>ExpectedEntityLow</c>.
        /// </summary>
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 65536)]
        [InlineData(1, 1, 65537)]
        [InlineData(255, 0, 255)]
        [InlineData(0, 255, unchecked((int)(255u << 16)))]
        [InlineData(100, 200, unchecked((int)(100u | (200u << 16))))]
        [InlineData(0xFFFF, 0, 65535)]
        [InlineData(0, 0xFFFF, unchecked((int)0xFFFF0000))]
        [InlineData(0xFFFF, 0xFFFF, -1)]
        public void EntityLow_Theory_VersionAndWorldId_ReturnExpected(
            int version, int worldId, int expected)
        {
            // Arrange
            GameObject go = new GameObject(
                worldId: (ushort)worldId,
                version: (ushort)version,
                entityId: 0);

            // Act
            int result = go.EntityLow;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}

