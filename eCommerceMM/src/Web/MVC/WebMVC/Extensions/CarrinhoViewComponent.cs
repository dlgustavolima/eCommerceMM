using WebMVC.Models;
using WebMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Extensions
{
    public class CarrinhoViewComponent : ViewComponent
    {
        private readonly IComprasBffService _comprasBffService;

        public CarrinhoViewComponent(IComprasBffService comprasBffService)
        {
            _comprasBffService = comprasBffService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _comprasBffService.ObterQuantidadeCarrinho());
        }
    }
}
