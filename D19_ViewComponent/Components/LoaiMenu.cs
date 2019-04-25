using D19_ViewComponent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D19_ViewComponent.Components
{
    public class LoaiMenu : ViewComponent
    {
        private readonly MyeStoreContext ctx;

        public LoaiMenu(MyeStoreContext db)
        {
            ctx = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(
                ctx.Loai.OrderBy(p => p.TenLoai)
                );
        }
    }
}
