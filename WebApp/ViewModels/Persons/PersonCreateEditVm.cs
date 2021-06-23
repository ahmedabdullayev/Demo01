using Domain.App;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels.Persons
{
    public class PersonCreateEditVm
    {
        public Person Person { get; set; } = default!;

        public SelectList? PersonPictureSelectList { get; set; }
        public bool isDarkMode { get; set; }
    }
}