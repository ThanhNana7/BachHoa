using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BachHoa.Models;

namespace BachHoa.Controllers
{
    public class BachHoaController : Controller
    {
        dbQLCTyBHDataContext data = new dbQLCTyBHDataContext();
        private List<MatHang> Laymathangmoi(int count)
        {
            return data.MatHangs.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        public ActionResult Index()
        {
            
            var mathangmoi = Laymathangmoi(8);
            return View(mathangmoi);
        }

        public ActionResult LoaiHang()
        {
            var loaihang = from lh in data.LoaiHangs select lh;
            return PartialView(loaihang);
        }
    }
}