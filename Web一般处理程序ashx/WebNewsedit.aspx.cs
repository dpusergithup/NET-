using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web一般处理程序ashx
{
    public partial class WebNewsedit : System.Web.UI.Page
    {
        Bll.NewsInfoBll bllnew = new Bll.NewsInfoBll();
        public NewsInfo list { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"] ?? "0");
            list = bllnew.GetDataById(id);
        }
    }
}