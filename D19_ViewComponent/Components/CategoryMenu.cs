using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D19_ViewComponent.Components
{
    public class CategoryMenu : ViewComponent
    {
        public IViewComponentResult Invoke(int n = 5, string ten = "")
        {
            //Xử lý dữ liệu
            Random rd = new Random();
            List<int> data = new List<int>();
            for(int i = 0; i < n; i++)
            {
                data.Add(rd.Next(100, 9999));
            }

            //trả về view
            return View(data);
        }
    }


}
