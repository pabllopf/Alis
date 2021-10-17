using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public class RenderSystem : System
    {
        private Configuration configuration;

        public RenderSystem(Configuration configuration)
        {
            this.configuration = configuration;
            Console.WriteLine("Init.RenderSystem()");
        }

        public Configuration Configuration { get => configuration; set => configuration = value; }
    }
}