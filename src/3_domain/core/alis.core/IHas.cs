using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public interface IHas<L, T>
    {
        public L Has(T obj);
    }
}