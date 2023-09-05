namespace Test1.Services
{
    public class Mainser<T> : Imainser<T> where T : class
    {

        private readonly HttpClient _httpClient;

        public Mainser(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> Addcat(T model, string newpath)
        {
            //var res=await _httpClient.PostAsJsonAsync<T>(newpath,model);    
            //return await res.Content.ReadFromJsonAsync<T>();  
            var res = await _httpClient.PostAsJsonAsync<T>(newpath, model);
            if (!res.IsSuccessStatusCode) { 
            var newres=await res.Content.ReadAsStringAsync();
                throw new Exception(newres);    
            }
            return null;
        }

        public async Task Deletecat(string newpath)
        {
             await _httpClient.DeleteAsync(newpath);   
        }

        public async Task<List<T>> Getallcat(string newpath)
        {
            var query = await _httpClient.GetFromJsonAsync<List<T>>(newpath);
            return query;
        }

        public async Task<T> Getcatbiid(string newpath)
        {
            return await _httpClient.GetFromJsonAsync<T>(newpath);
        }

        public async Task<T> Getcatbiname(string newpath)
        {
            var res=await _httpClient.GetAsync(newpath);
            if (!res.IsSuccessStatusCode)
            {
                var resnew=await res.Content.ReadAsStringAsync();
                throw new Exception(resnew);
            }
            return await _httpClient.GetFromJsonAsync<T>(newpath);

            //var res = await _httpClient.GetFromJsonAsync<T>(newpath);
            //if (res == null) {
            
            //}
        }

        public async Task<T> Updatecat(T model, string newpath)
        {
            var res = await _httpClient.PutAsJsonAsync<T>(newpath, model);
            return await res.Content.ReadFromJsonAsync<T>();
        }
    }
}
