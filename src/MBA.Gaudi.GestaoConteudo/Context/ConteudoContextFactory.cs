using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Data.Context
{
    public class ConteudoContextFactory : IDesignTimeDbContextFactory<ConteudoContext>
    {
        public ConteudoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConteudoContext>();

            optionsBuilder.UseSqlite("Data Source=../../../sqlite/dev.db");

            return new ConteudoContext(optionsBuilder.Options);
        }
    }
}
