using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Training.Models;
using Training.Models.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private IDataRepository<Student, long> _iRepo;
        public StudentsController(IDataRepository<Student, long> repo)
        {
            _iRepo = repo;
        }
        
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _iRepo.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _iRepo.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Student student)
        {
            _iRepo.Add(student);
        }

        // POST api/values
        [HttpPut]
        public void Put([FromBody]Student student)
        {
            _iRepo.Update(student.StudentId, student);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public long Delete(int id)
        {
            return _iRepo.Delete(id);
        }
    }
}
