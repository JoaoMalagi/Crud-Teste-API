using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_Campos_Dealer.Models.ProdutoModel
{

    public class ProdutoModel
    {
        public int? idProduto { get; set; }
        public string dscProduto { get; set; }
        public float vlrProduto { get; set; }
    }
}
