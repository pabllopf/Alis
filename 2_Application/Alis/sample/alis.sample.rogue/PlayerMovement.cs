// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlayerMovement.cs
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
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;

namespace Alis.Sample.Rogue
{
    /// <summary>
    ///     The player movement class
    /// </summary>
    /// <seealso cref="Component" />
    public class PlayerMovement : Component
    {
        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
        }

        /// <summary>
        ///     Ons the release key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnReleaseKey(SdlKeycode key)
        {
            if (key == SdlKeycode.SdlkD)
            {
            }

            if (key == SdlKeycode.SdlkA)
            {
            }
        }

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(SdlKeycode key)
        {
            if (key == SdlKeycode.SdlkD)
            {
                GameObject.Transform = new Transform(new Vector2(GameObject.Transform.Position.X + 1, GameObject.Transform.Position.Y), GameObject.Transform.Rotation, GameObject.Transform.Scale);
                Console.WriteLine(GameObject.Transform.Position.X + " " + GameObject.Transform.Position.Y + " " + GameObject.Transform.Rotation.Angle);
            }

            if (key == SdlKeycode.SdlkA)
            {
                GameObject.Transform = new Transform(new Vector2(GameObject.Transform.Position.X - 1, GameObject.Transform.Position.Y), GameObject.Transform.Rotation, GameObject.Transform.Scale);
                Console.WriteLine(GameObject.Transform.Position.X + " " + GameObject.Transform.Position.Y + " " + GameObject.Transform.Rotation.Angle);
            }

            if (key == SdlKeycode.SdlkW)
            {
                GameObject.Transform = new Transform(new Vector2(GameObject.Transform.Position.X, GameObject.Transform.Position.Y - 1), GameObject.Transform.Rotation, GameObject.Transform.Scale);
                Console.WriteLine(GameObject.Transform.Position.X + " " + GameObject.Transform.Position.Y + " " + GameObject.Transform.Rotation.Angle);
            }

            if (key == SdlKeycode.SdlkS)
            {
                GameObject.Transform = new Transform(new Vector2(GameObject.Transform.Position.X, GameObject.Transform.Position.Y + 1), GameObject.Transform.Rotation, GameObject.Transform.Scale);
                Console.WriteLine(GameObject.Transform.Position.X + " " + GameObject.Transform.Position.Y + " " + GameObject.Transform.Rotation.Angle);
            }
        }
    }
}