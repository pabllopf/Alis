// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Contact.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Narrowphase;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared.Optimization;

namespace Alis.Core.Physic.Collision.ContactSystem
{
    /// <summary>
    ///     The class manages contact between two shapes. A contact exists for each overlapping AABB in the broad-phase
    ///     (except if filtered). Therefore a contact object may exist that has no contact points.
    /// </summary>
    public class Contact
    {
        /// <summary>
        ///     The fixture
        /// </summary>
        private Fixture fixtureA;

        /// <summary>
        ///     The fixture
        /// </summary>
        private Fixture fixtureB;

        /// <summary>
        ///     The friction
        /// </summary>
        private float friction;

        /// <summary>
        ///     The index
        /// </summary>
        private int indexA;

        /// <summary>
        ///     The index
        /// </summary>
        private int indexB;

        /// <summary>
        ///     The manifold
        /// </summary>
        private Manifold manifold;

        /// <summary>
        ///     The next
        /// </summary>
        private Contact next;

        // World pool and list pointers.
        /// <summary>
        ///     The prev
        /// </summary>
        private Contact prev;

        /// <summary>
        ///     The restitution
        /// </summary>
        private float restitution;

        /// <summary>
        ///     The restitution threshold
        /// </summary>
        private float restitutionThreshold;

        /// <summary>
        ///     The tangent speed
        /// </summary>
        private float tangentSpeed;

        /// <summary>
        ///     The type
        /// </summary>
        private ContactType type;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Contact" /> class
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        private Contact(Fixture fA, int indexA, Fixture fB, int indexB)
        {
            Reset(fA, indexA, fB, indexB);
        }

        /// <summary>
        ///     The flags
        /// </summary>
        internal ContactFlags Flags { get; set; }

        /// <summary>
        ///     The contact edge
        /// </summary>
        internal ContactEdge NodeA { get; } = new ContactEdge();

        /// <summary>
        ///     The contact edge
        /// </summary>
        internal ContactEdge NodeB { get; } = new ContactEdge();

        /// <summary>
        ///     The toi
        /// </summary>
        internal float Toi { get; set; }

        /// <summary>
        ///     The toi count
        /// </summary>
        internal int ToiCount { get; set; }

        /// <summary>Get the contact manifold. Do not modify the manifold unless you understand the internals of Box2D.</summary>
        public Manifold Manifold
        {
            get => manifold;
            set => manifold = value;
        }

        /// <summary>
        ///     Gets or sets the value of the friction
        /// </summary>
        public float Friction
        {
            get => friction;
            set => friction = value;
        }

        /// <summary>
        ///     Gets or sets the value of the restitution
        /// </summary>
        public float Restitution
        {
            get => restitution;
            set => restitution = value;
        }

        /// <summary>
        ///     Gets or sets the value of the restitution threshold
        /// </summary>
        public float RestitutionThreshold
        {
            get => restitutionThreshold;
            set => restitutionThreshold = value;
        }

        /// <summary>Get or set the desired tangent speed for a conveyor belt behavior. In meters per second.</summary>
        public float TangentSpeed
        {
            get => tangentSpeed;
            set => tangentSpeed = value;
        }

        /// <summary>
        ///     Gets the value of the fixture a
        /// </summary>
        public Fixture FixtureA
        {
            get => fixtureA;
            set => fixtureA = value;
        }

        /// <summary>
        ///     Gets the value of the fixture b
        /// </summary>
        public Fixture FixtureB
        {
            get => fixtureB;
            set => fixtureB = value;
        }

        /// <summary>Get the child primitive index for fixture A.</summary>
        /// <value>The child index A.</value>
        public int ChildIndexA
        {
            get => indexA;
            set => indexA = value;
        }

        /// <summary>Get the child primitive index for fixture B.</summary>
        /// <value>The child index B.</value>
        public int ChildIndexB
        {
            get => indexB;
            set => indexB = value;
        }

        /// <summary>
        ///     Enable/disable this contact.The contact is only disabled for the current time step (or sub-step in continuous
        ///     collisions).
        /// </summary>
        public bool Enabled
        {
            get => (Flags & ContactFlags.EnabledFlag) == ContactFlags.EnabledFlag;
            set
            {
                if (value)
                {
                    Flags |= ContactFlags.EnabledFlag;
                }
                else
                {
                    Flags &= ~ContactFlags.EnabledFlag;
                }
            }
        }

        /// <summary>
        ///     Gets the value of the next
        /// </summary>
        public Contact Next
        {
            get => next;
            set => next = value;
        }

        /// <summary>
        ///     Gets the value of the previous
        /// </summary>
        public Contact Previous
        {
            get => prev;
            set => prev = value;
        }

        /// <summary>
        ///     Gets the value of the is touching
        /// </summary>
        internal bool IsTouching => (Flags & ContactFlags.TouchingFlag) == ContactFlags.TouchingFlag;

        /// <summary>
        ///     Gets the value of the island flag
        /// </summary>
        internal bool IslandFlag => (Flags & ContactFlags.IslandFlag) == ContactFlags.IslandFlag;

        /// <summary>
        ///     Gets the value of the toi flag
        /// </summary>
        internal bool ToiFlag => (Flags & ContactFlags.ToiFlag) == ContactFlags.ToiFlag;

        /// <summary>
        ///     Gets the value of the filter flag
        /// </summary>
        internal bool FilterFlag => (Flags & ContactFlags.FilterFlag) == ContactFlags.FilterFlag;

        /// <summary>
        ///     The edge shape
        /// </summary>
        private static readonly EdgeShape Edge = new EdgeShape();

        /// <summary>
        ///     The not supported
        /// </summary>
        private static readonly ContactType[,] Registers =
        {
            {
                ContactType.Circle,
                ContactType.EdgeAndCircle,
                ContactType.PolygonAndCircle,
                ContactType.ChainAndCircle
            },
            {
                ContactType.EdgeAndCircle,
                ContactType.NotSupported,


                ContactType.EdgeAndPolygon,
                ContactType.NotSupported
            },
            {
                ContactType.PolygonAndCircle,
                ContactType.EdgeAndPolygon,
                ContactType.Polygon,
                ContactType.ChainAndPolygon
            },
            {
                ContactType.ChainAndCircle,
                ContactType.NotSupported,


                ContactType.ChainAndPolygon,
                ContactType.NotSupported
            }
        };

        /// <summary>
        ///     Resets the restitution
        /// </summary>
        public void ResetRestitution()
        {
            Restitution = Settings.MixRestitution(FixtureA.Restitution, FixtureB.Restitution);
        }

        /// <summary>
        ///     Resets the restitution threshold
        /// </summary>
        public void ResetRestitutionThreshold()
        {
            RestitutionThreshold = Settings.MixRestitutionThreshold(FixtureA.Restitution, FixtureB.Restitution);
        }

        /// <summary>
        ///     Resets the friction
        /// </summary>
        public void ResetFriction()
        {
            Friction = Settings.MixFriction(FixtureA.Friction, FixtureB.Friction);
        }

        /// <summary>Gets the world manifold.</summary>
        public void GetWorldManifold(out Vector2F normal, out FixedArray2<Vector2F> points)
        {
            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;
            Shape shapeA = FixtureA.Shape;
            Shape shapeB = FixtureB.Shape;

            WorldManifold.Initialize(ref manifold, ref bodyA.Xf, shapeA.RadiusPrivate, ref bodyB.Xf,
                shapeB.RadiusPrivate,
                out normal, out points, out _);
        }

        /// <summary>
        ///     Resets the f a
        /// </summary>
        /// <param name="fA">The </param>
        /// <param name="indexA">The index</param>
        /// <param name="fB">The </param>
        /// <param name="indexB">The index</param>
        private void Reset(Fixture fA, int indexA, Fixture fB, int indexB)
        {
            Flags = ContactFlags.EnabledFlag;

            FixtureA = fA;
            FixtureB = fB;

            ChildIndexA = indexA;
            ChildIndexB = indexB;

            manifold.PointCount = 0;

            Previous = null;
            Next = null;

            NodeA.Contact = null;
            NodeA.Prev = null;
            NodeA.Next = null;
            NodeA.Other = null;

            NodeB.Contact = null;
            NodeB.Prev = null;
            NodeB.Next = null;
            NodeB.Other = null;

            ToiCount = 0;

            if ((FixtureA != null) && (FixtureB != null))
            {
                Friction = Settings.MixFriction(FixtureA.Friction, FixtureB.Friction);
                Restitution = Settings.MixRestitution(FixtureA.Restitution, FixtureB.Restitution);
                RestitutionThreshold =
                    Settings.MixRestitutionThreshold(FixtureA.RestitutionThreshold,
                        FixtureB.RestitutionThreshold);
            }

            TangentSpeed = 0;
        }

        /// <summary>
        ///     Update the contact manifold and touching status. Note: do not assume the fixture AABBs are overlapping or are
        ///     valid.
        /// </summary>
        /// <param name="contactManager">The contact manager.</param>
        internal void Update(ContactManager contactManager)
        {
            if (FixtureA == null || FixtureB == null)
            {
                return;
            }

            Manifold oldManifold = Manifold;

            Flags |= ContactFlags.EnabledFlag;

            bool touching;
            bool wasTouching = IsTouching;

            bool sensor = FixtureA.IsSensor || FixtureB.IsSensor;

            Body bodyA = FixtureA.Body;
            Body bodyB = FixtureB.Body;

            Transform xfA = bodyA.Xf;
            Transform xfB = bodyB.Xf;

            if (sensor)
            {
                Shape shapeA = FixtureA.Shape;
                Shape shapeB = FixtureB.Shape;
                touching = Narrowphase.Collision.TestOverlap(shapeA, ChildIndexA, shapeB, ChildIndexB, ref xfA,
                    ref xfB);

                manifold.PointCount = 0;
            }
            else
            {
                Evaluate(ref manifold, ref xfA, ref xfB);
                touching = Manifold.PointCount > 0;

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

                    manifold.Points[i] = mp2;
                }

                if (touching != wasTouching)
                {
                    bodyA.Awake = true;
                    bodyB.Awake = true;
                }
            }

            if (touching)
            {
                Flags |= ContactFlags.TouchingFlag;
            }
            else
            {
                Flags &= ~ContactFlags.TouchingFlag;
            }

            if ((wasTouching == false) && touching)
            {
                FixtureA.OnCollision?.Invoke(FixtureA, FixtureB, this);
                FixtureB.OnCollision?.Invoke(FixtureB, FixtureA, this);


                bodyA.OnCollision?.Invoke(FixtureA, FixtureB, this);
                bodyB.OnCollision?.Invoke(FixtureB, FixtureA, this);

                contactManager.BeginContact?.Invoke(this);

                if (!Enabled)
                {
                    touching = false;
                }
            }

            if (wasTouching && !touching)
            {
                FixtureA.OnSeparation?.Invoke(FixtureA, FixtureB, this);
                FixtureB.OnSeparation?.Invoke(FixtureB, FixtureA, this);

                bodyA.OnSeparation?.Invoke(FixtureA, FixtureB, this);
                bodyB.OnSeparation?.Invoke(FixtureB, FixtureA, this);

                contactManager.EndContact?.Invoke(this);
            }

            if (!sensor && touching)
            {
                contactManager.PreSolve?.Invoke(this, ref oldManifold);
            }
        }

        /// <summary>Evaluate this contact with your own manifold and transforms.</summary>
        /// <param name="manifold">The manifold.</param>
        /// <param name="transformA">The first transform.</param>
        /// <param name="transformB">The second transform.</param>
        private void Evaluate(ref Manifold manifold, ref Transform transformA, ref Transform transformB)
        {
            switch (type)
            {
                case ContactType.Polygon:
                    CollidePolygon.CollidePolygons(ref manifold, (PolygonShape) FixtureA.Shape, ref transformA,
                        (PolygonShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.PolygonAndCircle:
                    CollideCircle.CollidePolygonAndCircle(ref manifold, (PolygonShape) FixtureA.Shape, ref transformA,
                        (CircleShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.EdgeAndCircle:
                    CollideEdge.CollideEdgeAndCircle(ref manifold, (EdgeShape) FixtureA.Shape, ref transformA,
                        (CircleShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.EdgeAndPolygon:
                    CollideEdge.CollideEdgeAndPolygon(ref manifold, (EdgeShape) FixtureA.Shape, ref transformA,
                        (PolygonShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.ChainAndCircle:
                    ChainShape chain = (ChainShape) FixtureA.Shape;
                    chain.GetChildEdge(Edge, ChildIndexA);
                    CollideEdge.CollideEdgeAndCircle(ref manifold, Edge, ref transformA, (CircleShape) FixtureB.Shape,
                        ref transformB);
                    break;
                case ContactType.ChainAndPolygon:
                    ChainShape loop2 = (ChainShape) FixtureA.Shape;
                    loop2.GetChildEdge(Edge, ChildIndexA);
                    CollideEdge.CollideEdgeAndPolygon(ref manifold, Edge, ref transformA,
                        (PolygonShape) FixtureB.Shape, ref transformB);
                    break;
                case ContactType.Circle:
                    CollideCircle.CollideCircles(ref manifold, (CircleShape) FixtureA.Shape, ref transformA,
                        (CircleShape) FixtureB.Shape, ref transformB);
                    break;
                default:
                    throw new ArgumentException("You are using an unsupported contact type.");
            }
        }

        /// <summary>
        ///     Creates the fixture a
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="indexA">The index</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="indexB">The index</param>
        /// <returns>The </returns>
        internal static Contact Create(Fixture fixtureA, int indexA, Fixture fixtureB, int indexB)
        {
            ShapeType type1 = fixtureA.Shape.ShapeType;
            ShapeType type2 = fixtureB.Shape.ShapeType;

            Contact c;
            Queue<Contact> pool = ContactManager.Current.ContactPool;
            if (pool.Count > 0)
            {
                c = pool.Dequeue();
                if ((type1 >= type2 || ((type1 == ShapeType.Edge) && (type2 == ShapeType.Polygon))) &&
                    !((type2 == ShapeType.Edge) && (type1 == ShapeType.Polygon)))
                {
                    c.Reset(fixtureA, indexA, fixtureB, indexB);
                }
                else
                {
                    c.Reset(fixtureB, indexB, fixtureA, indexA);
                }
            }
            else
            {
                if ((type1 >= type2 || ((type1 == ShapeType.Edge) && (type2 == ShapeType.Polygon))) &&
                    !((type2 == ShapeType.Edge) && (type1 == ShapeType.Polygon)))
                {
                    c = new Contact(fixtureA, indexA, fixtureB, indexB);
                }
                else
                {
                    c = new Contact(fixtureB, indexB, fixtureA, indexA);
                }
            }

            c.type = Registers[(int) type1, (int) type2];

            return c;
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        internal void Destroy()
        {
            if ((Manifold.PointCount > 0) && !FixtureA.IsSensor && !FixtureB.IsSensor)
            {
                FixtureA.Body.Awake = true;
                FixtureB.Body.Awake = true;
            }

            ContactManager.Current.ContactPool.Enqueue(this);

            Reset(null, 0, null, 0);
        }

        /// <summary>
        ///     Clears the flags
        /// </summary>
        public void ClearFlags() => Flags &= ~ContactFlags.FilterFlag;

        /// <summary>
        ///     Invalidates the toi
        /// </summary>
        public void InvalidateToi()
        {
            Flags &= ~(ContactFlags.ToiFlag | ContactFlags.IslandFlag);
            ToiCount = 0;
            Toi = 1.0f;
        }
    }
}