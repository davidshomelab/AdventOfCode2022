using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal static class Extensions
    {
        internal static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> input, int minimum = 2)
        {
            IEnumerable<T> output = input
                .GroupBy(x => x)
                .Where(g => g.Count() >= minimum)
                .Select(y => y.Key);
            return output;
        }

        internal static IEnumerable<IEnumerable<T>> SplitInto<T>(this IEnumerable<T> source, int itemsPerGroup)
        {
            while (source.Any())
            {
                yield return source.Take(itemsPerGroup);
                source = source.Skip(itemsPerGroup);
            }
        }
    }
}
