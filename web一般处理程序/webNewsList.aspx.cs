using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace web一般处理程序
{
    public partial class webNewsList : System.Web.UI.Page
    {
        Bll.NewsInfoBll newsbll = new Bll.NewsInfoBll();
        public List<NewsInfo> pageNewslist = new List<NewsInfo>();
        public string pageList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //list=newsbll.GetAllNews();

            //分页查询
            int pageIndex = int.Parse(Request["pageindex"] ?? "1");
            int pageSize = 3;
            

            //@pageindex int,--当前点击页
            //@pageSize int,--每页数据条数
            //@total int out--一共多少页
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@pageindex",SqlDbType.Int) { Value=pageIndex},
                new SqlParameter("@pageSize",SqlDbType.Int) { Value=pageSize},
                new SqlParameter("@total",SqlDbType.Int) { Direction=ParameterDirection.Output}
            };

            DataTable dt= Dal.SqlHelper.pageDataTable("P_ShowPageDate",CommandType.StoredProcedure,pms);
            int total = Convert.ToInt32(pms[2].Value);

            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NewsInfo ni = new NewsInfo();
                ni.Nid = Convert.ToInt32(dt.Rows[i]["Nid"]);
                ni.Ntitle = Convert.ToString(dt.Rows[i]["NTitle"]);
                ni.Ndate = Convert.ToDateTime(dt.Rows[i]["NDate"]);
                ni.Ncontent = Convert.ToString(dt.Rows[i]["NContent"]);

                pageNewslist.Add(ni);
            }
            pageList = Common.pageNewsList.showpagenavigate(pageSize, pageIndex, total);
        }
    }
}