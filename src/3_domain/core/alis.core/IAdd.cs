using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public interface IAdd<L, T>
    {
        public L Add(T obj);
    }
}