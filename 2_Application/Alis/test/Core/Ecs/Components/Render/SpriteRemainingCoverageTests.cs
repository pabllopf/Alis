// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The sprite remaining coverage tests class
    /// </summary>
    public class SpriteRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that sprite record struct stores context name file and depth
        /// </summary>
        [Fact]
        public void SpriteRecordStruct_StoresValues()
        {
            Context context = new Context();
            Sprite sprite = new Sprite(context, "hero.png", 5);

            Assert.Same(context, sprite.Context);
            Assert.Equal("hero.png", sprite.NameFile);
            Assert.Equal(5, sprite.Depth);
        }

        /// <summary>
        ///     Tests that sprite depth property round trips
        /// </summary>
        [Fact]
        public void Depth_Property_RoundTrips()
        {
            Sprite sprite = new Sprite(new Context(), "hero.png", 0);

            sprite.Depth = 7;

            Assert.Equal(7, sprite.Depth);
        }

        /// <summary>
        ///     Tests that sprite name file property round trips
        /// </summary>
        [Fact]
        public void NameFile_Property_RoundTrips()
        {
            Sprite sprite = new Sprite(new Context(), "hero.png", 0);

            sprite.NameFile = "villain.png";

            Assert.Equal("villain.png", sprite.NameFile);
        }

        /// <summary>
        ///     Tests that sprite on update does not throw
        /// </summary>
        [Fact]
        public void OnUpdate_DoesNotThrow()
        {
            Sprite sprite = new Sprite(new Context(), "hero.png", 0);

            sprite.OnUpdate(null);
        }

        /// <summary>
        ///     Tests that sprite on start does not throw
        /// </summary>
        [Fact]
        public void OnStart_DoesNotThrow()
        {
            Sprite sprite = new Sprite(new Context(), "hero.png", 0);

            sprite.OnStart(null);
        }
    }
}
