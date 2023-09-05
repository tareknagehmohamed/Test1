using Microsoft.AspNetCore.Components;
using MudBlazor.Charts.SVG.Models;
using Test1.Models;
using Test1.Services;

namespace Test1.Pages
{
    public partial class Seach
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }    
        [Inject]
        public Imainser<News> Imainsernews { get; set; }
        public List<News> news { get; set; } = new List<News>();
        public List<News> newssearch { get; set; } = new List<News>();
        public News newsob { get; set; } = new News();
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public bool show=false;
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
     
        

    }
        private async Task<IEnumerable<News>> Searchbyname(string searchtext)
        {

            newssearch = await Imainsernews.Getallcat($"api/Newslists/Getallnewsbycatname?catname={searchtext}");
            show=true;
            return await Task.FromResult(news.Where(x => x.Name.ToLower().Contains(searchtext.ToLower())).ToList());
          


        }
        public async Task Goto(int id)
        {
            var res = await Imainsernews.Getcatbiid($"api/Newslists/Getbiidnewssearch?id={id}");
            
            await localst.SetItemAsync<string>("namenews",res.Name);
            await localst.SetItemAsync<string>("addressnews",res.address);
            await localst.SetItemAsync<string>("imgnews",res.imgpath);
        
            navigationManager.NavigateTo("searchbyinput");
        }
    }
}
