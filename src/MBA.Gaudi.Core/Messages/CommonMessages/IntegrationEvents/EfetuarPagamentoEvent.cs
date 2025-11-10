using MBA.Gaudi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EfetuarPagamentoEvent : IntegrationEvent
    {
        public Guid PedidoId { get; private set; }
        public Guid AlunoId { get; private set; }
        public decimal Total { get; private set; }
        public ListaCursosPedidoDto ListaCursos { get; set; }
        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }

        public EfetuarPagamentoEvent(
            Guid pedidoId,
            Guid alunoId,
            decimal total,
            ListaCursosPedidoDto listaCursos,
            string nomeCartao,
            string numeroCartao,
            string expiracaoCartao,
            string cvvCartao

        )
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            AlunoId = alunoId;
            Total = total;
            ListaCursos = listaCursos;
            NomeCartao = nomeCartao;
            NumeroCartao = numeroCartao;
            ExpiracaoCartao = expiracaoCartao;
            CvvCartao = cvvCartao;
        }
    }
}
