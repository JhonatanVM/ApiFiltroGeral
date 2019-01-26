using ApiFiltroGeral.Validacao;
using FluentValidation.Results;

namespace ApiFiltroGeral.Models
{
    public class Filtro
    {
        public byte? CodigoIbge { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new FiltroValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
