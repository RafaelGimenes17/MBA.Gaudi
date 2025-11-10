using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.Core.DTOs
{
    public class ListaCursosPedidoDto
    {
        public Guid PedidoId { get; set; }
        public ICollection<Item> Itens { get; set; }
    }

    public class Item
    {
        public Guid Id { get; set; }
        public int Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
