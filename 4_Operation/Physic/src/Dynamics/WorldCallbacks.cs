// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldCallbacks.cs
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
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;


namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     Called for each fixture found in the query.
    ///     <returns>true: Continues the query, false: Terminate the query</returns>
    /// </summary>
    public delegate bool QueryReportFixtureDelegate(Fixture fixture);

    /// <summary>
    ///     Called for each fixture found in the query. You control how the ray cast
    ///     proceeds by returning a float:
    ///     return -1: ignore this fixture and continue
    ///     return 0: terminate the ray cast
    ///     return fraction: clip the ray to this point
    ///     return 1: don't clip the ray and continue
    ///     @param fixture the fixture hit by the ray
    ///     @param point the point of initial intersection
    ///     @param normal the normal vector at the point of intersection
    ///     @return 0 to terminate, fraction to clip the ray for closest hit, 1 to continue
    /// </summary>
    public delegate float RayCastReportFixtureDelegate(Fixture fixture, Vector2 point, Vector2 normal, float fraction);

    /// <summary>
    ///     This delegate is called when a contact is deleted
    /// </summary>
    public delegate void EndContactDelegate(Contact contact);

    /// <summary>
    ///     This delegate is called when a contact is created
    /// </summary>
    public delegate bool BeginContactDelegate(Contact contact);

    /// <summary>
    /// The pre solve delegate
    /// </summary>
    public delegate void PreSolveDelegate(Contact contact, ref Manifold oldManifold);

    /// <summary>
    /// The post solve delegate
    /// </summary>
    public delegate void PostSolveDelegate(Contact contact, ContactVelocityConstraint impulse);

    /// <summary>
    /// The fixture delegate
    /// </summary>
    public delegate void FixtureDelegate(World sender, Body body, Fixture fixture);

    /// <summary>
    /// The joint delegate
    /// </summary>
    public delegate void JointDelegate(World sender, Joint joint);

    /// <summary>
    /// The body delegate
    /// </summary>
    public delegate void BodyDelegate(World sender, Body body);

    /// <summary>
    /// The controller delegate
    /// </summary>
    public delegate void ControllerDelegate(World sender, Controller controller);

    /// <summary>
    /// The collision filter delegate
    /// </summary>
    public delegate bool CollisionFilterDelegate(Fixture fixtureA, Fixture fixtureB);

    /// <summary>
    /// The before collision event handler
    /// </summary>
    public delegate bool BeforeCollisionEventHandler(Fixture sender, Fixture other);

    /// <summary>
    /// The on collision event handler
    /// </summary>
    public delegate bool OnCollisionEventHandler(Fixture sender, Fixture other, Contact contact);

    /// <summary>
    /// The after collision event handler
    /// </summary>
    public delegate void AfterCollisionEventHandler(Fixture sender, Fixture other, Contact contact, ContactVelocityConstraint impulse);

    /// <summary>
    /// The on separation event handler
    /// </summary>
    public delegate void OnSeparationEventHandler(Fixture sender, Fixture other, Contact contact);
}