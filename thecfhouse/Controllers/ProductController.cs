using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using thecfhouse.Models;

namespace thecfhouse.Controllers
{
    public class ProductController : Controller
    {
        DoAnWebbEntities database = new DoAnWebbEntities();
        // GET: Product
        public ActionResult Tra()
        {          
            var joinedData = database.Products
                .Join(database.ProductsDetails,
                      product => product.MALOAIHANG,  // Thay thế bằng thuộc tính khóa ngoại thực tế của bạn
                      detail => detail.MASP,    // Thay thế bằng thuộc tính khóa ngoại thực tế của bạn
                      (product, detail) => new ProductViewModel
                      {
                          MASP = product.MASP,
                          TENSP = product.TENSP,
                          MALOAIHANG = product.MALOAIHANG,
                          HINHSP = product.HINHSP,
                          MOTA = product.MOTA,
                          GIA = detail.GIA
                      })
                .ToList();

            return View(joinedData);
        }

        //public ActionResult Tra()
        //{
        //    var query = from p in database.Products
        //                join pd in database.ProductsDetails on p.MALOAIHANG equals pd.MASP
        //                select new ProductViewModel // Tạo một ViewModel để lưu thông tin cần thiết
        //                {
        //                    MASP = p.MASP,
        //                    TENSP = p.TENSP,
        //                    MALOAIHANG = p.MALOAIHANG,
        //                    HINHSP = p.HINHSP,
        //                    MOTA = p.MOTA,
        //                    GIA = pd.GIA
        //                };

        //    return View(query.ToList());
        //    return View(database.Products.ToList());
        //}
        public ActionResult Create()
        {
            Product pro = new Product();
            return View(pro);
        }
        public ActionResult SelectCate()
        {
            Category se_cate = new Category();
            se_cate.ListCate = database.Categories.ToList<Category>();
            return PartialView(se_cate);
        }

        [HttpPost]
        public ActionResult Create(Product pro) 
        {
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.HINHSP = "~/img/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/img/"), filename));
                }
                database.Products.Add(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}