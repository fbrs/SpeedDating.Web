﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedDating.Web.Helpers
{
    public static class NavigationInidicatorHelper
    {
        public static string MakeActiveClass(this IUrlHelper urlHelper, string controller, string action)
        {
            try
            {
                string result = "active";
                string controllerName = urlHelper.ActionContext.RouteData.Values["controller"].ToString();
                string methodName = urlHelper.ActionContext.RouteData.Values["action"].ToString();
                if (string.IsNullOrEmpty(controllerName)) return null;
                if (controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
                {
                    if (methodName.Equals(action, StringComparison.OrdinalIgnoreCase))
                    {
                        return result;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string MakeActiveClass(this IUrlHelper urlHelper, string controller)
        {
            try
            {
                string result = "active";
                string controllerName = urlHelper.ActionContext.RouteData.Values["controller"].ToString();
                if (string.IsNullOrEmpty(controllerName)) return null;
                if (controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
                {
                    return result;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string MakeMenuTreeActive(this IUrlHelper urlHelper, string controller)
        {
            try
            {
                string result = "menu-open";
                string controllerName = urlHelper.ActionContext.RouteData.Values["controller"].ToString();
                if (string.IsNullOrEmpty(controllerName)) return null;
                if (controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
                {
                    return result;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
