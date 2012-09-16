using System;
using System.Collections.Generic;

namespace ConsoleNancySignalR.Utils
{
    static class Dict
    {
        public static T Get<T>(IDictionary<string, object> dictionary, string key)
        {
            object value;
            return dictionary.TryGetValue(key, out value) ? (T)value : default(T);
        }

        public static T Get<T>(IDictionary<string, object> dictionary, string key, Func<T> createValue)
        {
            var value = Get<T>(dictionary, key);
            if (Equals(value, default(T)))
            {
                value = createValue();
                dictionary[key] = value;
            }
            return value;
        }
    }
}