using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Crud_Campos_Dealer.Data.Entities
{
	[Table("Cliente")]
	public class Cliente
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int idCliente { get; set; }

		
		public string nmCliente { get; set; }

		
		public string cidade { get; set; }
	}
}
