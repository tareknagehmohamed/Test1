using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using Test1.Dtos;
using Test1.Models;
using Test1.Reposetories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewslistsController : ControllerBase
    {
        protected readonly Irepo<News> _repo;
        protected readonly IWebHostEnvironment _webHostEnvironment;
        private readonly NewsConetext _db;
        public NewslistsController(Irepo<News> repo, IWebHostEnvironment webHostEnvironment, NewsConetext db)
        {
            _repo = repo;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        // GET: api/<NewslistsController>
        [HttpGet]
        public IActionResult Getallnews()
        {
            return Ok(_repo.GetAll("category"));
           
        }
        // GET: api/<takeskip>
        [HttpGet]
        public IActionResult Getallnewstakeskip(int skip,int take)
        {
            return Ok(_repo.GetAll("category").Skip(skip).Take(take).ToList());

        }
        [HttpGet]
        public IActionResult Getallnewsandcat()
        {
            //var res = _db.News.Include(x => x.category).SingleOrDefault(x=>x.Id==62);
            var res = _db.News.Include(x => x.category).ToList();
            return Ok(res);

        }
        [HttpGet]
        public IActionResult Getallgroupby()
        {
            var res = (_repo.GetAll("category")
            .GroupBy(x => x.category.Name)
            .Select(m => new
            {
                Categoryname = m.Key,
                Count = m.Count(),
                Sum = m.Sum(m => m.Id),
                Average = m.Average(m => m.Id)
            })).ToList();
           // var res = (_db.News
           //.GroupBy(x => x.category.Name)
           //.Select(m => new Groupclass
           //{
               
           //    Categoryname = m.Key,
           //    Count = m.Count(),
           //    Sum = m.Sum(m => m.Id),
           //    Average = m.Average(m => m.Id)
           //})).ToList();


            return Ok(res);
        }
        //get news by category id
        [HttpGet]
        public IActionResult Getallnewsbycatid(int id)
        {
            return Ok(_repo.GetAll("category").Where(x=>x.categoryId==id));

        }
        //get news by category name
        [HttpGet]
        public IActionResult Getallnewsbycatname(string catname)
        {
            return Ok(_repo.GetAll("category").Where(x => x.Name.ToLower().Contains(catname.ToLower())).ToList());

        }
        [HttpGet]
        public IActionResult Getsearch(string name="")
        {
     
                var res = _repo.GetAll("category").Where(x => x.Name.ToLower().Contains(name.ToLower())||string.IsNullOrWhiteSpace(name)).ToList();
                return Ok(res);
            
         
         

        }
        // GET api/<NewslistsController>/5
        [HttpGet("{id}")]
        public IActionResult Getbiidnews(int id)
        {
            // return Ok(_repo.Getid(id));
            return Ok(_repo.GetAll("category").Where(x => x.Id == id).FirstOrDefault());
        }
        [HttpGet]
        public IActionResult Getbiidnewssearch(int id)
        {
            // return Ok(_repo.Getid(id));
            return Ok(_repo.GetAll("category").Where(x => x.Id == id).FirstOrDefault());
        }
        [HttpGet("{name}")]
        public IActionResult Getbiname(string name)
        {
            // return Ok(_repo.Getid(id));
            return Ok(_repo.GetAll("category").Where(x => x.Name == name).FirstOrDefault());
        }
        // POST api/<NewslistsController>
        [HttpPost]
        public IActionResult AddNews([FromBody] News model)
        {
            //string Filename = "";
            //if (modeldto.newimage != null) {
            //    string fullpath = Path.Combine(_webHostEnvironment.WebRootPath, "NewsImages");
            //    if (!Directory.Exists(fullpath))
            //        {
            //        Directory.CreateDirectory(fullpath);
            //    }
            //    Filename = Guid.NewGuid() + "_" + modeldto.imgpath;
            //    string imagepath = Path.Combine(fullpath, Filename);
            //    await using var stream = new FileStream(imagepath, FileMode.Create);
            //    stream.Write(modeldto.newimage, 0, modeldto.newimage.Length);
            //}
            //News model = new News() {

            //    Name = modeldto.Name,
            //    address = modeldto.address,
            //    categoryId = modeldto.categoryId,
            //    imgpath = Filename
            //};
    
          _repo.Add(model);
            return Ok(model);
}
      

        // PUT api/<NewslistsController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateNews([FromBody] News model)
        {
            _repo.Update(model);
            return Ok(model);
        }

        // DELETE api/<NewslistsController>/5
        [HttpDelete("{id}")]
        public void DeleteNews(int id)
        {
            _repo.Delete(id);
        }
    }
}
