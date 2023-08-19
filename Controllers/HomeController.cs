using Microsoft.AspNetCore.Mvc;
using MVCHomework6.Models;
using System.Diagnostics;
using MVCHomework6.Data;
using MVCHomework6.Data.Database;
using X.PagedList;

namespace MVCHomework6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDbContext _context;

        public HomeController(ILogger<HomeController> logger, BlogDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? p, string? q)
        {
            //這是範例，已經塞了20筆資料進去
            var model = _context.Articles.AsQueryable();
            if (string.IsNullOrEmpty(q) == false)
            {
                ViewBag.KeyWord = q;
                model = model.Where(x => x.Title.Contains(q)
                                                    || x.Body.Contains(q)
                                                    || x.Tags.Contains(q));
            }
            //頁數，預設第一頁
            var pageNumber = p ?? 1;
            //現在第幾頁pageNumber , 每頁幾筆1
            var posts = model.ToPagedList(pageNumber, 1);
            ViewBag.Posts = posts;
            return View(model);
        }

        [HttpGet]
        public List<TagCloud> GetTagCloud()
        {
            var tags = _context.TagCloud;
            return tags.ToList();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}