using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Sample.Samples
{
    internal sealed class JointsDistanceAndRevoluteSample : IPhysicSample
    {
        public string Key => "joints";

        public string Title => "Distance and revolute joints";

        public string Description => "Connects bodies with spring-like distance joints and a motorized revolute joint.";

        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(new Vector2F(0.0f, -9.81f));

            Body anchor = world.CreateCircle(0.2f, 0.0f, new Vector2F(0.0f, 8.0f), BodyType.Static);
            Body bob = world.CreateCircle(0.8f, 1.0f, new Vector2F(0.0f, 5.0f), BodyType.Dynamic);
            RevoluteJoint revolute = JointFactory.CreateRevoluteJoint(world, anchor, bob, new Vector2F(0.0f, 8.0f));
            revolute.MotorEnabled = true;
            revolute.MotorSpeed = 1.5f;
            revolute.MaxMotorTorque = 30.0f;

            Body bodyA = world.CreateRectangle(1.2f, 1.2f, 1.0f, new Vector2F(-5.0f, 6.0f), 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateRectangle(1.2f, 1.2f, 1.0f, new Vector2F(-2.0f, 6.0f), 0.0f, BodyType.Dynamic);
            DistanceJoint distance = JointFactory.CreateDistanceJoint(world, bodyA, bodyB);
            distance.Frequency = 2.0f;
            distance.DampingRatio = 0.3f;

            runtime.StepWorld(world, 300);

            Console.WriteLine("Revolute joint speed: {0:F2}", revolute.JointSpeed);
            Console.WriteLine("Distance joint length: {0:F2}", distance.Length);
            runtime.PrintBodyState("Bob", bob);
            runtime.PrintBodyState("Body A", bodyA);
            runtime.PrintBodyState("Body B", bodyB);
        }
    }
}