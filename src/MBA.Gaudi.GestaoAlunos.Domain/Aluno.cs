using MBA.Gaudi.Core.Models;

namespace MBA.Gaudi.GestaoAlunos.Domain;

public class Aluno : Entity, IAggregateRoot
{
    public Aluno() { }

    public Aluno(Guid id, string nome, string email, string cpf)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Cpf = cpf;
        Ativo = true;
    }
    public string Nome { get; private set; }
    public string Email { get; private set; }   
    public string Cpf { get; private set; } 
    public bool Ativo { get; private set; } 

    public void AlterarStatus(bool ativo) => Ativo = true;
}
