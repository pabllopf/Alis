// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Island.cs
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
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Dynamics.Solver
{
    /// <summary>This is an internal class.</summary>
    internal class Island
    {
        /// <summary>
        ///     The angular sleep tolerance
        /// </summary>
        private const float AngTolSqr = Settings.AngularSleepTolerance * Settings.AngularSleepTolerance;

        /// <summary>
        ///     The linear sleep tolerance
        /// </summary>
        private const float LinTolSqr = Settings.LinearSleepTolerance * Settings.LinearSleepTolerance;

        /// <summary>
        ///     The bodies
        /// </summary>
        private readonly List<Body> bodies = new List<Body>(Settings.ToiContacts * 2);

        /// <summary>
        ///     The contacts
        /// </summary>
        private readonly List<Contact> contacts = new List<Contact>(Settings.ToiContacts * 2);

        /// <summary>
        ///     The contact solver
        /// </summary>
        private readonly ContactSolver contactSolver = new ContactSolver();

        /// <summary>
        ///     The joints
        /// </summary>
        private readonly List<Joint> joints = new List<Joint>(Settings.ToiContacts);

        /// <summary>
        ///     The positions
        /// </summary>
        private readonly List<Position> positions = new List<Position>(Settings.ToiContacts);

        /// <summary>
        ///     The velocities
        /// </summary>
        private readonly List<Velocity> velocities = new List<Velocity>(Settings.ToiContacts);

        /// <summary>
        ///     Gets or sets the value of the step
        /// </summary>
        private TimeStep TimeStepSolveToi { get; } = new TimeStep();

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            bodies.Clear();
            contacts.Clear();
            joints.Clear();
        }

        /// <summary>
        ///     Solves the step
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="gravity">The gravity</param>
        /// <param name="allowSleep">The allow sleep</param>
        /// <param name="contactManager">The contact manager</param>
        /// <param name="bodiesOfWorld">The bodies of world</param>
        public void Solve(TimeStep step, Vector2 gravity, bool allowSleep, ContactManager contactManager, List<Body> bodiesOfWorld)
        {
            for (int index = bodiesOfWorld.Count - 1; index >= 0; index--)
            {
                Body body = bodiesOfWorld[index];
                if (!HandleBodies(body))
                {
                    continue;
                }

                HandleContacts(body);
                HandleJoints(body);

                float h = step.DeltaTime;
                IntegrateVelocitiesAndApplyDamping(h, body, gravity);

                SolverData solverData = new SolverData
                {
                    Step = step,
                    Positions = positions,
                    Velocities = velocities
                };

                contactSolver.Reset(step, contacts.Count, contacts, positions, velocities);
                contactSolver.InitializeVelocityConstraints();

                if (step.WarmStarting)
                {
                    contactSolver.WarmStart();
                }

                SolveVelocityConstraints(step);
                contactSolver.StoreImpulses();

                IntegratePositions(h);
                bool positionSolved = SolvePositionConstraints(step);

                CopyStateBuffersBackToBodies();

                Report(contactSolver.VelocityConstraints, contactManager);

                if (allowSleep)
                {
                    HandleSleep(positionSolved, h);
                }
            }

            PostSolveCleanup();
        }

        /// <summary>
        ///     Describes whether this instance handle bodies
        /// </summary>
        /// <param name="body">The body</param>
        /// <returns>The bool</returns>
        private bool HandleBodies(Body body)
        {
            if ((body.Flags & BodyFlags.IslandFlag) == BodyFlags.IslandFlag)
            {
                return false;
            }

            if (!body.Awake || !body.Enabled)
            {
                return false;
            }

            if (body.BodyType == BodyType.Static)
            {
                return false;
            }

            Clear();
            body.Flags |= BodyFlags.IslandFlag;
            Add(body);

            if (body.BodyType == BodyType.Static)
            {
                return false;
            }

            body.Flags |= BodyFlags.AwakeFlag;

            return true;
        }

        /// <summary>
        ///     Handles the contacts using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        private void HandleContacts(Body body)
        {
            for (ContactEdge ce = body.ContactList; ce != null; ce = ce.Next)
            {
                Contact contact = ce.Contact;

                if (contact.IslandFlag)
                {
                    continue;
                }

                if (!contact.Enabled || !contact.IsTouching)
                {
                    continue;
                }

                bool sensorA = contact.FixtureA.IsSensor;
                bool sensorB = contact.FixtureB.IsSensor;
                if (sensorA || sensorB)
                {
                    continue;
                }

                Add(contact);
                contact.Flags |= ContactFlags.IslandFlag;

                Body other = ce.Other;

                if (other.IsIsland)
                {
                    continue;
                }

                other.Flags |= BodyFlags.IslandFlag;
            }
        }

        /// <summary>
        ///     Handles the joints using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        private void HandleJoints(Body body)
        {
            for (JointEdge je = body.JointList; je != null; je = je.Next)
            {
                if (je.Joint.IslandFlag)
                {
                    continue;
                }

                Body other = je.Other;

                if (other != null)
                {
                    if (!other.Enabled)
                    {
                        continue;
                    }

                    Add(je.Joint);
                    je.Joint.IslandFlag = true;

                    if (other.IsIsland)
                    {
                        continue;
                    }

                    other.Flags |= BodyFlags.IslandFlag;
                }
                else
                {
                    Add(je.Joint);
                    je.Joint.IslandFlag = true;
                }
            }
        }

        /// <summary>
        ///     Integrates the velocities and apply damping using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="body">The body</param>
        /// <param name="gravity">The gravity</param>
        private void IntegrateVelocitiesAndApplyDamping(float h, Body body, Vector2 gravity)
        {
            foreach (Body b in bodies)
            {
                Vector2 c = b.Sweep.C;
                float a = b.Sweep.A;
                Vector2 v = b.LinearVelocity;
                float w = b.AngularVelocity;

                b.Sweep.C0 = b.Sweep.C;
                b.Sweep.A0 = b.Sweep.A;

                if (b.BodyType == BodyType.Dynamic)
                {
                    v += h * b.InvMass * (b.GravityScale * b.Mass * gravity + b.Force);
                    w += h * b.InvI * b.Torque;

                    v *= MathUtils.Clamp(1.0f - h * b.LinearDamping, 0.0f, 1.0f);
                    w *= MathUtils.Clamp(1.0f - h * b.AngularDamping, 0.0f, 1.0f);
                }

                if (positions.Count <= bodies.IndexOf(b))
                {
                    positions.Add(new Position(c, a));
                }
                else
                {
                    positions[bodies.IndexOf(b)].C = c;
                    positions[bodies.IndexOf(b)].A = a;
                }

                if (velocities.Count <= bodies.IndexOf(b))
                {
                    velocities.Insert(bodies.IndexOf(b), new Velocity(v, w));
                }
                else
                {
                    velocities[bodies.IndexOf(b)].V = v;
                    velocities[bodies.IndexOf(b)].W = w;
                }
            }
        }


        /// <summary>
        ///     Integrates the positions using the specified h
        /// </summary>
        /// <param name="h">The </param>
        private void IntegratePositions(float h)
        {
            for (int i = 0; i < positions.Count; ++i)
            {
                Vector2 c = positions[i].C;
                float a = positions[i].A;
                Vector2 v = velocities[i].V;
                float w = velocities[i].W;

                Vector2 translation = h * v;
                if (Vector2.Dot(translation, translation) > Settings.Translation * Settings.Translation)
                {
                    float ratio = Settings.Translation / translation.Length();
                    v *= ratio;
                }

                float rotation = h * w;
                if (rotation * rotation > Settings.Rotation * Settings.Rotation)
                {
                    float ratio = Settings.Rotation / Math.Abs(rotation);
                    w *= ratio;
                }

                c += h * v;
                a += h * w;

                positions[i].C = c;
                positions[i].A = a;
                velocities[i].V = v;
                velocities[i].W = w;
            }
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="step">The step</param>
        /// <returns>The position solved</returns>
        private bool SolvePositionConstraints(TimeStep step)
        {
            SolverData solverData = new SolverData
            {
                Step = step,
                Positions = positions,
                Velocities = velocities
            };

            bool positionSolved = false;
            for (int i = 0; i < step.PositionIterations; ++i)
            {
                bool contactsOkay = contactSolver.SolvePositionConstraints();

                bool jointsOkay = true;
                for (int j = 0; j < joints.Count; ++j)
                {
                    Joint joint = joints[j];

                    if (!joint.Enabled)
                    {
                        continue;
                    }

                    bool jointOkay = joint.SolvePositionConstraints(ref solverData);
                    jointsOkay = jointsOkay && jointOkay;
                }

                if (contactsOkay && jointsOkay)
                {
                    positionSolved = true;
                    break;
                }
            }

            return positionSolved;
        }

        /// <summary>
        ///     Copies the state buffers back to bodies
        /// </summary>
        private void CopyStateBuffersBackToBodies()
        {
            for (int i = 0; i < bodies.Count; ++i)
            {
                bodies[i].Sweep.C = positions[i].C;
                bodies[i].Sweep.A = positions[i].A;
                bodies[i].LinearVelocity = velocities[i].V;
                bodies[i].AngularVelocity = velocities[i].W;
                bodies[i].SynchronizeTransform();
            }
        }

        /// <summary>
        ///     Handles the sleep using the specified position solved
        /// </summary>
        /// <param name="positionSolved">The position solved</param>
        /// <param name="h">The </param>
        private void HandleSleep(bool positionSolved, float h)
        {
            float minSleepTime = float.MaxValue;

            for (int i = 0; i < bodies.Count; ++i)
            {
                Body b = bodies[i];

                if (b.BodyType == BodyType.Static)
                {
                    continue;
                }

                if (!b.SleepingAllowed || b.AngularVelocity * b.AngularVelocity > AngTolSqr ||
                    Vector2.Dot(b.LinearVelocity, b.LinearVelocity) > LinTolSqr)
                {
                    b.SleepTime = 0.0f;
                    minSleepTime = 0.0f;
                }
                else
                {
                    b.SleepTime += h;
                    minSleepTime = Math.Min(minSleepTime, b.SleepTime);
                }
            }

            if ((minSleepTime >= Settings.TimeToSleep) && positionSolved)
            {
                for (int i = 0; i < bodies.Count; ++i)
                {
                    bodies[i].Awake = false;
                }
            }
        }

        /// <summary>
        ///     Posts the solve cleanup
        /// </summary>
        private void PostSolveCleanup()
        {
            for (int i = 0; i < bodies.Count; ++i)
            {
                if (bodies[i].BodyType == BodyType.Static)
                {
                    bodies[i].Flags &= ~BodyFlags.IslandFlag;
                }
            }
        }


        /// <summary>
        ///     Solves the toi using the specified min alpha
        /// </summary>
        /// <param name="minAlpha">The min alpha</param>
        /// <param name="subStep">The sub step</param>
        /// <param name="toiIndexA">The toi index</param>
        /// <param name="toiIndexB">The toi index</param>
        /// <param name="contactManager">The contact manager</param>
        internal void SolveToi(float minAlpha, TimeStep subStep, int toiIndexA, int toiIndexB, ContactManager contactManager)
        {
            InitializeTimeStep(minAlpha, subStep);
            InitializeBodyState();
            contactSolver.Reset(subStep, contacts.Count, contacts, positions, velocities);
            SolvePositionConstraints(subStep, toiIndexA, toiIndexB);
            LeapToNewState(toiIndexA, toiIndexB);
            contactSolver.InitializeVelocityConstraints();
            SolveVelocityConstraints(subStep);
            IntegratePositions(subStep);
            Report(contactSolver.VelocityConstraints, contactManager);
        }

        /// <summary>
        ///     Initializes the time step using the specified min alpha
        /// </summary>
        /// <param name="minAlpha">The min alpha</param>
        /// <param name="subStep">The sub step</param>
        private void InitializeTimeStep(float minAlpha, TimeStep subStep)
        {
            TimeStepSolveToi.DeltaTime = (1.0f - minAlpha) * subStep.DeltaTime;
            TimeStepSolveToi.InvertedDeltaTime = 1.0f / ((1.0f - minAlpha) * subStep.DeltaTime);
            TimeStepSolveToi.DeltaTimeRatio = 1.0f;
            TimeStepSolveToi.PositionIterations = 20;
            TimeStepSolveToi.VelocityIterations = subStep.VelocityIterations;
            TimeStepSolveToi.WarmStarting = false;
        }

        /// <summary>
        ///     Initializes the body state
        /// </summary>
        private void InitializeBodyState()
        {
            for (int i = 0; i < bodies.Count; ++i)
            {
                Body b = bodies[i];
                if (positions.Count <= bodies.IndexOf(b))
                {
                    positions.Add(new Position(b.Sweep.C, b.Sweep.A));
                }
                else
                {
                    positions[bodies.IndexOf(b)].C = b.Sweep.C;
                    positions[bodies.IndexOf(b)].A = b.Sweep.A;
                }

                if (velocities.Count <= bodies.IndexOf(b))
                {
                    velocities.Insert(bodies.IndexOf(b), new Velocity(b.LinearVelocity, b.AngularVelocity));
                }
                else
                {
                    velocities[bodies.IndexOf(b)].V = b.LinearVelocity;
                    velocities[bodies.IndexOf(b)].W = b.AngularVelocity;
                }
            }
        }

        /// <summary>
        ///     Solves the position constraints using the specified sub step
        /// </summary>
        /// <param name="subStep">The sub step</param>
        /// <param name="toiIndexA">The toi index</param>
        /// <param name="toiIndexB">The toi index</param>
        private void SolvePositionConstraints(TimeStep subStep, int toiIndexA, int toiIndexB)
        {
            for (int i = 0; i < subStep.PositionIterations; ++i)
            {
                bool contactsOkay = contactSolver.SolveToiPositionConstraints(toiIndexA, toiIndexB);
                if (contactsOkay)
                {
                    break;
                }
            }
        }

        /// <summary>
        ///     Leaps the to new state using the specified toi index a
        /// </summary>
        /// <param name="toiIndexA">The toi index</param>
        /// <param name="toiIndexB">The toi index</param>
        private void LeapToNewState(int toiIndexA, int toiIndexB)
        {
            bodies[toiIndexA].Sweep.C0 = positions[toiIndexA].C;
            bodies[toiIndexA].Sweep.A0 = positions[toiIndexA].A;
            bodies[toiIndexB].Sweep.C0 = positions[toiIndexB].C;
            bodies[toiIndexB].Sweep.A0 = positions[toiIndexB].A;
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified sub step
        /// </summary>
        /// <param name="subStep">The sub step</param>
        private void SolveVelocityConstraints(TimeStep subStep)
        {
            for (int i = 0; i < subStep.VelocityIterations; ++i)
            {
                contactSolver.SolveVelocityConstraints();
            }
        }

        /// <summary>
        ///     Integrates the positions using the specified sub step
        /// </summary>
        /// <param name="subStep">The sub step</param>
        private void IntegratePositions(TimeStep subStep)
        {
            float h = subStep.DeltaTime;
            for (int i = 0; i < bodies.Count; ++i)
            {
                Vector2 c = positions[i].C;
                float a = positions[i].A;
                Vector2 v = velocities[i].V;
                float w = velocities[i].W;

                Vector2 translation = h * v;
                if (Vector2.Dot(translation, translation) > Settings.Translation * Settings.Translation)
                {
                    float ratio = Settings.Translation / translation.Length();
                    v *= ratio;
                }

                float rotation = h * w;
                if (rotation * rotation > Settings.Rotation * Settings.Rotation)
                {
                    float ratio = Settings.Rotation / Math.Abs(rotation);
                    w *= ratio;
                }

                c += h * v;
                a += h * w;

                positions[i].C = c;
                positions[i].A = a;
                velocities[i].V = v;
                velocities[i].W = w;

                Body body = bodies[i];
                body.Sweep.C = c;
                body.Sweep.A = a;
                body.LinearVelocity = v;
                body.AngularVelocity = w;
                body.SynchronizeTransform();
            }
        }

        /// <summary>
        ///     Adds the body
        /// </summary>
        /// <param name="body">The body</param>
        public void Add(Body body)
        {
            body.IslandIndex = bodies.Count;
            bodies.Add(body);
        }

        /// <summary>
        ///     Adds the contact
        /// </summary>
        /// <param name="contact">The contact</param>
        public void Add(Contact contact) => contacts.Add(contact);

        /// <summary>
        ///     Adds the joint
        /// </summary>
        /// <param name="joint">The joint</param>
        private void Add(Joint joint) => joints.Add(joint);

        /// <summary>
        ///     Reports the constraints
        /// </summary>
        /// <param name="constraints">The constraints</param>
        /// <param name="contactManager">The contact manager</param>
        private void Report(List<ContactVelocityConstraint> constraints, ContactManager contactManager)
        {
            for (int i = 0; i < contacts.Count; ++i)
            {
                Contact c = contacts[i];

                //Velcro feature: added after collision
                c.FixtureA.AfterCollision?.Invoke(c.FixtureA, c.FixtureB, c, constraints[i]);
                c.FixtureB.AfterCollision?.Invoke(c.FixtureB, c.FixtureA, c, constraints[i]);

                //Velcro optimization: We don't store the impulses and send it to the delegate. We just send the whole contact.
                contactManager.PostSolve?.Invoke(c, constraints[i]);
            }
        }

        /// <summary>
        ///     Synchronizes the bodies
        /// </summary>
        public void SynchronizeBodies()
        {
            for (int i = 0; i < bodies.Count; ++i)
            {
                Body body = bodies[i];
                body.Flags &= ~BodyFlags.IslandFlag;

                if (body.BodyType != BodyType.Dynamic)
                {
                    continue;
                }

                body.SynchronizeFixtures();

                // Invalidate all contact TOIs on this displaced body.
                for (ContactEdge ce = body.ContactList; ce != null; ce = ce.Next)
                {
                    ce.Contact.Flags &= ~(ContactFlags.ToiFlag | ContactFlags.IslandFlag);
                }
            }
        }
    }
}