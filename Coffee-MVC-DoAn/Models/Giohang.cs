using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee_MVC_DoAn.Models
{
    public class Giohang
    {
        dbQLCoffeeDataContext data = new dbQLCoffeeDataContext();
        public int iMaCF { get; set; }
        public string sTenCF { set; get; }
        public string sAnhbia { get; set; }
        public Double dDongia { get; set; }
        public int iSoluong { set; get; }
        public Double  dThanhtien
        {
            get { return iSoluong * dDongia; }
        }
        public Giohang(int MaCF)
        {
            iMaCF = MaCF;
            COFFEE coffee = data.COFFEEs.Single(n => n.MaCF == iMaCF);
            sTenCF = coffee.TenCF;
            sAnhbia = coffee.Anhbia;
            dDongia = double.Parse(coffee.Giaban.ToString());
            iSoluong = 1;
        }
    }
}