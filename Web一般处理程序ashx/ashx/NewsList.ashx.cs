using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web一般处理程序ashx.ashx
{
    /// <summary>
    /// NewsList 的摘要说明
    /// </summary>
    public class NewsList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            Bll.NewsInfoBll bllnew = new Bll.NewsInfoBll();
            var list=bllnew.GetAllNews();

            System.Web.Script.Serialization.JavaScriptSerializer javascriptserializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            string jsonStr = javascriptserializer.Serialize(list);
            context.Response.Write(jsonStr);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}