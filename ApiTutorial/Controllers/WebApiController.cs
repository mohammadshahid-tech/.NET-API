using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTutorial.Controllers
{
    public class WebApiController : ApiController
    {
        Repository.AdoRepo re = new Repository.AdoRepo();

        public IHttpActionResult GetAll()
        {
            var da = re.GetAllStudents();
            return Ok(da);
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetSingleRecord(int id )
        {
            var dt = re.GetSingleData(id);
            return Ok(dt);
        }
    }
}
