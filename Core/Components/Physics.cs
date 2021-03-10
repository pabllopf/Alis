//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Physics.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
using System;

namespace Alis.Core.Components
{
    /// <summary>Define a component</summary>
    public class Physics : Component
    {
        /// <summary>Initializes a new instance of the <see cref="Physics" /> class.</summary>
        public Physics() 
        {
        }

        /// <summary>Starts this instance.</summary>
        public override void Start()
        {
        }

        /// <summary>Before the update.</summary>
        public override void BeforeUpdate()
        { 
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