using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Utils
{
    public static class EnumTools
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

    }
}
