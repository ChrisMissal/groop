using System;
using System.Linq.Expressions;

namespace Groop.Framework
{
    /// <summary>
    /// Validates arguments for methods
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Validate that the passed argument is not null.
        /// </summary>
        /// <param name="obj">The object to validate</param>
        /// <param name="name">The name of the argument</param>
        /// <exception cref="ArgumentNullException">
        /// If the obj is null, an ArgumentNullException with the passed name
        /// is thrown.
        /// </exception>
        public static void IsNotNull(object obj, string name)
        {
            if (obj == null)
                throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Validates that the passed argument is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reference">The reference.</param>
        /// <param name="value">The value.</param>
        public static void IsNotNull<T>(Expression<Func<T>> reference, T value)
        {
            if (value == null) throw new ArgumentNullException(GetParameterName(reference), "Parameter cannot be null");
        }

        /// <summary>
        /// Nots the null or empty.
        /// </summary>
        /// <param name="reference">The reference.</param>
        /// <param name="value">The value.</param>
        public static void IsNotNullOrEmpty(Expression<Func<string>> reference, string value)
        {
            IsNotNull(reference, value);
            if (value.Length == 0) throw new ArgumentException(GetParameterName(reference), "Parameter cannot be empty.");
        }

        /// <summary>
        /// If the specified condition is true, an ArgumentException is thrown.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="name">The name.</param>
        public static void Condition(Func<bool> condition, string name)
        {
            if (condition())
                throw new ArgumentException(name);
        }

        private static string GetParameterName(Expression reference)
        {
            var lambda = reference as LambdaExpression;
            var member = lambda.Body as MemberExpression;

            return member.Member.Name;
        }
    }
}