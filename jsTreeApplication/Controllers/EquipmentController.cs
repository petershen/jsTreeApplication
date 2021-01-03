using jsTreeApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jsTreeApplication.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            TreeNode model = new TreeNode();
            return View(model);
        }
    }
}
