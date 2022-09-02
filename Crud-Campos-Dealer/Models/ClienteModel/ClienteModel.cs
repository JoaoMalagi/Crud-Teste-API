using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Crud_Campos_Dealer.Models.ClienteModel
{

    public class ClienteModel
    {
        public int? idCliente { get; set; }
        public string nmCLiente { get; set; }
        public string cidade { get; set; }
    }
}
