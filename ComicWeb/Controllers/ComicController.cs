using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ComicWeb.Models;
using Microsoft.Extensions.Configuration;
using ComicClient;
using ComicSharedModels;

namespace ComicWeb.Controllers
{
    public class ComicController : Controller
    {
        private readonly ILogger<ComicController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ComicService _comicClient;

        public ComicController(ILogger<ComicController> logger, IConfiguration configuration, ComicService comicFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _comicClient = comicFactory;
        }

        public IActionResult Index()
        {
            ComicModel comic = new ComicModel();
            comic = _comicClient.GetMostRecentComicAsync().Result;
            return View(comic);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
