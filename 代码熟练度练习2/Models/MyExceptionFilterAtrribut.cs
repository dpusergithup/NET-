using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 代码熟练度练习2.Models
{
    public class MyExceptionFilterAtrribut: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);

            //把错误文件写到日志里面去
            LogHelper.WriteLof(filterContext.Exception.ToString());
        }
    }
}