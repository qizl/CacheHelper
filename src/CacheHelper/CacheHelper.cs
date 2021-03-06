﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

        #region Utility Methods
        /// <summary>
        /// 生成Key
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string GenerateKey(params object[] keys)
        {
            StackTrace stackTrace = new StackTrace();
            //return stackTrace.GetFrame(1).GetMethod().ReflectedType.FullName + "." + stackTrace.GetFrame(1).GetMethod().Name + "." + string.Join(".", keys);
            return stackTrace.GetFrame(1).GetMethod().ReflectedType.FullName + "." + string.Join(".", keys);
        }

        /// <summary>
        /// 生成Key
        /// </summary>
        /// <param name="keys"></param>
        /// <returns>调用者命名空间 + keys</returns>
        public static string GenerateKey(StackTrace stackTrace)
        {
            //return stackTrace.GetFrame(1).GetMethod().ReflectedType.FullName + "." + stackTrace.GetFrame(1).GetMethod().Name + ".";
            return stackTrace.GetFrame(1).GetMethod().ReflectedType.FullName + ".";
        }
        #endregion

        #region Methods Insert
        public static void InsertAbsoluteExpiration(string key, object value, CacheDependency dependencies, double storeMinutes)
        {
            Remove(key);
            _cache.Insert(key, value, dependencies, DateTime.Now.AddMinutes(storeMinutes), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        /// <summary>
        /// 插入缓存
        ///     绝对到期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dependencies">缓存依赖</param>
        public static void InsertAbsoluteExpiration(string key, object value, CacheDependency dependencies)
        { InsertAbsoluteExpiration(key, value, dependencies, _storeMinutes); }

        /// <summary>
        /// 插入缓存
        ///     绝对到期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="storeMinutes">绝对到期时间</param>
        public static void InsertAbsoluteExpiration(string key, object value, double storeMinutes)
        { InsertAbsoluteExpiration(key, value, null, storeMinutes); }

        /// <summary>
        /// 插入缓存
        ///     绝对到期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void InsertAbsoluteExpiration(string key, object value)
        { InsertAbsoluteExpiration(key, value, _storeMinutes); }

        public static void InsertSlidingExpiration(string key, object value, CacheDependency dependencies, double storeMinutes)
        {
            Remove(key);
            _cache.Insert(key, value, dependencies, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(storeMinutes), CacheItemPriority.High, null);
        }

        /// <summary>
        /// 插入缓存
        ///     平滑到期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dependencies">缓存依赖</param>
        public static void InsertSlidingExpiration(string key, object value, CacheDependency dependencies)
        { InsertSlidingExpiration(key, value, dependencies, _storeMinutes); }

        /// <summary>
        /// 插入缓存
        ///     平滑到期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="storeMinutes">平滑到期时间</param>
        public static void InsertSlidingExpiration(string key, object value, double storeMinutes)
        { InsertSlidingExpiration(key, value, null, storeMinutes); }

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
        /// <summary>
        /// 获取缓存
        ///     根据调用对象生成Key
        /// </summary>
        /// <returns></returns>
        public static object Get()
        { return _cache.Get(GenerateKey(new StackTrace())); }

        public static object Get(string key)
        { return string.IsNullOrEmpty(key) ? null : _cache.Get(key); }

        public static List<string> GetKeys(string s)
        {
            List<string> keys = new List<string>();
            foreach (DictionaryEntry item in _cache)
                if (item.Key.ToString().Contains(s))
                    keys.Add(item.Key.ToString());
            return keys;
        }

        public static List<string> GetKeys()
        { return GetKeys(string.Empty); }

        public static void RemoveAll()
        {
            IList<string> keys = GetKeys();
            foreach (string key in keys)
                _cache.Remove(key);
        }

        /// <summary>
        /// 移除包含指定字符的缓存
        /// </summary>
        /// <param name="keywords"></param>
        public static void RemoveMany(string s)
        {
            var hwsKeys = CacheHelper.GetKeys(s);
            if (hwsKeys != null)
                foreach (var item in hwsKeys)
                    CacheHelper.Remove(item);
        }

        public static void Remove(string key)
        {
            if (string.IsNullOrEmpty(key)) return;
            _cache.Remove(key);
        }
        #endregion
    }
}
