using Alis.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Alis.Core
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Sprite : Component
    {
        public Sprite()
        {
            
        }

        public Sprite(string name, string path, int depth)
        {

        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            Logger.Log("Update sprite");
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}