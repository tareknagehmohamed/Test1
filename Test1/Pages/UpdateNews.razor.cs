using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Test1.Dtos;
using Test1.Models;
using Test1.Services;

namespace Test1.Pages
{
    public partial class UpdateNews
    {
        [Inject]
        public Imainser<News> Imainsernews { get; set; }
        public List<News> news { get; set; } = new List<News>();
        public News newsob { get; set; } = new News();
      
        [Inject]
        public Imainser<Category> Imainsercat { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public Category category { get; set; } = new Category();
   
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Inject]
        public IWebHostEnvironment webHostEnvironment { get; set; }
        IBrowserFile browserFile;
        string imgurl = string.Empty;
        [Parameter]
        public string id { get; set; }
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
            newsob = await Imainsernews.Getcatbiid($"api/Newslists/Getbiidnews/{id}");
            Categories = await Imainsercat.Getallcat("api/Category/Get");

        }
        public async Task Update()
        {
         
           // string fullpath = Path.Combine(webHostEnvironment.WebRootPath, "NewsImages");
           // if (Directory.Exists(fullpath))
           // {
           //     Directory.CreateDirectory(fullpath);
           // }
        
           // string Filename = Guid.NewGuid() + "_" + browserFile.Name;
           //string imagepath = Path.Combine(fullpath, Filename);
           // await using var stream = new FileStream(imagepath, FileMode.Create);
           // newsob.imgpath = Filename;
            await Imainsernews.Updatecat(newsob, $"api/Newslists/UpdateNews/{id}");
            navigationManager.NavigateTo("showallnews");

        }
        private async Task Onfileselection(InputFileChangeEventArgs e)
        {
            browserFile = e.File;
            var buffer = new byte[browserFile.Size];
            await browserFile.OpenReadStream().ReadAsync(buffer);
            string imgtype = browserFile.ContentType;
            newsob.imgpath = $"data:{imgtype};Base64,{Convert.ToBase64String(buffer)}";
            this.StateHasChanged();
        }
    
    }
}
