using ASp_MVC.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Collections.Generic;
using System.Text;

namespace ASp_MVC.ViewComponents
{
    public class ConsultationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Consult> consults)
        {
            return View(consults);
        }
    }
}