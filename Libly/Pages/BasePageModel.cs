using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libly.Pages
{
    public abstract class BasePageModel : PageModel
    {
        protected void DisplayError(string errorMessage)
        {
            ModelState.AddModelError(string.Empty, errorMessage);
        }
    }
}