using Entity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://bgapitest.azurewebsites.net/api/user");

                var result = JsonConvert.DeserializeObject<List<User>>(response.Result.Content.ReadAsStringAsync().Result);

                return View(result);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Index(User model)
        {
            using (var client = new HttpClient())
            {
                var data = new
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                client.BaseAddress = new Uri("https://bgapitest.azurewebsites.net");
                var response = await client.PostAsJsonAsync("/api/user", data);
            }

            return RedirectToAction("Index");
        }
    }
}