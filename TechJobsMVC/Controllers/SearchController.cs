﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view.
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;

            if (String.IsNullOrWhiteSpace(searchTerm))
            {
                jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
            }

            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Jobs with " + searchType + ": " + searchTerm;
            }
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;

            return View("Index");
        }
    }
}

//public IActionResult Jobs(string column, string value)
//{
//    List<Job> jobs;
//    if (column.ToLower().Equals("all"))
//    {
//        jobs = JobData.FindAll();
//        ViewBag.title = "All Jobs";
//    }
//    else
//    {
//        jobs = JobData.FindByColumnAndValue(column, value);
//        ViewBag.title = "Jobs with " + ColumnChoices[column] + ": " + value;
//    }
//    ViewBag.jobs = jobs;

//    return View();
//}