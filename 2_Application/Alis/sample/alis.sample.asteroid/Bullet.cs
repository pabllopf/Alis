// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Bullet.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components;

namespace Alis.Sample.Asteroid
{
    /// <summary>
    ///     The bullet class
    /// </summary>
    public struct Bullet : IOnCollisionEnter
    {
        /// <summary>
        ///     Ons the collision enter using the specified other
        /// </summary>
        /// <param name="other">The other</param>
        public void OnCollisionEnter(IGameObject other)
        {
            if (other.Has<Info>())
            {
                ref Info gameObject = ref other.Get<Info>();

                if (gameObject.Tag == "Asteroid")
                {
                    //Logger.Info("Bullet hit an asteroid and will decrease its health.");
                    other.Get<Asteroid>().DecreaseHealth();
                    //Context.SceneManager.CurrentWorld.(this.GameObject);
                }

                if (gameObject.Tag == "Wall")
                {
                    //Logger.Info("Bullet hit a wall and will be destroyed.");
                    //this.GameObject.Context.SceneManager.DestroyGameObject(this.GameObject);
                }
            }
        }
    }
}