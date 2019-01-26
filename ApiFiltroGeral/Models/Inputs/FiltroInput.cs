using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFiltroGeral.Models.Inputs
{
    public class FiltroInput
    {
        public byte? CodigoIbge { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }
    }
}
