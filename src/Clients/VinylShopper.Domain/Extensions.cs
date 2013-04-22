using System;
using System.Collections.Generic;

namespace VinylShopper.Domain
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var t in list)
            {
                action(t);
            }
        }
    }
}