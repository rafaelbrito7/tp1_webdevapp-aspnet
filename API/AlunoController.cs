using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private AlunoRepository Repository { get; set; } = new AlunoRepository();

        // GET: api/<AlunoController>
        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return Repository.GetAll();
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return Repository.GetAlunoById(id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        public void Post([FromBody] Aluno value)
        {
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }
    }
}