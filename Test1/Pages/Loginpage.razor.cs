using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Test1.Models;
using Test1.Services;

namespace Test1.Pages
{
    public partial class Loginpage
    {
        public bool AlarmOn { get; set; }
        [Inject]
        public Imainser<Registerlogin> _registerser { get; set; }

        public Registerlogin Registerlogin { get; set; } = new Registerlogin();
        public List<Registerlogin> RegisterloginList { get; set; }=new List<Registerlogin>();

        IBrowserFile browserFile;
        public string message { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [CascadingParameter]
        public EventCallback enotify { get; set; }
        public async Task Login(string email,string password)
        {
            try
            {
                var res = await _registerser.Getcatbiname($"api/Register/Getbyemail?email={email}&&password={password}");
                await localst.SetItemAsync<string>("emailselogin", res.Email);
                await localst.SetItemAsync<string>("nameselogin", res.Name);
                await localst.SetItemAsync<string>("userselogin", res.username);
                await localst.SetItemAsync<string>("imgselogin", res.imgpath);
     
                await enotify.InvokeAsync();
                navigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
          
              if (ex.Message.Contains("not correct")) {
                    message = "not correct";
                }
            }
          //var res=  await _registerser.Getcatbiname($"api/Register/Getbyemail?email={email}&&password={password}");
            //var res =  RegisterloginList.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            //if (res != null)
            //{
            //    await localst.SetItemAsync<string>("emailselogin",res.Email);
            //    await localst.SetItemAsync<string>("nameselogin", res.Name);
            //    await localst.SetItemAsync<string>("userselogin", res.username);
            //    await localst.SetItemAsync<string>("imgselogin", res.imgpath);
            //    await enotify.InvokeAsync();
            //    navigationManager.NavigateTo("/");

            //}
            //else
            //{
            //    message = "your Email  or password is not correct";
            //}
        }
    }
}
