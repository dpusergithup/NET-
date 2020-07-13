using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 代码熟练度练习2.Models;

namespace 代码熟练度练习2.Controllers
{
    public class RoleInfoController : Controller
    {
        short delflgNormal = (short)Models.Enum.DelFlagEnum.Normal;
        // GET: RoleInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {
            var temp=DbContentFactory.GetCurrentDbContent().RoleInfo.Where(r => true).Select(r=>new { r.Id, r.RoleName, r.Remark, r.SubTime, r.ModifedOn, r.DelFlag });
            var data = new { total = temp.Count(), rows = temp.ToList() };//按照上面的table格式传送数据

            return Json(data, JsonRequestBehavior.AllowGet);//JsonRequestBehavior.AllowGet允许客户端传的get请求
        }

        public ActionResult Add(RoleInfo ri)
        {
            ri.DelFlag = delflgNormal;
            ri.ModifedOn = DateTime.Now;
            ri.SubTime = DateTime.Now;
            DbContentFactory.GetCurrentDbContent().RoleInfo.Add(ri);
            DbContentFactory.GetCurrentDbContent().SaveChanges();
            return Content("OK");
        }

        public ActionResult showedit(int id)
        {
            var temp = DbContentFactory.GetCurrentDbContent().RoleInfo.Where(r => r.Id == id).Select(r=>new { r.RoleName,r.Remark,r.Id}).FirstOrDefault();
            
            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult edit(RoleInfo ri)
        {
            ri.DelFlag = delflgNormal;
            ri.ModifedOn = DateTime.Now;
            ri.SubTime = DateTime.Now;
            DbContentFactory.GetCurrentDbContent().Entry(ri).State = System.Data.Entity.EntityState.Modified;
            DbContentFactory.GetCurrentDbContent().SaveChanges();

            return Content("OK");
        }

        public ActionResult Delete(string ids)
        {
            if (ids == null)
            {
                return Content("请选着要删除的对象");
            }
            string[] sids= ids.Split(',');
            List<int> lid = new List<int>();

            foreach (var sid in sids)
            {
                lid.Add(int.Parse(sid));
            }
            foreach (var id in lid)
            {
                var temp=DbContentFactory.GetCurrentDbContent().RoleInfo.Find(id);
                DbContentFactory.GetCurrentDbContent().RoleInfo.Remove(temp);
            }
            DbContentFactory.GetCurrentDbContent().SaveChanges();

            return Content("OK");
        }
    }
}