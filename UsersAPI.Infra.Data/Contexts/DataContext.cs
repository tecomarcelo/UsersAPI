using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Domain.Models;

namespace UsersAPI.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        //Mapeando os modelos de dominio do contexto
        public DbSet<User> Users { get; set; }

        //Sobrescrever o méotodo OnConfiguring para definir o tipo de banco de dados do projeto
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //definindo o banco de dados do contexto
            optionsBuilder.UseInMemoryDatabase(databaseName: "db_users");
    }        
    }
}
