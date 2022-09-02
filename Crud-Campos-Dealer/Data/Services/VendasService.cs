using Crud_Campos_Dealer.Data.Entities;
using Crud_Campos_Dealer.Models.VendasModel;
using Microsoft.EntityFrameworkCore;

namespace Crud_Campos_Dealer.Data.Services
{
    public class VendasService
    {
		private readonly Contexto _context;

		public VendasService(Contexto context)
		{
			_context = context;
		}
		public async Task<List<ListaVendasModel>> Listar()
        {
			var lista = await _context.Venda
				.Include(v => v.Cliente)
				.Include(v => v.Produto)
				.Select(s => new ListaVendasModel
				{
					idVenda = s.idVenda,
					dscProduto = s.Produto.dscProduto,
					nmCliente = s.Cliente.nmCliente,
					dthVenda = s.dthVenda,
					qtdVenda = s.qtdVenda,
					vlrUnitarioVenda = s.vlrUnitarioVenda,
					vlrTotalVenda = s.vlrTotalVenda,
					
				}).ToListAsync();

			return lista;
		}

		public async Task<DetalhesVendaModel> Detalhes(int id)
		{
			var venda = await _context.Venda.Where(
				w => w.idVenda == id).Select(s => new DetalhesVendaModel
				{
					idVenda = s.idVenda,
					idCliente = s.Cliente.idCliente,
					idProduto = s.Produto.idProduto,
					dthVenda = s.dthVenda,
					qtdVenda = s.qtdVenda,
					vlrUnitarioVenda = s.vlrUnitarioVenda,
					vlrTotalVenda = s.vlrTotalVenda
				}).FirstOrDefaultAsync();

			if (venda != null)
			{
				return venda;
			}
			else
			{
				throw new Exception("Venda não encontrada");
			}
		}

		public async Task CreateOrEdit(VendaModel venda)
		{
			if (venda.qtdVenda == 0 || venda.vlrUnitarioVenda == 0 )
			{
				throw new Exception("Os campos da venda não podem ser vazios");
			}
			if (venda.idVenda == null)
			{
				var _venda = new Venda
				{
					idProduto = venda.idProduto,
					idCliente = venda.idCliente,
					dthVenda = DateTime.Now,
					qtdVenda = venda.qtdVenda,
					vlrUnitarioVenda = venda.vlrUnitarioVenda
				};
				_context.Add(_venda);
			}
			else
			{
				var _venda = _context.Venda.Where(
					w => w.idVenda == venda.idVenda).FirstOrDefault();
					_venda.dthVenda = DateTime.Now;
					_venda.qtdVenda = venda.qtdVenda;
					_venda.vlrUnitarioVenda = venda.vlrUnitarioVenda;

				if (_venda == null)
				{
					throw new Exception("Venda não encontrada");
				}
				
				_context.Update(_venda);
			}
			await _context.SaveChangesAsync();

			
		}
		public async Task Delete(int id)
		{
			var venda = _context.Venda.Where(
				w => w.idVenda == id).FirstOrDefault();

			if (venda != null)
			{
				_context.Venda.Remove(venda);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Venda não encontrado");
			}
		}

		public async Task<List<ListaVendasModel>> Buscar(string nome)
		{
			var listar = await _context.Venda.Where(
				w => w.Produto.dscProduto.Contains(nome) || w.Cliente.nmCliente.Contains(nome)
				).Select(s => new ListaVendasModel
				{
					dscProduto = s.Produto.dscProduto,
					nmCliente = s.Cliente.nmCliente,
					dthVenda = s.dthVenda,
					qtdVenda = s.qtdVenda,
					vlrUnitarioVenda = s.vlrUnitarioVenda,
					vlrTotalVenda = s.vlrTotalVenda,
				}).ToListAsync();

			return listar;
		}


	}
}
