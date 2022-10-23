// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BallController.cs
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
using Alis.Core.Component;
using Alis.Core.Component.Collider;
using Alis.Core.Entity;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.PingPong
{
    /// <summary>
    /// The ball controller class
    /// </summary>
    /// <seealso cref="ComponentBase"/>
    public class BallController : ComponentBase
    {
        private BoxCollider boxCollider;
        
        /// <summary>
        /// Starts this instance
        /// </summary>
        public override void Start()
        {
            boxCollider = GameObject.GetComponent<BoxCollider>();
            boxCollider.Body.OnCollision += OnCollision;
        }

        private void OnCollision(Fixture fixturebfixturea, Fixture fixtureb, Contact contact)
        {
            //Console.WriteLine((((GameObject) fixturea.Body.UserData)!).Name);
            //Console.WriteLine((((GameObject) fixtureb.Body.UserData)!).Name);
            //Console.WriteLine((((GameObject) contact.FixtureA.Body.UserData)!).Name);
            //Console.WriteLine((((GameObject) contact.FixtureB.Body.UserData)!).Name);
            
            if ((((GameObject) fixtureb.Body.UserData)!).Name.Equals("leftWall"))
            {
                Console.WriteLine("CONTACT WITH leftWall");
            }
            
            if ((((GameObject) fixtureb.Body.UserData)!).Name.Equals("rightWall"))
            {
                Console.WriteLine("CONTACT WITH rightWall");
            }
        }

        /// <summary>
        /// Updates this instance
        /// </summary>
        public override void Update()
        {
        }
    }
}