using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public interface ISet<L, T>
    {
        public L Set(T value);
    }
}