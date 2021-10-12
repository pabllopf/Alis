using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public interface IWith<L, T>
    {
        public L With(T value);
    }
}