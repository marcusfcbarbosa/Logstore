using System;
using Logstore.Domain.LogStoreContext.Entities;
using Logstore.Domain.ValueObjects;


namespace Logstore.Domain.LogStoreContext.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco( String rua, String numero, String cidade, String estado, String pais, String cep)
        {
            this.Rua = rua;
            this.Numero = numero;
            this.Cidade = cidade;
            this.Estado = estado;
            this.Pais = pais;
            this.Cep = cep;
        }
        public String Rua { get; private set; }
        public String Numero { get; private set; }
        public String Cidade { get; private set; }
        public String Estado { get; private set; }
        public String Pais { get; private set; }
        public String Cep { get; private set; }
    }
}