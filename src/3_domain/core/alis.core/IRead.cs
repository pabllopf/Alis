using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public interface IRead<L, T>
    {
        public L Read(T obj);
    }
}