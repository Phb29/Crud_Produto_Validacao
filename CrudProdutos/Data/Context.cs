using CrudProdutos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CrudProdutos.Data
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
//dotnet ef migrations add InitialCreate --project C:\Users\paulo\source\repos\CrudProdutos\CrudProdutos
//dotnet ef database update  --project  C:\Users\paulo\source\repos\CrudProdutos\CrudProdutos