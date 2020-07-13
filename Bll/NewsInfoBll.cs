using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bll
{
    
    public class NewsInfoBll
    {
        private Dal.NewsInfoDal newsdal = new Dal.NewsInfoDal();

        public List<NewsInfo> GetAllNews()
        {
            return newsdal.GetAllNews();
        }

        public int Insert(NewsInfo ni)
        {
            return newsdal.Insert(ni);
        }

        public int Update(NewsInfo ni)
        {
            return newsdal.Update(ni);
        }

        public NewsInfo GetDataById(int id)
        {

            return newsdal.GetDataById(id);
        }

        //EF调用数据库方法
        public IQueryable<NewsInfoes> GetAllMVCList(Expression<Func<NewsInfoes, bool>> whereLamber)
        {
            return newsdal.GetAllMVCList(whereLamber);
        }

        public bool editNews(NewsInfoes ni)
        {

            return newsdal.editNews(ni);
        }

        public bool DeleteNews(NewsInfoes ni)
        {
            return newsdal.DeleteNews(ni);
        }


        public bool AddNews(NewsInfoes ni)
        {
            return newsdal.AddNews(ni);
        }

        //webService服务封装方法
        //public IQueryable<NewsInfoes> webServiceGetAllMVCList(Expression<Func<NewsInfoes, bool>> whereLamber)
        //{
        //    return newsdal.webServiceGetAllMVCList(whereLamber);
        //}

        public List<NewsInfoes> webServiceGetAllMVCList()
        {
            return newsdal.webServiceGetAllMVCList();
        }
        public List<NewsInfoes> webServiceGetAllMVCListByName(string name)
        {
            return newsdal.webServiceGetAllMVCListByName(name);
        }
        public NewsInfoes webServiceGetAllMVCListById(int id)
        {
            return newsdal.webServiceGetAllMVCListById(id);
        }

        public bool webServiceeditNews(NewsInfoes ni)
        {

            return newsdal.editNews(ni);
        }

        public bool webServiceDeleteNews(NewsInfoes ni)
        {
            return newsdal.DeleteNews(ni);
        }

        public bool webServiceAddNews(NewsInfoes ni)
        {
            return newsdal.AddNews(ni);
        }
    }
}
