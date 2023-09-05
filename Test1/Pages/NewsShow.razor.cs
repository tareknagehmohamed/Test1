using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using Test1.Dtos;
using Test1.Models;
using Test1.Services;

namespace Test1.Pages
{
    public partial class NewsShow
    {

        [Inject]
        public Imainser<News> Imainserdto { get; set; }
      
        public News imagedto { get; set; } = new News();
        public List<Category> Categories { get; set; } = new List<Category>();
        public Category category { get; set; } = new Category();
        [Inject]
        public Imainser<Category> Imainsercat { get; set; }
        IBrowserFile browserFile;
        string imgurl=string.Empty;
        [Inject]
        public NavigationManager navigationManager { get; set; }
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
            Categories = await Imainsercat.Getallcat("api/Category/Get");


        }
        public async Task Create()
        {
            //imagedto.imgpath = browserFile.Name;
            //using (var ms = new MemoryStream()) {
            //    await browserFile.OpenReadStream().CopyToAsync(ms);
            //    imagedto.newimage=ms.ToArray();
            //    ms.Dispose();
            //}
            await Imainserdto.Addcat(imagedto,"api/Newslists/AddNews");
            navigationManager.NavigateTo("showallnews");
        }
        private async Task Onfileselection(InputFileChangeEventArgs e) {
            browserFile = e.File;
            var buffer=new byte[browserFile.Size];
            await browserFile.OpenReadStream().ReadAsync(buffer);
            string imgtype = browserFile.ContentType;
            // imgurl = $"data:{imgtype};Base64,{Convert.ToBase64String(buffer)}";
            imagedto.imgpath = $"data:{imgtype};Base64,{Convert.ToBase64String(buffer)}";
            //imagedto.imgpath = imgurl;
            this.StateHasChanged();
        }
    }
}
