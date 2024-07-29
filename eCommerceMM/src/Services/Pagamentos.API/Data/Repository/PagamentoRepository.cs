﻿using Core.Data;
using Microsoft.EntityFrameworkCore;
using Pagamentos.API.Models;

namespace Pagamentos.API.Data.Repository;

public interface IPagamentoRepository : IRepository<Pagamento>
{
    void AdicionarPagamento(Pagamento pagamento);
    void AdicionarTransacao(Transacao transacao);
    Task<Pagamento> ObterPagamentoPorPedidoId(Guid pedidoId);
    Task<IEnumerable<Transacao>> ObterTransacaoesPorPedidoId(Guid pedidoId);
}

public class PagamentoRepository : IPagamentoRepository
{
    private readonly PagamentosContext _context;

    public PagamentoRepository(PagamentosContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public void AdicionarPagamento(Pagamento pagamento)
    {
        _context.Pagamentos.Add(pagamento);
    }

    public void AdicionarTransacao(Transacao transacao)
    {
        _context.Transacoes.Add(transacao);
    }

    public async Task<Pagamento> ObterPagamentoPorPedidoId(Guid pedidoId)
    {
        return await _context.Pagamentos.AsNoTracking()
            .FirstOrDefaultAsync(p => p.PedidoId == pedidoId);
    }

    public async Task<IEnumerable<Transacao>> ObterTransacaoesPorPedidoId(Guid pedidoId)
    {
        return await _context.Transacoes.AsNoTracking()
            .Where(t => t.Pagamento.PedidoId == pedidoId).ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}