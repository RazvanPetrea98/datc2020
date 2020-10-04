using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tema_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return StudentRepo.Students;
        }

        [HttpGet("{id}")]
        public Student GetStudents(int id)
        {
            return StudentRepo.Students.FirstOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public string Post(Student st)
        {
            try
            {
                StudentRepo.Students.Add(st);
                return "S-a adaugat studentul!";

            }
            catch (System.Exception e)
            {
                return "Eroare:" + e.Message;
                throw;
            }

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student st)
        {
            StudentRepo.Students[id] = st;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            StudentRepo.Students.RemoveAt(id);
        }

    }

}
  