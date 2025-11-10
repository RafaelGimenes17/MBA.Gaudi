using MBA.Gaudi.Core.Messages;
using MBA.Gaudi.GestaoAlunos.Application.Commands;
using MBA.Gaudi.GestaoAlunos.Domain.Entites;
using MBA.Gaudi.GestaoAlunos.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.Handlers.Commands
{
    public class CriarAlunoCommandHandler : IRequestHandler<CriarAlunoCommand, bool>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly INotificador _notificador;

        public CriarAlunoCommandHandler(IAlunoRepository alunoRepository, INotificador notificador)
        {
            _alunoRepository = alunoRepository;
            _notificador = notificador;
        }

        public async Task<bool> Handle(CriarAlunoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            var alunoExistente = _alunoRepository.BuscarPorUsuarioId(request.UsuarioId);
            if (alunoExistente != null)
            {
                Notificar("UsuarioId", "Já existe um aluno cadastrado para este usuário");
                return false;
            }

            var aluno = new Aluno(request.UsuarioId.Normalize(), request.Nome, request.Email);

            _alunoRepository.Adicionar(aluno);
            return await _alunoRepository.UnitOfWork.Commit();
        }

        private bool ValidarComando(Command request)
        {
            if (request.IsValid()) return true;

            foreach (var error in request.ValidationResult.Errors)
            {
                Notificar(error.PropertyName, error.ErrorMessage);
            }

            return false;
        }

        private void Notificar(string campo, string mensagem)
        {
            _notificador.Handle(new Notificacao
            {
                Campo = campo,
                Mensagem = mensagem
            });
        }
    }
}
