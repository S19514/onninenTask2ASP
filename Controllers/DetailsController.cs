using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Zadanie2.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Zadanie2.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {                      
            return View();
        }
        //  var Metoda = Request.Method;
        //var czas = (DateTime)HttpContext.Items["RequestTimestamp"];
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Details details)
        {
            if (ModelState.IsValid)
            {
                details.dateTime = (DateTime)HttpContext.Items["RequestTimestamp"];
                details.RequestType = Request.Method;
                details.ClientIPAdress = Request.Host.Host;

                using (StreamWriter writer = System.IO.File.AppendText(@"C:\Users\piotr\Desktop\onninen\output\Data.txt"))
                {
                    writer.WriteLine($"{JsonSerializer.Serialize(details)}");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
