using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class NewsInfoDal
    {
        TextDemo1Entities db = new TextDemo1Entities();
        public List<NewsInfo> GetAllNews()
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from NewsInfoes");
            //DataSet dataset = SqlHelper.ExecuteDataSet("select * from NewsInfo");

            //DataTable dt = dataset.Tables[0];

            List<NewsInfo> list = new List<NewsInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NewsInfo ni = new NewsInfo();
                ni.Nid = Convert.ToInt32(dt.Rows[i]["Nid"]);
                ni.Ntitle = Convert.ToString(dt.Rows[i]["NTitle"]);
                ni.Ndate = Convert.ToDateTime(dt.Rows[i]["NDate"]);
                ni.Ncontent = Convert.ToString(dt.Rows[i]["NContent"]);

                list.Add(ni);
            }

            return list;
        }

        public int Insert(NewsInfo ni)
        {
            return SqlHelper.ExecuteNonQuery("insert into NewsInfoes(NTitle, NDate, NContent)values(@NTitle, @NDate, @NContent)",
                new SqlParameter("@NTitle",ni.Ntitle),
                new SqlParameter("@NDate", ni.Ndate),
                new SqlParameter("@NContent", ni.Ncontent));
        }

        public int Update(NewsInfo ni)
        {
            return SqlHelper.ExecuteNonQuery("update NewsInfoes set NTitle=@txtName,NDate=@mydate,NContent=@txtnum where Nid=@id",
                new SqlParameter("@id", ni.Nid),
                new SqlParameter("@txtName", ni.Ntitle),
                new SqlParameter("@mydate", ni.Ndate),
                new SqlParameter("@txtnum", ni.Ncontent));
        }

        public NewsInfo GetDataById(int id)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select * from NewsInfoes where Nid=@id",
                new SqlParameter("@id", id));

            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count > 1)
            {
                throw new Exception("系统错误");
            }

            NewsInfo ni = new NewsInfo();
            ni.Nid = Convert.ToInt32(dt.Rows[0]["Nid"]);
            ni.Ntitle = Convert.ToString(dt.Rows[0]["NTitle"]);
            ni.Ndate = Convert.ToDateTime(dt.Rows[0]["NDate"]);
            ni.Ncontent = Convert.ToString(dt.Rows[0]["NContent"]);

            return ni;
        }

        //EF调用数据库方法
        public IQueryable<NewsInfoes> GetAllMVCList(Expression<Func<NewsInfoes, bool>> whereLamber)
        {
            return db.NewsInfoes.Where(whereLamber).AsQueryable();
        }

        public bool editNews(NewsInfoes ni)
        {
            db.Entry(ni).State = System.Data.Entity.EntityState.Modified;

            return db.SaveChanges()>0;
        }

        public bool DeleteNews(NewsInfoes ni)
        {
            db.Entry(ni).State = System.Data.Entity.EntityState.Deleted;

            return db.SaveChanges() > 0;
        }


        public bool AddNews(NewsInfoes ni)
        {
            db.NewsInfoes.Add(ni);

            return db.SaveChanges() > 0;
        }

        //webService服务封装方法
        //web服务封装不了（未解决问题）
        //public IQueryable<NewsInfoes> webServiceGetAllMVCList(Expression<Func<NewsInfoes, bool>> whereLamber)
        //{
        //    return db.NewsInfoes.Where(whereLamber).AsQueryable();
        //}

        public List<NewsInfoes> webServiceGetAllMVCList()
        {
            return db.NewsInfoes.ToList();
        }
        public List<NewsInfoes> webServiceGetAllMVCListByName(string name)
        {
            return db.NewsInfoes.Where(u=>u.NTitle==name).ToList();
        }
        public NewsInfoes webServiceGetAllMVCListById(int id)
        {
            return db.NewsInfoes.Where(u=>u.Nid==id).FirstOrDefault();
        }
        public bool webServiceeditNews(NewsInfoes ni)
        {
            db.Entry(ni).State = System.Data.Entity.EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        public bool webServiceDeleteNews(NewsInfoes ni)
        {
            db.Entry(ni).State = System.Data.Entity.EntityState.Deleted;

            return db.SaveChanges() > 0;
        }

        public bool webServiceAddNews(NewsInfoes ni)
        {
            db.NewsInfoes.Add(ni);

            return db.SaveChanges() > 0;
        }
    }
}
