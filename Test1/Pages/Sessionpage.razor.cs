using Microsoft.AspNetCore.Components;

namespace Test1.Pages
{
    public partial class Sessionpage
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        string res = "";
        [CascadingParameter]
        public EventCallback enotify { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await enotify.InvokeAsync();
            }

        }
        public void sessionres()
        {
           
            localst.SetItemAsync<string>("mysession",res);
            NavigationManager.NavigateTo("/");
        }
    }
}
