using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web一般处理程序
{
    public partial class webNewsAdd : System.Web.UI.Page
    {
        Bll.NewsInfoBll newbll = new Bll.NewsInfoBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NewsInfo ni = new NewsInfo();
                ni.Ntitle = Request["ptnName"];
                ni.Ncontent = Request["ptnContent"];
                ni.Ndate = DateTime.Now;

                if (newbll.Insert(ni) > 0)
                {
                    Response.Redirect("/webNewsList.aspx");
                }
            }

        }
    }
}