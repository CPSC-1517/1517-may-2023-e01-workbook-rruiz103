using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        // form controls properties
        public double Num { get; set; }

        public string MassText { get;set; }

        public int FavouriteCourse { get; set; } // using integer value for select

        public string FavouriteCourseNoValueOnOption { get; set; } // using string value for select

        public string FeedBack { get; set; }

        public void OnGet()
        {
        }

        public void OnPostControlProcessing() 
        { FeedBack = $"Number value is {Num}, MassText is {MassText}, Favourite Course with value is {FavouriteCourse}, " +
                $"Favourite Course without value is {FavouriteCourseNoValueOnOption}"; }
    }
}
