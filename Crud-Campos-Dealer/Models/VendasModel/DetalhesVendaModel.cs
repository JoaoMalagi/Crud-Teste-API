namespace Crud_Campos_Dealer.Models.VendasModel
{
    public class DetalhesVendaModel
    {
		public int idVenda { get; set; }
		public int idCliente { get; set; }
		public int idProduto { get; set; }
		public int qtdVenda { get; set; }
		public DateTime dthVenda { get; set; }
		public float vlrUnitarioVenda { get; set; }
		public float vlrTotalVenda { get; set; }

	}
}
