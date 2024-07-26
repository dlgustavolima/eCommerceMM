using Catalogo.API.Data.Repository;
using Catalogo.API.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Core.Controllers;

namespace Catalogo.API.Controllers;

public class CatalogoController : MainController
{

    private readonly IProdutoRepository _produtoRepository;

    public CatalogoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet("catalogo/produtos")]
    public async Task<PagedResult<Produto>> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null)
    {
        return await _produtoRepository.ObterTodos(ps, page, q);
    }

    //[ClaimsAuthorize("Catalogo", "Ler")]
    [HttpGet("catalogo/produtos/{id}")]
    public async Task<Produto> ProdutoDetalhe(Guid id)
    {
        return await _produtoRepository.ObterPorId(id);
    }

    [HttpGet("catalogo/produtos/lista/{ids}")]
    public async Task<IEnumerable<Produto>> ObterProdutosPorId(string ids)
    {
        return await _produtoRepository.ObterProdutosPorId(ids);
    }
}