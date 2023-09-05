namespace Test1.Reposetories
{
    public interface Irepo<T>where T : class
    {
        IEnumerable<T> GetAll(string include="");   
        T Getid(int id);
        T Add(T model);
        T Update(T model);  
       void Delete(int id);  
    }
}
