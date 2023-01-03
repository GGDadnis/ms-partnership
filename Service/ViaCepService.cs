using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ms_partnership.Models.External;
using Newtonsoft.Json;

namespace ms_partnership.Service
{
    public class ViaCepService
    {

        public async Task<ResponseViaCep> buscarCep(string cep)
        {
            HttpClient httpClient = new HttpClient();

            Uri route = new Uri($"http://viacep.com.br/ws/{cep}/json/");

            HttpResponseMessage response = await httpClient.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {

                var stringContent = await response.Content.ReadAsStringAsync();

                ResponseViaCep content = JsonConvert.DeserializeObject<ResponseViaCep>(stringContent);

                return content;
            }

            return null;
        }
    }
}