using Microsoft.AspNetCore.Components;
using Test1.Models;
using Test1.Services;

namespace Test1.Pages
{
    public partial class Showjoin
    {

        [Inject]
        public Imainser<News> Imainser { get; set; }
        public List<News> News { get; set; } = new List<News>();
        public News news { get; set; } = new News();
    
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
            News = await Imainser.Getallcat("api/Newslists/Getallnewsandcat");


        }
    }
}
