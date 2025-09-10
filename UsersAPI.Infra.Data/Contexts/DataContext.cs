using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Domain.Models;
using UsersAPI.Infra.Data.configurations;

namespace UsersAPI.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        //método construtor
        public DataContext(DbContextOptions<DataContext> options)
             : base(options)
        {

        }

        //adicionando as configurações de modelos de entidade do banco de dados (ORM)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //classe de configuração de mapeamento.

            //se quiser pegar todas as modelBuilders sem passar uma por linha...
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        //mapeando os modelos de domínio deste contexto 
        public DbSet<User> Users { get; set; }
    }
}
