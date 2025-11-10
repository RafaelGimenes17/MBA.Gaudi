using MBA.Gaudi.Core.Domain.Messages;

namespace MBA.Gaudi.Cursos.Application.Events.Cursos
{
    public class CriarCursoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }

        public CriarCursoEvent(Guid id, string titulo, string descricao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
        }

    }
}