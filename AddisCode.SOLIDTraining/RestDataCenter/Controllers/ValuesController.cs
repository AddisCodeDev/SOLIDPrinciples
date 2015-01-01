using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataModel;

namespace RestDataCenter.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public Student[] Get()
        {
            List<Student> students = new List<Student>();
            Student student1 = new Student()
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Derartu",
                LastName = "Tulu",
                Age = 20
            };
            Student student2 = new Student()
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Teddy",
                LastName = "Afro",
                Age = 21
            };
            Student student3 = new Student()
            {
                StudentId = Guid.NewGuid(),
                FirstName = "Mesfin",
                LastName = "Negash",
                Age = 22
            };
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            return students.ToArray();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
