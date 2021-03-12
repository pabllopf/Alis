//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Physics.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;

    /// <summary>Define a component</summary>
    public class Physics : Component
    {
        private Transform transform;

        private bool test;

        private bool isStatic;

        /// <summary>Initializes a new instance of the <see cref="Physics" /> class.</summary>
        public Physics() 
        {
            test = true;
        }

        public override void OnCollionEnter(Collision collision)
        {
            Console.WriteLine("Collsion dentro");

           
        }

        public override void OnCollionExit(Collision collision)
        {
            Console.WriteLine("Collision saliente");
        }

        public override void OnCollionStay(Collision collision)
        {
            if (test) 
            {
                Console.WriteLine("Collision chocando");
                test = false;
            }
        }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
            this.transform = this.GetGameObject().Transform;
        }

        /// <summary>Updates this instance.</summary>
        public override void Update()
        {
        }

        /// <summary>Disable this instance.</summary>
        public override void Disable()
        {
            Console.WriteLine("Disable " + this.GetType());
        }
    }
}