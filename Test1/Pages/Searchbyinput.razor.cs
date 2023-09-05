using Microsoft.AspNetCore.Components;
using MudBlazor.Charts.SVG.Models;
using Test1.Models;
using Test1.Services;

namespace Test1.Pages
{
    public partial class Searchbyinput
    {
        [Inject]
        public Imainser<News> Imainsernews { get; set; }
        public List<News> news { get; set; } = new List<News>();
        public News newsob { get; set; } = new News();
        public string msg = "";
        [Parameter]
        public string Namenews { get; set; }
        public string addressnews { get; set; }
        public string imgnews { get; set; }
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

            Namenews = await localst.GetItemAsync<string>("namenews");
            addressnews = await localst.GetItemAsync<string>("addressnews");
            imgnews = await localst.GetItemAsync<string>("imgnews");
        }

    }
}
