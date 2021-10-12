using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public interface ISet<Builder, Argument>
    {
        public Builder Set(Argument value);
    }
}