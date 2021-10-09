using System;
using System.Collections.Generic;
using System.Text;

namespace Alis.Core
{
    public static class Validation<T>
    {
        public static readonly Predicate<T> NotNull = (obj) => obj is not null;

        public static readonly Predicate<T> IsNull = (obj) => obj is null;
    }
}