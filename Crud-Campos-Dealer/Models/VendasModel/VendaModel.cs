using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Crud_Campos_Dealer.Models.VendasModel
{

    public class VendaModel
    {
        public int? idVenda { get; set; }
        public int idCliente { get; set; }

        public int idProduto { get; set; }

        public int qtdVenda { get; set; }

        public DateTime dthVenda { get; set; }

        public int vlrUnitarioVenda { get; set; }

        public float vlrTotalVenda { get; set; }
    }
}
