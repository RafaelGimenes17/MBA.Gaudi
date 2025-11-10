using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.Core.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converte uma string em um Guid. Retorna Guid.Empty se a string não for um Guid válido.
        /// </summary>
        /// <param name="value">A string a ser convertida para Guid.</param>
        /// <returns>O Guid convertido ou Guid.Empty se inválido.</returns>
        public static Guid ToGuid(this string value)
        {
            return Guid.TryParse(value, out var guid) ? guid : Guid.Empty;
        }
    }
}
