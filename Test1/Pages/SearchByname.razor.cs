using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Test1.Models;
using Test1.Services;

namespace Test1.Pages
{
    public partial class SearchByname
    {
        [Inject]
        public Imainser<News> Imainsernews { get; set; }
        public List<News> news { get; set; } = new List<News>();
        public News newsob { get; set; } = new News();
      
 

   
        [CascadingParameter]
        public EventCallback enotify { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await enotify.InvokeAsync();
            }

        }
        public async Task Search(string name)
        {
           
                news = await Imainsernews.Getallcat($"api/Newslists/Getsearch?name={name}");
            
           
        }
        public async Task showall()
        {
            news = await Imainsernews.Getallcat("api/Newslists/Getallnews");

        }
        protected override async Task OnInitializedAsync()
        {

            news = await Imainsernews.Getallcat("api/Newslists/Getallnews");
           

        }
    }
}
