using System;
using System.Collections;
using System.Collections.Generic;

namespace CRIneta.Framework
{
    public static class Extensions
    {
        public static bool IsNullOrEmpty(this string @this)
        {
            return (string.IsNullOrEmpty(@this));
        }

        public static string FormatWith(this string @this, params object[] args)
        {
            return String.Format(@this, args);
        }

        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (var item in @this)
            {
                action(item);
            }
        }
    }
}
