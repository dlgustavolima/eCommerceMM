﻿using Pagamentos.API.Models;

namespace Pagamentos.API.Facade;

public interface IPagamentoFacade
{
    Task<Transacao> AutorizarPagamento(Pagamento pagamento);
    Task<Transacao> CapturarPagamento(Transacao transacao);
    Task<Transacao> CancelarAutorizacao(Transacao transacao);
}
