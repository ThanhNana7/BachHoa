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
        public List<LoaiHang> Layloaihang(int count)
        {
            return data.LoaiHangs.OrderByDescending(a => a.MSLH).Take(count).ToList();
        }
        public ActionResult Index()
        {
            var loaihang = Layloaihang(5);
            return View(loaihang);
        }
    }
}