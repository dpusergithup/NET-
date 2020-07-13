using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;

namespace WebServiceDemo
{
    /// <summary>
    /// WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        Bll.NewsInfoBll bllnew = new Bll.NewsInfoBll();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        //[WebMethod]
        //public IQueryable<NewsInfoes> webServiceGetAllMVCList(Expression<Func<NewsInfoes, bool>> whereLamber)
        //{
        //    return bllnew.webServiceGetAllMVCList(whereLamber);
        //}
        [WebMethod]
        public List<NewsInfoes> webServiceGetAllMVCList()
        {
            return bllnew.webServiceGetAllMVCList();
        }
        [WebMethod]
        public List<NewsInfoes> webServiceGetAllMVCListByName(string name)
        {
            return bllnew.webServiceGetAllMVCListByName(name);
        }
        [WebMethod]
        public NewsInfoes webServiceGetAllMVCListById(int id)
        {
            return bllnew.webServiceGetAllMVCListById(id);
        }
        [WebMethod]
        public bool webServiceeditNews(NewsInfoes ni)
        {

            return bllnew.editNews(ni);
        }
        [WebMethod]
        public bool webServiceDeleteNews(NewsInfoes ni)
        {
            return bllnew.DeleteNews(ni);
        }
        [WebMethod]
        public bool webServiceAddNews(NewsInfoes ni)
        {
            return bllnew.AddNews(ni);
        }

    }
}
