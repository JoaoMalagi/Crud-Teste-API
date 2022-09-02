using Microsoft.AspNetCore.Mvc;
using Crud_Campos_Dealer.Data;
using Crud_Campos_Dealer.Data.Services;
using Crud_Campos_Dealer.Models.ProdutoModel;

namespace Crud_Campos_Dealer.Controllers
{
	[Route("/[controller]")]
	public class ProdutoesController : Controller
	{
		private readonly Contexto _context;

		private readonly ProdutoService _service;

		public ProdutoesController(Contexto context, ProdutoService service)
		{
			_context = context;
			_service = service;
		}
		//Lista todos clientes
		[HttpGet("")]
		public async Task<List<ListaProdutosModel>> Listar()
		{
			return await this._service.Listar();
		}

		[HttpGet("Detalhes/{id}")]
		public async Task<DetalhesProdutoModel> Detalhes(int id)
		{
			return await this._service.Detalhes(id);
		}

		[HttpGet("Buscar/{nome}")]
		public async Task<List<ListaProdutosModel>> Buscar(string nome)
		{
			return await this._service.Buscar(nome);
		}

		[HttpPost("")]
		public async Task CreateOrEdit([FromBody] ProdutoModel produto)
		{
			 await this._service.CreateOrEdit(produto);
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await this._service.Delete(id);
		}

	}
}
