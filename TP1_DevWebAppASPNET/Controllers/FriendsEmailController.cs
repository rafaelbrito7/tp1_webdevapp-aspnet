using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP1_DevWebAppASPNET.Models;
using Repository;

namespace TP1_DevWebAppASPNET.Controllers
{
    public class FriendsEmailController : Controller
    {
        private readonly ILogger<FriendsEmailController> _logger;
        private AlunoRepository Repository { get; set; }


        public FriendsEmailController(ILogger<FriendsEmailController> logger)
        {
            _logger = logger;
            this.Repository = new AlunoRepository();
        }

        public ActionResult Index()
        {
            return View(this.Repository.GetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
