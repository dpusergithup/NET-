using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 代码熟练度练习2.Models;

namespace 代码熟练度练习2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserInfo ui)
        {

            try
            {
                DbContentFactory.GetCurrentDbContent().UserInfo.Add(ui);
                DbContentFactory.GetCurrentDbContent().SaveChanges();
            }
            catch (Exception ex)
            {

                return Content("异常信息"+ex);
            }
            return RedirectToAction("Index", "UserInfo");
        }

        public ActionResult ProcessLogin()
        {
            //获取验证码
            var strvode=Request["VCode"];
            //拿到Session里的验证码
            var strSeion = Session["code"] as string;

            Session["code"] = null;
            if (strvode != strSeion)
            {
                return Content("验证码错误");
            }

            //拿到用户名密码
            string name = Request["UserName"];
            string pwd = Request["Password"];
            var users=  DbContentFactory.GetCurrentDbContent().UserInfo.Where(u => u.UName == name && u.Pwd == pwd).FirstOrDefault();

            if (users == null)
            {
                return Content("账号密码错误错误");
            }

            //把登录用户放到Session里面去
            Session["LoginUsers"] = users;

            return Content("OK");
        }

        public ActionResult ShowVCode()
        {
            //生成验证码
            Models.ValidateCode valid = new Models.ValidateCode();
            var strVod= valid.CreateValidateCode(4);

            //把验证码放到Session里面去
            Session["code"] = strVod;

            //生成验证码图片
            Byte[] imgbyte= valid.CreateValidateGraphic(strVod);

            return File(imgbyte, @"image/jpeg");
        }
    }
}