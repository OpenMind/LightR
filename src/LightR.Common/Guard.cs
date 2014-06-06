using System;

namespace LightR.Common
{
    /// <summary>
    /// Help to make check assertions
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        public static void AgainstNull<T>(T value)
            where T : class
        {
            if (value == null)
                throw new ArgumentNullException();
        }

        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TE"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="setup"></param>
        public static void AgainstNull<T, TE>(T value, Func<TE> setup)
            where T : class
            where TE : Exception
        {
            if (value == null)
                throw setup();
        }

        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void AgainstNull<T>(T value, string paramName)
            where T : class
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="message">The message.</param>
        public static void AgainstNull<T>(T value, string paramName, string message)
            where T : class
        {
            if (value == null)
                throw new ArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        public static void AgainstNull<T>(T? value)
            where T : struct
        {
            if (!value.HasValue)
                throw new ArgumentNullException();
        }

        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void AgainstNull<T>(T? value, string paramName)
            where T : struct
        {
            if (!value.HasValue)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="message">The message.</param>
        public static void AgainstNull<T>(T? value, string paramName, string message)
            where T : struct
        {
            if (!value.HasValue)
                throw new ArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <param name="value">The value.</param>
        public static void AgainstNull(string value)
        {
            if (value == null)
                throw new ArgumentNullException();
        }

        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void AgainstNull(string value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Againsts the null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="message">The message.</param>
        public static void AgainstNull(string value, string paramName, string message)
        {
            if (value == null)
                throw new ArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Againsts the empty.
        /// </summary>
        /// <param name="value">The value.</param>
        public static void AgainstEmpty(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("string value must not be empty");
        }

        /// <summary>
        /// Againsts the empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void AgainstEmpty(string value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("string value must not be empty", paramName);
        }

        /// <summary>
        /// Againsts the empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="message">The message.</param>
        public static void AgainstEmpty(string value, string paramName, string message)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(message, paramName);
        }

        /// <summary>
        /// Determines whenever the value is greather than the lower limit.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lowerLimit">The lower limit.</param>
        /// <param name="value">The value.</param>
        public static void GreaterThan<T>(T lowerLimit, T value)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
                throw new ArgumentOutOfRangeException();
        }

        public static void GreaterThan<T>(T lowerLimit, T value, string paramName)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
                throw new ArgumentOutOfRangeException(paramName);
        }

        public static void GreaterThan<T>(T lowerLimit, T value, string paramName, string message)
            where T : IComparable<T>
        {
            if (value.CompareTo(lowerLimit) <= 0)
                throw new ArgumentOutOfRangeException(paramName, message);
        }

        public static void LessThan<T>(T upperLimit, T value)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
                throw new ArgumentOutOfRangeException();
        }

        public static void LessThan<T>(T upperLimit, T value, string paramName)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
                throw new ArgumentOutOfRangeException(paramName);
        }

        public static void LessThan<T>(T upperLimit, T value, string paramName, string message)
            where T : IComparable<T>
        {
            if (value.CompareTo(upperLimit) >= 0)
                throw new ArgumentOutOfRangeException(paramName, message);
        }

        /// <summary>
        /// Determines whether the specified condition is true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">The condition.</param>
        /// <param name="target">The target.</param>
        public static void IsTrue<T>(Func<T, bool> condition, T target)
        {
            if (!condition(target))
                throw new ArgumentException("condition was not true");
        }

        /// <summary>
        /// Determines whether the specified condition is true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">The condition.</param>
        /// <param name="target">The target.</param>
        /// <param name="paramName">Name of the param.</param>
        public static void IsTrue<T>(Func<T, bool> condition, T target, string paramName)
        {
            if (!condition(target))
                throw new ArgumentException("condition was not true", paramName);
        }

        /// <summary>
        /// Determines whether the specified condition is true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="condition">The condition.</param>
        /// <param name="target">The target.</param>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="message">The message.</param>
        public static void IsTrue<T>(Func<T, bool> condition, T target, string paramName, string message)
        {
            if (!condition(target))
                throw new ArgumentException(message, paramName);
        }

        /// <summary>
        /// Determines whether [is type of] [the specified obj].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static T IsTypeOf<T>(object obj)
        {
            AgainstNull(obj);
            if (obj is T)
                return (T)obj;

            throw new ArgumentException(string.Format("{0} is not an instance of type {1}", obj.GetType().Name, typeof(T).Name));
        }
    }
}