using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public interface IIs<L, T>
    {
        static L? Is(T value) => default;
    }
}