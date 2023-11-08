using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using thecfhouse.Models;

namespace thecfhouse.Controllers
{
    public class CategoriesController : Controller
    {
        //tạo biến name database = new name();
        DoAnWebbEntities database = new DoAnWebbEntities();

        // GET: Categories
        public ActionResult Index(string _name)
        {
            if (_name == null)
                return View(database.Categories.ToList());
            else
                return View(database.Categories.Where(s => s.TENLOAIHANG.Contains(_name)).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category cate)
        {
            database.Categories.Add(cate);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}