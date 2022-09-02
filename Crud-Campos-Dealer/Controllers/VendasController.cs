using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud_Campos_Dealer.Data;
using Crud_Campos_Dealer.Data.Entities;
using Crud_Campos_Dealer.Models.VendasModel;
using Crud_Campos_Dealer.Data.Services;
namespace Crud_Campos_Dealer.Controllers
{
    [Route("/[controller]")]
    public class VendasController : Controller
    {
        private readonly Contexto _context;

        private readonly VendasService _service;

        public VendasController(Contexto context, VendasService service)
        {
            _context = context;
            _service = service;
        }
        [HttpGet("")]
        public async Task<List<ListaVendasModel>> Listar()
        {
            return await this._service.Listar();
        }

		[HttpGet("Detalhes/{id}")]
		public async Task<DetalhesVendaModel> Detalhes(int id)
		{
			return await this._service.Detalhes(id);
		}

		[HttpGet("Buscar/{nome}")]
		public async Task<List<ListaVendasModel>> Buscar(string nome)
		{
			return await this._service.Buscar(nome);
		}

		[HttpPost("")]
		public async Task CreateOrEdit([FromBody] VendaModel venda)
		{
			 await this._service.CreateOrEdit(venda);
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await this._service.Delete(id);
		}

	}

}
