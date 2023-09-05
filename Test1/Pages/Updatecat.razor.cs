using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Test1.Models;
using Test1.Services;

namespace Test1.Pages
{
    public partial class Updatecat
    {
        [Inject]
        public Imainser<Category> Imainser { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public Category category { get; set; } = new Category();
        [Inject]
        public NavigationManager navigationManager { get; set; }
        [Parameter]
        public string id { get; set; }
        [Inject]
        public IJSRuntime jSRuntime { get; set; }
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
            category = await Imainser.Getcatbiid($"api/Category/Getidcat/{id}");


        }
        public async Task Update()
        {
            await Imainser.Updatecat(category, $"api/Category/Put/{id}");
            await Alert("updated successfully");
            navigationManager.NavigateTo("showallcategory");

        }
        public async Task Alert(string Message) {
            await jSRuntime.InvokeAsync<object>("Alert", Message);

        }
    }
}
