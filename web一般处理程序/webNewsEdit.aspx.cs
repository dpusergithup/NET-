using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web一般处理程序
{
    public partial class webNewsEdit : System.Web.UI.Page
    {
        Bll.NewsInfoBll newsbll = new Bll.NewsInfoBll();
        public NewsInfo list;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                NewsInfo ni = new NewsInfo();
                ni.Nid = int.Parse(Request["ptnId"] ?? "0");
                ni.Ntitle = Request["ptnName"];
                ni.Ndate = DateTime.Now;
                ni.Ncontent = Request["ptnContent"];

                if (newsbll.Update(ni)>0)
                {
                    Response.Redirect("/webNewsList.aspx");
                }

            }
            else
            {
                int id = Convert.ToInt32(Request["id"] ?? "0");
                list=newsbll.GetDataById(id);
            }
        }
    }
}