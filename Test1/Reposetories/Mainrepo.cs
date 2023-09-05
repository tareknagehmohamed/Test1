using Microsoft.EntityFrameworkCore;
using Test1.Models;

namespace Test1.Reposetories
{
    public class Mainrepo<T> : Irepo<T> where T : class
    {
        private readonly NewsConetext _db;

        public Mainrepo(NewsConetext db)
        {
            _db = db;
        }

        public T Add(T model)
        {
            _db.Set<T>().Add(model) ;
            _db.SaveChanges();
                return model;

        }

        public void Delete(int id)
        {
            var deleteditem = Getid(id);
            _db.Set<T>().Remove(deleteditem) ;    
            _db.SaveChanges();  
        }

        public IEnumerable<T> GetAll(string include = "")
        {
       IQueryable<T> myquery=_db.Set<T>();
            if (include!="") {
                myquery=myquery.Include(include);
            }
            return myquery.ToList();   
        }

        public T Getid(int id)
        {
         return _db.Set<T>().Find(id);
        }

        public T Update(T model)
        {
            DbSet<T> ts = _db.Set<T>();
            ts.Attach(model);
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();
            return model;   

        }
    }
}
