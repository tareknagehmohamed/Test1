using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Test1.Models;
using Test1.Services;
using Blazored.Typeahead;
namespace Test1.Pages
{
    public partial class Showallnews
    {
        private bool _hidePosition;
        private bool _loading;
        [Inject]
        public Imainser<News> Imainsernews { get; set; }
        public List<News> news { get; set; } = new List<News>();
        public News newsob { get; set; }=new News();
        [Inject]
        public Imainser<Category> Imainsercat { get; set; }
        public List<Category> categories { get; set; } = new List<Category>();
        [Inject]
        public IJSRuntime JSRuntime { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public int catid { get; set; }
        [Parameter]
        public string catname { get; set; }
        public int take = 0;
        public int skip = 4;
        public bool AlarmOn { get; set; }
        [CascadingParameter]
        public EventCallback enotify { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await enotify.InvokeAsync();
            }

        }
        protected override async Task OnInitializedAsync()
        {
 
            news = await Imainsernews.Getallcat("api/Newslists/Getallnews");
            categories = await Imainsercat.Getallcat("api/Category/Get");

        }
        public async Task Delete(int id,string name)
        {
       
            var result= news.FirstOrDefault(x=>x.Name==name);  
            var confirm = await JSRuntime.InvokeAsync<bool>("confirm", $"Are You Sure To Confirm This Item {result.Name} ?");
            if (confirm)
            {
                await Imainsernews.Deletecat($"api/Newslists/DeleteNews/{id}");
                news = await Imainsernews.Getallcat("api/Newslists/Getallnews");
            }
        }
        public async Task Update(int id)
        {
            NavigationManager.NavigateTo($"updatenews/{id}");
        }
        public async Task Getnewsbycatid(int value)
        {
            catid = value;
            news = new List<News>();
            if (catid == 0)
            {
                news = await Imainsernews.Getallcat("api/Newslists/Getallnews");
            }
            else
            {
               news= await Imainsernews.Getallcat($"api/Newslists/Getallnewsbycatid?id={catid}");

            }

        }
        private async Task<IEnumerable<News>> Searchbyname(string searchtext) { 
        
        return await Task.FromResult(news.Where(x=>x.Name.ToLower().Contains(searchtext.ToLower())).ToList());
        }
        public void printdocument()
        {
            JSRuntime.InvokeVoidAsync("print");
            //await JSRuntime.InvokeAsync<object>("open",new object[] { "/showallnews", "_blank" });
        }

    }
}
