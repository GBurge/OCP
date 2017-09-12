using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCP.Components
{
    public class AppCache
    {
        #region Constructor
        public AppCache()
        {
            Init();
        }
        #endregion

        #region Init Method
        public static void Init()
        {
            TeamId = int.MinValue;
        }
        #endregion

        public static string LastPage
        {
            get { return (string)HttpContext.Current.Session["LastPage"]; }
            set { HttpContext.Current.Session["LastPage"] = value; }
        }

        public static string CurrentPage
        {
            get { return (string)HttpContext.Current.Session["CurrentPage"]; }
            set { HttpContext.Current.Session["CurrentPage"] = value; }
        }

        public static string CurrentPageName
        {
            get
            {
                string ret = string.Empty;
                if (HttpContext.Current.Session["CurrentPage"] != null)
                {
                    ret = (string)HttpContext.Current.Session["CurrentPage"];
                    ret = System.IO.Path.GetFileNameWithoutExtension(ret);
                }

                return ret;
            }
        }

        public static int TeamId
        {
            get { return (int) HttpContext.Current.Session["TeamId"]; }
            set { HttpContext.Current.Session["TeamID"] = value; }
        }
    }
}