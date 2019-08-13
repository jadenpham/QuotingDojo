using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost("create")]
        public IActionResult Create(string name, string quote)
        {
            // string query = $"INSERT INTO table1 (fullname, quote) VALUES ('{name}, '{quote}');";
            string query = $"INSERT INTO table1 (fullname, quote) VALUES ('{name}', '{quote}');";
            DbConnector.Execute(query);
            return RedirectToAction("ShowAll");
        }

        [HttpGet("all")]
        public IActionResult ShowAll()
        {
            List<Dictionary<string, object>> allQuotes = DbConnector.Query($"SELECT * FROM table1");
            ViewBag.quotes = allQuotes;
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
