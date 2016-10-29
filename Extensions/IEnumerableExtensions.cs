using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool HasValue<T>(this IEnumerable<T> e)
        {
            return e != null && e.Any();
        }
    }
}