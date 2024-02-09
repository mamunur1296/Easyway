using Easyway.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace Easyway.Controllers
{
    public class HomeController : Controller
    {
        private string url = "https://localhost:7231/api/ContactApi";
        private HttpClient client=new HttpClient();
        
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
        public IActionResult ContactUs(Contact conInfo)
        {
            string data = JsonConvert.SerializeObject(conInfo);
            StringContent stringContent = new StringContent(data , Encoding.UTF8, "application/json");
            Console.Write(stringContent);
            HttpResponseMessage response = client.PostAsync(url,stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.SuccessMessage = "Your message has been sent. Thank you!";
                ModelState.Clear();
                //return RedirectToAction("ContactUs");
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