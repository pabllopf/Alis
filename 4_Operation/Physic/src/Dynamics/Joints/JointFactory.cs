// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JointFactory.cs
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

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     An easy to use factory for using joints.
    /// </summary>
    public static class JointFactory
    {
        /// <summary>
        ///     Creates the motor joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        /// <returns>The joint</returns>
        public static MotorJoint CreateMotorJoint(World world, Body bodyA, Body bodyB, bool useWorldCoordinates = false)
        {
            MotorJoint joint = new MotorJoint(bodyA, bodyB, useWorldCoordinates);
            world.Add(joint);
            return joint;
        }

        /// <summary>
        ///     Creates the revolute joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="anchorA">The anchor</param>
        /// <param name="anchorB">The anchor</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        /// <returns>The joint</returns>
        public static RevoluteJoint CreateRevoluteJoint(World world, Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, bool useWorldCoordinates = false)
        {
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, anchorA, anchorB, useWorldCoordinates);
            world.Add(joint);
            return joint;
        }

        /// <summary>
        ///     Creates the revolute joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="anchor">The anchor</param>
        /// <returns>The joint</returns>
        public static RevoluteJoint CreateRevoluteJoint(World world, Body bodyA, Body bodyB, Vector2F anchor)
        {
            Vector2F localanchorA = bodyA.GetLocalPoint(bodyB.GetWorldPoint(anchor));
            RevoluteJoint joint = new RevoluteJoint(bodyA, bodyB, localanchorA, anchor);
            world.Add(joint);
            return joint;
        }

        /// <summary>
        ///     Creates the rope joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="anchorA">The anchor</param>
        /// <param name="anchorB">The anchor</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        /// <returns>The rope joint</returns>
        public static RopeJoint CreateRopeJoint(World world, Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, bool useWorldCoordinates = false)
        {
            RopeJoint ropeJoint = new RopeJoint(bodyA, bodyB, anchorA, anchorB, useWorldCoordinates);
            world.Add(ropeJoint);
            return ropeJoint;
        }

        /// <summary>
        ///     Creates the weld joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="anchorA">The anchor</param>
        /// <param name="anchorB">The anchor</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        /// <returns>The weld joint</returns>
        public static WeldJoint CreateWeldJoint(World world, Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, bool useWorldCoordinates = false)
        {
            WeldJoint weldJoint = new WeldJoint(bodyA, bodyB, anchorA, anchorB, useWorldCoordinates);
            world.Add(weldJoint);
            return weldJoint;
        }

        /// <summary>
        ///     Creates the prismatic joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="anchor">The anchor</param>
        /// <param name="axis">The axis</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        /// <returns>The joint</returns>
        public static PrismaticJoint CreatePrismaticJoint(World world, Body bodyA, Body bodyB, Vector2F anchor, Vector2F axis, bool useWorldCoordinates = false)
        {
            PrismaticJoint joint = new PrismaticJoint(bodyA, bodyB, anchor, axis, useWorldCoordinates);
            world.Add(joint);
            return joint;
        }

        /// <summary>
        ///     Creates the wheel joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="anchor">The anchor</param>
        /// <param name="axis">The axis</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        /// <returns>The joint</returns>
        public static WheelJoint CreateWheelJoint(World world, Body bodyA, Body bodyB, Vector2F anchor, Vector2F axis, bool useWorldCoordinates = false)
        {
            WheelJoint joint = new WheelJoint(bodyA, bodyB, anchor, axis, useWorldCoordinates);
            world.Add(joint);
            return joint;
        }

        /// <summary>
        ///     Creates the wheel joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="axis">The axis</param>
        /// <returns>The wheel joint</returns>
        public static WheelJoint CreateWheelJoint(World world, Body bodyA, Body bodyB, Vector2F axis) => CreateWheelJoint(world, bodyA, bodyB, Vector2F.Zero, axis);

        /// <summary>
        ///     Creates the angle joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <returns>The angle joint</returns>
        public static AngleJoint CreateAngleJoint(World world, Body bodyA, Body bodyB)
        {
            AngleJoint angleJoint = new AngleJoint(bodyA, bodyB);
            world.Add(angleJoint);
            return angleJoint;
        }

        /// <summary>
        ///     Creates the distance joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="anchorA">The anchor</param>
        /// <param name="anchorB">The anchor</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        /// <returns>The distance joint</returns>
        public static DistanceJoint CreateDistanceJoint(World world, Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, bool useWorldCoordinates = false)
        {
            DistanceJoint distanceJoint = new DistanceJoint(bodyA, bodyB, anchorA, anchorB, useWorldCoordinates);
            world.Add(distanceJoint);
            return distanceJoint;
        }

        /// <summary>
        ///     Creates the distance joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <returns>The distance joint</returns>
        public static DistanceJoint CreateDistanceJoint(World world, Body bodyA, Body bodyB) => CreateDistanceJoint(world, bodyA, bodyB, Vector2F.Zero, Vector2F.Zero);

        /// <summary>
        ///     Creates the friction joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="anchor">The anchor</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        /// <returns>The friction joint</returns>
        public static FrictionJoint CreateFrictionJoint(World world, Body bodyA, Body bodyB, Vector2F anchor, bool useWorldCoordinates = false)
        {
            FrictionJoint frictionJoint = new FrictionJoint(bodyA, bodyB, anchor, useWorldCoordinates);
            world.Add(frictionJoint);
            return frictionJoint;
        }

        /// <summary>
        ///     Creates the friction joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <returns>The friction joint</returns>
        public static FrictionJoint CreateFrictionJoint(World world, Body bodyA, Body bodyB) => CreateFrictionJoint(world, bodyA, bodyB, Vector2F.Zero);

        /// <summary>
        ///     Creates the gear joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointA">The joint</param>
        /// <param name="jointB">The joint</param>
        /// <param name="ratio">The ratio</param>
        /// <returns>The gear joint</returns>
        public static GearJoint CreateGearJoint(World world, Body bodyA, Body bodyB, Joint jointA, Joint jointB, float ratio)
        {
            GearJoint gearJoint = new GearJoint(bodyA, bodyB, jointA, jointB, ratio);
            world.Add(gearJoint);
            return gearJoint;
        }

        /// <summary>
        ///     Creates the pulley joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="anchorA">The anchor</param>
        /// <param name="anchorB">The anchor</param>
        /// <param name="worldAnchorA">The world anchor</param>
        /// <param name="worldAnchorB">The world anchor</param>
        /// <param name="ratio">The ratio</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        /// <returns>The pulley joint</returns>
        public static PulleyJoint CreatePulleyJoint(World world, Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, Vector2F worldAnchorA, Vector2F worldAnchorB, float ratio, bool useWorldCoordinates = false)
        {
            PulleyJoint pulleyJoint = new PulleyJoint(bodyA, bodyB, anchorA, anchorB, worldAnchorA, worldAnchorB, ratio, useWorldCoordinates);
            world.Add(pulleyJoint);
            return pulleyJoint;
        }

        /// <summary>
        ///     Creates the fixed mouse joint using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="body">The body</param>
        /// <param name="worldAnchor">The world anchor</param>
        /// <returns>The joint</returns>
        public static FixedMouseJoint CreateFixedMouseJoint(World world, Body body, Vector2F worldAnchor)
        {
            FixedMouseJoint joint = new FixedMouseJoint(body, worldAnchor);
            world.Add(joint);
            return joint;
        }
    }
}