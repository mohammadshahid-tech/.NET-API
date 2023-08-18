using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTutorial.Controllers
{
    public class InsertDataController : ApiController
    {
        Repository.AdoRepo re = new Repository.AdoRepo();
        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertRow(int studentID, string studentName, string address, string age, string contact)
        {
           var inst =  re.InsertData(studentID, studentName, address, age, contact);   
            return Ok(inst);
        }
    }
}
