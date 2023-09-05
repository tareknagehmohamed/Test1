using Microsoft.AspNetCore.Components;
using System.Reflection;
using Test1.Models;
using Test1.Services;
using System.Collections.Generic;
namespace Test1.Pages
{
    public partial class Showgroupby
    {
        [Inject]
        public Imainser<News> Imainser { get; set; }
        [Inject]
        public Imainser<Groupclass> imainsergroup { get; set; }
        public List<News> News { get; set; } = new List<News>();
        public List<Groupclass> Groupclasses { get; set; } = new List<Groupclass>();
        public List<News> Newsdata { get; set; }=new List<News>();
        public int count;
        public int sum;
        public double avg;
        public string catname;
        private readonly NewsConetext _db;
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
            Groupclasses = await imainsergroup.Getallcat("api/Newslists/Getallgroupby");
            //News = await Imainser.Getallcat("api/Newslists/Getallgroupby");
            //News = await Imainser.Getallcat("api/Newslists/Getallnews");
            //var x= News.GroupBy(x => x.Name)
            //    .Select(m => new
            //    {
            //        Categoryname = m.Key,
            //        Count = m.Count(),
            //        Sum = m.Sum(m => m.Id),
            //        Average = m.Average(m => m.Id)
            //    });

            //    foreach (var item in x)
            //    {
            //        catname = item.Categoryname;
            //        count = item.Count;
            //        sum = item.Sum;
            //        avg = item.Average;
            //    }

        }
    }
}
