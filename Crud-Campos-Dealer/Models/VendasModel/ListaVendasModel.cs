namespace Crud_Campos_Dealer.Models.VendasModel
{
    public class ListaVendasModel
    {
        public int idVenda { get; set; }
        public string dscProduto { get; set; }
        public string nmCliente { get; set; }
        public int qtdVenda { get; set; }
        public DateTime dthVenda { get; set; }
        public float vlrUnitarioVenda { get; set; }
        public float vlrTotalVenda { get; set; }

    }
}
