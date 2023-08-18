using ApiTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ApiTutorial.Controllers
{
    public class ReadApiController : Controller
    {
       
        ConsumeApi.ConsumeApi ConApi = new ConsumeApi.ConsumeApi();
        public async Task<ActionResult> IndexAsync()
        {
            string link = "https://localhost:44369/api/WebApi";
            string controller = "WebApi";
            List<student> students = await ConApi.ImplementApiAsync<student>(link , controller);

            return View(students);
        }
    }
}