using Kotabko.Models;
using Kotabko.ViewsModels;

using Microsoft.AspNetCore.Authorization;


using Microsoft.AspNetCore.Mvc;

namespace Kotabko.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            List<MainBookVM> list = new List<MainBookVM>()
            {
                new MainBookVM(){Author=new Author()
                {
                    Name="Author Name"
                },
                Image="33.jpg",
                Price=25,
                Rate=4,
                Title="Book Title"
                },
                                new MainBookVM(){Author=new Author()
                {
                    Name="Author Name"
                },
                Image="33.jpg",
                Price=25,
                Rate=4,
                Title="Book Title"
                },                new MainBookVM(){Author=new Author()
                {
                    Name="Author Name"
                },
                Image="33.jpg",
                Price=25,
                Rate=4,
                Title="Book Title"
                },                new MainBookVM(){Author=new Author()
                {
                    Name="Author Name"
                },
                Image="33.jpg",
                Price=25,
                Rate=4,
                Title="Book Title"
                },                new MainBookVM(){Author=new Author()
                {
                    Name="Author Name"
                },
                Image="33.jpg",
                Price=25,
                Rate=4,
                Title="Book Title"
                },                new MainBookVM(){Author=new Author()
                {
                    Name="Author Name"
                },
                Image="33.jpg",
                Price=25,
                Rate=4,
                Title="Book Title"
                },
            };
            return View(list);
        }

    }
}