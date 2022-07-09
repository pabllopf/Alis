// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Contact.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The class manages contact between two shapes. A contact exists for each overlapping
    ///     AABB in the broad-phase (except if filtered). Therefore a contact object may exist
    ///     that has no contact points.
    /// </summary>
    public abstract class Contact
    {
        /// <summary>
        ///     The collision flags enum
        /// </summary>
        [Flags]
        public enum CollisionFlags
        {
            /// <summary>
            ///     The non solid collision flags
            /// </summary>
            NonSolid = 0x0001,

            /// <summary>
            ///     The slow collision flags
            /// </summary>
            Slow = 0x0002,

            /// <summary>
            ///     The island collision flags
            /// </summary>
            Island = 0x0004,

            /// <summary>
            ///     The toi collision flags
            /// </summary>
            Toi = 0x0008,

            /// <summary>
            ///     The touch collision flags
            /// </summary>
            Touch = 0x0010
        }

        /// <summary>
        ///     The shape type count
        /// </summary>
        public static readonly ContactRegister[][] SRegisters =
            new ContactRegister[(int) ShapeType.ShapeTypeCount][ /*(int)ShapeType.ShapeTypeCount*/];

        /// <summary>
        ///     The manifold
        /// </summary>
        private Manifold manifold = new Manifold();

        /// <summary>
        ///     The collide shape function
        /// </summary>
        internal CollideShapeDelegate CollideShapeFunction;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Contact" /> class
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Contact" /> class
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="fB">The </param>
        public Contact(Fixture fA, Fixture fB)
        {
            Flags = 0;

            if (fA.IsSensor || fB.IsSensor)
            {
                Flags |= CollisionFlags.NonSolid;
            }

            FixtureA = fA;
            FixtureB = fB;

            Manifold.PointCount = 0;

            Prev = null;
            Next = null;

            NodeA = new ContactEdge();
            NodeB = new ContactEdge();
        }

        /// <summary>
        ///     The initialized
        /// </summary>
        public static bool SInitialized { get; set; }

        /// <summary>
        ///     The flags
        /// </summary>
        public CollisionFlags Flags { get; set; }

        // World pool and list pointers.

        /// <summary>
        ///     The prev
        /// </summary>
        public Contact Prev { get; set; }

        /// <summary>
        ///     The next
        /// </summary>
        public Contact Next { get; set; }

        // Nodes for connecting bodies.

        /// <summary>
        ///     The node
        /// </summary>
        public ContactEdge NodeA { get; }

        /// <summary>
        ///     The node
        /// </summary>
        public ContactEdge NodeB { get; }

        /// <summary>
        ///     The toi
        /// </summary>
        public float Toi { get; set; }

        /// <summary>
        ///     Get the contact manifold.
        /// </summary>
        public Manifold Manifold => manifold;

        /// <summary>
        ///     Is this contact solid?
        /// </summary>
        /// <returns>True if this contact should generate a response.</returns>
        public bool IsSolid => (Flags & CollisionFlags.NonSolid) == 0;

        /// <summary>
        ///     Are fixtures touching?
        /// </summary>
        public bool AreTouching => (Flags & CollisionFlags.Touch) == CollisionFlags.Touch;

        /// <summary>
        ///     Get the first fixture in this contact.
        /// </summary>
        public Fixture FixtureA { get; }

        /// <summary>
        ///     Get the second fixture in this contact.
        /// </summary>
        public Fixture FixtureB { get; }

        /// <summary>
        ///     Adds the type using the specified create fcn
        /// </summary>
        /// <param name="createFcn">The create fcn</param>
        /// <param name="contactDestroyFcn">The destory fcn</param>
        /// <param name="type1">The type</param>
        /// <param name="type2">The type</param>
        public static void AddType(ContactCreateFcn createFcn, ContactDestroyFcn contactDestroyFcn,
            ShapeType type1, ShapeType type2)
        {
            Box2DXDebug.Assert(ShapeType.UnknownShape < type1 && type1 < ShapeType.ShapeTypeCount);
            Box2DXDebug.Assert(ShapeType.UnknownShape < type2 && type2 < ShapeType.ShapeTypeCount);

            if (SRegisters[(int) type1] == null)
                SRegisters[(int) type1] = new ContactRegister[(int) ShapeType.ShapeTypeCount];

            SRegisters[(int) type1][(int) type2].CreateFcn = createFcn;
            SRegisters[(int) type1][(int) type2].DestroyFcn = contactDestroyFcn;
            SRegisters[(int) type1][(int) type2].Primary = true;

            if (type1 != type2)
            {
                SRegisters[(int) type2][(int) type1].CreateFcn = createFcn;
                SRegisters[(int) type2][(int) type1].DestroyFcn = contactDestroyFcn;
                SRegisters[(int) type2][(int) type1].Primary = false;
            }
        }

        /// <summary>
        ///     Initializes the registers
        /// </summary>
        public static void InitializeRegisters()
        {
            AddType(CircleContact.Create, CircleContact.Destroy, ShapeType.CircleShape, ShapeType.CircleShape);
            AddType(PolyAndCircleContact.Create, PolyAndCircleContact.Destroy, ShapeType.PolygonShape,
                ShapeType.CircleShape);
            AddType(PolygonContact.Create, PolygonContact.Destroy, ShapeType.PolygonShape, ShapeType.PolygonShape);

            AddType(EdgeAndCircleContact.Create, EdgeAndCircleContact.Destroy, ShapeType.EdgeShape,
                ShapeType.CircleShape);
            AddType(PolyAndEdgeContact.Create, PolyAndEdgeContact.Destroy, ShapeType.PolygonShape, ShapeType.EdgeShape);
        }

        /// <summary>
        ///     Creates the fixture a
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <returns>The contact</returns>
        public static Contact Create(Fixture fixtureA, Fixture fixtureB)
        {
            if (SInitialized == false)
            {
                InitializeRegisters();
                SInitialized = true;
            }

            ShapeType type1 = fixtureA.ShapeType;
            ShapeType type2 = fixtureB.ShapeType;

            Box2DXDebug.Assert(ShapeType.UnknownShape < type1 && type1 < ShapeType.ShapeTypeCount);
            Box2DXDebug.Assert(ShapeType.UnknownShape < type2 && type2 < ShapeType.ShapeTypeCount);

            ContactCreateFcn createFcn = SRegisters[(int) type1][(int) type2].CreateFcn;
            if (createFcn != null)
            {
                if (SRegisters[(int) type1][(int) type2].Primary)
                {
                    return createFcn(fixtureA, fixtureB);
                }

                return createFcn(fixtureB, fixtureA);
            }

            return null;
        }

        /// <summary>
        ///     Destroys the contact
        /// </summary>
        /// <param name="contact">The contact</param>
        public static void Destroy(ref Contact contact)
        {
            Box2DXDebug.Assert(SInitialized);

            if (contact.Manifold.PointCount > 0)
            {
                contact.FixtureA.Body.WakeUp();
                contact.FixtureB.Body.WakeUp();
            }

            ShapeType typeA = contact.FixtureA.ShapeType;
            ShapeType typeB = contact.FixtureB.ShapeType;

            Box2DXDebug.Assert(ShapeType.UnknownShape < typeA && typeA < ShapeType.ShapeTypeCount);
            Box2DXDebug.Assert(ShapeType.UnknownShape < typeB && typeB < ShapeType.ShapeTypeCount);

            ContactDestroyFcn destroyFcn = SRegisters[(int) typeA][(int) typeB].DestroyFcn;
            destroyFcn(ref contact);
        }

        /// <summary>
        ///     Updates the listener
        /// </summary>
        /// <param name="listener">The listener</param>
        public void Update(ContactListener listener)
        {
            Manifold oldManifold = Manifold.Clone();

            Evaluate();

            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;

            int oldCount = oldManifold.PointCount;
            int newCount = Manifold.PointCount;

            if (newCount == 0 && oldCount > 0)
            {
                bodyA.WakeUp();
                bodyB.WakeUp();
            }

            // Slow contacts don't generate TOI events.
            if (bodyA.IsStatic() || bodyA.IsBullet() || bodyB.IsStatic() || bodyB.IsBullet())
            {
                Flags &= ~CollisionFlags.Slow;
            }
            else
            {
                Flags |= CollisionFlags.Slow;
            }

            // Match old contact ids to new contact ids and copy the
            // stored impulses to warm start the solver.
            for (int i = 0; i < Manifold.PointCount; ++i)
            {
                ManifoldPoint mp2 = Manifold.Points[i];
                mp2.NormalImpulse = 0.0f;
                mp2.TangentImpulse = 0.0f;
                ContactId id2 = mp2.Id;

                for (int j = 0; j < oldManifold.PointCount; ++j)
                {
                    ManifoldPoint mp1 = oldManifold.Points[j];

                    if (mp1.Id.Key == id2.Key)
                    {
                        mp2.NormalImpulse = mp1.NormalImpulse;
                        mp2.TangentImpulse = mp1.TangentImpulse;
                        break;
                    }
                }
            }

            if (oldCount == 0 && newCount > 0)
            {
                Flags |= CollisionFlags.Touch;
                if (listener != null)
                    listener.BeginContact(this);
            }

            if (oldCount > 0 && newCount == 0)
            {
                Flags &= ~CollisionFlags.Touch;
                if (listener != null)
                    listener.EndContact(this);
            }

            if ((Flags & CollisionFlags.NonSolid) == 0)
            {
                if (listener != null)
                    listener.PreSolve(this, oldManifold);

                // The user may have disabled contact.
                if (Manifold.PointCount == 0)
                {
                    Flags &= ~CollisionFlags.Touch;
                }
            }
        }

        /// <summary>
        ///     Evaluates this instance
        /// </summary>
        public void Evaluate()
        {
            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;

            Box2DXDebug.Assert(CollideShapeFunction != null);

            CollideShapeFunction(ref manifold, FixtureA.Shape, bodyA.GetXForm(), FixtureB.Shape, bodyB.GetXForm());
        }

        /// <summary>
        ///     Computes the toi using the specified sweep a
        /// </summary>
        /// <param name="sweepA">The sweep</param>
        /// <param name="sweepB">The sweep</param>
        /// <returns>The float</returns>
        public float ComputeToi(Sweep sweepA, Sweep sweepB)
        {
            ToiInput input = new ToiInput();
            input.SweepA = sweepA;
            input.SweepB = sweepB;
            input.SweepRadiusA = FixtureA.ComputeSweepRadius(sweepA.LocalCenter);
            input.SweepRadiusB = FixtureB.ComputeSweepRadius(sweepB.LocalCenter);
            input.Tolerance = Settings.LinearSlop;

            return Collision.Collision.TimeOfImpact(input, FixtureA.Shape, FixtureB.Shape);
        }

        /// <summary>
        ///     Get the world manifold.
        /// </summary>
        public void GetWorldManifold(out WorldManifold worldManifold)
        {
            worldManifold = new WorldManifold();

            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;
            Shape shapeA = FixtureA.Shape;
            Shape shapeB = FixtureB.Shape;

            worldManifold.Initialize(Manifold, bodyA.GetXForm(), shapeA.Radius, bodyB.GetXForm(), shapeB.Radius);
        }

        /// <summary>
        ///     Get the next contact in the world's contact list.
        /// </summary>
        public Contact GetNext()
        {
            return Next;
        }

        /// <summary>
        ///     The collide shape delegate
        /// </summary>
        internal delegate void CollideShapeDelegate(
            ref Manifold manifold, Shape circle1, XForm xf1, Shape circle2, XForm xf2);
    }
}