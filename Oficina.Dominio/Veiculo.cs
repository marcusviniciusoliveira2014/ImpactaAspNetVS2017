using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    public abstract class Veiculo
    {

        //ToDo: OO - Abstração ou Classe
        public Guid Id { get; set; } = Guid.NewGuid();
        private string _placa; //Field

        //ToDo: Encapsulamento Exemplo
        public string Placa {
            get {
                return _placa.ToUpper();
            }
            set {

                _placa = value.ToUpper();
            }
        }

        public int Ano { get; set; }
        public string Observacao { get; set; }
        public Cor Cor { get; set; }
        public Modelo Modelo { get; set; }
        public Marca Marca { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }
       // public string Placa { get => _placa.ToUpper(); set => _placa = value.ToUpper(); }

        public abstract List<String> Validar();

        protected List<String> ValidarBase() {
            var erros = new List<string>();
            if (String.IsNullOrEmpty(Placa))
            {
                erros.Add("A placa é Obrigatória...!"); 
            }
            return erros;
        }
        //ToDo: OO - Polomorfiscmo por substituição
        public override string ToString()
        {
            return $"{Modelo.Nome}-{Cor.Nome}-{Placa}";
        }

    }

}
