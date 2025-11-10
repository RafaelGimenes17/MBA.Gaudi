using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Domain.DTOs.ConteudoProgramatico
{
    public class ConteudoProgramaticoDto
    {
        [StringLength(2000)]
        public string? Ementa { get; init; }

        [StringLength(1000)]
        public string? Objetivo { get; init; }

        [StringLength(2000)]
        public string? Bibliografia { get; init; }

        [StringLength(500)]
        [Url(ErrorMessage = "MaterialUrl não é uma URL válida.")]
        public string? MaterialUrl { get; init; }

    }
}
