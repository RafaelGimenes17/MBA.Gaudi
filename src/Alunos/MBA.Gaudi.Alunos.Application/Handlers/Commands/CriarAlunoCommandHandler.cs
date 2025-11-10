using MBA.Gaudi.Alunos.Application.Commands;
using MBA.Gaudi.Alunos.Domain.Entities;
using MBA.Gaudi.Alunos.Domain.Interfaces.Repositories;
using MBA.Gaudi.Core.Domain.Extensions;
using MBA.Gaudi.Core.Domain.Interfaces.Notifications;
using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Core.Domain.Notifications;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MBA.Gaudi.Alunos.Application.Handlers.Commands
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

