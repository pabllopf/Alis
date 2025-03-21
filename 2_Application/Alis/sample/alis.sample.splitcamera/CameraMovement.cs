// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CameraMovement.cs
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

using Alis.Core.Aspect.Data.Mapping;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.EcsOld.Component;
using Alis.Core.EcsOld.Component.Render;

namespace Alis.Sample.SplitCamera
{
    /// <summary>
    ///     The camera movement class
    /// </summary>
    /// <seealso cref="AComponent" />
    public class CameraMovement : AComponent
    {
        /// <summary>
        ///     The speed
        /// </summary>
        private const float Speed = 1.0f;

        /// <summary>
        ///     The camera
        /// </summary>
        private Camera _camera;

        /// <summary>
        ///     Ons the start
        /// </summary>
        public override void OnStart()
        {
            _camera = GameObject.Get<Camera>();
        }

        /// <summary>
        ///     Ons the press down key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressDownKey(Keys key)
        {
            if (key == Keys.D)
            {
                GameObject.Transform = new Transform(new Vector2F(GameObject.Transform.Position.X + 1, GameObject.Transform.Position.Y), GameObject.Transform.Rotation, GameObject.Transform.Scale);
                Logger.Info(GameObject.Transform.Position.X + " " + GameObject.Transform.Position.Y + " " + GameObject.Transform.Rotation);
            }

            if (key == Keys.A)
            {
                GameObject.Transform = new Transform(new Vector2F(GameObject.Transform.Position.X - 1, GameObject.Transform.Position.Y), GameObject.Transform.Rotation, GameObject.Transform.Scale);
                Logger.Info(GameObject.Transform.Position.X + " " + GameObject.Transform.Position.Y + " " + GameObject.Transform.Rotation);
            }

            if (key == Keys.W)
            {
                GameObject.Transform = new Transform(new Vector2F(GameObject.Transform.Position.X, GameObject.Transform.Position.Y - 1), GameObject.Transform.Rotation, GameObject.Transform.Scale);
                Logger.Info(GameObject.Transform.Position.X + " " + GameObject.Transform.Position.Y + " " + GameObject.Transform.Rotation);
            }

            if (key == Keys.S)
            {
                GameObject.Transform = new Transform(new Vector2F(GameObject.Transform.Position.X, GameObject.Transform.Position.Y + 1), GameObject.Transform.Rotation, GameObject.Transform.Scale);
                Logger.Info(GameObject.Transform.Position.X + " " + GameObject.Transform.Position.Y + " " + GameObject.Transform.Rotation);
            }
        }
    }
}