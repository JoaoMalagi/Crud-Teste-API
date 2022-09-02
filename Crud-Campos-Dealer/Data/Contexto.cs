using Crud_Campos_Dealer.Data.Entities;
using Crud_Campos_Dealer.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Campos_Dealer.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Venda> Venda { get; set; }
    }
}
