using System;

namespace CatalystAssignment.Utilities
{
    public static class StringExtensions
    {
        /// <summary>
        /// Take a string, trim it and convert ToUpper
        /// </summary>
        /// <param name="str">String to use</param>
        /// <returns></returns>
        public static string TrimToUpper(this String str)
        {
            if (str == null)
                return "";

            return str.ToUpper().Trim();
        }
    }
}
