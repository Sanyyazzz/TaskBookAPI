using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using API.Providers;
using API.Models;

namespace API.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            var provider = new TaskBookProviderDB();
            var tasks = provider.GetAllTasks();
            var json = JsonConvert.SerializeObject(tasks);
            return json;
        }
    }
}
