using Kotabko.Models;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authorization;
=======
using Kotabko.ViewsModels;
>>>>>>> 4a67b3e4a831f247a45ad11b56897899cc9bfdad
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