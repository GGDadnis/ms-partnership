using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms_partnership.Models.External
{
    public class ResponseViaCep
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public string Localidade { get; set; }

        public string Uf { get; set; }

        public string Ddd { get; set; }

        public string Complemento { get; set; }

    }
}