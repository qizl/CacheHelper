using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Caching;

namespace CacheHelper
{
    public class CacheHelper
    {
        private static Cache _cache = null;
        private static double _storeMinutes { get; set; }

        public static void Initialize(Cache cache)
        {
            if (_cache == null)
            {
                _cache = cache;
                _storeMinutes = 15d;
            }
        }

        public static void Insert(string key, object value, CacheDependency dependency, CacheItemPriority priority, CacheItemRemovedCallback callback)
        { _cache.Insert(key, value, dependency, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(_storeMinutes), priority, callback); }

        public static void Insert(string key, object value, CacheDependency dependency, CacheItemRemovedCallback callback)
        { Insert(key, value, dependency, CacheItemPriority.Default, callback); }

        public static void Insert(string key, object value, CacheDependency dependency)
        { Insert(key, value, dependency, CacheItemPriority.Default, null); }

        public static void Insert(string key, object value, double storeMinutes)
        {
            Remove(key);
            _cache.Insert(key, value, null, DateTime.Now.AddMinutes(storeMinutes), Cache.NoSlidingExpiration);
        }

        public static void Insert(string key, object value)
        { Insert(key, value, _storeMinutes); }

        public static object Get(string key)
        { return string.IsNullOrEmpty(key) ? null : _cache.Get(key); }

        public static List<string> GetKeys()
        {
            List<string> keys = new List<string>();
            foreach (DictionaryEntry item in _cache)
                keys.Add(item.Key.ToString());
            return keys;
        }

        public static void RemoveAll()
        {
            IList<string> keys = GetKeys();
            foreach (string key in keys)
                _cache.Remove(key);
        }

        public static void Remove(string key)
        {
            if (string.IsNullOrEmpty(key)) return;
            _cache.Remove(key);
        }
    }
}
