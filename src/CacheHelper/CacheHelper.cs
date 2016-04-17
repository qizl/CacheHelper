﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

namespace Com.EnjoyCodes.CacheHelper
{
    public class CacheHelper
    {
        #region Members & Properties
        private static Cache _cache = HttpRuntime.Cache;
        private static double _storeMinutes = 15d;
        public static double StoreMinutes
        {
            get { return _storeMinutes; }
            set { _storeMinutes = value; }
        }
        #endregion

        #region Methods Insert
        /// <summary>
        /// 插入缓存
        ///     绝对到期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="storeMinutes">绝对到期时间</param>
        public static void InsertAbsoluteExpiration(string key, object value, double storeMinutes)
        {
            Remove(key);
            _cache.Insert(key, value, null, DateTime.Now.AddMinutes(storeMinutes), Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 插入缓存
        ///     绝对到期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void InsertAbsoluteExpiration(string key, object value)
        { InsertAbsoluteExpiration(key, value, _storeMinutes); }

        /// <summary>
        /// 插入缓存
        ///     平滑到期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="storeMinutes">平滑到期时间</param>
        public static void InsertSlidingExpiration(string key, object value, double storeMinutes)
        {
            Remove(key);
            _cache.Insert(key, value, null, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(storeMinutes));
        }

        /// <summary>
        /// 插入缓存
        ///     平滑到期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void InsertSlidingExpiration(string key, object value)
        { InsertSlidingExpiration(key, value, _storeMinutes); }

        /// <summary>
        /// 插入缓存
        ///     不到期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Insert(string key, object value)
        { _cache.Insert(key, value); }
        #endregion

        #region Methods Get & Remove
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
        #endregion
    }
}
