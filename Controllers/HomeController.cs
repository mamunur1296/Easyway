using Easyway.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace Easyway.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactDBContext contactDB;

        public HomeController(ContactDBContext _contactDB)
        {
            contactDB = _contactDB;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult CorporateCulture()
        {
            return View();
        }
        public IActionResult VisionMission()
        {
            return View();
        }
        public IActionResult Specialties()
        {
            return View();
        }
        public IActionResult ForEmployess()
        {
            return View();
        }
        public IActionResult Career()
        {
            return View();
        }
     
        public IActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult ContactUs(Contactinfo conInfo)
        {
            
            try
            {
                // Add contact info to the database
                contactDB.Contactinfos.Add(conInfo);
                contactDB.SaveChanges();

                // Clear the model state and provide success message
                ModelState.Clear();
                ViewBag.SuccessMessage = "Your message has been sent. Thank you!";
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                // You may also want to notify the user about the error
                // For simplicity, I'm just logging the exception here
                Console.WriteLine($"An error occurred: {ex.Message}");

                // You can also return a specific error view if needed
            }
            return View();
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