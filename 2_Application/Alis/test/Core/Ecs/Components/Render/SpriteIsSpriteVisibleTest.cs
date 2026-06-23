// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteIsSpriteVisibleTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    ///     Tests for the Sprite.IsSpriteVisible method
    /// </summary>
    public class SpriteIsSpriteVisibleTest
    {
        private const float PixelsPerMeter = 32f;
        private static readonly Vector2F CameraResolution = new Vector2F(800f, 600f);
        private static readonly Vector2F CameraPosition = new Vector2F(0f, 0f);

        /// <summary>
        ///     Tests that sprite at center of camera is visible (no rotation)
        /// </summary>
        [Fact]
        public void SpriteAtCameraCenter_ShouldBeVisible()
        {
            Vector2F spritePosition = new Vector2F(0f, 0f);
            Vector2F spriteSize = new Vector2F(32f, 32f);
            Vector2F spriteScale = new Vector2F(1f, 1f);

            bool visible = Sprite.IsSpriteVisible(spritePosition, spriteSize, spriteScale, 0f, CameraPosition, CameraResolution, PixelsPerMeter);

            Assert.True(visible);
        }

        /// <summary>
        ///     Tests that sprite far outside camera bounds on X axis is not visible
        /// </summary>
        [Fact]
        public void SpriteOutsideBoundsX_ShouldNotBeVisible()
        {
            Vector2F spritePosition = new Vector2F(50f, 0f);
            Vector2F spriteSize = new Vector2F(16f, 16f);
            Vector2F spriteScale = new Vector2F(1f, 1f);

            bool visible = Sprite.IsSpriteVisible(spritePosition, spriteSize, spriteScale, 0f, CameraPosition, CameraResolution, PixelsPerMeter);

            Assert.False(visible);
        }

        /// <summary>
        ///     Tests that sprite far outside camera bounds on Y axis is not visible
        /// </summary>
        [Fact]
        public void SpriteOutsideBoundsY_ShouldNotBeVisible()
        {
            Vector2F spritePosition = new Vector2F(0f, 40f);
            Vector2F spriteSize = new Vector2F(16f, 16f);
            Vector2F spriteScale = new Vector2F(1f, 1f);

            bool visible = Sprite.IsSpriteVisible(spritePosition, spriteSize, spriteScale, 0f, CameraPosition, CameraResolution, PixelsPerMeter);

            Assert.False(visible);
        }

        /// <summary>
        ///     Tests that sprite at the edge of camera bounds is visible
        /// </summary>
        [Fact]
        public void SpriteAtCameraEdge_ShouldBeVisible()
        {
            Vector2F spritePosition = new Vector2F(12f, 9f);
            Vector2F spriteSize = new Vector2F(32f, 32f);
            Vector2F spriteScale = new Vector2F(1f, 1f);

            bool visible = Sprite.IsSpriteVisible(spritePosition, spriteSize, spriteScale, 0f, CameraPosition, CameraResolution, PixelsPerMeter);

            Assert.True(visible);
        }

        /// <summary>
        ///     Tests that sprite with rotation near zero skips rotation adjustment
        /// </summary>
        [Fact]
        public void SpriteWithMinimalRotation_ShouldUseNoRotationBounds()
        {
            Vector2F spritePosition = new Vector2F(0f, 0f);
            Vector2F spriteSize = new Vector2F(32f, 32f);
            Vector2F spriteScale = new Vector2F(1f, 1f);

            bool visible = Sprite.IsSpriteVisible(spritePosition, spriteSize, spriteScale, 0.00005f, CameraPosition, CameraResolution, PixelsPerMeter);

            Assert.True(visible);
        }

        /// <summary>
        ///     Tests that sprite with rotation adjusts bounding box correctly
        /// </summary>
        [Fact]
        public void SpriteWithRotation_ShouldAdjustBounds()
        {
            Vector2F spritePosition = new Vector2F(0f, 0f);
            Vector2F spriteSize = new Vector2F(32f, 32f);
            Vector2F spriteScale = new Vector2F(1f, 1f);

            bool visible = Sprite.IsSpriteVisible(spritePosition, spriteSize, spriteScale, 45f, CameraPosition, CameraResolution, PixelsPerMeter);

            Assert.True(visible);
        }

        /// <summary>
        ///     Tests that large sprite just outside camera on X is not visible
        /// </summary>
        [Fact]
        public void LargeSpriteFarOutsideX_ShouldNotBeVisible()
        {
            Vector2F spritePosition = new Vector2F(20f, 0f);
            Vector2F spriteSize = new Vector2F(16f, 16f);
            Vector2F spriteScale = new Vector2F(1f, 1f);

            bool visible = Sprite.IsSpriteVisible(spritePosition, spriteSize, spriteScale, 0f, CameraPosition, CameraResolution, PixelsPerMeter);

            Assert.False(visible);
        }

        /// <summary>
        ///     Tests that rotated sprite outside bounds is not visible
        /// </summary>
        [Fact]
        public void RotatedSpriteOutsideBounds_ShouldNotBeVisible()
        {
            Vector2F spritePosition = new Vector2F(20f, 0f);
            Vector2F spriteSize = new Vector2F(64f, 64f);
            Vector2F spriteScale = new Vector2F(1f, 1f);

            bool visible = Sprite.IsSpriteVisible(spritePosition, spriteSize, spriteScale, 90f, CameraPosition, CameraResolution, PixelsPerMeter);

            Assert.False(visible);
        }

        /// <summary>
        ///     Tests that sprite far outside on negative X is not visible
        /// </summary>
        [Fact]
        public void SpriteOutsideNegativeX_ShouldNotBeVisible()
        {
            Vector2F spritePosition = new Vector2F(-50f, 0f);
            Vector2F spriteSize = new Vector2F(16f, 16f);
            Vector2F spriteScale = new Vector2F(1f, 1f);

            bool visible = Sprite.IsSpriteVisible(spritePosition, spriteSize, spriteScale, 0f, CameraPosition, CameraResolution, PixelsPerMeter);

            Assert.False(visible);
        }
    }
}
