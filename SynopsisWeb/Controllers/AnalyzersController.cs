using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynopsisWeb.Controllers
{

    public class Temp
    {
        public string A { get; set; }
        public string B { get; set; }
    }

    public class AnalyzersController : Controller
    {
        public IActionResult MembersByModifier()
        {
            // TODO: Pass Members By Access Modifier data object to the page
            // TODO: Render object on page

            ViewData["thing"] = new Temp() { A = "foo", B = "bar" };
            ViewData["Message"] = "This is a test message. I can update without compiling.";

            return View();
        }

    }
}
