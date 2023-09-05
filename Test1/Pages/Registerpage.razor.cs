using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Test1.Models;
using Test1.Services;
using Test1.Dtos;

namespace Test1.Pages
{
    public partial class Registerpage
    {

        [Inject]
        public Imainser<Registerlogin> _registerser { get; set; }

     public Registerlogin Registerlogin { get; set; }=new Registerlogin();
      
 
        IBrowserFile browserFile;
    
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public string Message { get;set; }
        //[CascadingParameter]
        //public EventCallback enotify { get; set; }
        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        await enotify.InvokeAsync();
        //    }

        //}
        public async Task Create()
        {
            try
            {
                await _registerser.Addcat(Registerlogin, "api/Register/Add");
                navigationManager.NavigateTo("loginpage");
            }
            catch (Exception ex)
            {

             if (ex.Message.Contains("This Email Already Exist")) { 
                Message = "This Email Already Exist";
                
                }
            }
  
        }
        private async Task Onfileselection(InputFileChangeEventArgs e)
        {
            browserFile = e.File;
            var buffer = new byte[browserFile.Size];
            await browserFile.OpenReadStream().ReadAsync(buffer);
            string imgtype = browserFile.ContentType;
            // imgurl = $"data:{imgtype};Base64,{Convert.ToBase64String(buffer)}";
            Registerlogin.imgpath = $"data:{imgtype};Base64,{Convert.ToBase64String(buffer)}";
            //imagedto.imgpath = imgurl;
            this.StateHasChanged();
        }
    }
}
