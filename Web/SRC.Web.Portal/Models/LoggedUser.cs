using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRC.Web.Portal.Models
{
    public class LoggedUser
    {
        public static Contact Current
        {
            get { return (Contact)HttpContext.Current.Session["User"]; }
            set { HttpContext.Current.Session["User"] = value; }
        }

        public static bool IsLoggedIn
        {
            get
            {
                return Current != null;
            }
        }
    }
}