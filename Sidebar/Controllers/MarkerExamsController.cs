using Microsoft.AspNetCore.Mvc;
using Sidebar.Data;
using Sidebar.Services;

namespace Sidebar.Controllers
{
    public class MarkerExamsController : Controller
    {

        private readonly WebAppDbContext _db;


        public MarkerExamsController(WebAppDbContext context)
        {
            _db = context;
           
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
