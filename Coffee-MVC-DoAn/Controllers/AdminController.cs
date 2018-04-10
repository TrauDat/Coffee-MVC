using Coffee_MVC_DoAn.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;    
namespace Coffee_MVC_DoAn.Controllers
{
    public class AdminController : Controller
    {
        private dbQLCoffeeDataContext db = new dbQLCoffeeDataContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Coffee(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;

            return View(db.COFFEEs.ToList().OrderBy(n => n.MaCF).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["username"];
            var matkhau = collection["password"];
           
                Admin ad = db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index","Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            
            return View();
        }
    }
}