using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Test1.Models;
using Test1.Services;
using static MudBlazor.CategoryTypes;

namespace Test1.Pages
{
    
    public partial class Showallcategory
    {
        public bool showalertcreate=false;
        private bool dense = false;
        private bool hover = true;
        private bool striped = false;
        private bool bordered = false;
        private string searchString1 = "";
        [Inject]
        public Imainser<Category> Imainser { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        private HashSet<Category> selectedItems = new HashSet<Category>();
        public Category category { get; set; } = new Category();
        private Category selectedItem1 = null;
        [Parameter]
        public string message { get; set; } = "";
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
            Categories = await Imainser.Getallcat("api/Category/Get");
       

        }
        public async Task Create()
        {
            try
            {
                await Imainser.Addcat(category, "api/Category/Post");
                showalertcreate=true;
                Categories = await Imainser.Getallcat("api/Category/Get");

                message = "";
            }
            catch (Exception e)
            {
            //    if (e.Message.Contains("This Item Already Exist")) { }
            //message= "This Item Already Exist";
            message = e.Message;    
            }
   

        }
        private bool FilterFunc1(Category element) => FilterFunc(element, searchString1);

        private bool FilterFunc(Category element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
        
            return false;
        }
        public void closeiconclicked(bool value)
        {
            if (value)
            {

                showalertcreate = false;
                message = "";
            }
            else { 
                showalertcreate = true;
            }
          

        }
        public void printcat()
        {
            js.InvokeVoidAsync("print");
        }
    }
}
