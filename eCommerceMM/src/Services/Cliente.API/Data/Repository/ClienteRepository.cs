using Cliente.API.Models;
using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace Cliente.API.Data.Repository;

public interface IClienteRepository : IRepository<UserCliente>
{
    void Adicionar(UserCliente cliente);
    Task<IEnumerable<UserCliente>> ObterTodos();
    Task<UserCliente> ObterPorCpf(string cpf);
    Task<UserCliente> ObterPorEmail(string email);

    void AdicionarEndereco(Endereco endereco);
    Task<Endereco> ObterEnderecoPorId(Guid id);
}

public class ClienteRepository : IClienteRepository
{
    private readonly ClientesContext _context;

    public ClienteRepository(ClientesContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<UserCliente>> ObterTodos()
    {
        return await _context.Clientes.AsNoTracking().ToListAsync();
    }

    public Task<UserCliente> ObterPorCpf(string cpf)
    {
        return _context.Clientes.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
    }

    public Task<UserCliente> ObterPorEmail(string email)
    {
        return _context.Clientes.FirstOrDefaultAsync(c => c.Email.Endereco == email);
    }

    public void Adicionar(UserCliente cliente)
    {
        _context.Clientes.Add(cliente);
    }

    public async Task<Endereco> ObterEnderecoPorId(Guid id)
    {
        return await _context.Enderecos.FirstOrDefaultAsync(e => e.ClienteId == id);
    }

    public void AdicionarEndereco(Endereco endereco)
    {
        _context.Enderecos.Add(endereco);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}