﻿using System.Web;
using System.Web.Mvc;

namespace Com.EnjoyCodes.CacheHelper.WebClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
