using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D19_ViewComponent.Models;
using Microsoft.AspNetCore.Mvc;

namespace D19_ViewComponent.Controllers
{
    public class DemoController : Controller
    {
        private readonly MyeStoreContext ctx;
        public DemoController(MyeStoreContext db)
        {
            ctx = db;
        }
        public IActionResult ThongKe()
        {
            var data = ctx.HangHoa
                .GroupBy(p => p.MaLoaiNavigation)
                .Select(p => new
                {
                    p.Key.MaLoai,
                    p.Key.TenLoai,
                    SoMatHang = p.Count(),
                    TongSoLanXem = p.Sum(q => q.SoLanXem),
                    GiaTB = p.Average(q => q.DonGia.Value)
                });
            return Json(data);
        }

        public IActionResult DoanhThu()
        {
            var data = from cthd in ctx.ChiTietHd
                       group cthd by new
                       {
                           Thang = cthd.MaHdNavigation.NgayDat.Month,
                           Nam = cthd.MaHdNavigation.NgayDat.Year
                       } into g
                       select new
                       {
                           g.Key.Thang,
                           g.Key.Nam,
                           DoanhThu = g.Sum(p => p.SoLuong * p.DonGia * (1 - p.GiamGia))
                       };
            return Json(data);
        }
    }
}