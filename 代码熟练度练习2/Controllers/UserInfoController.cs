using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 代码熟练度练习2.Models;

namespace 代码熟练度练习2.Controllers
{
    public class UserInfoController : Controller
    {
        //JHcoTextDemoEntities db = new JHcoTextDemoEntities();
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {
            var temp = DbContentFactory.GetCurrentDbContent().UserInfo.Where(u => true).Select(u=> new { u.Id, u.UName, u.ShowName, u.SubTime, u.ModifedOn, u.Pwd, u.Remark }); ;
            var total = DbContentFactory.GetCurrentDbContent().UserInfo.Count();
            var data = new { total = total, rows = temp.ToList() };//按照上面的table格式传送数据

            return Json(data, JsonRequestBehavior.AllowGet);//JsonRequestBehavior.AllowGet允许客户端传的get请求
        }

        public ActionResult Add(UserInfo ui)
        {
            ui.ModifedOn = DateTime.Now;
            ui.SubTime = DateTime.Now;
            ui.DelFlag = (short)Models.Enum.DelFlagEnum.Normal;
            DbContentFactory.GetCurrentDbContent().UserInfo.Add(ui);
            DbContentFactory.GetCurrentDbContent().SaveChanges();
            return Content("OK");
        }

        public ActionResult Edit(int id)
        {
            ViewData.Model= DbContentFactory.GetCurrentDbContent().UserInfo.Where(u => u.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(UserInfo ui)
        {
            DbContentFactory.GetCurrentDbContent().Entry(ui).State = System.Data.Entity.EntityState.Modified;
            DbContentFactory.GetCurrentDbContent().SaveChanges();
            return Content("OK");
        }

        public ActionResult Delete(string ids)
        {
            if (ids == null)
            {
                return Content("请选着要删除的项");
            }
            //把字符串分成数组
            string[] strId = ids.Split(',');

            List<int> lids = new List<int>();
            foreach (var id in strId)
            {
                lids.Add(int.Parse(id));
            }

            foreach (var id in lids)
            {
                var user=DbContentFactory.GetCurrentDbContent().UserInfo.Find(id);
                DbContentFactory.GetCurrentDbContent().UserInfo.Remove(user);

            }
            DbContentFactory.GetCurrentDbContent().SaveChanges();
            return Content("OK");
        }

        public ActionResult SetRole(int id)
        {
            var delFlag = (short)Models.Enum.DelFlagEnum.Normal;
            //查询给哪个用户添加角色
            var users=DbContentFactory.GetCurrentDbContent().UserInfo.Find(id);
            ViewBag.user = users;
            //查询出所有的角色
            ViewData.Model=DbContentFactory.GetCurrentDbContent().RoleInfo.Where(r => r.DelFlag == delFlag);

            //查询当前用户拥有的角色
            ViewBag.AllRole = (from u in users.RoleInfo
                        select u.Id).ToList();

            return View();
        }

        public ActionResult ProcessSetRole(int UId)
        {
            //第一：给谁设置角色
            int userId = UId;
            //第一：所有打上勾的角色
            List<int> lids = new List<int>();
            foreach (var item in Request.Form.AllKeys)//遍历表单的所有的key
            {
                if (item.Contains("ckb_"))
                {
                    var id= int.Parse(item.Replace("ckb_", ""));
                    lids.Add(id);
                }
            }
            //查询当前用户
            var user=DbContentFactory.GetCurrentDbContent().UserInfo.Find(userId);
            //清除当前用户的所有角色
            user.RoleInfo.Clear();

            //查询当前的角色
            foreach (var rid in lids)
            {
                var ruser=DbContentFactory.GetCurrentDbContent().RoleInfo.Find(rid);
                user.RoleInfo.Add(ruser);
            }
            DbContentFactory.GetCurrentDbContent().SaveChanges();
            return Content("OK");
        }
        //TODO:测试页面的Model类型
        public ActionResult Edit1(int id)
        {
            ViewData.Model = DbContentFactory.GetCurrentDbContent().UserInfo.Where(u => u.Id == id).FirstOrDefault();
            return View();
        }
    }
}