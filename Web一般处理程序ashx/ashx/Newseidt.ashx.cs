using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web一般处理程序ashx.ashx
{
    /// <summary>
    /// Newseidt 的摘要说明
    /// </summary>
    public class Newseidt : IHttpHandler
    {
        Bll.NewsInfoBll bllnew = new Bll.NewsInfoBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            NewsInfo ni = new NewsInfo();
            ni.Nid= int.Parse(context.Request["ptnId"]);
            ni.Ntitle = context.Request["ptnName"];
            ni.Ndate = DateTime.Now;
            ni.Ncontent = context.Request["ptnContent"];
            if (bllnew.Update(ni) > 0)
            {
                context.Response.Write("OK");
            }

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