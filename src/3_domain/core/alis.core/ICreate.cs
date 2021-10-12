using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public interface ICreate<L, T>
    {
        public L Create(T obj);
    }
}