using Microsoft.AspNetCore.Components;
using Test1.Models;
using Test1.Services;

namespace Test1.Pages
{
    public partial class Showskiptake
    {
        [Inject]
        public Imainser<News> Imainser { get; set; }
        public List<News> News { get; set; } = new List<News>();
        public List<News> Newscount { get; set; } = new List<News>();
        public News news { get; set; } = new News();
        public string msg { get; set; } = "";
        public bool visiblebuttonnext = true;
        public bool visiblebuttonback = true;
        public int count = 0;
        public int skip = 1;
        public int take = 4;
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
            News = await Imainser.Getallcat($"api/Newslists/Getallnewstakeskip?skip={(skip - 1) * take}&&take={take}");
            visiblebuttonnext = true;
            visiblebuttonback = false;
             Newscount = await Imainser.Getallcat("api/Newslists/Getallnews");
            count = Newscount.Count();

        }
        public async Task Nextpage()
        {
            skip++;
            News = await Imainser.Getallcat($"api/Newslists/Getallnewstakeskip?skip={(skip-1)*take}&&take={take}");
            Newscount = await Imainser.Getallcat("api/Newslists/Getallnews");
            count = Newscount.Count();
            visiblebuttonback = true;
            if ((skip - 1) * take>=count|| take % 2 == 1)
            {
              
                    visiblebuttonnext = false;
                    visiblebuttonback = true;
                msg = "You are at the end of the content";

                // skip--;
                // News = await Imainser.Getallcat($"api/Newslists/Getallnewstakeskip?skip={(skip - 1) * take}&&take={take}");
            }
            else { msg = ""; }
         
        }
        public async Task Backpage()
        {
            msg = "";
            skip--;
            News = await Imainser.Getallcat($"api/Newslists/Getallnewstakeskip?skip={(skip - 1) * take}&&take={take}");
            visiblebuttonnext = true;
            if ((skip - 1) * take <= 0)
            {
                visiblebuttonnext = true;
                visiblebuttonback =false;
               // skip++;
               // News = await Imainser.Getallcat($"api/Newslists/Getallnewstakeskip?skip={(skip - 1) * take}&&take={take}");
        }
        }
    }
}
