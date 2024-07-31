using WebMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Extensions;

public class PaginacaoViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(IPagedList modeloPaginado)
    {
        return View(modeloPaginado);
    }
}
