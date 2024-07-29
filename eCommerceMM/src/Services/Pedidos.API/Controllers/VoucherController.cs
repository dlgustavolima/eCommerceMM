using Pedidos.API.Application.Queries;
using WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FB.Pedidos.API.Controllers;

[Authorize]
public class VoucherController : MainController
{

    private readonly IVoucherQueries _voucherQueries;

    public VoucherController(IVoucherQueries voucherQueries)
    {
        _voucherQueries = voucherQueries;
    }

    [HttpGet("voucher/{codigo}")]
    public async Task<IActionResult> ObterPorCodigo(string codigo)
    {
        if (string.IsNullOrEmpty(codigo)) return NotFound();

        var voucher = await _voucherQueries.ObterVoucherPorCodigo(codigo);

        return voucher == null ? NotFound() : CustomResponse(voucher);
    }

}
