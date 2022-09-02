using Crud_Campos_Dealer.Data.Entities;
using Crud_Campos_Dealer.Models.ProdutoModel;
using Microsoft.EntityFrameworkCore;

namespace Crud_Campos_Dealer.Data.Services
{
    public class ProdutoService
    {
		private readonly Contexto _context;

		public ProdutoService(Contexto context)
		{
			_context = context;
		}

		public async Task<List<ListaProdutosModel>> Listar()
		{
			var lista = await _context.Produto.Select(
				s => new ListaProdutosModel
				{
					idProduto = s.idProduto,
					dscProduto = s.dscProduto,
					vlrProduto = s.vlrUnitario
				}
				).ToListAsync();

			return lista;
		}

		public async Task<DetalhesProdutoModel> Detalhes(int id)
		{
			var produtoDetalhes = await _context.Produto.Where(
				w => w.idProduto == id)
				.Select(s => new DetalhesProdutoModel
				{	
					idProduto = s.idProduto,
					dscProduto = s.dscProduto,
					vlrProduto = s.vlrUnitario
				}).FirstOrDefaultAsync();

			return produtoDetalhes;
		}

		public async Task CreateOrEdit(ProdutoModel produto)
		{
			if (produto.dscProduto == "" || produto.vlrProduto == 0)
			{
				throw new Exception("Os campos do produto não podem ser vazios");
			}
			if (produto.idProduto == null)
			{
				var _produto = new Produto
				{
					dscProduto = produto.dscProduto,
					vlrUnitario = produto.vlrProduto
				};
				_context.Add(_produto);
			}
			else
			{
				var _produto = _context.Produto.Where(
					w => w.idProduto == produto.idProduto).FirstOrDefault();
				if (_produto == null)
				{
					throw new Exception("Produto não encontrado");
				}
				_produto.dscProduto = produto.dscProduto;
				_produto.vlrUnitario = produto.vlrProduto;

				_context.Update(_produto);
			}
			await _context.SaveChangesAsync();

			
		}

		public async Task Delete(int id)
		{
			var produto = _context.Produto.Where(
				w => w.idProduto == id).FirstOrDefault();

			if (produto != null)
			{
				_context.Produto.Remove(produto);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Produto não encontrado");
			}
		}

		public async Task<List<ListaProdutosModel>> Buscar(string nome)
		{
			var listar = await _context.Produto.Where(
				w => w.dscProduto.Contains(nome)
				).Select(s => new ListaProdutosModel
				{
					dscProduto = s.dscProduto,
					vlrProduto = s.vlrUnitario
				}).ToListAsync();

			return listar;
		}
	}
}
