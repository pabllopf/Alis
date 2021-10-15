using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Fluent
{
    public interface IGeneral<Builder, Argument>
    {
        public Builder General(Argument value);
    }
}