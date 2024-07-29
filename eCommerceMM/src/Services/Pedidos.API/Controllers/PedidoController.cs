using Core.Mediator;
using Pedidos.API.Application.Commands;
using Pedidos.API.Application.Queries;
using WebAPI.Core.Controllers;
using WebAPI.Core.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace FB.Pedidos.API.Controllers;

public class PedidoController : MainController
{
    private readonly IMediatorHandler _mediator;
    private readonly IAspNetUser _user;
    private readonly IPedidoQueries _pedidoQueries;

    public PedidoController(IMediatorHandler mediator, 
                            IAspNetUser user, 
                            IPedidoQueries pedidoQueries)
    {
        _mediator = mediator;
        _user = user;
        _pedidoQueries = pedidoQueries; 
    }

    [HttpPost("pedido/adicionar")]
    public async Task<IActionResult> AdicionarPedido(AdicionarPedidoCommand pedido)
    {
        pedido.ClienteId = _user.ObterUserId();
        return CustomResponse(await _mediator.EnviarComando(pedido));
    }

    [HttpGet("pedido/ultimo")]
    public async Task<IActionResult> UltimoPedido()
    {
        var pedido = await _pedidoQueries.ObterUltimoPedido(_user.ObterUserId());

        return pedido == null ? NotFound() : CustomResponse(pedido);
    }

    [HttpGet("pedido/lista-cliente")]
    public async Task<IActionResult> ListaPorCliente()
    {
        var pedidos = await _pedidoQueries.ObterListaPorClienteId(_user.ObterUserId());

        return pedidos == null ? NotFound() : CustomResponse(pedidos);
    }
}