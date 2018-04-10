using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coffee_MVC_DoAn.Models;

using PagedList;
using PagedList.Mvc;

namespace Coffee_MVC_DoAn.Controllers
{
    public class CoffeeController : Controller
    {
        dbQLCoffeeDataContext data = new dbQLCoffeeDataContext();
        // GET: Coffee
        private List<COFFEE> Layspmoi(int count)
        {
            return data.COFFEEs.OrderByDescending(a => a.Ngaycapnhat).Take(count).ToList();
        }
        public ActionResult Index(int ? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            var spmoi = Layspmoi(15);
            return View(spmoi.ToPagedList(pageNum,pageSize));
        }
        public ActionResult LoaiCF()
        {
            var loaicf = from cd in data.LOAICFs select cd;
            return PartialView(loaicf);
        }
        public ActionResult SPTheoLoaiCF(int id)
        {
            var coffee = from s in data.COFFEEs where s.MaCF == id select s;
            return View(coffee);
        }
        public ActionResult Details(int id)
        {
            var coffee = from s in data.COFFEEs
                         where s.MaCF == id
                         select s;
            return View(coffee.Single());
        }
    }
}