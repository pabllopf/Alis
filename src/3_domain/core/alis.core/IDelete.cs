using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public interface IDelete<T>
    {
        public T Delete();
    }
}