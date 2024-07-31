using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Extensions;

public class SummaryViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}
