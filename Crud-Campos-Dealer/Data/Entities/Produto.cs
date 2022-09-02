using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_Campos_Dealer.Data.Entities
{ 
	[Table("Produto")]
	public class Produto
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int idProduto { get; set; }

		[Column("Descricao")]
		public string dscProduto { get; set; }

		[Column("ValorUnit")]
		public float vlrUnitario { get; set; }

	}
}
