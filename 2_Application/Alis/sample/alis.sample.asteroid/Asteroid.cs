// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Asteroid.cs
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
using System.Numerics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Audio;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Entity;

namespace Alis.Sample.Asteroid
{
    public class Asteroid : AComponent
    {
        private BoxCollider rb;
        public float speed;

        public GameObject[] subAsteroids;
        public int numberOfAsteroids;
        
        private static readonly Random random = new Random();

        // Start is called before the first frame update
        private void Start () {
            rb = this.GameObject.Get<BoxCollider>();


            rb.Body.LinearVelocity = new Vector2F(
                (float) (random.NextDouble() * 2 - 1),
                (float) (random.NextDouble() * 2 - 1)
            );
            rb.Body.LinearVelocity.Normalize();
            rb.Body.LinearVelocity *= speed;

            rb.AngularVelocity = (float)(random.NextDouble() * 100 - 50);
        }

        public override void OnCollisionEnter(GameObject gameObject)
        {
            if (gameObject.Tag == "Bullet")
            {
                
            }
            
            if (gameObject.Tag == "Player")
            {
            }
        }

        public override void OnCollisionExit(GameObject gameObject)
        {
            
        }
    }
}