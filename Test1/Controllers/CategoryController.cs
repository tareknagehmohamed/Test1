using Microsoft.AspNetCore.Mvc;
using Test1.Models;
using Test1.Reposetories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Irepo<Category> _repo;
        public CategoryController(Irepo<Category> repo)
        {
            _repo = repo;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            var data = _repo.GetAll().OrderByDescending(x=>x.Id);
            return Ok(data);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Getidcat(int id)
        {
            return Ok(_repo.Getid(id));

        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category model)
        {
            if (ModelState.IsValid)
            {
                var res = _repo.GetAll().Where(x=>x.Name==model.Name).FirstOrDefault();
                if (res!=null) {
                    ModelState.AddModelError("Error", "This Item Already Exist");
                  //  return BadRequest(ModelState);
                  return BadRequest(ModelState.First().Value.Errors.First().ErrorMessage);
                }
                _repo.Add(model);
                return Ok(model);
            }
    return BadRequest(ModelState);
       
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put( [FromBody] Category model)
        {
            _repo.Update( model);
            return Ok(model);   
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
