using ApiFiltroGeral.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFiltroGeral.Validacao
{
    public class FiltroValidacao : AbstractValidator<Filtro>
    {
        public FiltroValidacao()
        {
            ValidacaoAll();
        }

        private void ValidacaoAll()
        {
            RuleFor(doc => doc)
                .Must(BeAValidFilter)
                .OnAnyFailure(x =>
                {
                    throw new ArgumentException("Dados Inválidos, ao menos um deve ter valor");
                });

            When(doc => doc.CodigoIbge != null, () =>
            {
                RuleFor(doc => doc.CodigoIbge)
                    .GreaterThan((byte)0)
                    .LessThanOrEqualTo((byte)99)
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentException("CodigoIbge deve ser nulo ou estar entre 0 e 100");
                    });
            });

            When(doc => doc.Nome != null, () =>
            {
                RuleFor(doc => doc.Nome)
                    .Must(HaveOnlyLetter)
                    .Length(1, 100)
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentException("Nome deve ser nulo ou ter de 1 a 100 letras");
                    });
            });

            When(doc => doc.Sigla != null, () =>
            {
                RuleFor(doc => doc.Sigla)
                    .Must(HaveOnlyLetter)
                    .Length(1, 2)
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentException("Sigla deve ser nulo ou ter 2 letras");
                    });
            });
        }

        protected bool BeAValidFilter(Filtro filtro)
        {
            if (filtro.CodigoIbge == null && filtro.Nome == null && filtro.Sigla == null)
                return false;

            return true;
        }

        protected bool HaveOnlyLetter(string nome)
        {
            nome = nome.Replace(" ", "");
            nome = nome.Replace("-", "");
            return nome.All(Char.IsLetter);
        }
    }
}
