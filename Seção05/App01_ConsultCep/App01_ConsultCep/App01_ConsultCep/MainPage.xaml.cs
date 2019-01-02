using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultCep.Servico.Modelo;
using App01_ConsultCep.Servico;

namespace App01_ConsultCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BUTTON.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try { 
                Endereco end = ViaCEPServico.BuscarCEP(cep);

                    if (end != null)
                    {
                        RESULT.Text = string.Format("Endereço: {0}, {1}, {2}, {3} - {4}", end.cep, end.logradouro, end.bairro, end.localidade, end.uf);

                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço nao foi encontrado para o cep digitado:" + cep, "OK!");
                    }

                }catch(Exception a)
                {
                    DisplayAlert("ERRO DO CARALHO EM!", a.Message, "OK!");
                }
            }

        }
        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK!");
                valido = false;
            }

            int NovoCEP = 0;
             if(!int.TryParse(cep, out NovoCEP))
            {
                //erro
                DisplayAlert("CEP INVÁLIDO", "O CEP deve ser composto só por números", "OK!");
                valido = false;
            }

            return valido;
        }
    }
}
