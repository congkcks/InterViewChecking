using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;
using System.Collections.Generic;

namespace WebApplication12.ViewComponents
{
    public class RenderViewComponent : ViewComponent
    {
        private readonly List<MenuItem> menuItems = new List<MenuItem>();

        public RenderViewComponent()
        {
            menuItems = new List<MenuItem>() {
                new MenuItem() {Id=1, Name="Branches", Link="Branches/List" },
                new MenuItem() {Id=2, Name="Students", Link="Students/List" },
                new MenuItem() {Id=3, Name="Subjects", Link="Subjects/List"},
                new MenuItem() {Id=4, Name="Courses", Link="Courses/List"},
                new MenuItem() {Id=5,Name="ThucHanh",Link="ThucHanh/List"}
            };
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(menuItems);
        }


    }
}
