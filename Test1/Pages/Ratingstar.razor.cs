using Microsoft.AspNetCore.Components;
using Test1.Models;
using Test1.Services;

namespace Test1.Pages
{
	public partial class Ratingstar
    {
         //DateTime? date = DateTime.Today;
        public bool showalertcreate = false;
        public string msg = "";
		[Inject]
		public Imainser<Rating> Imainserrating { get; set; }
		public List<Rating> ratings { get; set; } = new List<Rating>();
		public Rating rating { get; set; } = new Rating();
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

            ratings = await Imainserrating.Getallcat("api/Rating/Get");
		

		}
        public async Task Create()
        {
           
                await Imainserrating.Addcat(rating,"api/Rating/Post");

                ratings = await Imainserrating.Getallcat("api/Rating/Get");
            showalertcreate = true;
            //msg = "Added Successfully";
            
        


        }
        public void closeiconclicked(bool value)
        {
            if (value)
            {

                showalertcreate = false;
            
            }
            else
            {
                showalertcreate = true;
            }


        }
    }
}
