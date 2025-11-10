using MBA.Gaudi.Core.Interfaces.Mediator;
using MBA.Gaudi.Core.Messages;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Data.Context
{
    public class AlunoContextFactory : IDesignTimeDbContextFactory<AlunoContext>
    {
        public AlunoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AlunoContext>();

            optionsBuilder.UseSqlite("Data Source=../../../sqlite/dev.db");

            // Usar um mediator fake para design-time (migrations)
            var fakeMediatorHandler = new DesignTimeMediatorHandler();

            return new AlunoContext(optionsBuilder.Options, fakeMediatorHandler);
        }

        private class DesignTimeMediatorHandler : IMediatorHandler
        {
            public Task<bool> EnviarComando<T>(T comando) where T : Command
            {
                throw new NotImplementedException();
            }

            public Task<TResponse> EnviarComando<TResponse>(IRequest<TResponse> comando)
            {
                throw new NotImplementedException();
            }

            public Task PublicarEvento<T>(T evento) where T : Event
            {
                return Task.CompletedTask;
            }
        }
    }
}
