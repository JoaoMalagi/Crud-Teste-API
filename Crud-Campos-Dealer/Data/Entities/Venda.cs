using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud_Campos_Dealer.Data.Entities
{
	[Table("Venda")]
	public class Venda
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int idVenda { get; set; }

		public int idCliente { get; set; }
		[ForeignKey(nameof(idCliente))]

		public Cliente Cliente { get; set; }

		public int idProduto { get; set; }
		[ForeignKey(nameof(idProduto))]

		public Produto Produto { get; set; }

		public int qtdVenda { get; set; }

		public DateTime dthVenda { get; set; }

		public int vlrUnitarioVenda { get; set; }

		[NotMapped]
		public float vlrTotalVenda
		{
			get
			{
				return qtdVenda * vlrUnitarioVenda;
			}

		}

	}
}
