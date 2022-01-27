using ApiCatalogoJogos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoJogos.Data
{
    public class ApiCatalogoJogosContext : DbContext
    {
        public ApiCatalogoJogosContext(DbContextOptions<ApiCatalogoJogosContext> option) : base(option)
        {

        }

        public DbSet<Jogo> Jogos { get; set; }
    }
}
