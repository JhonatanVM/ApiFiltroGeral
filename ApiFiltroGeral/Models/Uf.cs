using System.ComponentModel.DataAnnotations;

namespace ApiFiltroGeral.Models
{
    public class Uf
    {
        [Key]
        public byte CodigoIbge { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public byte IdRegiaoPais { get; set; }

        public void AtualizaEntidade(byte codigoIbge, byte idRegiaoPais, string sigla, string nome)
        {
            CodigoIbge = codigoIbge;
            IdRegiaoPais = idRegiaoPais;
            Sigla = sigla;
            Nome = nome;
        }
    }
}
