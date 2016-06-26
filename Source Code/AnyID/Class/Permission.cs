using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnyID.Class;

namespace AnyID.Class
{
    public class Permission : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            if (CommonHelper.IsNotnull(HttpContext.Current.Request["staff_code"]) && CommonHelper.IsNotnull(HttpContext.Current.Request["department_code"]))
            {
                HttpContext.Current.Session["UserID"] = HttpContext.Current.Request["staff_code"];
                HttpContext.Current.Session["SolID"] = HttpContext.Current.Request["department_code"];//DepartmentCode(HttpContext.Current.Request["department_code"]);
            }
            else
            {
                if (CommonHelper.Isnull(HttpContext.Current.Session["UserID"]))
                {
                    HttpContext.Current.Response.Redirect("~/Default/PermissionTimeOut");
                }
            }
        }
        public void Logout()
        {
            HttpContext.Current.Session.Abandon();
        }

        public string DepartmentCode(string DepCode)
        {
            string Code;
            try
            {
                if (DepCode == "00001A1")
                {
                    Code = "00100";
                }
                else 
                {
                    Code = DepCode.Substring(2, 5);
                }
                
            }
            catch
            {
                Code = "";
            }

            return Code;
            
        }
    }
}