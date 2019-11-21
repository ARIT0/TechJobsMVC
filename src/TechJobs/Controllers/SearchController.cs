using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // Done #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();
                   
            ViewBag.columns = ListController.columnChoices;
            
            if (searchType != "all")
            {
                results = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            else
            {
               if (searchTerm == null)
               {
                    results = JobData.FindAll();
               }
               else
               {
                    results = JobData.FindByValue(searchTerm);
               }
            }
            
            ViewBag.jobs = results;

            return View("Index");
        }

    }
}
