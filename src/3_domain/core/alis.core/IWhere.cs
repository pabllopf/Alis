using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public interface IWhere<Builder, Argument>
    {
        public Builder Where(Argument value);
    }
}