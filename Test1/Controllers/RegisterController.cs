using Microsoft.AspNetCore.Mvc;
using Test1.Models;
using Test1.Reposetories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        protected readonly Irepo<Registerlogin> _repo;
     
        public RegisterController(Irepo<Registerlogin> repo )
        {
            _repo = repo;
        
        }

        // GET: api/<RegisterController>
        [HttpGet]
        public IActionResult Getall()
        {
            return Ok(_repo.GetAll());

        }
        [HttpGet]
        public IActionResult Getbyemail(string email,string password)
        {
            if (ModelState.IsValid)
            {
                var res = _repo.GetAll().Where(x => x.Email == email && x.Password == password).FirstOrDefault();
                if (res == null)
                {
                    ModelState.AddModelError("Error", "not correct");
                    return BadRequest(ModelState);
                }
                return Ok(res);
            }

            return BadRequest(ModelState);
            //return Ok(_repo.GetAll().Where(x => x.Email == email && x.Password == password).FirstOrDefault());
        }
        // GET api/<RegisterController>/5
        [HttpGet("{id}")]
        public IActionResult Getbiid(int id)
        {
            // return Ok(_repo.Getid(id));
            return Ok(_repo.GetAll().Where(x => x.Id == id).FirstOrDefault());
        }

        // POST api/<RegisterController>
        [HttpPost]
        public IActionResult Add([FromBody] Registerlogin model)
        {
            if (ModelState.IsValid)
            {
                var res=_repo.GetAll().Where(x => x.Email==model.Email).FirstOrDefault();
                if (res!=null)
                {
                    ModelState.AddModelError("Error", "This Email Already Exist");
                    return BadRequest(ModelState);
                }
                _repo.Add(model);
                return Ok(model);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Registerlogin model)
        {
            _repo.Update(model);
            return Ok(model);
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public void DeleteNews(int id)
        {
            _repo.Delete(id);
        }
    }
}
