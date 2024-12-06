using Microsoft.EntityFrameworkCore;
using APIFuncionarios.Models;

namespace APIFuncionarios.DataContext
{
    // esse rapaz vai realizar a conexão e indicar qual tabela deve ser criada no banco atravez de um construtor.
    public class ApplicationDbContext : DbContext
    {
        // construtor que se conecta com o banco
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // qual tabela e quais os campos (model) da tabela a serem criados no banco

                    // model          // nome da tabela
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
