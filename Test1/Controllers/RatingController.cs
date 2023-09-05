using Microsoft.AspNetCore.Mvc;
using Test1.Models;
using Test1.Reposetories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        protected readonly Irepo<Rating> _repo;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        private readonly NewsConetext _db;
        public RatingController(Irepo<Rating> repo, IWebHostEnvironment webHostEnvironment, NewsConetext db)
        {
            _repo = repo;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }
        // GET: api/<RatingController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll().OrderByDescending(x=>x.Id));
        }

        // GET api/<RatingController>/5
        [HttpGet("{id}")]
        public IActionResult Getbiid(int id)
        {
            return Ok(_repo.GetAll().Where(x => x.Id == id).FirstOrDefault());
        }

        // POST api/<RatingController>
        [HttpPost]
        public IActionResult Post([FromBody] Rating model)
        {
            _repo.Add(model);
            return Ok(model);
        }

        // PUT api/<RatingController>/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody] Rating model)
        {
            _repo.Update(model);
            return Ok(model);
        }

        // DELETE api/<RatingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
