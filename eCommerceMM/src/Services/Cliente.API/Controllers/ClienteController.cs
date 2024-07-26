using Cliente.API.Application.Commands;
using Cliente.API.Data.Repository;
using Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.Controllers;
using WebAPI.Core.Usuario;

namespace Cliente.API.Controllers;

public class ClienteController : MainController
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMediatorHandler _mediator;
    private readonly IAspNetUser _user;

    public ClienteController(IClienteRepository clienteRepository,
                             IMediatorHandler mediator,
                             IAspNetUser user)
    {
        _clienteRepository = clienteRepository;
        _mediator = mediator;
        _user = user;
    }


    [HttpGet("cliente/endereco")]
    public async Task<IActionResult> ObterEndereco()
    {
        var endereco = await _clienteRepository.ObterEnderecoPorId(_user.ObterUserId());

        return endereco == null ? NotFound() : CustomResponse(endereco);
    }

    [HttpPost("cliente/endereco")]
    public async Task<IActionResult> AdicionarEndereco(AdicionarEnderecoCommand endereco)
    {
        endereco.ClienteId = _user.ObterUserId();
        return CustomResponse(await _mediator.EnviarComando(endereco));
    }
}