using System;
using System.Collections.Generic;

namespace System.Collections
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (var item in @this)
            {
                action(item);
            }
        }
    }
}

namespace System
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string @this)
        {
            return (string.IsNullOrEmpty(@this));
        }

        public static string FormatWith(this string @this, params object[] args)
        {
            return String.Format(@this, args);
        }
    }
}
