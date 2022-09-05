using Crud_Campos_Dealer.Data.Entities;
using Crud_Campos_Dealer.Models.ClienteModel;
using Microsoft.EntityFrameworkCore;

namespace Crud_Campos_Dealer.Data.Services
{
	public class ClienteService
	{
		private readonly Contexto _context;

		public ClienteService(Contexto context)
		{
			_context = context;
		}

		public async Task<List<ListaClienteModel>> Listar()
		{
			var lista = await _context.Cliente.Select(
				s => new ListaClienteModel
				{
					idCliente = s.idCliente,
					cidade = s.cidade,
					nmCliente = s.nmCliente
				}
				).ToListAsync();

			return lista;
		}

		public async Task<DetalhesClienteModel> Detalhes(int id)
		{
			var clienteDetalhes = await _context.Cliente.Where(
				w => w.idCliente == id)
				.Select(s => new DetalhesClienteModel
				{
					idCliente = s.idCliente,
					cidade = s.cidade,
					nmCliente = s.nmCliente
				}).FirstOrDefaultAsync();

			return clienteDetalhes;
		}

		public async Task CreateOrEdit(ClienteModel cliente)
		{
			var _vnmCLiente = cliente.nmCLiente.Trim();
			var _vcCliente = cliente.cidade.Trim();

			if (_vnmCLiente == "" || _vcCliente == "")
			{
				throw new Exception("Os campos do cliente não podem ser vazios");
			}
			if ( cliente.idCliente == null)
			{
				var _cliente = new Cliente
				{
					nmCliente = cliente.nmCLiente,
					cidade = cliente.cidade
				};
				_context.Add(_cliente);
			}
			else
			{				
				var _cliente = _context.Cliente.Where(
					w => w.idCliente == cliente.idCliente).FirstOrDefault();
				if (_cliente == null)
				{
					throw new Exception("Cliente não encontrado");
				}
				_cliente.nmCliente = cliente.nmCLiente;
				_cliente.cidade = cliente.cidade;

				_context.Update(_cliente);
			}
				await _context.SaveChangesAsync();

			
		}

		public async Task Delete(int id)
		{
			var cliente = _context.Cliente.Where(
				w => w.idCliente == id).FirstOrDefault();

			if (cliente != null)
			{
				_context.Cliente.Remove(cliente);
				await _context.SaveChangesAsync();				
			}
			else
			{
				throw new Exception("Cliente não encontrado");
			}
		}

		public async Task<List<ListaClienteModel>> Buscar(string nome)
		{
			var Buscar = await _context.Cliente.Where(
				w => w.nmCliente.Contains(nome)
				).Select(s => new ListaClienteModel
				{
					cidade = s.cidade,
					nmCliente = s.nmCliente
				}).ToListAsync();

			return Buscar;
		}

		
	}
}
