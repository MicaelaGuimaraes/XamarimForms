using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultCep.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultCep.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarCEP (string cep)
        {
            string NewEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NewEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
