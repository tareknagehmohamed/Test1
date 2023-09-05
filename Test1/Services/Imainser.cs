namespace Test1.Services
{
    public interface Imainser<T>where T : class
    {
        Task<List<T>> Getallcat(string newpath);
        Task<T> Getcatbiid(string newpath);
        Task<T> Getcatbiname(string newpath);
     
        Task<T> Addcat(T model, string newpath);
        Task<T> Updatecat(T model, string newpath);
        Task Deletecat(string newpath);
    }
}
