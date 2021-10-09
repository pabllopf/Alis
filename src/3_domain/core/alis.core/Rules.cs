using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Alis.Core
{
    public static class Rules
    {
        [return: NotNull]
        public static bool AllTrue<T>([NotNull] T data, [NotNull] params Predicate<T>[] rules)
        {
            if (rules is not null)
            {
                if (data is not null)
                {
                    int counter = 0;
                    for (int index = 0; index < rules.Length; index++)
                    {
                        if (rules[index] is not null)
                        {
                            if (rules[index](data))
                            {
                                counter++;
                            }
                        }
                    }

                    return rules.Length == counter;
                }
                else
                {
                    throw new ArgumentNullException("Data params is null.");
                }
            }
            else
            {
                throw new ArgumentNullException("Rules params is null.");
            }
        }
    }
}