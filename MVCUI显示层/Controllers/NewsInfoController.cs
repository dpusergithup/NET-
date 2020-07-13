using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUI显示层.Controllers
{
    public class NewsInfoController : Controller
    {
        Bll.NewsInfoBll bllnew = new Bll.NewsInfoBll();
        // GET: NewsInfo
        public ActionResult Index()
        {
            ViewData.Model = bllnew.GetAllMVCList(n=>true);
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewData.Model = bllnew.GetAllMVCList(n => n.Nid== id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(NewsInfoes ni)
        {
            bllnew.editNews(ni);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ViewData.Model= bllnew.GetAllMVCList(n => n.Nid == id).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id,FormCollection coll)
        {

            NewsInfoes ni = new NewsInfoes();
            ni.Nid = id;
            ni.NDate = DateTime.Now;
            ni.NTitle = string.Empty;
            ni.NContent = string.Empty;

            bllnew.DeleteNews(ni);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewsInfoes ni)
        {
             bllnew.AddNews(ni);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            ViewData.Model = bllnew.GetAllMVCList(n => n.Nid == id).FirstOrDefault();
            return View();
        }

        //异步增删改查
        public ActionResult NewsList()
        {
            return View();
        }

        public ActionResult AllNewsList()
        {
            var model= bllnew.GetAllMVCList(u=>true);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NewsAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewsAdd(NewsInfoes ni)
        {
            bllnew.AddNews(ni);
            return RedirectToAction("NewsList");
        }

        public ActionResult Newsedit(int id)
        {
            //int sid = int.Parse(Request["id"] ?? "0");//和直接传值效果一样
            ViewData.Model= bllnew.GetAllMVCList(n => n.Nid == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Newsedit(NewsInfoes ni)
        {
            bllnew.editNews(ni);
            return RedirectToAction("NewsList");
        }

        //MVC自带异步
        public ActionResult MVCNewsList()
        {
            return View();
        }

        public ActionResult MVCAllNewsList()
        {
            var model = bllnew.GetAllMVCList(u => true);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MVCNewsedit(int id)
        {
            //int sid = int.Parse(Request["id"] ?? "0");//和直接传值效果一样
            ViewData.Model = bllnew.GetAllMVCList(n => n.Nid == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult MVCNewsedit(NewsInfoes ni)
        {
            bllnew.editNews(ni);
            return Content("OK");
        }

        //webServier封装增删改查
        web.webservice.WebServiceSoapClient webs = new web.webservice.WebServiceSoapClient();
        public ActionResult WebServiceList()
        {
            ViewData.Model = webs.webServiceGetAllMVCList();
            return View();
        }

        public ActionResult CreateWebService()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CreateWebService(web.webservice.NewsInfoes ni)
        {
            webs.webServiceAddNews(ni);
            return View();
        }
    }
}