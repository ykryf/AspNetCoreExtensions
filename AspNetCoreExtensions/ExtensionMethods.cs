using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreExtensions
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Searches for a key in the whole configuration tree and returns the first occurence whose value is not an object or array.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Find(this IConfiguration config, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            return config.AsEnumerable().Reverse().Where(x => x.Key.ToString().Split(':').LastOrDefault() == key)?.FirstOrDefault().Value;
        }
    }
}
