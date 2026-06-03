// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicJointTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The world physic joint test class
    /// </summary>
    public class WorldPhysicJointTest
    {
    /// <summary>
    ///     Tests that add joint should add joint to joint list
    /// </summary>
    [Fact]
    public void AddJoint_ShouldAddJointToJointList()
    {
        WorldPhysic world = new WorldPhysic(Vector2F.Zero);
        Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
        Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
        DistanceJoint joint = new DistanceJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(2, 0));

        world.Add(joint);

        Assert.Single(world.JointList);
        Assert.Contains(joint, world.JointList);
    }

    /// <summary>
    ///     Tests that remove joint should remove joint from joint list
    /// </summary>
    [Fact]
    public void RemoveJoint_ShouldRemoveJointFromJointList()
    {
        WorldPhysic world = new WorldPhysic(Vector2F.Zero);
        Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
        Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
        DistanceJoint joint = new DistanceJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(2, 0));
        world.Add(joint);

        world.Remove(joint);

        Assert.Empty(world.JointList);
    }

    /// <summary>
    ///     Tests that add null joint should throw argument null exception
    /// </summary>
    [Fact]
    public void Add_NullJoint_ShouldThrowArgumentNullException()
    {
        WorldPhysic world = new WorldPhysic();

        Assert.Throws<ArgumentNullException>(() => world.Add((Joint)null));
    }

    /// <summary>
    ///     Tests that add same joint twice should throw argument exception
    /// </summary>
    [Fact]
    public void Add_SameJointTwice_ShouldThrowArgumentException()
    {
        WorldPhysic world = new WorldPhysic();
        Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
        Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
        DistanceJoint joint = new DistanceJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(2, 0));

        world.Add(joint);

        Assert.Throws<ArgumentException>(() => world.Add(joint));
    }

    /// <summary>
    ///     Tests that add joint from wrong world should throw argument exception
    /// </summary>
    [Fact]
    public void Add_JointFromWrongWorld_ShouldThrowArgumentException()
    {
        WorldPhysic world = new WorldPhysic();
        WorldPhysic other = new WorldPhysic();
        Body bodyA = other.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
        Body bodyB = other.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
        DistanceJoint joint = new DistanceJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(2, 0));
        other.Add(joint);

        Assert.Throws<ArgumentException>(() => world.Add(joint));
    }

    /// <summary>
    ///     Tests that remove null joint should throw argument null exception
    /// </summary>
    [Fact]
    public void Remove_NullJoint_ShouldThrowArgumentNullException()
    {
        WorldPhysic world = new WorldPhysic();

        Assert.Throws<ArgumentNullException>(() => world.Remove((Joint)null));
    }

    /// <summary>
    ///     Tests that remove joint from wrong world should throw argument exception
    /// </summary>
    [Fact]
    public void Remove_JointFromWrongWorld_ShouldThrowArgumentException()
    {
        WorldPhysic world = new WorldPhysic();
        WorldPhysic other = new WorldPhysic();
        Body bodyA = other.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
        Body bodyB = other.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
        DistanceJoint joint = new DistanceJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(2, 0));
        other.Add(joint);

        Assert.Throws<ArgumentException>(() => world.Remove(joint));
    }

    /// <summary>
    ///     Tests that joint added event should fire when joint is added
    /// </summary>
    [Fact]
    public void JointAddedEvent_ShouldFire_WhenJointIsAdded()
    {
        WorldPhysic world = new WorldPhysic(Vector2F.Zero);
        Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
        Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
        DistanceJoint joint = new DistanceJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(2, 0));
        int fireCount = 0;
        world.JointAdded += (w, j) => fireCount++;

        world.Add(joint);

        Assert.Equal(1, fireCount);
    }

    /// <summary>
    ///     Tests that joint removed event should fire when joint is removed
    /// </summary>
    [Fact]
    public void JointRemovedEvent_ShouldFire_WhenJointIsRemoved()
    {
        WorldPhysic world = new WorldPhysic(Vector2F.Zero);
        Body bodyA = world.CreateBody(new Vector2F(0, 0), 0, BodyType.Dynamic);
        Body bodyB = world.CreateBody(new Vector2F(2, 0), 0, BodyType.Dynamic);
        DistanceJoint joint = new DistanceJoint(bodyA, bodyB, new Vector2F(0, 0), new Vector2F(2, 0));
        world.Add(joint);
        int fireCount = 0;
        world.JointRemoved += (w, j) => fireCount++;

        world.Remove(joint);

        Assert.Equal(1, fireCount);
    }
    }
}