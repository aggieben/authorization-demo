using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Extensions
{
    public static class ICollectionExtensions
    {
        public static bool HasValue<T>(this ICollection<T> e)
        {
            return e != null && e.Any();
        }
    }
}